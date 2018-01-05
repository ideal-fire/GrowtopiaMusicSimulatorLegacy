using System;
using IrrKlang;
using System.IO;
using System.Diagnostics;

//https://web.archive.org/web/20171208220332/https://www.growtopiagame.com/forums/archive/index.php/t-208287.html

namespace GrowtopiaMusicSimulatorReborn{
	
public static class LoadSounds{
		
		public static void SetSoundNames(ref string[] noteSounds, ref string[] noteSharpSounds, ref string[] noteFlatSounds, string _noteName){
			noteSounds = new string[14];
			noteSharpSounds = new string[14];
			noteFlatSounds = new string[14];

			noteSounds[0]=_noteName+"_24";
			noteSounds[1]=_noteName+"_22";
			noteSounds[2]=_noteName+"_20";
			noteSounds[3]=_noteName+"_18";
			noteSounds[4]=_noteName+"_17";
			noteSounds[5]=_noteName+"_15";
			noteSounds[6]=_noteName+"_13";
			noteSounds[7]=_noteName+"_12";
			noteSounds[8]=_noteName+"_10";
			noteSounds[9]=_noteName+"_8";
			noteSounds[10]=_noteName+"_6";
			noteSounds[11]=_noteName+"_5";
			noteSounds[12]=_noteName+"_3";
			noteSounds[13]=_noteName+"_1";
			
			noteFlatSounds[0]=_noteName+"_23";
			noteFlatSounds[1]=_noteName+"_21";
			noteFlatSounds[2]=_noteName+"_19";
			noteFlatSounds[3]=_noteName+"_17";
			noteFlatSounds[4]=_noteName+"_16";
			noteFlatSounds[5]=_noteName+"_14";
			noteFlatSounds[6]=_noteName+"_12";
			noteFlatSounds[7]=_noteName+"_11";
			noteFlatSounds[8]=_noteName+"_9";
			noteFlatSounds[9]=_noteName+"_7";
			noteFlatSounds[10]=_noteName+"_5";
			noteFlatSounds[11]=_noteName+"_4";
			noteFlatSounds[12]=_noteName+"_2";
			noteFlatSounds[13]=_noteName+"_0";
			
			noteSharpSounds[0]=_noteName+"_25";
			noteSharpSounds[1]=noteFlatSounds[0];
			noteSharpSounds[2]=noteFlatSounds[1];
			noteSharpSounds[3]=noteFlatSounds[2];
			noteSharpSounds[4]=noteSounds[3];
			noteSharpSounds[5]=noteFlatSounds[4];
			noteSharpSounds[6]=noteFlatSounds[5];
			noteSharpSounds[7]=noteSounds[6];
			noteSharpSounds[8]=noteFlatSounds[7];
			noteSharpSounds[9]=noteFlatSounds[8];
			noteSharpSounds[10]=noteFlatSounds[9];
			noteSharpSounds[11]=noteSounds[10];
			noteSharpSounds[12]=noteFlatSounds[11];
			noteSharpSounds[13]=noteFlatSounds[12];
		}

		public static void LoadSpecificSounds(ref byte[][] _toStoreArray, string _noteName){
			for (int i=0;i!=26;i++){
				if (File.Exists(Path.Combine("./NoteSounds/",_noteName+"_"+i+".wav"))){
					_toStoreArray[i] = File.ReadAllBytes(Path.Combine("./NoteSounds/",_noteName+"_"+i+".wav"));
				}
			}
		}

