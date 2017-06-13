/*
 * User: admin
 * Date: 7/3/2016
 * Time: 10:26 PM
 */
namespace GrowtopiaMusicSimulatorReborn
{
	partial class HotkeyConfig
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.setPlay = new System.Windows.Forms.Button();
			this.setSave = new System.Windows.Forms.Button();
			this.setLeft = new System.Windows.Forms.Button();
			this.setRight = new System.Windows.Forms.Button();
			this.setYellowPlay = new System.Windows.Forms.Button();
			this.setLoad = new System.Windows.Forms.Button();
			this.setPiano = new System.Windows.Forms.Button();
			this.setPianoSharp = new System.Windows.Forms.Button();
			this.setPianoFlat = new System.Windows.Forms.Button();
			this.setBass = new System.Windows.Forms.Button();
			this.setBassSharp = new System.Windows.Forms.Button();
			this.setBassFlat = new System.Windows.Forms.Button();
			this.setDrums = new System.Windows.Forms.Button();
			this.doneButton = new System.Windows.Forms.Button();
			this.setSpooky = new System.Windows.Forms.Button();
			this.setSax = new System.Windows.Forms.Button();
			this.setSaxSharp = new System.Windows.Forms.Button();
			this.setSaxFlat = new System.Windows.Forms.Button();
			this.setRepeatStart = new System.Windows.Forms.Button();
			this.setRepeatEnd = new System.Windows.Forms.Button();
			this.setBlank = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// setPlay
			// 
			this.setPlay.Location = new System.Drawing.Point(13, 81);
			this.setPlay.Name = "setPlay";
			this.setPlay.Size = new System.Drawing.Size(42, 23);
			this.setPlay.TabIndex = 0;
			this.setPlay.Text = "Play";
			this.setPlay.UseVisualStyleBackColor = true;
			this.setPlay.Click += new System.EventHandler(this.SetPlayClick);
			// 
			// setSave
			// 
			this.setSave.Location = new System.Drawing.Point(13, 110);
			this.setSave.Name = "setSave";
			this.setSave.Size = new System.Drawing.Size(42, 23);
			this.setSave.TabIndex = 1;
			this.setSave.Text = "Save";
			this.setSave.UseVisualStyleBackColor = true;
			this.setSave.Click += new System.EventHandler(this.SetSaveClick);
			// 
			// setLeft
			// 
			this.setLeft.Location = new System.Drawing.Point(12, 139);
			this.setLeft.Name = "setLeft";
			this.setLeft.Size = new System.Drawing.Size(42, 23);
			this.setLeft.TabIndex = 2;
			this.setLeft.Text = "Left";
			this.setLeft.UseVisualStyleBackColor = true;
			this.setLeft.Click += new System.EventHandler(this.SetLeftClick);
			// 
			// setRight
			// 
			this.setRight.Location = new System.Drawing.Point(13, 168);
			this.setRight.Name = "setRight";
			this.setRight.Size = new System.Drawing.Size(42, 23);
			this.setRight.TabIndex = 3;
			this.setRight.Text = "Right";
			this.setRight.UseVisualStyleBackColor = true;
			this.setRight.Click += new System.EventHandler(this.SetRightClick);
			// 
			// setYellowPlay
			// 
			this.setYellowPlay.Location = new System.Drawing.Point(12, 197);
			this.setYellowPlay.Name = "setYellowPlay";
			this.setYellowPlay.Size = new System.Drawing.Size(69, 23);
			this.setYellowPlay.TabIndex = 4;
			this.setYellowPlay.Text = "Yellow play";
			this.setYellowPlay.UseVisualStyleBackColor = true;
			this.setYellowPlay.Click += new System.EventHandler(this.SetYellowPlayClick);
			// 
			// setLoad
			// 
			this.setLoad.Location = new System.Drawing.Point(13, 226);
			this.setLoad.Name = "setLoad";
			this.setLoad.Size = new System.Drawing.Size(42, 23);
			this.setLoad.TabIndex = 5;
			this.setLoad.Text = "Load";
			this.setLoad.UseVisualStyleBackColor = true;
			this.setLoad.Click += new System.EventHandler(this.SetLoadClick);
			// 
			// setPiano
			// 
			this.setPiano.Location = new System.Drawing.Point(104, 81);
			this.setPiano.Name = "setPiano";
			this.setPiano.Size = new System.Drawing.Size(51, 23);
			this.setPiano.TabIndex = 6;
			this.setPiano.Text = "Piano";
			this.setPiano.UseVisualStyleBackColor = true;
			this.setPiano.Click += new System.EventHandler(this.SetPianoClick);
			// 
			// setPianoSharp
			// 
			this.setPianoSharp.Location = new System.Drawing.Point(104, 110);
			this.setPianoSharp.Name = "setPianoSharp";
			this.setPianoSharp.Size = new System.Drawing.Size(75, 23);
			this.setPianoSharp.TabIndex = 7;
			this.setPianoSharp.Text = "Piano Sharp";
			this.setPianoSharp.UseVisualStyleBackColor = true;
			this.setPianoSharp.Click += new System.EventHandler(this.SetPianoSharpClick);
			// 
			// setPianoFlat
			// 
			this.setPianoFlat.Location = new System.Drawing.Point(104, 139);
			this.setPianoFlat.Name = "setPianoFlat";
			this.setPianoFlat.Size = new System.Drawing.Size(75, 23);
			this.setPianoFlat.TabIndex = 8;
			this.setPianoFlat.Text = "Piano Flat";
			this.setPianoFlat.UseVisualStyleBackColor = true;
			this.setPianoFlat.Click += new System.EventHandler(this.SetPianoFlatClick);
			// 
			// setBass
			// 
			this.setBass.Location = new System.Drawing.Point(104, 168);
			this.setBass.Name = "setBass";
			this.setBass.Size = new System.Drawing.Size(51, 23);
			this.setBass.TabIndex = 9;
			this.setBass.Text = "Bass";
			this.setBass.UseVisualStyleBackColor = true;
			this.setBass.Click += new System.EventHandler(this.SetBassClick);
			// 
			// setBassSharp
			// 
			this.setBassSharp.Location = new System.Drawing.Point(104, 197);
			this.setBassSharp.Name = "setBassSharp";
			this.setBassSharp.Size = new System.Drawing.Size(75, 23);
			this.setBassSharp.TabIndex = 10;
			this.setBassSharp.Text = "Bass Sharp";
			this.setBassSharp.UseVisualStyleBackColor = true;
			this.setBassSharp.Click += new System.EventHandler(this.SetBassSharpClick);
			// 
			// setBassFlat
			// 
			this.setBassFlat.Location = new System.Drawing.Point(104, 226);
			this.setBassFlat.Name = "setBassFlat";
			this.setBassFlat.Size = new System.Drawing.Size(60, 23);
			this.setBassFlat.TabIndex = 11;
			this.setBassFlat.Text = "Bass Flat";
			this.setBassFlat.UseVisualStyleBackColor = true;
			this.setBassFlat.Click += new System.EventHandler(this.SetBassFlatClick);
			// 
			// setDrums
			// 
			this.setDrums.Location = new System.Drawing.Point(13, 255);
			this.setDrums.Name = "setDrums";
			this.setDrums.Size = new System.Drawing.Size(60, 23);
			this.setDrums.TabIndex = 12;
			this.setDrums.Text = "Drums";
			this.setDrums.UseVisualStyleBackColor = true;
			this.setDrums.Click += new System.EventHandler(this.SetDrumsClick);
			// 
			// doneButton
			// 
			this.doneButton.BackColor = System.Drawing.Color.Lime;
			this.doneButton.FlatAppearance.BorderColor = System.Drawing.Color.OrangeRed;
			this.doneButton.Location = new System.Drawing.Point(204, 81);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 13;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = false;
			this.doneButton.Click += new System.EventHandler(this.DoneButtonClick);
			// 
			// setSpooky
			// 
			this.setSpooky.Location = new System.Drawing.Point(204, 110);
			this.setSpooky.Name = "setSpooky";
			this.setSpooky.Size = new System.Drawing.Size(75, 23);
			this.setSpooky.TabIndex = 14;
			this.setSpooky.Text = "Spooky";
			this.setSpooky.UseVisualStyleBackColor = true;
			this.setSpooky.Click += new System.EventHandler(this.SetSpookyClick);
			// 
			// setSax
			// 
			this.setSax.Location = new System.Drawing.Point(204, 139);
			this.setSax.Name = "setSax";
			this.setSax.Size = new System.Drawing.Size(75, 23);
			this.setSax.TabIndex = 15;
			this.setSax.Text = "Sax";
			this.setSax.UseVisualStyleBackColor = true;
			this.setSax.Click += new System.EventHandler(this.SetSaxClick);
			// 
			// setSaxSharp
			// 
			this.setSaxSharp.Location = new System.Drawing.Point(204, 168);
			this.setSaxSharp.Name = "setSaxSharp";
			this.setSaxSharp.Size = new System.Drawing.Size(75, 23);
			this.setSaxSharp.TabIndex = 16;
			this.setSaxSharp.Text = "Sax Sharp";
			this.setSaxSharp.UseVisualStyleBackColor = true;
			this.setSaxSharp.Click += new System.EventHandler(this.SetSaxSharpClick);
			// 
			// setSaxFlat
			// 
			this.setSaxFlat.Location = new System.Drawing.Point(204, 197);
			this.setSaxFlat.Name = "setSaxFlat";
			this.setSaxFlat.Size = new System.Drawing.Size(75, 23);
			this.setSaxFlat.TabIndex = 17;
			this.setSaxFlat.Text = "Sax Flat";
			this.setSaxFlat.UseVisualStyleBackColor = true;
			this.setSaxFlat.Click += new System.EventHandler(this.SetSaxFlatClick);
			// 
			// setRepeatStart
			// 
			this.setRepeatStart.Location = new System.Drawing.Point(204, 226);
			this.setRepeatStart.Name = "setRepeatStart";
			this.setRepeatStart.Size = new System.Drawing.Size(75, 23);
			this.setRepeatStart.TabIndex = 18;
			this.setRepeatStart.Text = "Repeat Start";
			this.setRepeatStart.UseVisualStyleBackColor = true;
			this.setRepeatStart.Click += new System.EventHandler(this.SetRepeatStartClick);
			// 
			// setRepeatEnd
			// 
			this.setRepeatEnd.Location = new System.Drawing.Point(204, 255);
			this.setRepeatEnd.Name = "setRepeatEnd";
			this.setRepeatEnd.Size = new System.Drawing.Size(75, 23);
			this.setRepeatEnd.TabIndex = 19;
			this.setRepeatEnd.Text = "Repeat End";
			this.setRepeatEnd.UseVisualStyleBackColor = true;
			this.setRepeatEnd.Click += new System.EventHandler(this.SetRepeatEndClick);
			// 
			// setBlank
			// 
			this.setBlank.Location = new System.Drawing.Point(104, 255);
			this.setBlank.Name = "setBlank";
			this.setBlank.Size = new System.Drawing.Size(75, 23);
			this.setBlank.TabIndex = 20;
			this.setBlank.Text = "Blank";
			this.setBlank.UseVisualStyleBackColor = true;
			this.setBlank.Click += new System.EventHandler(this.SetBlankClick);
			// 
			// HotkeyConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 291);
			this.Controls.Add(this.setBlank);
			this.Controls.Add(this.setRepeatEnd);
			this.Controls.Add(this.setRepeatStart);
			this.Controls.Add(this.setSaxFlat);
			this.Controls.Add(this.setSaxSharp);
			this.Controls.Add(this.setSax);
			this.Controls.Add(this.setSpooky);
			this.Controls.Add(this.doneButton);
			this.Controls.Add(this.setDrums);
			this.Controls.Add(this.setBassFlat);
			this.Controls.Add(this.setBassSharp);
			this.Controls.Add(this.setBass);
			this.Controls.Add(this.setPianoFlat);
			this.Controls.Add(this.setPianoSharp);
			this.Controls.Add(this.setPiano);
			this.Controls.Add(this.setLoad);
			this.Controls.Add(this.setYellowPlay);
			this.Controls.Add(this.setRight);
			this.Controls.Add(this.setLeft);
			this.Controls.Add(this.setSave);
			this.Controls.Add(this.setPlay);
			this.Name = "HotkeyConfig";
			this.Text = "HotkeyConfig";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.HotkeyConfigKeyDown);
			this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button doneButton;
		private System.Windows.Forms.Button setDrums;
		private System.Windows.Forms.Button setBassFlat;
		private System.Windows.Forms.Button setBassSharp;
		private System.Windows.Forms.Button setBass;
		private System.Windows.Forms.Button setPianoFlat;
		private System.Windows.Forms.Button setPianoSharp;
		private System.Windows.Forms.Button setPiano;
		private System.Windows.Forms.Button setLoad;
		private System.Windows.Forms.Button setYellowPlay;
		private System.Windows.Forms.Button setRight;
		private System.Windows.Forms.Button setLeft;
		private System.Windows.Forms.Button setSave;
		private System.Windows.Forms.Button setPlay;
		private System.Windows.Forms.Button setSpooky;
		private System.Windows.Forms.Button setSax;
		private System.Windows.Forms.Button setSaxSharp;
		private System.Windows.Forms.Button setSaxFlat;
		private System.Windows.Forms.Button setRepeatStart;
		private System.Windows.Forms.Button setRepeatEnd;
		private System.Windows.Forms.Button setBlank;
	}
}
