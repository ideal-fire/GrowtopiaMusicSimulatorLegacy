/*
 * User: knoob
 * Date: 8/27/2017
 * Time: 12:53 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using MapLibrary;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// GUI for editing audio rack
	/// 
	/// size is 192 x 480
	/// </summary>
	public partial class EditAudioRack : Form{
		// Variables
		public AudioRack editedAudioRack;
		MainForm myMainForm;
		Pen blackPen = new Pen(Color.Black,5);
		byte currentNote;
		Thread mainThread;
		bool needRedraw=true;
		
		Map songPlace = new Map();
		public EditAudioRack(AudioRack _toEdit, MainForm sender){
			editedAudioRack = _toEdit;
			myMainForm = sender;
			InitializeComponent();
			this.MouseWheel += changeNoteWheel;
			songPlace.SetMap (5, 14, MapFunctions.NewMap (5, 14, 0, 1).Item3, 1);
			currentNote = myMainForm.noteValue;
			for (int i=0;i<5;i++){
				if (_toEdit.noteInfo[i].noteValue!=0){
					songPlace.maparray[0][i,_toEdit.noteInfo[i].noteYPosition] = _toEdit.noteInfo[i].noteValue;
				}
			}
			GenerateText();
			mainThread = new Thread (mainLop);
			mainThread.Start ();
		}
		
		void mainLop(){
			while (true) {
				// Why redraw the screen if we don't need to?
				if (needRedraw) {
					needRedraw = false;
					this.Invalidate ();
				}
				// I'm just using thread.sleep becuase this does not need to be that accurate.
				Thread.Sleep (MainForm.redrawWait);
			}
		}
		void changeNoteWheel(object sender, MouseEventArgs e){
			if (e.Delta < 0) {
				if (currentNote == 0) {
					currentNote = MainForm.maxNote;
				} else {
					currentNote--;
				}
			} else {
				if (currentNote == MainForm.maxNote) {
					currentNote = 0;
				} else {
					currentNote++;
				}
			}
			needRedraw = true;
		}
		void EditAudioRackPaint(object sender, PaintEventArgs e){
			e.Graphics.DrawImage(myMainForm.bigBG,myMainForm.bigBG.Width*-1+6*32,0);
			if (currentNote > 0) {
				e.Graphics.DrawImage(myMainForm.noteImages[currentNote],0,myMainForm.ClientSize.Height-32);
			} else {
				e.Graphics.DrawImage(myMainForm.gridImage,0,myMainForm.ClientSize.Height-32);
			}
			songPlace.draw(e.Graphics,5,14,0,0,0,0,myMainForm.noteImages);
			
			//e.Graphics.DrawRectangle(blackPen,new Rectangle(0,0,192,480));
		}
		void EditAudioRackMouseDown(object sender, MouseEventArgs e){
			if (e.X<192-32 && e.Y>0 && e.Y<480-32 && e.X>0){
				if (currentNote == MainForm.repeatStartId || currentNote == MainForm.repeatEndId || currentNote == MainForm.audioGearId || currentNote == MainForm.spookyId || currentNote == MainForm.blankId){ // Restrict repeat notes and audio gear
					return;
				}
				needRedraw=true;
				for (int i=0;i<14;i++){
					songPlace.maparray[0][(int)Math.Floor((float)(e.X/32)),i]=0;
				}
				songPlace.maparray[0][(int)Math.Floor((float)(e.X/32)),(int)Math.Floor((float)(e.Y/32))]=currentNote;
				if (OptionHolder.playNoteOnPlace){
					myMainForm.playNote(currentNote,(byte)Math.Floor((float)(e.Y/32)));
				}
				GenerateText();
			}else{
				if (e.X<32 && e.Y>480-32){
					if (e.Button == MouseButtons.Left){
						if (currentNote == MainForm.maxNote) {
							currentNote = 0;
						} else {
							currentNote++;
						}
					}else{
						if (currentNote == 0) {
							currentNote = MainForm.maxNote;
						} else {
							currentNote--;
						}
					}
				}
			}
		}
		

		
		void GenerateText(){
			growtopiaText.Text="";
			//growtopiaText
			for (int i=0;i<5;i++){
				for (int j=0;j<14;j++){
					if (songPlace.maparray[0][i,j]!=0){
						byte _foundNote = (byte)songPlace.maparray[0][i,j];
						if (i!=0){
							growtopiaText.Text+=" ";
						}
						growtopiaText.Text+=AudioGearParseHelp.GetNoteName(_foundNote);
						growtopiaText.Text+=AudioGearParseHelp.noteNames[j];
						growtopiaText.Text+=AudioGearParseHelp.GetNoteAccidental(_foundNote);
					}
				}
			}
		}
		

		
		void GenerateFromText(string audioGearText){
			int _currentTextPosition=-1;
			int _currentNote=0; // Current note in the audio rack/gear we're editing.
			char[] _textAsCharArray = audioGearText.ToCharArray();
			while (_currentTextPosition < audioGearText.Length && _currentNote!=5){
				// Go to the next spot in the text.
				_currentTextPosition++;
				// If it's a space, ignore it and move on to the next character.
				if (_textAsCharArray[_currentTextPosition]==' '){
					continue;
				}
				
				// From here, we can assume we're at the start of the next note.
				byte _currentNoteId = AudioGearParseHelp.GetNoteIdFromInfo(_textAsCharArray[_currentTextPosition],_textAsCharArray[_currentTextPosition+2]);
				songPlace.maparray[0][_currentNote,AudioGearParseHelp.NoteNameToY(_textAsCharArray[_currentTextPosition+1])] = _currentNoteId;
				_currentNote++;
				_currentTextPosition+=2; // We only add 2 because 1 is added at the start of the loop for the total of 3 that we want.
			}
			needRedraw=true;
		}
		
		void EditAudioRackFormClosing(object sender, FormClosingEventArgs e){
			Debug.Print("Close main thread.");
			mainThread.Abort();
			for (int i=0;i<5;i++){
				for (int j=0;j<14;j++){
					if (songPlace.maparray[0][i,j]!=0){
						editedAudioRack.noteInfo[i].noteValue=songPlace.maparray[0][i,j];
						editedAudioRack.noteInfo[i].noteYPosition=(byte)j;
						break;
					}
				}
			}
		}
		void DoneButtonClick(object sender, EventArgs e){
			this.Close();
		}
		void GrowtopiaTextKeyDown(object sender, KeyEventArgs e){
			if (e.KeyCode == Keys.Enter){
				GenerateFromText(((TextBox)sender).Text);
			}
		}
	}
}
