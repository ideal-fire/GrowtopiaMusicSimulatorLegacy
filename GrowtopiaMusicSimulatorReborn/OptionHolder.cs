using System;

namespace GrowtopiaMusicSimulatorReborn
{
	public static class OptionHolder
	{
		public static bool playNoteOnPlace=true;
		public static bool showConfirmation=true;
		public static short noteWait=150;
		public const byte maxOptionsFormat=1;
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

