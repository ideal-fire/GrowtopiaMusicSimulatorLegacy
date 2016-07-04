using System;

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
	}
}

