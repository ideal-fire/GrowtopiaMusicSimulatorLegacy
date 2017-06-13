using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GrowtopiaMusicSimulatorReborn
{
	public static class OptionHolder
	{
		public static bool playNoteOnPlace=true;
		public static bool showConfirmation=true;
		public static short noteWait=150;
		// Options file version
		// 2 is 2.8(7) and below?
		// 3 is when all notes (up to spooky) got hotkeys
		public const byte maxOptionsFormat=3;

		/// <summary>
		/// The hotkeys.
		/// It seems that each note has a spot in this array and that spot stores its hotkey
		/// 13 is blank (backspace) (f1 - 112)
		/// 14 is sax (8)
		/// 15 is sax sharp (9)
		/// 16 is sax flat (0)
		/// 17 is repeat start
		/// 18 is repeat end
		/// 19 is spooky (backspace)
		/// </summary>
		public static byte[] hotkeys = {65,83,68,70,71,72,49,50,51,52,53,54,55, 112,56,57,48,189,187,8};


		/// <summary>
		/// byteEX.
		/// </summary>
		public static bool byteEX=false;
		/// <summary>
		/// False for the new version, true for thread.sleep.
		/// </summary>
		public static bool timerMode=false;

		/// <summary>
		/// The scale of the window. It works as anythingAboutTheWindow*windowScale.
		/// It uses that for window size and mouse cords.
		/// </summary>
		public static float windowScale=1;


		/// <summary>
		/// Converts a real number to a number that's scaled by the window's scale.
		/// </summary>
		/// <returns>The number for the scaled window.</returns>
		/// <param name="_input">The number that's real for the window size.</param>
		public static int convertRealToScaled(int _input) {
			return (int)(_input * windowScale);
		}
		/// <summary>
		/// Converts a scaled number to a real number.
		/// </summary>
		/// <returns>The number relative to real cordinates</returns>
		/// <param name="_input">The number scaled by the window scale.</param>
		public static int convertScaledToReal(int _input) {
			return (int)(_input / windowScale);
		}


		/// <summary>
		/// Applys the window scale to the supplied graphics object.
		/// </summary>
		/// <returns>void!!!</returns>
		/// <param name="_passedG">The graphics object to apply the scale to</param>
		public static void setScaleGraphics(Graphics _passedG) {
			if (windowScale > 1) {
				//_passedG.InterpolationMode = InterpolationMode.NearestNeighbor;
				_passedG.ScaleTransform(windowScale, windowScale);
			}
		}

	}
}

