/*
 * User: admin
 * Date: 3/26/2016
 * Time: 5:33 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MapLibrary;
using System.IO;
using System.Threading;
using System.Diagnostics;
using IrrKlang;
using System.Net;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Place where you see all of da stuff.
	/// Stuff is also done on here.
	/// </summary>
	/// 
	/// 
	/// Four notes in each beat
	/// All is played in 16th notes

	public partial class MainForm : Form
	{
		// The map that's displayed
		Map songPlace = new Map();

		// Normal paint handler
		PaintEventHandler normalPaint;

		// Array to hold all the images so we don't need if statements or something/
		Bitmap[] noteImages;

		// Threadz
		Thread mainThread;
		Thread playThread;

		// So we don't always redraw wasting cpu powerz.
		bool needRedraw = true;

		// For playing sounds.
		ISoundEngine soundEngine;

		// Arrays to hold sound string references
		string[] pianoSounds = new string[14];
		string[] pianoSharpSounds = new string[14];
		string[] pianoFlatSounds = new string[14];
		string[] drumSounds = new string[14];
		string[] bassSounds = new string[14];
		string[] bassSharpSounds = new string[14];
		string[] bassFlatSounds = new string[14];
		string[][] noteArrays = new string[7][];
		byte noteValue=1;

		//Various images
		Bitmap playButtonImage;
		Bitmap stopButtonImage;
		Bitmap saveButtonImage;
		Bitmap loadButtonImage;
		Bitmap bigBG;
		Bitmap rightButtonImage;
		Bitmap leftButtonImage;
		Bitmap gridImage;
		Bitmap bpmButtonImage;
		Bitmap yellowPlayButtonImage;
		Bitmap creditsButtonImage;
		Bitmap loadOldImage;
		Bitmap optionsImage;
		Bitmap resizeImage;

		// Misc stuffz
		short pageNumber=0;
		bool clicking=false;
		bool playing=false;
		// Two variables so we don't try to rapidly place where we've already placed.
		byte lastPlaceX=255;
		byte lastPlaceY=255;


		// Options
		const byte redrawWait = 20;

		// For drawing shapes and whatnot.
		public static System.Drawing.Brush textBrush = new SolidBrush(System.Drawing.Color.Black);
		public static Font textFont = new Font("Arial",14);
		public static Brush grayBrush = new SolidBrush (Color.FromArgb (100, 128, 128, 128));
		Brush redBrush = new SolidBrush(Color.Red);
		// Spice it up a bit with SpringGreen instead of green.
		Brush greenBrush = new SolidBrush(Color.SpringGreen);
		
		const short gmsVersion=6;

		// Bar position displaying variable of doom
		byte barX=0;

		/// <summary>
		/// For timign the space in between notes.
		/// </summary>
		TickTimer playingTimer = new TickTimer();

		/// <summary>
		/// This is the max X. Once the bar reaches here, the song repeats.
		/// </summary>
		int maxX = 0;

		// Width/radio = height
		const double sizeRatio = 15.0 / 26.0;

		public MainForm()
		{
			// Check for the credits file.
			if (File.Exists (Directory.GetCurrentDirectory () + "/Images/_useOld.nathan")) {
				OptionHolder.timerMode = true;
			}
			// Load options
			loadOptionsFile(ref OptionHolder.playNoteOnPlace,ref OptionHolder.showConfirmation,ref OptionHolder.byteEX, ref OptionHolder.hotkeys);
			Icon = new Icon((Directory.GetCurrentDirectory () + "/Images/icon.ico"));
			this.Name = "GrowtopiaMusicSimulatorReborn";
			this.Text = "Growtopia Music Simulator Re;born v2.7 ("+gmsVersion+")";
			// True size is 832x480
			//this.Size = new System.Drawing.Size(848,518);
			this.ClientSize = new Size(832, 480);
			this.AutoScaleMode = AutoScaleMode.None;
			this.MinimumSize = new Size(1, 1);
			// Turne off form reszing.
			this.FormBorderStyle = FormBorderStyle.Sizable;
			songPlace.SetMap (25, 14, MapFunctions.NewMap (399, 13, 0, 1).Item3, 1);
			normalPaint = new PaintEventHandler (paint_stuff);
			this.Paint += normalPaint;
			// Load note images.
			noteImages = new Bitmap[9];
			gridImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/Grid.bmp"));
			noteImages [1] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/piano.png"));
			noteImages [2] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/pianoSharp.png"));
			noteImages [3] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/pianoFlat.png"));
			noteImages [4] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/bass.png"));
			noteImages [5] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/bassSharp.png"));
			noteImages [6] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/bassFlat.png"));
			noteImages [7] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/drum.png"));
			noteImages [8] = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/blankNote.png"));
			this.DoubleBuffered = true;
			this.MouseDown += mouseDownWithScale;
			this.MouseUp += mouseup;
			this.MouseMove += mouseMove;
			this.MouseWheel += changeNoteWheel;
			Application.ApplicationExit += new EventHandler(this.closeStuff);

			// Load misc images
			playButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/playButton.png"));
			stopButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/stopButton.png"));
			saveButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/saveButton.png"));
			loadButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/loadButton.png"));
			leftButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/leftButton.png"));
			rightButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/rightButton.png"));
			bpmButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/bpmButton.png"));
			yellowPlayButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/yellowPlayButton.png"));
			creditsButtonImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/creditsButton.png"));
			loadOldImage = loadBitmap ((Directory.GetCurrentDirectory()+"/Images/loadOld.png"));
			optionsImage = loadBitmap((Directory.GetCurrentDirectory() + "/Images/optionsButton.png"));
			resizeImage = loadBitmap((Directory.GetCurrentDirectory() + "/Images/resizeButton.png"));

			// Set up sound engine thing
			soundEngine = new ISoundEngine ();

			// I'm going to do everything on a thread because you won't be able to close the application if it's during a method or something.
			mainThread = new Thread (mainLop);
			mainThread.Start ();

			// Remember Nathan, this is how to play sounds with string index.
			//soundEngine.Play2D("testsound.wav");

			// Set the strings that can be used as argument to play sounds
			SetSounds.setSoundArray(ref pianoSounds,ref pianoSharpSounds,ref pianoFlatSounds, ref drumSounds, ref bassSounds,ref bassSharpSounds,ref bassFlatSounds);
			noteArrays [0] = pianoSounds;
			noteArrays [1] = pianoSharpSounds;
			noteArrays [2] = pianoFlatSounds;
			noteArrays [3] = bassSounds;
			noteArrays [4] = bassSharpSounds;
			noteArrays [5] = bassFlatSounds;
			noteArrays [6] = drumSounds;

			// Contains giant byte arrays for the sounds.
			soundEngine = SetSounds.setTheSounds ();

			bigBG = loadBitmap ((Directory.GetCurrentDirectory () + "/Images/BigBG.png"));

			try{
			WebClient client = new WebClient();
			String downloadedString = client.DownloadString("http://pastebin.com/raw/VNLxD23j");
			if (Int32.Parse (downloadedString) > gmsVersion) {
				MessageBox.Show ("Yo, there's a new version out.\nRemember to get it if you have the time.");
			}
				// Dispose.
				client.Dispose();
			}
			catch{
				Debug.Print ("Couldn't connect.");
			}

			//OptionHolder.windowScale = 1.4f;
			//applyWindowScale();

			this.FormClosing+=new FormClosingEventHandler(mainFormClosing);
			this.KeyDown += new KeyEventHandler(mainFormKeyDown);

			this.Resize += windowResized;
		}


		void windowResized(object sender, EventArgs e) {
			if (ClientSize.Width * sizeRatio > ClientSize.Height) {
				this.ClientSize = new Size(ClientSize.Width, (int)(ClientSize.Width * sizeRatio));
			} else {
				this.ClientSize = new Size((int)(ClientSize.Height/sizeRatio), (int)(ClientSize.Height));
			}
			OptionHolder.windowScale = (float)(ClientSize.Width / 832.0);
			needRedraw = true;
		}

		void changeNoteWheel(object sender, MouseEventArgs e){
			if (e.Delta < 0) {
				if (noteValue == 0) {
					noteValue = 8;
				} else {
					noteValue--;
				}
			} else {
				if (noteValue == 8) {
					noteValue = 0;
				} else {
					noteValue++;
				}
			}
			needRedraw = true;
		}

		void mainLop(){
			while (true) {
				// Why redraw the screen if we don't need to?
				if (needRedraw) {
					needRedraw = false;
					this.Invalidate ();
				}
				// I'm just using thread.sleep becuase this does not need to be that accurate.
				Thread.Sleep (redrawWait);
			}
		}

		void mainFormClosing(object sender, FormClosingEventArgs e) {
			// Make sure the user really wants to close the window.
			DialogResult dialogAnswer = MessageBox.Show("Are you sure you want to close Growtopia Music Simulator Re;born?\nYou'll loose anything you haven't saved.", "Don't mess up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dialogAnswer == DialogResult.No) {
				// If they chose no, stop closing.
				e.Cancel = true;
				return;
			}
		}

		void closeStuff(object sender, EventArgs e){
			// We need to close all these threads to make sure that the program fully closes.
			// Don't want any noobs thinking that they've got a virus just because the program's still running after they thought they closed.
			mainThread.Abort ();
			if (playing) {
				playThread.Abort ();
			}
		}

		void playMusic(object startX){
			barX = 0;
			int x = Convert.ToInt32(startX);
			//for (int x = Convert.ToInt32(startX); x < 400; x++) {
			while (true){
				needRedraw = true;
				for (int y = 0; y < 14; y++) {
					if (songPlace.maparray[0][x,y]!=0 && songPlace.maparray[0][x,y]!=8){
						soundEngine.Play2D(noteArrays[(songPlace.maparray[0][x,y])-1][y]);
					}
				}

				if (OptionHolder.timerMode) {
					Thread.Sleep (OptionHolder.noteWait);
				} else {
					playingTimer.wait (OptionHolder.noteWait);
				}


				if ((barX+1) % 25 == 0) {
					barX = 0;
					if (pageNumber != songPlace.maparray[0].GetLength(0) / 25) {
						pageNumber++;
					} else {
						MessageBox.Show("Wow, this is a strange bug that should be reported! I think... Maybe... Herez some valuez:\n" + pageNumber.ToString() + "\n" + songPlace.maparray[0].GetLength(0) + "\n" + x.ToString());
						break;
					}
				} else {
					barX++;
				}

				if (barX + pageNumber * 25 > maxX) {
					pageNumber = 0;
					barX = 0;
					x = -1;
				}
				x++;
			}
		}

		void playNote(byte noteId, byte yLevel){
			if (noteId > 0 && noteId<8) {
				soundEngine.Play2D (noteArrays [noteId - 1] [yLevel]);
			}
		}

		void place(MouseEventArgs e){
			if (e.X < 800 && e.Y < 448 && e.Y>0 && e.X>0 && (lastPlaceX!=(int)e.X / 32 || lastPlaceY!=(int)e.Y / 32)) {
				if (e.Button == MouseButtons.Right) {
					songPlace.maparray [0] [e.X / 32+(pageNumber*25), e.Y / 32] = 0;
					needRedraw = true;
					lastPlaceX = (byte)(e.X / 32);
					lastPlaceY = (byte)(e.Y / 32);

					if (lastPlaceX+pageNumber*25== maxX) {
						for (int _y = 0; _y < songPlace.maparray[0].GetLength(1); _y++) {
							if (songPlace.maparray[0][lastPlaceX, _y] != 0) {
								return;
							}
						}
					}
					maxX = GetMaxX();

					return;
				}
				if (OptionHolder.playNoteOnPlace) {
					playNote ((byte)noteValue, Convert.ToByte(e.Y / 32));
				}
				songPlace.maparray [0] [e.X / 32+(pageNumber*25), e.Y / 32] = (byte)noteValue;
				needRedraw = true;
				lastPlaceX = (byte)(e.X / 32);
				lastPlaceY = (byte)(e.Y / 32);
				if (lastPlaceX+pageNumber*25 > maxX) {
					maxX = (lastPlaceX+pageNumber*25);
				}
			}
		}

		/////////////////////////////////////
		// Mouse stuff
		/// /////////////////////////////////
		void mouseMove(object sender, MouseEventArgs e){
			if (clicking) {
				place (new MouseEventArgs(e.Button, e.Clicks, OptionHolder.convertScaledToReal(e.X), OptionHolder.convertScaledToReal(e.Y), e.Delta));
			}
		}

		/// <summary>
		/// Does the mousedown event, but with the scale applied.
		/// </summary>
		/// <returns>void</returns>
		/// <param name="sender">Sender.</param>
		/// <param name="e">MouseEvnetArgs for da event.</param>
		void mouseDownWithScale(object sender, MouseEventArgs e) {
			mousedown(sender, new MouseEventArgs(e.Button, e.Clicks, OptionHolder.convertScaledToReal(e.X), OptionHolder.convertScaledToReal(e.Y), e.Delta));
		}

		void mouseup(object sender, MouseEventArgs e){
			lastPlaceX = 244;
			lastPlaceY = 244;
			clicking = false;
		}

		void mousedown(object sender, MouseEventArgs e){
			// Make sure we don't click out of bounds.
			if (e.Y > 448) {
				checkUI (e);
				return;
			}
			clicking = true;
			place (e);
		}

		void drawUI(Graphics g){
			if (noteValue > 0) {
				g.DrawImage (noteImages [noteValue], 32, 448);
			} else {
				g.DrawImage (gridImage, 32, 448);
			}
			g.DrawImage (saveButtonImage, 64, 448);
			g.DrawImage (loadButtonImage, 544, 448);
			g.DrawImage (leftButtonImage, 128, 448);
			g.DrawImage (rightButtonImage, 160, 448);
			if (playing) {
				g.DrawImage (stopButtonImage, 0, 448);
			} else {
				g.DrawImage (playButtonImage, 0, 448);
			}
			g.DrawImage (bpmButtonImage, 800, 448);
			g.DrawImage (yellowPlayButtonImage, 192, 448);
			g.DrawString ("Page:" + (pageNumber + 1) + "/"+songPlace.maparray[0].GetLength(0)/25,textFont,textBrush,300,448);
			g.DrawImage (creditsButtonImage, 448, 448);
			g.DrawImage(resizeImage, 480, 448);
			if (OptionHolder.playNoteOnPlace){
				g.FillRectangle(greenBrush,224,448,32,32);
			}else{
				g.FillRectangle(redBrush,224,448,32,32);
			}
			/*
			if (OptionHolder.showConfirmation){
			g.FillRectangle(greenBrush,256,448,32,32);
			}else{
			g.FillRectangle(redBrush,256,448,32,32);
			}
			*/
			g.DrawImage(optionsImage, 256, 448);
			g.DrawImage (loadOldImage, 416, 448);
		}

		void paint_stuff(object sender, PaintEventArgs e){
			OptionHolder.setScaleGraphics(e.Graphics);
			e.Graphics.DrawImage (bigBG, 0, 0);
			songPlace.drawLayer (e.Graphics, 24, 13, pageNumber*25, 0, 0, 0, noteImages,0);
			drawUI (e.Graphics);
			if (playing) {
				e.Graphics.DrawImage (bpmButtonImage, 800, 448);
				e.Graphics.FillRectangle (grayBrush, barX*32, 0, 32, 448);
			}
		}



	}
}
