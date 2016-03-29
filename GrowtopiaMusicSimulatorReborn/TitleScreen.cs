using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace GrowtopiaMusicSimulatorReborn
{
	public class TitleScreen : Form
	{

		/// <summary>
		/// Titlte screeen - scrapped.
		/// </summary>

		Bitmap logo;
		Bitmap composeButton;


		public TitleScreen ()
		{
			this.SetClientSizeCore (832, 480);
			this.MouseDown += mouseDownEvent;
			this.Text = "GrowtopiaMusicSimulatorRebornTitle";
			this.Name = "Growtopia Music Simulator Re;born - title screen";
			this.Paint += new PaintEventHandler (paintStuff);
			logo = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/Logo.png"));
			composeButton = new Bitmap ((Directory.GetCurrentDirectory()+"/Images/composeButton.png"));
		}

		void mouseDownEvent(object sender, MouseEventArgs e){
			if (e.X > 366 && e.X < 466 && e.Y > 208 && e.Y < 272) {
				gotoMain ();
			}
		}
		
		void paintStuff(object sender, PaintEventArgs e){
			e.Graphics.DrawImage (logo, 0, 0);
			e.Graphics.DrawImage (composeButton, 366, 208);
		}

		void gotoMain(){
			// Gotta make sure we dispose of what we don't need.
			logo.Dispose();
			composeButton.Dispose ();
			//Thread a = new Thread (wheelGun.showPlay);
			//a.Start ();
			MainForm happyMain = new MainForm ();
			happyMain.Show ();
			this.Dispose ();
		}

	}
}

