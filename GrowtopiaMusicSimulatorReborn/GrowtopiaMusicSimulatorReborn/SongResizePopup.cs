/*
 * User: admin
 * Date: 7/27/2016
 * Time: 1:25 AM
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Description of SongResizePopup.
	/// </summary>
	public partial class SongResizePopup : Form
	{
		public SongResizePopup(int startWidth)
		{
			InitializeComponent();
			songLengthBox.Maximum = 99975;
			songLengthBox.Value = startWidth;
		}
		void DoneButtonClick(object sender, EventArgs e)
		{
			this.DialogResult=DialogResult.OK;
		}
		void SongResizePopupLoad(object sender, EventArgs e)
		{
	
		}
	}
}
