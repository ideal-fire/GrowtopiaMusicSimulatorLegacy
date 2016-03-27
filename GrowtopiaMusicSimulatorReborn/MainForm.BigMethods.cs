using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace GrowtopiaMusicSimulatorReborn
{
	public partial class MainForm : Form
	{

		public bool checkFileExistance(){
			bool gone = false;
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/playButton.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/stopButton.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/Grid.bmp"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/piano.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/pianoFlat.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/pianoSharp.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/bass.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/bassFlat.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/bassSharp.png"))) {
				gone = true;
			}
			if (!File.Exists ((Directory.GetCurrentDirectory () + "/Images/drum.png"))) {
				gone = true;
			}
			return gone;
		}


		void checkUI(MouseEventArgs e){
			if (e.X<32){
				if (!playing) {
					playing = true;
					playThread = new Thread (playMusic);
					playThread.Start ();
				} else {
					playThread.Abort ();
					playing = false;
				}
				//playMusic();
			}else{
				if (e.X < 64) {
					if (noteValue == 7) {
						noteValue = 0;
					} else {
						noteValue++;
					}
					needRedraw = true;
				} else {
					if (e.X < 96) {
						save ();
					} else if (e.X < 128) {
						OpenFileDialog ofd = new OpenFileDialog ();
						ofd.ShowDialog ();
						FileStream fs = new FileStream (ofd.FileName, FileMode.Open);
						songPlace.maparray = MapLibrary.MapFunctions.LoadMapFromFile (ref fs).Item4;
						fs.Dispose ();
						needRedraw = true;
						if (showConfirmation) {
							MessageBox.Show ("Loadedededed.");
						}
					} else if (e.X < 160) {
					
						pageNumber--;
						needRedraw = true;
					} else if (e.X < 192) {
						Debug.Print ("nub");
						pageNumber++;
						needRedraw = true;
					}
				}
			}
		}











		/// <summary>
		/// Save method stolen- er... borrowed from An Excellent Map Editor.
		/// But I wrote it, so it's okay.
		/// </summary>
		public void save(){
			SaveFileDialog a = new SaveFileDialog();
			a.OverwritePrompt=false;
			a.Filter="Angry LegGuy files (*.AngryLegGuy)|*.AngryLegGuy|Angry Level files (*.AngryLevel)|*.AngryLevel|All files (*.*)|*.*";
			a.ShowDialog();
			FileStream happyfile = File.Open(a.FileName,FileMode.Create);
			BinaryWriter br = new BinaryWriter(happyfile);
			int numero=0;
			byte currentRun=255;
			bool doingRun = false;
			int runNumber = 0;
			int finishNumero = -80;
			byte past=254;
			byte present=255;
			// Map format versiom
			br.Write (Convert.ToByte(3));
			// Width
			br.Write (Convert.ToByte(25));
			// Height
			br.Write (Convert.ToByte(14));
			// Layers?
			br.Write (Convert.ToByte(1));
				currentRun=255;
				doingRun = false;
				runNumber = 0;
				finishNumero = -80;
				for (int ya = 0; ya < 14; ya++) {
					for (int xa = 0; xa < 25; xa++) {
						topoffor:
						if (!doingRun) {
							past = present;
						present = Convert.ToByte ((songPlace.maparray [0] [xa, ya]));
							br.Write (present);	
							//Debug.Print ("Was: " + numero.ToString () + ".");
							numero += 1;
							//Debug.Print ("Wrote:" + byteworld [numero - 1].ToString());
							if (past==present) {
								//Debug.Print ("Good thing " + (numero - 2).ToString () + " isn't " + finishNumero.ToString () + ".");
								//Debug.Print ("Starting run with: " + byteworld [numero-1].ToString ());
								doingRun = true;
								currentRun = present;
							} else {
								//Debug.Print ("Numero:" + numero.ToString () + ".");
								//Debug.Print ("No pudedo. Last char is: " + byteworld [numero - 2].ToString () + " while this one is: " + byteworld [numero-1].ToString () + ".");
							}
						} else {
						if (songPlace.maparray [0] [xa, ya] == currentRun && runNumber<=254) {
								//Debug.Print ("Increment run number. "+world.maparray [xa, ya].ToString());
								runNumber += 1;
							} else {
								//Debug.Print("Going to finish and write:"+ Convert.ToByte ((runNumber)).ToString()+".");
								past=present;
								present = Convert.ToByte ((runNumber));
								br.Write (present);	
								finishNumero = numero;
								numero += 1;
								doingRun = false;
								currentRun = 0;
								runNumber = 0;
								past = 255;
								present = 254;
								//Debug.Print ("Finish numero is:" + finishNumero.ToString ());
								goto topoffor;
							}
						}

					}
				}
			if (doingRun) {
				Debug.Print ("a:" + runNumber.ToString ());
				past = present;
				present= Convert.ToByte ((runNumber));
				br.Write (present);	
				numero += 1;
				doingRun = false;
				currentRun = 0;
				runNumber = 0;
			}
			br.Close();

			if (showConfirmation) {
				MessageBox.Show ("Savedededed.");
			}

		}















	}
}

