using System;
using System.Windows.Forms;

namespace GrowtopiaMusicSimulatorReborn
{

	/// <summary>
	/// Scrapped.
	/// </summary>

	public class RealMain : Form
	{
		public void showPlay(){
			MainForm happyMain = new MainForm ();
			happyMain.Show ();
		}

		public void killMe(object sender, EventArgs e){
			this.Dispose ();
		}

		public RealMain ()
		{
			this.Hide ();
			//TitleScreen aTitle = new TitleScreen (this);
			//aTitle.Show ();

		}
	}
}

