using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace GrowtopiaMusicSimulatorReborn
{
	/// <summary>
	/// Description of HotkeyConfig.
	/// </summary>
	public partial class HotkeyConfig : Form
	{
		/// <summary>
		/// If we're waiting for the user to type a key to change the hotkey.
		/// </summary>
		bool isWaitingForKey=false;
		/// <summary>
		/// The current hotkey we're going to change when the user presses something.
		/// </summary>
		byte currentHotkeySet=0;
		
		public HotkeyConfig()
		{
			InitializeComponent();
			System.Diagnostics.Debug.Print("happy");
			this.Paint+=drawStuff;
			//this.KeyDown+=HotkeyConfigKeyDown;
			//this.KeyDown += (HotkeyConfigKeyDown);
			this.KeyPreview=true;
			this.FormBorderStyle = FormBorderStyle.FixedSingle;
		}
		
		void HotkeyConfigKeyDown(object sender, KeyEventArgs e){
			System.Diagnostics.Debug.Print("Pressed.");
			Debug.Print(e.KeyValue.ToString());
			if (isWaitingForKey){
				System.Diagnostics.Debug.Print("Pressed two.");
				OptionHolder.hotkeys[currentHotkeySet]=(byte)(e.KeyValue);
				isWaitingForKey=false;
				Invalidate();
			}
		}
		
		void drawStuff(object sender, PaintEventArgs e){
			if (isWaitingForKey){
				e.Graphics.FillRectangle(MainForm.grayBrush,0,0,this.Width,this.Height);
				e.Graphics.DrawString("Press a key.",MainForm.textFont,MainForm.textBrush,0,0);
			}else{
				e.Graphics.DrawString("Click a button to set its hotkey.",MainForm.textFont,MainForm.textBrush,0,0);
			}
		}
		
		void readyPress(byte _num){
			if (!isWaitingForKey){
				isWaitingForKey=true;
				currentHotkeySet=_num;
				Invalidate();
			}else{
				MessageBox.Show("Before clicking a button, press a key to finish setting up\nthe hotkey for the button you already clicked.");
			}
		}
		
		
		void SetSaveClick(object sender, EventArgs e)
		{
			readyPress(1);
		}
		
		void SetYellowPlayClick(object sender, EventArgs e)
		{
			readyPress(4);			
		}
		
		void SetPlayClick(object sender, EventArgs e)
		{
			readyPress(0);
		}
		
		void SetLeftClick(object sender, EventArgs e)
		{
			readyPress(2);			
		}
		
		void SetRightClick(object sender, EventArgs e)
		{
			readyPress(3);			
		}
		
		void SetLoadClick(object sender, EventArgs e)
		{
			readyPress(5);			
		}
		
		void SetPianoClick(object sender, EventArgs e)
		{
			readyPress(6);			
		}
		
		void SetPianoSharpClick(object sender, EventArgs e)
		{
			readyPress(7);			
		}
		
		void SetPianoFlatClick(object sender, EventArgs e)
		{
			readyPress(8);			
		}
		
		void SetBassClick(object sender, EventArgs e)
		{
			readyPress(9);			
		}
		
		void SetBassSharpClick(object sender, EventArgs e)
		{
			readyPress(10);			
		}
		
		void SetBassFlatClick(object sender, EventArgs e)
		{
			readyPress(11);			
		}
		
		void SetDrumsClick(object sender, EventArgs e)
		{
			readyPress(12);			
		}
		
		void DoneButtonClick(object sender, EventArgs e)
		{
			this.Close();
		}

		void SetSpookyClick(object sender, EventArgs e)
		{
			readyPress(19);
		}
		void SetSaxClick(object sender, EventArgs e)
		{
			readyPress(14);
		}
		void SetSaxSharpClick(object sender, EventArgs e)
		{
			readyPress(15);
		}
		void SetSaxFlatClick(object sender, EventArgs e)
		{
			readyPress(16);
		}
		void SetRepeatStartClick(object sender, EventArgs e)
		{
			readyPress(17);
		}
		void SetRepeatEndClick(object sender, EventArgs e)
		{
			readyPress(18);
		}
		void SetBlankClick(object sender, EventArgs e)
		{
			readyPress(13);
		}
		void SetFluteClick(object sender, EventArgs e)
		{
			readyPress(MainForm.fluteId+5);
		}
		void SetFluteSharpClick(object sender, EventArgs e)
		{
			readyPress(MainForm.fluteSharpId+5);
		}
		void SetFluteFlatClick(object sender, EventArgs e)
		{
			readyPress(MainForm.fluteFlatId+5);
		}
		void SetFestiveClick(object sender, EventArgs e)
		{
			readyPress(MainForm.festiveId+5);
		}
		void SetGuitarClick(object sender, EventArgs e)
		{
			readyPress(MainForm.guitarId+5);
		}
		void SetGuitarSharpClick(object sender, EventArgs e)
		{
			readyPress(MainForm.guitarSharpId+5);
		}
		void SetGuitarFlatClick(object sender, EventArgs e)
		{
			readyPress(MainForm.guitarFlatId+5);
		}
		

		
	}
}
