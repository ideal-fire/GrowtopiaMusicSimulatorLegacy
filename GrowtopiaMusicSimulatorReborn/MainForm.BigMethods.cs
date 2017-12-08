using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;

namespace GrowtopiaMusicSimulatorReborn
{
	public partial class MainForm : Form
	{

		static void easySaveOptions(){
			saveOptionsFile(OptionHolder.playNoteOnPlace,OptionHolder.showConfirmation,OptionHolder.byteEX,OptionHolder.hotkeys);
		}

		Bitmap loadBitmap(string _filePath){
			try{
				return new Bitmap(_filePath);
			}catch(Exception ex){
				if (File.Exists(_filePath)){
					MessageBox.Show("File does not exist. "+_filePath);
				}else{
					MessageBox.Show("Error loading file: "+_filePath+"\nHere's the error:\n"+ex.ToString());
				}
				return null;
			}
		}


		public static void loadOptionsFile(ref bool _playOnPlace, ref bool _showConfirmation, ref bool _byteEX, ref byte[] hotkeys){
			FileStream file;
			try{
				file = new FileStream((Directory.GetCurrentDirectory () + "/Images/Options.txt"),FileMode.Open);
			}catch{
				//MessageBox.Show ("Options file not found.\nWill create a new one.");
				easySaveOptions ();
				return;
			}
			BinaryReader br = new BinaryReader(file);
			byte optionsFormat = br.ReadByte();
			if (optionsFormat>OptionHolder.maxOptionsFormat){
				MessageBox.Show("The options file format is newer than this version of Growtopia Music Simulator Re;born can load.\nA new options file will be created with the default settings.");
				br.Dispose();
				file.Dispose();
				saveOptionsFile(true,true,OptionHolder.byteEX,OptionHolder.hotkeys);
				return;
			}

			_byteEX = br.ReadBoolean();
			_playOnPlace = br.ReadBoolean();
			_showConfirmation = br.ReadBoolean();
			if (optionsFormat == 1) {
				return;
			}
			
			try{
				for (int i = 0; i < 13; i++) {
					hotkeys[i] = br.ReadByte();
				}
				if (optionsFormat>=3){
					for (int i = 13; i < 20; i++) {
						hotkeys[i] = br.ReadByte();
					}
				}
			}catch{
				MessageBox.Show("Error loading hotkeys.");
			}
			

			br.Dispose();
			file.Dispose();
		}
		
		public static void saveOptionsFile(bool _playOnPlace, bool _showConfirmation, bool _byteEX, byte[] hotkeys){
			FileStream file = new FileStream((Directory.GetCurrentDirectory () + "/Images/Options.txt"),FileMode.Create);
			BinaryWriter bw = new BinaryWriter(file);
			// Options file version
			bw.Write((byte)OptionHolder.maxOptionsFormat);
			bw.Write(_byteEX);
			bw.Write(_playOnPlace);
			bw.Write(_showConfirmation);

			for (int i = 0; i < hotkeys.Length; i++) {
				bw.Write((byte)hotkeys[i]);
			}

			// Close files
			bw.Dispose();
			file.Dispose();
		}

