using System;
using IrrKlang;

namespace GrowtopiaMusicSimulatorReborn{
	
public class SetSounds{
	
		public static void setSoundArray(ref string[] pianoSounds, ref string[] pianoSharpSounds, ref string[] pianoFlatSounds, ref string[] drumSounds, ref string[] bassSounds, ref string[] bassSharpSounds, ref string[] bassFlatSounds, ref string[] saxSounds, ref string[] saxSharpSounds, ref string[] saxFlatSounds, ref string[] spookySounds){
			pianoSounds[0]="piano_high_b";
			pianoSounds[1]="piano_high_a";	
			pianoSounds[2]="piano_high_g";
			pianoSounds[3]="piano_high_f";
			pianoSounds[4]="piano_high_e";	
			pianoSounds[5]="piano_high_d";
			pianoSounds[6]="piano_c";
			pianoSounds[7]="piano_b";
			pianoSounds[8]="piano_a";	
			pianoSounds[9]="piano_g";	
			pianoSounds[10]="piano_f";
			pianoSounds[11]="piano_e";
			pianoSounds[12]="piano_low_d";	
			pianoSounds[13]="piano_low_c";	

			pianoSharpSounds[0]="piano_high_c";
			pianoSharpSounds[1]="piano_high_a_sharp";	
			pianoSharpSounds[2]="piano_high_g_sharp_a_flat";	
			pianoSharpSounds[3]="piano_high_f_sharp";	
			pianoSharpSounds[4]="piano_high_f";	
			pianoSharpSounds[5]="piano_d_sharp_e_flat";	
			pianoSharpSounds[6]="piano_c_sharp_d_flat";	
			pianoSharpSounds[7]="piano_c";	
			pianoSharpSounds[8]="piano_a_sharp_b_flat";	
			pianoSharpSounds[9]="piano_g_sharp_a_flat";	
			pianoSharpSounds[10]="piano_f_sharp_g_flat";	
			pianoSharpSounds[11]="piano_f";	
			pianoSharpSounds[12]="piano_low_d_sharp_e_flat";	
			pianoSharpSounds[13]="piano_low_c_sharp_or_d_flat";	

			pianoFlatSounds[0]="piano_high_a_sharp";
			pianoFlatSounds[1]="piano_high_g_sharp_a_flat";	
			pianoFlatSounds[2]="piano_high_f_sharp_g_flat";	
			pianoFlatSounds[3]="piano_high_e";	
			pianoFlatSounds[4]="piano_d_sharp_e_flat";	
			pianoFlatSounds[5]="piano_c_sharp_d_flat";	
			pianoFlatSounds[6]="piano_b";	
			pianoFlatSounds[7]="piano_a_sharp_b_flat";	
			pianoFlatSounds[8]="piano_g_sharp_a_flat";	
			pianoFlatSounds[9]="piano_f_sharp_g_flat";	
			pianoFlatSounds[10]="piano_e";	
			pianoFlatSounds[11]="piano_low_d_sharp_e_flat";	
			pianoFlatSounds[12]="piano_low_c_sharp_or_d_flat";	
			pianoFlatSounds[13]="piano_c_flat_which_is_b";


			drumSounds[0]="drum_0";
			drumSounds[1]="drum_1";	
			drumSounds[2]="drum_2";
			drumSounds[3]="drum_3";
			drumSounds[4]="drum_4";
			drumSounds[5]="drum_5";
			drumSounds[6]="drum_6";
			drumSounds[7]="drum_0";
			drumSounds[8]="drum_1";
			drumSounds[9]="drum_2";
			drumSounds[10]="drum_3";
			drumSounds[11]="drum_4";
			drumSounds[12]="drum_5";
			drumSounds[13]="drum_6";


			bassSounds[0]="bass_high_b";
			bassSounds[1]="bass_a";
			bassSounds[2]="bass_g";
			bassSounds[3]="bass_f";
			bassSounds[4]="bass_e";
			bassSounds[5]="bass_d";
			bassSounds[6]="bass_c";
			bassSounds[7]="bass_b";
			bassSounds[8]="bass_low_a";
			bassSounds[9]="bass_low_g";
			bassSounds[10]="bass_low_f";
			bassSounds[11]="bass_low_e";
			bassSounds[12]="bass_low_d";
			bassSounds[13]="bass_low_c";	


			bassSharpSounds[0]="bass_high_c";
			bassSharpSounds[1]="bass_b_flat_a_sharp";	
			bassSharpSounds[2]="bass_a_flat_g_sharp";	
			bassSharpSounds[3]="bass_g_flat_f_sharp";
			bassSharpSounds[4]="bass_f";
			bassSharpSounds[5]="bass_e_flat_d_sharp";
			bassSharpSounds[6]="bass_d_flat_c_sharp";
			bassSharpSounds[7]="bass_c";
			bassSharpSounds[8]="bass_low_b_flat_a_sharp";
			bassSharpSounds[9]="bass_low_a_flat_g_sharp";
			bassSharpSounds[10] = "bass_low_g_flat_f_sharp";
			bassSharpSounds[11]="bass_low_f";
			bassSharpSounds[12]="bass_low_e_flat_d_sharp";
			bassSharpSounds[13]="bass_low_d_flat_c_sharp";	



			bassFlatSounds[0]="bass_b_flat_a_sharp";
			bassFlatSounds[1]="bass_a_flat_g_sharp";	
			bassFlatSounds[2]="bass_g_flat_f_sharp";	
			bassFlatSounds[3]="bass_e";
			bassFlatSounds[4]="bass_e_flat_d_sharp";
			bassFlatSounds[5]="bass_d_flat_c_sharp";
			bassFlatSounds[6]="bass_b";
			bassFlatSounds[7]="bass_low_b_flat_a_sharp";
			bassFlatSounds[8]="bass_low_a_flat_g_sharp";
			bassFlatSounds[9]="bass_low_g_flat_f_sharp";
			bassFlatSounds[10]="bass_low_e";
			bassFlatSounds[11]="bass_low_e_flat_d_sharp";
			bassFlatSounds[12]="bass_low_d_flat_c_sharp";
			bassFlatSounds[13]="bass_low_b";
			
			saxSounds[0]="sax_24";
			saxSounds[1]="sax_22";
			saxSounds[2]="sax_20";
			saxSounds[3]="sax_18";
			saxSounds[4]="sax_17";
			saxSounds[5]="sax_15";
			saxSounds[6]="sax_13";
			saxSounds[7]="sax_12";
			saxSounds[8]="sax_10";
			saxSounds[9]="sax_8";
			saxSounds[10]="sax_6";
			saxSounds[11]="sax_5";
			saxSounds[12]="sax_3";
			saxSounds[13]="sax_1";
			
			saxFlatSounds[0]="sax_23";
			saxFlatSounds[1]="sax_21";
			saxFlatSounds[2]="sax_19";
			saxFlatSounds[3]="sax_17";
			saxFlatSounds[4]="sax_16";
			saxFlatSounds[5]="sax_14";
			saxFlatSounds[6]="sax_12";
			saxFlatSounds[7]="sax_11";
			saxFlatSounds[8]="sax_9";
			saxFlatSounds[9]="sax_7";
			saxFlatSounds[10]="sax_5";
			saxFlatSounds[11]="sax_4";
			saxFlatSounds[12]="sax_2";
			saxFlatSounds[13]="sax_0";
			
			saxSharpSounds[0]="sax_25";
			saxSharpSounds[1]=saxFlatSounds[0];
			saxSharpSounds[2]=saxFlatSounds[1];
			saxSharpSounds[3]=saxFlatSounds[2];
			saxSharpSounds[4]=saxSounds[3];
			saxSharpSounds[5]=saxFlatSounds[4];
			saxSharpSounds[6]=saxFlatSounds[5];
			saxSharpSounds[7]=saxSounds[7];
			saxSharpSounds[8]=saxFlatSounds[7];
			saxSharpSounds[9]=saxFlatSounds[8];
			saxSharpSounds[10]=saxFlatSounds[9];
			saxSharpSounds[11]=saxSounds[10];
			saxSharpSounds[12]=saxFlatSounds[11];
			saxSharpSounds[13]=saxFlatSounds[12];
			
			spookySounds[13]="spooky_1";
			spookySounds[12]="spooky_3";
			spookySounds[11]="spooky_5";
			spookySounds[10]="spooky_6";
			spookySounds[9]="spooky_8";
			spookySounds[8]="spooky_10";
			spookySounds[7]="spooky_12";
			spookySounds[6]="spooky_13";
			spookySounds[5]="spooky_15";
			spookySounds[4]="spooky_17";
			spookySounds[3]="spooky_18";
			spookySounds[2]="spooky_20";
			spookySounds[1]="spooky_22";
			spookySounds[0]="spooky_24";
		}

