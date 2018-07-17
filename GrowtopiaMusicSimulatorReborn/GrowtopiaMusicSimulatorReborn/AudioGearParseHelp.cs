/*
 * User: knoob
 * Date: 8/27/2017
 * Time: 4:28 PM
 */
using System;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Description of AudioGearParseHelp.
	/// </summary>
	public static class AudioGearParseHelp
	{
		
		public static char[] noteNames = {'B','A','G','F','E','D','C','b','a','g','f','e','d','c'};
		
		public static char GetNoteName(byte _noteValue){
			if (_noteValue<=MainForm.pianoFlatId){
				return 'P';
			}else if (_noteValue<=MainForm.bassFlatId){
				return 'B';
			}else if (_noteValue<=MainForm.drumId){
				return 'D';
			}else if (_noteValue<=MainForm.saxFlatId){
				return 'S';
			}else if (_noteValue==MainForm.spookyId){
				return 'N';
			}else if (_noteValue<=MainForm.fluteFlatId){
				return 'F';
			}else if (_noteValue==MainForm.festiveId){
				return 'N';
			}else if (_noteValue<=MainForm.guitarFlatId){
				return 'G';
			}
			return 'N';
		}
		public static char GetNoteAccidental(byte _noteValue){
			if (_noteValue == MainForm.pianoId || _noteValue == MainForm.bassId || _noteValue == MainForm.saxId || _noteValue == MainForm.drumId){
				return '-';
			}else if (_noteValue == MainForm.pianoSharpId || _noteValue == MainForm.bassSharpId || _noteValue == MainForm.saxSharpId){
				return '#';
			}else{
				return 'b';
			}
		}
		
		// Give it a note name, such as 'A' and it will return the y position for that note.
		public static byte NoteNameToY(char _noteName){
			for (byte i=0;i<noteNames.Length;i++){
				if (_noteName==noteNames[i]){
					return i;
				}
			}
			return 0;
		}
		
		public static byte NoteCharToNoteBaseId(char _noteChar){
			if (_noteChar == 'P'){
				return MainForm.pianoId;
			}else if (_noteChar == 'B'){
				return MainForm.bassId;
			}else if (_noteChar == 'D'){
				return MainForm.drumId;
			}else if (_noteChar == 'S'){
				return MainForm.saxId;
			}else{
				return MainForm.blankId; // Default
			}
		}
		// Note IDs are alligned in such a way that the sharp ID is always 1 above the neutral ID and the flat ID is 2 above the neutral ID
		// This will return the offset from the netrual ID when you give it the accidental as a char.
		public static byte GetAccidentalOffset(char _noteAccidental){
			if (_noteAccidental=='-'){
				return 0;
			}else if (_noteAccidental == '#'){
				return 1;
			}else if (_noteAccidental=='b'){
				return 2;
			}else{
				return 0;
			}
		}
		
		public static byte GetNoteIdFromInfo(char _noteChar, char _noteAccidental){
			return (byte)(NoteCharToNoteBaseId(_noteChar)+GetAccidentalOffset(_noteAccidental));
		}
	}
}
