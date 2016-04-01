/*
 * User: admin
 * Date: 3/26/2016
 * Time: 5:33 PM
 */
using System;
using System.Collections.Generic;
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
		int noteValue=1;

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

		// Misc stuffz
		// True = Draw big bg. False = draw lots of tiny grid images.
		// Now a constant because I don't plan on making this an option.
		const bool backgroundMode=true;
		byte pageNumber=0;
		bool clicking=false;
		bool playing=false;
		// Two variables so we don't try to rapidly place where we've already placed.
		byte lastPlaceX=255;
		byte lastPlaceY=255;


		// Options
		const byte redrawWait = 20;

		// For drawing shapes and whatnot.
		System.Drawing.Brush textBrush = new SolidBrush(System.Drawing.Color.Black);
		Font textFont = new Font("Arial",14);
		Brush grayBrush = new SolidBrush (Color.FromArgb (100, 128, 128, 128));
		Brush redBrush = new SolidBrush(Color.Red);
		// Spice it up a bit with SpringGreen instead of green.
		Brush greenBrush = new SolidBrush(Color.SpringGreen);
		
		const short gmsVersion=2;

		// Bar position displaying variable of doom
		byte barX=0;

		public MainForm()
		{
			// Make sure there's no missing images.
			if (checkFileExistance() == true) {
				MessageBox.Show ("At least one file is missing.\nMake sure you have a folder called Images in the same place as this executable is in along with\nTODO Insert file names here\nin there.");
			// 721 error code. Why not?
				Environment.Exit (721);
			}
			// Load options
			loadOptionsFile(ref OptionHolder.playNoteOnPlace,ref OptionHolder.showConfirmation,ref OptionHolder.byteEX);
			Icon = new Icon((Directory.GetCurrentDirectory () + "/Images/icon.ico"));
			// TODO fix this?
			this.Text = "GrowtopiaMusicSimulatorReborn";
			this.Name = "Growtopia Music Simulator Re;born";
			// True size is 832x480		
			this.Size = new System.Drawing.Size(848,518);
			// Turn off form reszing.
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
			songPlace.SetMap (25, 14, MapFunctions.NewMap (399, 13, 0, 1).Item3, 1);
			normalPaint = new PaintEventHandler (paint_stuff);
			this.Paint += normalPaint;
			// Load note images.
			noteImages = new Bitmap[8];
			gridImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/Grid.bmp"));
			noteImages [1] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/piano.png"));
			noteImages [2] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/pianoSharp.png"));
			noteImages [3] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/pianoFlat.png"));
			noteImages [4] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bass.png"));
			noteImages [5] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bassSharp.png"));
			noteImages [6] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bassFlat.png"));
			noteImages [7] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/drum.png"));
			// TODO Sharp develop no le gusta este.
			this.DoubleBuffered = true;
			this.MouseDown += mousedown;
			this.MouseUp += mouseup;
			this.MouseMove += mouseMove;
			this.MouseWheel += changeNoteWheel;
			Application.ApplicationExit += new EventHandler(this.closeStuff);

			// Load misc images
			playButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/playButton.png"));
			stopButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/stopButton.png"));
			saveButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/saveButton.png"));
			loadButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/loadButton.png"));
			leftButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/leftButton.png"));
			rightButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/rightButton.png"));
			bpmButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bpmButton.png"));
			yellowPlayButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/yellowPlayButton.png"));
			creditsButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/creditsButton.png"));
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

			if (backgroundMode == true) {
				// We don't draw grid block if big bg mode.
				noteImages [0] = null;
				bigBG = new Bitmap ((Directory.GetCurrentDirectory () + "/Images/BigBG.png"));
			}

			try{
			WebClient client = new WebClient();
			String downloadedString = client.DownloadString("http://pastebin.com/raw/VNLxD23j");
			if (Int32.Parse (downloadedString) > gmsVersion) {
				MessageBox.Show ("Yo, there's a new version out.\nRemember to get it if you have the time.");
			}
			}
			catch{
				Debug.Print ("Couldn't connect.");
			}
		}

		void changeNoteWheel(object sender, MouseEventArgs e){
			if (e.Delta < 0) {
				if (noteValue == 0) {
					noteValue = 7;
				} else {
					noteValue--;
				}
			} else {
				if (noteValue == 7) {
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
				Thread.Sleep (redrawWait);
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
			for (int x = Convert.ToInt32(startX); x < 400; x++) {
				needRedraw = true;
				for (int y = 0; y < 14; y++) {
					if (songPlace.maparray[0][x,y]!=0){
						soundEngine.Play2D(noteArrays[(songPlace.maparray[0][x,y])-1][y]);
					}
				}

				Thread.Sleep (OptionHolder.noteWait);
				if ((barX+1) % 25 == 0) {
					barX = 0;
					pageNumber++;
				} else {
					barX++;
				}
			}
			playing = false;
			needRedraw = true;
		}

		void playNote(byte noteId, byte yLevel){
			if (noteValue > 0) {
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
					return;
				}
				if (OptionHolder.playNoteOnPlace) {
					playNote ((byte)noteValue, Convert.ToByte(e.Y / 32));
				}
				songPlace.maparray [0] [e.X / 32+(pageNumber*25), e.Y / 32] = noteValue;
				needRedraw = true;
				lastPlaceX = (byte)(e.X / 32);
				lastPlaceY = (byte)(e.Y / 32);
			}
		}

		/////////////////////////////////////
		// Mouse stuff
		/// /////////////////////////////////
		void mouseMove(object sender, MouseEventArgs e){
			if (clicking) {
				place (e);
			}
		}

		void mouseup(object sender, MouseEventArgs e){
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
			g.DrawImage (loadButtonImage, 96, 448);
			g.DrawImage (leftButtonImage, 128, 448);
			g.DrawImage (rightButtonImage, 160, 448);
			if (playing) {
				g.DrawImage (stopButtonImage, 0, 448);
			} else {
				g.DrawImage (playButtonImage, 0, 448);
			}
			g.DrawImage (bpmButtonImage, 800, 448);
			g.DrawImage (yellowPlayButtonImage, 192, 448);
			g.DrawString ("Page:" + (pageNumber + 1).ToString () + "/16",textFont,textBrush,300,448);
			g.DrawImage (creditsButtonImage, 448, 448);
			if (OptionHolder.playNoteOnPlace){
				g.FillRectangle(greenBrush,224,448,32,32);
			}else{
				g.FillRectangle(redBrush,224,448,32,32);
			}
			if (OptionHolder.showConfirmation){
			g.FillRectangle(greenBrush,256,448,32,32);
			}else{
			g.FillRectangle(redBrush,256,448,32,32);
			}
		}

		void paint_stuff(object sender, PaintEventArgs e){
		// 3/27/16 - I don't plan on reimplementing normal grid mode.
		
		/*
			if (backgroundMode == false) {
				songPlace.drawNoErrorCheck (e.Graphics, 24, 13, pageNumber*25, 0, 0, 0, noteImages);
			} else {
		*/
				e.Graphics.DrawImage (bigBG, 0, 0);
				songPlace.drawLayer (e.Graphics, 24, 13, pageNumber*25, 0, 0, 0, noteImages,0);
		//	}
			drawUI (e.Graphics);
			if (playing) {
				e.Graphics.DrawImage (bpmButtonImage, 800, 448);
				e.Graphics.FillRectangle (grayBrush, barX*32, 0, 32, 448);
			}
		}



	}
}