		public static ISoundEngine setTheSounds(){
			ISoundEngine engine = new ISoundEngine ();
			//ISoundSource source = soundEngine.AddSoundSourceFromMemory(SoundDataArray, "testsound.wav");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_a, "piano_a");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_a_sharp_b_flat, "piano_a_sharp_b_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_b, "piano_b");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_c, "piano_c");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_c_flat_which_is_b, "piano_c_flat_which_is_b");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_c_sharp_d_flat, "piano_c_sharp_d_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_d_sharp_e_flat, "piano_d_sharp_e_flat");
			engine.AddSoundSourceFromMemory (PianoSounds.piano_e, "piano_e");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_f, "piano_f");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_f_sharp_g_flat, "piano_f_sharp_g_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_g, "piano_g");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_g_sharp_a_flat, "piano_g_sharp_a_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_a, "piano_high_a");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_a_sharp, "piano_high_a_sharp");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_b, "piano_high_b");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_c, "piano_high_c");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_d, "piano_high_d");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_e, "piano_high_e");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_f, "piano_high_f");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_f_sharp, "piano_high_f_sharp");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_f_sharp_g_flat, "piano_high_f_sharp_g_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_g, "piano_high_g");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_high_g_sharp_a_flat, "piano_high_g_sharp_a_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_low_c, "piano_low_c");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_low_c_sharp_or_d_flat, "piano_low_c_sharp_or_d_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_low_d, "piano_low_d");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_low_d_sharp_e_flat, "piano_low_d_sharp_e_flat");
			engine.AddSoundSourceFromMemory(PianoSounds.piano_normal_b, "piano_normal_b");

			engine.AddSoundSourceFromMemory(BassSounds.bass_a, "bass_a");
			engine.AddSoundSourceFromMemory(BassSounds.bass_a_flat_g_sharp, "bass_a_flat_g_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_b, "bass_b");
			engine.AddSoundSourceFromMemory(BassSounds.bass_b_flat_a_sharp, "bass_b_flat_a_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_c, "bass_c");
			engine.AddSoundSourceFromMemory(BassSounds.bass_d, "bass_d");
			engine.AddSoundSourceFromMemory(BassSounds.bass_d_flat_c_sharp, "bass_d_flat_c_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_e, "bass_e");
			engine.AddSoundSourceFromMemory(BassSounds.bass_e_flat_d_sharp, "bass_e_flat_d_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_f, "bass_f");
			engine.AddSoundSourceFromMemory(BassSounds.bass_g, "bass_g");
			engine.AddSoundSourceFromMemory(BassSounds.bass_g_flat_f_sharp, "bass_g_flat_f_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_high_b, "bass_high_b");
			engine.AddSoundSourceFromMemory(BassSounds.bass_high_c, "bass_high_c");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_a, "bass_low_a");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_a_flat_g_sharp, "bass_low_a_flat_g_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_b, "bass_low_b");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_b_flat_a_sharp, "bass_low_b_flat_a_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_c, "bass_low_c");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_d, "bass_low_d");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_d_flat_c_sharp, "bass_low_d_flat_c_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_e, "bass_low_e");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_e_flat_d_sharp, "bass_low_e_flat_d_sharp");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_f, "bass_low_f");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_g, "bass_low_g");
			engine.AddSoundSourceFromMemory(BassSounds.bass_low_g_flat_f_sharp, "bass_low_g_flat_f_sharp");

			engine.AddSoundSourceFromMemory(DrumSounds.drum_1, "drum_1");
			engine.AddSoundSourceFromMemory(DrumSounds.drum_0, "drum_0");
			engine.AddSoundSourceFromMemory(DrumSounds.drum_2, "drum_2");
			engine.AddSoundSourceFromMemory(DrumSounds.drum_3, "drum_3");
			engine.AddSoundSourceFromMemory(DrumSounds.drum_4, "drum_4");
			engine.AddSoundSourceFromMemory(DrumSounds.drum_5, "drum_5");
			engine.AddSoundSourceFromMemory(DrumSounds.drum_6, "drum_6");
			
			
			engine.AddSoundSourceFromMemory(SaxSounds.sax_0, "sax_0");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_1, "sax_1");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_2, "sax_2");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_3, "sax_3");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_4, "sax_4");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_5, "sax_5");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_6, "sax_6");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_7, "sax_7");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_8, "sax_8");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_9, "sax_9");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_10, "sax_10");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_11, "sax_11");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_12, "sax_12");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_13, "sax_13");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_14, "sax_14");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_15, "sax_15");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_16, "sax_16");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_17, "sax_17");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_18, "sax_18");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_19, "sax_19");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_20, "sax_20");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_21, "sax_21");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_22, "sax_22");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_23, "sax_23");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_24, "sax_24");
			engine.AddSoundSourceFromMemory(SaxSounds.sax_25, "sax_25");
			
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_1, "spooky_1");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_3, "spooky_3");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_5, "spooky_5");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_6, "spooky_6");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_8, "spooky_8");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_10, "spooky_10");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_12, "spooky_12");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_13, "spooky_13");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_15, "spooky_15");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_17, "spooky_17");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_18, "spooky_18");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_20, "spooky_20");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_22, "spooky_22");
			engine.AddSoundSourceFromMemory(SpookySoundData.spooky_24, "spooky_24");

			return engine;
		}
	
}


}