		public static ISoundEngine loadTheSounds(){
			byte[][] loadedPiano = new byte[26][];
			byte[][] loadedBass = new byte[26][];
			byte[][] loadedSax = new byte[26][];
			byte[][] loadedDrum = new byte[7][];
			byte[][] loadedSpooky = new byte[25][];

			LoadSpecificSounds(ref loadedPiano, "piano");
			LoadSpecificSounds(ref loadedBass, "bass");
			LoadSpecificSounds(ref loadedSax, "sax");
			LoadSpecificSounds(ref loadedSpooky, "spooky");
			LoadSpecificSounds(ref loadedDrum, "drum");

			ISoundEngine engine = new ISoundEngine ();
			//ISoundSource source = soundEngine.AddSoundSourceFromMemory(SoundDataArray, "testsound.wav");
			engine.AddSoundSourceFromMemory(loadedPiano[0], "piano_0");
			engine.AddSoundSourceFromMemory(loadedPiano[1], "piano_1");
			engine.AddSoundSourceFromMemory(loadedPiano[2], "piano_2");
			engine.AddSoundSourceFromMemory(loadedPiano[3], "piano_3");
			engine.AddSoundSourceFromMemory(loadedPiano[4], "piano_4");
			engine.AddSoundSourceFromMemory(loadedPiano[5], "piano_5");
			engine.AddSoundSourceFromMemory(loadedPiano[6], "piano_6");
			engine.AddSoundSourceFromMemory(loadedPiano[7], "piano_7");
			engine.AddSoundSourceFromMemory(loadedPiano[8], "piano_8");
			engine.AddSoundSourceFromMemory(loadedPiano[9], "piano_9");
			engine.AddSoundSourceFromMemory(loadedPiano[10], "piano_10");
			engine.AddSoundSourceFromMemory(loadedPiano[11], "piano_11");
			engine.AddSoundSourceFromMemory(loadedPiano[12], "piano_12");
			engine.AddSoundSourceFromMemory(loadedPiano[13], "piano_13");
			engine.AddSoundSourceFromMemory(loadedPiano[14], "piano_14");
			engine.AddSoundSourceFromMemory(loadedPiano[15], "piano_15");
			engine.AddSoundSourceFromMemory(loadedPiano[16], "piano_16");
			engine.AddSoundSourceFromMemory(loadedPiano[17], "piano_17");
			engine.AddSoundSourceFromMemory(loadedPiano[18], "piano_18");
			engine.AddSoundSourceFromMemory(loadedPiano[19], "piano_19");
			engine.AddSoundSourceFromMemory(loadedPiano[20], "piano_20");
			engine.AddSoundSourceFromMemory(loadedPiano[21], "piano_21");
			engine.AddSoundSourceFromMemory(loadedPiano[22], "piano_22");
			engine.AddSoundSourceFromMemory(loadedPiano[23], "piano_23");
			engine.AddSoundSourceFromMemory(loadedPiano[24], "piano_24");
			engine.AddSoundSourceFromMemory(loadedPiano[25], "piano_25");

			engine.AddSoundSourceFromMemory(loadedBass[0], "bass_0");
			engine.AddSoundSourceFromMemory(loadedBass[1], "bass_1");
			engine.AddSoundSourceFromMemory(loadedBass[2], "bass_2");
			engine.AddSoundSourceFromMemory(loadedBass[3], "bass_3");
			engine.AddSoundSourceFromMemory(loadedBass[4], "bass_4");
			engine.AddSoundSourceFromMemory(loadedBass[5], "bass_5");
			engine.AddSoundSourceFromMemory(loadedBass[6], "bass_6");
			engine.AddSoundSourceFromMemory(loadedBass[7], "bass_7");
			engine.AddSoundSourceFromMemory(loadedBass[8], "bass_8");
			engine.AddSoundSourceFromMemory(loadedBass[9], "bass_9");
			engine.AddSoundSourceFromMemory(loadedBass[10], "bass_10");
			engine.AddSoundSourceFromMemory(loadedBass[11], "bass_11");
			engine.AddSoundSourceFromMemory(loadedBass[12], "bass_12");
			engine.AddSoundSourceFromMemory(loadedBass[13], "bass_13");
			engine.AddSoundSourceFromMemory(loadedBass[14], "bass_14");
			engine.AddSoundSourceFromMemory(loadedBass[15], "bass_15");
			engine.AddSoundSourceFromMemory(loadedBass[16], "bass_16");
			engine.AddSoundSourceFromMemory(loadedBass[17], "bass_17");
			engine.AddSoundSourceFromMemory(loadedBass[18], "bass_18");
			engine.AddSoundSourceFromMemory(loadedBass[19], "bass_19");
			engine.AddSoundSourceFromMemory(loadedBass[20], "bass_20");
			engine.AddSoundSourceFromMemory(loadedBass[21], "bass_21");
			engine.AddSoundSourceFromMemory(loadedBass[22], "bass_22");
			engine.AddSoundSourceFromMemory(loadedBass[23], "bass_23");
			engine.AddSoundSourceFromMemory(loadedBass[24], "bass_24");
			engine.AddSoundSourceFromMemory(loadedBass[25], "bass_25");			
			
			engine.AddSoundSourceFromMemory(loadedSax[0], "sax_0");
			engine.AddSoundSourceFromMemory(loadedSax[1], "sax_1");
			engine.AddSoundSourceFromMemory(loadedSax[2], "sax_2");
			engine.AddSoundSourceFromMemory(loadedSax[3], "sax_3");
			engine.AddSoundSourceFromMemory(loadedSax[4], "sax_4");
			engine.AddSoundSourceFromMemory(loadedSax[5], "sax_5");
			engine.AddSoundSourceFromMemory(loadedSax[6], "sax_6");
			engine.AddSoundSourceFromMemory(loadedSax[7], "sax_7");
			engine.AddSoundSourceFromMemory(loadedSax[8], "sax_8");
			engine.AddSoundSourceFromMemory(loadedSax[9], "sax_9");
			engine.AddSoundSourceFromMemory(loadedSax[10], "sax_10");
			engine.AddSoundSourceFromMemory(loadedSax[11], "sax_11");
			engine.AddSoundSourceFromMemory(loadedSax[12], "sax_12");
			engine.AddSoundSourceFromMemory(loadedSax[13], "sax_13");
			engine.AddSoundSourceFromMemory(loadedSax[14], "sax_14");
			engine.AddSoundSourceFromMemory(loadedSax[15], "sax_15");
			engine.AddSoundSourceFromMemory(loadedSax[16], "sax_16");
			engine.AddSoundSourceFromMemory(loadedSax[17], "sax_17");
			engine.AddSoundSourceFromMemory(loadedSax[18], "sax_18");
			engine.AddSoundSourceFromMemory(loadedSax[19], "sax_19");
			engine.AddSoundSourceFromMemory(loadedSax[20], "sax_20");
			engine.AddSoundSourceFromMemory(loadedSax[21], "sax_21");
			engine.AddSoundSourceFromMemory(loadedSax[22], "sax_22");
			engine.AddSoundSourceFromMemory(loadedSax[23], "sax_23");
			engine.AddSoundSourceFromMemory(loadedSax[24], "sax_24");
			engine.AddSoundSourceFromMemory(loadedSax[25], "sax_25");
			
			engine.AddSoundSourceFromMemory(loadedDrum[0], "drum_0");
			engine.AddSoundSourceFromMemory(loadedDrum[1], "drum_1");
			engine.AddSoundSourceFromMemory(loadedDrum[2], "drum_2");
			engine.AddSoundSourceFromMemory(loadedDrum[3], "drum_3");
			engine.AddSoundSourceFromMemory(loadedDrum[4], "drum_4");
			engine.AddSoundSourceFromMemory(loadedDrum[5], "drum_5");
			engine.AddSoundSourceFromMemory(loadedDrum[6], "drum_6");

			engine.AddSoundSourceFromMemory(loadedSpooky[1], "spooky_1");
			engine.AddSoundSourceFromMemory(loadedSpooky[3], "spooky_3");
			engine.AddSoundSourceFromMemory(loadedSpooky[5], "spooky_5");
			engine.AddSoundSourceFromMemory(loadedSpooky[6], "spooky_6");
			engine.AddSoundSourceFromMemory(loadedSpooky[8], "spooky_8");
			engine.AddSoundSourceFromMemory(loadedSpooky[10], "spooky_10");
			engine.AddSoundSourceFromMemory(loadedSpooky[12], "spooky_12");
			engine.AddSoundSourceFromMemory(loadedSpooky[13], "spooky_13");
			engine.AddSoundSourceFromMemory(loadedSpooky[15], "spooky_15");
			engine.AddSoundSourceFromMemory(loadedSpooky[17], "spooky_17");
			engine.AddSoundSourceFromMemory(loadedSpooky[18], "spooky_18");
			engine.AddSoundSourceFromMemory(loadedSpooky[20], "spooky_20");
			engine.AddSoundSourceFromMemory(loadedSpooky[22], "spooky_22");
			engine.AddSoundSourceFromMemory(loadedSpooky[24], "spooky_24");

			return engine;
		}
	
}


}