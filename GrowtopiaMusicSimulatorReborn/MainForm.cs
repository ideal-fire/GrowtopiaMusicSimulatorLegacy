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

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Place where you see all of da stuff.
	/// </summary>
	/// 
	/// 
	/// Four notes in each beat
	/// All is played in 16th notes
	public partial class MainForm : Form
	{
		// The map that's displayed/
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

		// Misc stuffz
		// True = Draw big bg. False = draw lots of tiny grid images.
		bool backgroundMode=true;
		byte pageNumber=0;
		bool clicking=false;
		bool playing=false;


		// Options
		const bool showConfirmation=true;

		public MainForm()
		{
			// Make sure there's no missing images.
			if (checkFileExistance() == true) {
				MessageBox.Show ("At least one file is missing.\nMake sure you have a folder called Images in the same place as this executable is in along with\nTODO Insert file names here\nin there.");
			// 721 error code? Why not?
				Environment.Exit (721);
			}


			this.Text = "GrowtopiaMusicSimulatorReborn";
			this.Name = "Growtopia Music Simulator Re;born";
			this.SetClientSizeCore (832, 480);
			songPlace.SetMap (25, 14, MapFunctions.NewMap (399, 13, 0, 1).Item3, 1);
			normalPaint = new PaintEventHandler (paint_stuff);
			this.Paint += normalPaint;
			noteImages = new Bitmap[8];
			gridImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/Grid.bmp"));
			noteImages [1] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/piano.png"));
			noteImages [2] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/pianoSharp.png"));
			noteImages [3] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/pianoFlat.png"));
			noteImages [4] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bass.png"));
			noteImages [5] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bassSharp.png"));
			noteImages [6] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/bassFlat.png"));
			noteImages [7] = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/drum.png"));
			this.DoubleBuffered = true;
			this.MouseDown += mousedown;
			this.MouseUp += mouseup;
			this.MouseMove += mouseMove;
			Application.ApplicationExit += new EventHandler(this.closeStuff);

			// Load misc images
			playButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/playButton.png"));
			stopButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/stopButton.png"));
			saveButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/saveButton.png"));
			loadButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/loadButton.png"));
			leftButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/leftButton.png"));
			rightButtonImage = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/rightButton.png"));

			// Set up sound engine thing
			soundEngine = new ISoundEngine ();

			// I'm going to do everything on a thread because you won't be able to close the application if it's during a method or something.
			mainThread = new Thread (mainLop);
			mainThread.Start ();




			// Remember Nathan, this is how to play sounds with string index.
			//soundEngine.Play2D("testsound.wav");


			// Set the strings that can be used as argument to play sounds
			SetSounds.setSoundArray(ref pianoSounds,ref pianoSharpSounds,ref pianoFlatSounds, ref drumSounds, ref bassSounds,ref bassSounds,ref bassFlatSounds);
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



		}

		void mainLop(){
			while (true) {
				// Why redraw the screen if we don't need to?
				if (needRedraw) {
					needRedraw = false;
					this.Invalidate ();
				}
				Thread.Sleep (20);
			}
		}

		void closeStuff(object sender, EventArgs e){
			// We need to close all these threads to make sure that the program fully closes.
			// Don't want any noobs thinking that they've got a virus just because the program's still running after they thought they closed.
			mainThread.Abort ();
			playThread.Abort ();

		}

		void playMusic(){
			for (int x = 0; x < 25; x++) {
				for (int y = 0; y < 14; y++) {
					if (songPlace.maparray[0][x,y]!=0){
						soundEngine.Play2D(noteArrays[(songPlace.maparray[0][x,y])-1][y]);
					}
				}
				Thread.Sleep (150);
			}

		}


		void place(MouseEventArgs e){
			if (e.X < 800 && e.Y < 448) {
				songPlace.maparray [0] [e.X / 32+(pageNumber*25), e.Y / 32] = noteValue;
				needRedraw = true;
			}
		}

		/////////////////////////////////////
		// Mouse stuff
		/// /////////////////////////////////////
		/// 
		void mouseMove(object sender, MouseEventArgs e){
			if (clicking) {
				place (e);
			}
		}

		void mouseup(object sender, MouseEventArgs e){
			Debug.Print ("unclick");
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
		}

		void paint_stuff(object sender, PaintEventArgs e){
		// 3/27/16 - I don't plan on reimplementing normal grid mode.
			if (backgroundMode == false) {
				songPlace.drawNoErrorCheck (e.Graphics, 24, 13, pageNumber*25, 0, 0, 0, noteImages);
			} else {
				e.Graphics.DrawImage (bigBG, 0, 0);
				songPlace.drawLayer (e.Graphics, 24, 13, pageNumber*25, 0, 0, 0, noteImages,0);
			}
			drawUI (e.Graphics);
		}



	}
}
