/*
 * User: admin
 * Date: 3/26/2016
 * Time: 5:33 PM
 */
using System;
using System.Windows.Forms;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try{
				Application.Run(new MainForm(args));
			}catch(System.IO.FileNotFoundException e){
				if (e.ToString().Contains("irrKlang")){
					MessageBox.Show("irrKlang couldn't be loaded. Here are the details:\n\n"+e.ToString());
					DialogResult dialogResult = MessageBox.Show("irrKlang loading errors can usually be fixed by installing Microsft Visual Studio 2010 redistributeable (x86).\n\nWould you like to open the link to the download page for that?", "irrKlang loading error", MessageBoxButtons.YesNo);
					if(dialogResult == DialogResult.Yes){
						System.Diagnostics.Process.Start("https://www.microsoft.com/en-us/download/details.aspx?id=5555");
					}
				}else{
					MessageBox.Show("There was an IO error. Here are the details:\n\n"+e.ToString());
				}
			}
		}
		
	}
}
