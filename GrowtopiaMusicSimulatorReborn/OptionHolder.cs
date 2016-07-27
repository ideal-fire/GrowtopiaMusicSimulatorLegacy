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
		public const byte maxOptionsFormat=2;

		/// <summary>
		/// The hotkeys.
		/// </summary>
		public static byte[] hotkeys = {65,83,68,70,71,72,49,50,51,52,53,54,55};

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

