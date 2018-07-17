/*
 * User: 820136
 * Date: 4/13/2016
 * Time: 12:47 PM
 */
using System;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Class for counting ticks.
	/// </summary>
	public class TickTimer
	{
		private int startTick = Environment.TickCount;

		// Resets the number of ticks that it's counting from.
		public void resetTickCount(){
			startTick=Environment.TickCount;
		}
		
		// Returns the number of ticks since the last tick reset.
		public int getTicks(){
			return Environment.TickCount-startTick;
		}

		public void wait(int ticks){
			resetTickCount ();
			while (getTicks () <= ticks) {
				System.Threading.Thread.Sleep (1);
			}
		}

		public void setStartTicks(int _toSet){
			startTick=_toSet;
		}


		/*
		 * Example usage:
		 * TickTimer noob = new TickTimer();
		 * 
		 * while (true){
		 * noob.resetTickCount();
		 * while (noob.getTicks()<=50){};
		 * }
		 * 
		 * // This will make this code run every 50 ms or so. (Will run slower if compuuter is too slow. 
		 */
		
	}
}
