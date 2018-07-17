/*
 * User: admin
 * Date: 3/28/2016
 * Time: 8:08 PM
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Popup for entering bpm
	/// </summary>
	public partial class PopBPM : Form
	{
		public PopBPM(int currentBPM)
		{
			InitializeComponent();
			numericUpDown1.Maximum = 9999;
			numericUpDown1.Minimum = 1;
			numericUpDown1.Value=currentBPM;
		}
		
		void Button1Click(object sender, EventArgs e)
		{
			this.DialogResult=DialogResult.OK;			
		}
	}
}