		void checkUI(MouseEventArgs e){
			if (e.X<32){
				// When you press play button.
				if (!playing) {
					pageNumber = 0;
					playing = true;
					needRedraw = true;
					playThread = new Thread (new ParameterizedThreadStart(playMusic));
					playThread.Start (0);
				} else {
					playThread.Abort ();
					playing = false;
				}
				needRedraw = true;
				//playMusic();
			}else{
				// When you press note change button.
				if (e.X < 64) {
					if (e.Button == MouseButtons.Left){
						if (noteValue == maxNote) {
							noteValue = 0;
						} else {
							noteValue++;
						}
					}else if (e.Button == MouseButtons.Right){
						if (noteValue == 0) {
							noteValue = maxNote;
						} else {
							noteValue--;
						}
					}
					needRedraw = true;
				} else {
					// When you press save button
					if (e.X < 96) {
						try{
						save ();
						}
						catch(Exception ex){
							MessageBox.Show ("Could not save file.\n"+ex.ToString());
							return;
						}
					}else if (e.X < 160) {
						// Left button
						// Gotta protect morons from themselves.
						if (!playing) {
							needRedraw = true;
							if (pageNumber == 0) {
								pageNumber = (short)(songPlace.maparray[0].GetLength(0) / 25-1);
								return;
							}
							pageNumber--;
						}
					} else if (e.X < 192) {
						if (!playing) {
							// right button
							// Morons...must protect...
							needRedraw = true;
							if (pageNumber == songPlace.maparray[0].GetLength(0)/25-1) {
								pageNumber = 0;
								return;
							}
							pageNumber++;
						}
					} else if (e.X < 224) {
						if (!playing) {
							playing = true;
							playThread = new Thread (new ParameterizedThreadStart (playMusic));
							playThread.Start (pageNumber * 25);
						} else {
							playThread.Abort ();
							playing = false;
						}
						needRedraw = true;
					} else if (e.X < 256) {
					// Play note on place
						OptionHolder.playNoteOnPlace = !OptionHolder.playNoteOnPlace;
						easySaveOptions ();
						MessageBox.Show ("Play note on place is now:" + OptionHolder.playNoteOnPlace.ToString () + "\nOptions file saved.");
						needRedraw = true;
					} else if (e.X < 288) {
						//OptionHolder.showConfirmation = !OptionHolder.showConfirmation;
						//easySaveOptions ();
						//MessageBox.Show ("Showing confirmations for saving and whatnot is now:" + OptionHolder.showConfirmation + "\nOptions file saved.");
						//needRedraw = true;
						HotkeyConfig hc = new HotkeyConfig();
						hc.ShowDialog();
						saveOptionsFile(OptionHolder.playNoteOnPlace,OptionHolder.showConfirmation,OptionHolder.byteEX,OptionHolder.hotkeys);
					} else if (e.X < 448) {
					// Load old gms file.
					MessageBox.Show("This button is for loading old song files from the original Growtopia Music Simulator. To load newer song files from Growtopia Music Simulator Re;born, use the normal load button. It's a yellow folder.");
						DialogResult dialogAnswer = MessageBox.Show("Are you sure you want to open a song file?\nYou'll loose your current song if you haven't saved.", "Don't mess up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogAnswer == DialogResult.No) {
							// They don't want this madness.
							return;
						}
						loadOld();
						maxX = GetMaxX();
					}
					else if (e.X<480){
						MessageBox.Show ("Programming - MyLegGuy\nOriginal theme - SumRndmDde\nBPM formula - y3ll0\nMatching sounds to notes - HonestyCow\n\nThxz..");
					}else if (e.X<512){
						resizeSong();
					}else if (e.X<544){
						int[] countedNotes = new int[noteImages.Length];
						for (int ya=0;ya<14;ya++){
							for (int xa=0;xa<songPlace.maparray[0].GetLength(0);xa++){
								if (songPlace.maparray[0][xa,ya]!=0){
									countedNotes[songPlace.maparray[0][xa,ya]]+=1;
								}
							}
						}
						string _resultingMessage = String.Format("Piano: {0}. Piano sharp: {1}. Piano flat: {2}\nBass: {3}. Bass sharp: {4}. Bass flat: {5}\nSax: {6}. Sax sharp: {7}. Sax flat: {8}\nRepeat start: {9}. Repeat end: {10}. Spooky: {11}\nDrums: {12}. Blank: {13}. Audio gear: {14}",countedNotes[pianoId], countedNotes[pianoSharpId], countedNotes[pianoFlatId], countedNotes[bassId], countedNotes[bassSharpId], countedNotes[bassFlatId], countedNotes[saxId], countedNotes[saxSharpId], countedNotes[saxFlatId], countedNotes[repeatStartId], countedNotes[repeatEndId], countedNotes[spookyId], countedNotes[drumId], countedNotes[blankId], countedNotes[audioGearId]);
						MessageBox.Show(_resultingMessage);
					}else if (e.X < 576 && e.X>=544) {
						// When you press load button
						OpenFileDialog ofd = new OpenFileDialog();
						ofd.ShowDialog();

						if (ofd.FileName == String.Empty) {
							return;
						}

						DialogResult dialogAnswer = MessageBox.Show("Are you sure you want to open a song file?\nYou'll loose your current song if you haven't saved.", "Don't mess up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
						if (dialogAnswer == DialogResult.No) {
							// They don't want this madness.
							return;
						}
						
						if (Path.GetExtension(ofd.FileName)==".gtmusic"){
							songPlace.maparray = LoadMoronFormat(ofd.FileName);
						}else{	
							FileStream fs;
							try {
								fs = new FileStream(ofd.FileName, FileMode.Open);
							}
							catch (Exception ex) {
								MessageBox.Show("Could not open file.\nDid you select nothing?\n" + ex.ToString());
								return;
							}
							try {
								songPlace.maparray = customLoadMapFromFile(ref fs,this).Item4;
								// Make sure you're not out of bounds.
								if (songPlace.maparray[0].GetLength(0) / 25 - 1 < pageNumber) {
									pageNumber = 0;
								}
							}
							catch (Exception ex) {
								MessageBox.Show("There was an error loading the file.\nHere's the error.\n\n" + ex.ToString());
							}
							fs.Dispose();
						}

						needRedraw = true;
						if (OptionHolder.showConfirmation) {
							MessageBox.Show("Loadedededed.");
						}
						maxX = GetMaxX();
					}else if (e.X>800){
						PopBPM pbpm = new PopBPM(reverseBPMformula(OptionHolder.noteWait));
						pbpm.StartPosition = FormStartPosition.CenterParent;
						pbpm.ShowDialog();
						if (pbpm.numericUpDown1.Value < 20 || pbpm.numericUpDown1.Value > 200) {
							MessageBox.Show ("In Growtopia, BPM ranges from 20 to 200. You can't use this BPM in Growtopia, but you can use it in this simulator.");
						}
						OptionHolder.noteWait=(short)(bpmFormula(Convert.ToInt32(pbpm.numericUpDown1.Value)));
						pbpm.Dispose();
					}
				}
			}
		}

		public static int bpmFormula(int re){
			return 60000 / (4 * re);
		}

		public static int reverseBPMformula(int re){
			return 15000/re;
		}
		
		void actuallyDoTheResize(int _width){
			ResizeArray(ref songPlace.maparray[0], _width, 14);
			ResizeArray(ref RepeatUsed, _width, 14);
			ResizeArray(ref possibleAudioRacks, _width, 14);
		}
		
		void resizeSong() {
			SongResizePopup srp = new SongResizePopup(songPlace.maparray[0].GetLength(0));
			srp.ShowDialog();
			if (srp.songLengthBox.Value % 25 != 0) {
				srp.songLengthBox.Value = ((Math.Floor(srp.songLengthBox.Value / 25) + 1) * 25);
				MessageBox.Show("The song length was rounded up to " + srp.songLengthBox.Value+".");
			}

			if (srp.songLengthBox.Value<songPlace.maparray[0].GetLength(0)) {
				DialogResult dialogAnswer = MessageBox.Show("You're about to shrink your song. You will loose any notes that are in the area that'll be cut off.", "Don't mess up", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dialogAnswer == DialogResult.No) {
					srp.Dispose();
					return;
				}
			}
			
			actuallyDoTheResize((int)srp.songLengthBox.Value);
			if (maxX + 1 > songPlace.maparray[0].GetLength(0)) {
				maxX = GetMaxX();
			}
			needRedraw = true;
			srp.Dispose();
			if (songPlace.maparray[0].GetLength(0) / 25 - 1 < pageNumber) {
				pageNumber = 0;
			}
		}


		/// <summary>
		/// Mthod for resizing a multi dimensional array
		/// Stole from PsychoCoder on dreamincode.
		/// </summary>
		/// <param name="original">Original array you want to resize
		/// <param name="rows"># of rows in the new array
		/// <param name="cols"># of columns in the new array
		private void ResizeArray(ref byte[,] original, int rows, int cols) {
			//create a new 2 dimensional array with
			//the size we want
			byte[,] newArray = new byte[rows, cols];
			//copy the contents of the old array to the new one
			Array.Copy(original, newArray, Math.Min(original.Length,rows*cols));
			//set the original to the new array
			original = newArray;
		}
		private void ResizeArray(ref AudioRack[,] original, int rows, int cols) {
			//create a new 2 dimensional array with
			//the size we want
			AudioRack[,] newArray = new AudioRack[rows, cols];
			//copy the contents of the old array to the new one
			Array.Copy(original, newArray, Math.Min(original.Length,rows*cols));
			//set the original to the new array
			original = newArray;
			
			for (int i=0;i<original.GetLength(0);i++){
				for (int j=0;j<original.GetLength(1);j++){
					if (possibleAudioRacks[i,j].noteInfo==null){
						possibleAudioRacks[i,j] = new AudioRack(3);
					}
				}
			}
			
		}

		// Map format revisions:
		// 3 - Initial format
		// 4 - Adds GMSr after map format byte
		// 5 - Replaces map height byte so mapwidth can be read as a short.

		void loadOld(){
			OpenFileDialog ofd = new OpenFileDialog ();
			ofd.ShowDialog ();
			FileStream fs;
			try{
				fs = new FileStream (ofd.FileName, FileMode.Open);
			}
			catch (Exception ex){
				MessageBox.Show ("Couldn't open file.\n" + ex.ToString ());
				return;
			}
			int tempByte;
			tempByte = fs.ReadByte ();
			tempByte = fs.ReadByte ();
			tempByte = fs.ReadByte ();
			tempByte = 0;
			for (int y = 0; y < 14; y++) {
				for (int x = 0; x < 400; x++) {
					songPlace.maparray[0][x, y] = (byte)Int32.Parse((Convert.ToChar (fs.ReadByte())).ToString());
					if (songPlace.maparray [0] [x, y] != 0 && songPlace.maparray [0] [x, y] != 1) {
					}
					//Debug.Print (songPlace.maparray [0] [x, y].ToString ());
				}
			}
			//fs.ReadByte
			fs.Dispose ();
			needRedraw = true;
			if (OptionHolder.showConfirmation) {
				MessageBox.Show ("Loadedededed old Growtopia MUsic simulator file.\nNote that this can be saved to the new format by using the normal save button.");
			}
		}

		public static void LoadAudioGearInFile(ref BinaryReader file, ref byte[][,] workMap, int x, int y, MainForm tmf){
			for (int i=0;i<5;i++){
				tmf.possibleAudioRacks[x,y].noteInfo[i].noteValue=file.ReadByte();
				tmf.possibleAudioRacks[x,y].noteInfo[i].noteYPosition=file.ReadByte();
			}
		}
		
		// Why is the note's name stored when they're already in order of the note?
		public static byte[][,] LoadMoronFormat(string _filepath){
			StreamReader sr = new StreamReader(new FileStream(_filepath,FileMode.Open));
			if (sr.ReadLine()!="%cernmusicsim;"){
				MessageBox.Show("Corrupt .gtmusic file! Magic letters not found.");
			}
			string _tempLine = sr.ReadLine();
			OptionHolder.noteWait = (short)bpmFormula(int.Parse(_tempLine.Substring(_tempLine.IndexOf('=')+1,_tempLine.Length-_tempLine.IndexOf('=')-1)));
			
			byte[][,] workMap = new byte[1][,];
			workMap [0] = new byte[400, 14];
			
			for (int i=0;i<400;i++){
				_tempLine = sr.ReadLine();
				string[] _notesInThisColumn = _tempLine.Split(','); // Will have a length of 15 with the first element empty.
				for (int j=0;j<_notesInThisColumn.Length;j++){
					//Debug.Print(j.ToString()+" "+i.ToString());
					//Debug.Print(_notesInThisColumn[j]);
					if (_notesInThisColumn[j].Length!=3){
						continue;
					}
					//
					//byte _currentNoteId = AudioGearParseHelp.GetNoteIdFromInfo(Convert.ToChar(_notesInThisColumn[j].Substring(0,1)),Convert.ToChar(_notesInThisColumn[j].Substring(2,1))); // note char then accidental
					//workMap[0][i,13-(j)]=_currentNoteId;
					char[] _textAsCharArray = _notesInThisColumn[j].ToCharArray();
					byte _currentNoteId = AudioGearParseHelp.GetNoteIdFromInfo(_textAsCharArray[0],_textAsCharArray[2]);
					workMap[0][i,AudioGearParseHelp.NoteNameToY(_textAsCharArray[1])] = _currentNoteId;
				}
			}
			
			return workMap;
		}
		
		// File stream has already seeked pasted "GMSO"
		public static byte[][,] LoadGrowtopiaMusicSimulatorOnlineFile(ref FileStream file){
			byte[][,] workMap = new byte[1][,];
			file.Seek(4,SeekOrigin.Current);
			workMap[0] = new byte[400,14];
			for (int i=0;i<400;i++){
				for (int j=0;j<14;j++){
					workMap[0][i,j] = (byte)(file.ReadByte()-48); // Subtract 48 to convert from ASCII
					//Debug.Print(workMap[0][i,j].ToString());
				}
			}
			return workMap;
		}
		
		// It came back to haunt me. Making it so I can have a maximum of 255x255 map. I had to write this custom method now.
		// Tuple is map width, map height, map layers, and map.
		public static Tuple<int,int,int,byte[][,]> customLoadMapFromFile(ref FileStream filea, MainForm tmf){
			BinaryReader file = new BinaryReader(filea);
			int mapversion=file.ReadByte();
			
			// Set to true if the verification process marks this as probrablly not a Gms reborn file
			bool failed=false;
			
			if (mapversion==71){ // This is "G" in ASCII. This is the first letter of "GMSO", the magic word for Growtopia Music Simulator Online files.
				string magicGMSOString = "G"+System.Text.Encoding.UTF8.GetString(file.ReadBytes(3));
				if (magicGMSOString=="GMSO"){
					//MessageBox.Show("Growtopia Music Simulator Online file detected.");
					return Tuple.Create(400,14,1,LoadGrowtopiaMusicSimulatorOnlineFile(ref filea));
				}else{ // If not, seek back.
					file.BaseStream.Seek(1,SeekOrigin.Begin);
				}
			}
			
			if (mapversion>OptionHolder.maxMusicFormat){
				string happyString = System.Text.Encoding.UTF8.GetString(file.ReadBytes(4));
				if (happyString == "GMSr"){
					MessageBox.Show("This is a Growtopia Music Simulator Re;born song file, but its format version number is "+mapversion+" and this version only supports up to "+OptionHolder.maxMusicFormat+". Please update.");
				}else{
					failed=true;
				}
			}else if (mapversion >= 4) { // Verify that this is a Growtopia Music Simulator reborn song file.
				try {
					string happyString = System.Text.Encoding.UTF8.GetString(file.ReadBytes(4));
					if (happyString != "GMSr") {
						// String doesn't match.
						Debug.Print(happyString);
						failed = true;
					}
				}
				catch (Exception ex) {
					Debug.Print(ex.ToString());
					failed = true;
				}
			}else if (mapversion == 3) {
				file.BaseStream.Position += 2;
				byte[] nextBytes = file.ReadBytes(3);
				if (!(nextBytes[0] == 1 && nextBytes[1] == 2 && nextBytes[2] == 3)) {
					failed = true;
				}
				else {
					file.BaseStream.Position -= 5;
				}
			}else{
				failed = true;
			}

			if (failed) {
				file.Close();
				file.Dispose();
				MessageBox.Show("Corrupted or invalid Growtopia Music Simulator Re;born song file.\nIf this is an old Growtopia Music Simulator file (2015 Java version) then you can load it with the \"Load OLD\" button.", "Wierd file detected");
				throw(new ArgumentException("Invalid Growtopia Music Simulator Re;born file."));
			}

			OptionHolder.noteWait = (short)bpmFormula((int)file.ReadInt16());
			int mapWidth;
			int mapHeight;
			if (mapversion <= 4) {
				mapWidth = file.ReadByte();
				mapWidth = 400;
				mapHeight = file.ReadByte();
			} else {
				// Version 5 is when map resizing was introduced, actually load the map width.
				mapWidth = file.ReadInt16();
			}
			mapHeight = 14;

			byte past = 255;
			byte present = 254;
			byte rollValue = 55;
			bool rolling = false;
			int rollAmount = 0;
			int layers = file.ReadByte();
			layers = 1;
			byte[][,] workMap = new byte[layers][,];
			for (int i = 0; i < layers; i++) {
				workMap [i] = new byte[mapWidth, 14];
			}
			
			// HACK - E-z fix
			tmf.actuallyDoTheResize(mapWidth);
			
			//Debug.Print(mapversion.ToString()+";"+mapWidth.ToString()+";"+mapHeight.ToString()+".");
			for (int i = 0; i < layers; i++) {
				for (int y = 0; y < mapHeight; y++) {
					for (int x = 0; x < mapWidth; x++) {
						if (!rolling) {
							if (past == present) {
								// Checked here for good reasons.
								rolling = true;
								rollValue = present;
								rollAmount = file.ReadByte ();
								//Debug.Print("Starting roll with value: "+rollValue.ToString()+" and amount: "+rollAmount.ToString()+".");
								if (rollAmount <= 0) {
									//Debug.Print ("Ending roll...");
									past = 255;
									present = 244;
									rolling = false;
									workMap[i][x, y] = file.ReadByte ();
									if (workMap[i][x,y]==MainForm.audioGearId){
										LoadAudioGearInFile(ref file, ref workMap, x, y, tmf);
										past=255;
										present=254;
										continue;
									}
									past = present;
									present = Convert.ToByte (workMap[i][x, y]);
									//Debug.Print ("Wrote: " + workMap [trueX, trueY].ToString () + " and present and past is: " + present.ToString () + " ; " + past.ToString () + ".");
									continue;
								}
								workMap[i][x, y] = rollValue;
								rollAmount--;
								continue;
							}else{
								workMap[i][x, y] = file.ReadByte ();
								if (workMap[i][x,y]==MainForm.audioGearId){
									LoadAudioGearInFile(ref file, ref workMap, x, y, tmf);
									past=255;
									present=254;
									continue;
								}
								past = present;
								present = Convert.ToByte (workMap[i][x, y]);
							}
							//Debug.Print ("Wrote: " + workMap [trueX, trueY].ToString () + " and present and past is: " + present.ToString () + " ; " + past.ToString () + ".");
						} else {
							if (rollAmount <= 0) {
								//Debug.Print ("Ending roll...");
								past = 255;
								present = 244;
								rolling = false;
								workMap[i][x, y] = file.ReadByte ();
								if (workMap[i][x,y]==MainForm.audioGearId){
									LoadAudioGearInFile(ref file, ref workMap, x, y, tmf);
									past=255;
									present=254;
									continue;
								}
								past = present;
								present = Convert.ToByte (workMap[i][x, y]);
								//Debug.Print ("Wrote: " + workMap [trueX, trueY].ToString () + " and present and past is: " + present.ToString () + " ; " + past.ToString () + ".");
								continue;
							}else{
								workMap[i][x, y] = rollValue;
								rollAmount--;
							}

						}
					}
				}
			}
			file.Close ();
			file.Dispose ();
			filea.Close();
			filea.Dispose();
			return Tuple.Create (mapWidth, mapHeight,layers, workMap);
		}

		/// <summary>
		/// Custom save method instead of using one with MapLibrary.
		/// 
		/// </summary>
		public void save(){
			SaveFileDialog a = new SaveFileDialog();
			a.OverwritePrompt=true;
			a.Filter="Angry LegGuy files (*.AngryLegGuy)|*.AngryLegGuy|All files (*.*)|*.*";
			a.ShowDialog();
			if (a.FileName == String.Empty) {
				return;
			}
			FileStream happyfile = File.Open(a.FileName,FileMode.Create);
			BinaryWriter br = new BinaryWriter(happyfile);
			int numero=0;
			byte currentRun=255;
			bool doingRun = false;
			int runNumber = 0;
			int finishNumero = -80;
			byte past=254;
			byte present=255;

			// Groowtopia Music Simulator rebotn map format
			br.Write(Convert.ToByte(6));
			// Write GMSR to define this as a Growtopia Music Simulator reborn song
			br.Write(System.Text.Encoding.UTF8.GetBytes("GMSr"));
			// Write bpm
			br.Write ((short)reverseBPMformula(OptionHolder.noteWait));
			// Write width as a short, taking up the height byte, and a dummy value for layers.
			// Width
			br.Write ((short)songPlace.maparray[0].GetLength(0));
			// Layers?
			br.Write (Convert.ToByte(3));
				currentRun=255;
				doingRun = false;
				runNumber = 0;
				finishNumero = -80;
				for (int ya = 0; ya < 14; ya++) {
					for (int xa = 0; xa < songPlace.maparray[0].GetLength(0); xa++) {
						topoffor:
						if (!doingRun) {
							
							if ((songPlace.maparray [0] [xa, ya])==MainForm.audioGearId){
								Debug.Print("Writign "+MainForm.audioGearId.ToString());
								past=254;
								present=255;
								br.Write((byte)MainForm.audioGearId);
								for (int i=0;i<5;i++){
									br.Write(possibleAudioRacks[xa,ya].noteInfo[i].noteValue);
									br.Write(possibleAudioRacks[xa,ya].noteInfo[i].noteYPosition);
								}
								continue;
							}
							
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
				past = present;
				present= Convert.ToByte ((runNumber));
				br.Write (present);	
				numero += 1;
				doingRun = false;
				currentRun = 0;
				runNumber = 0;
			}
			br.Close();

			if (OptionHolder.showConfirmation) {
				MessageBox.Show ("Savedededed.");
			}

		}

		void mainFormKeyDown(object sender, KeyEventArgs e){

			if (e.KeyValue == OptionHolder.hotkeys[0]) {
				checkUI(new MouseEventArgs(MouseButtons.Left, 1, 1, 0, 0));
			}
			else if (e.KeyValue == OptionHolder.hotkeys[1]) {
				checkUI(new MouseEventArgs(MouseButtons.Left, 1, 64, 0, 0));
			}
			else if (e.KeyValue == OptionHolder.hotkeys[2]) {
				checkUI(new MouseEventArgs(MouseButtons.Left, 1, 128, 0, 0));
			}
			else if (e.KeyValue == OptionHolder.hotkeys[3]) {
				checkUI(new MouseEventArgs(MouseButtons.Left, 1, 160, 0, 0));
			}
			else if (e.KeyValue == OptionHolder.hotkeys[4]) {
				checkUI(new MouseEventArgs(MouseButtons.Left, 1, 192, 0, 0));
			}
			else if (e.KeyValue == OptionHolder.hotkeys[5]) {
				checkUI(new MouseEventArgs(MouseButtons.Left, 1, 544, 0, 0));
			}else{
				for (int i = 6; i < 20; i++) {
					if (e.KeyValue == OptionHolder.hotkeys[i]) {
						noteValue = (byte)(i-5);
					}
				}
			}
			needRedraw = true;
		}


		short GetMaxX(){
			short _max=0;
			for (int x = 0; x < songPlace.maparray[0].GetLength(0); x++) {
				for (int y = 0; y < songPlace.maparray[0].GetLength(1); y++) {
					if (songPlace.maparray[0][x, y] != 0) {
						_max = (short)x;
					}
				}
			}
			return _max;
		}

		// That's all.

	}
}

