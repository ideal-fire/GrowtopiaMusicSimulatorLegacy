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
			this.SuspendLayout();
			// 
			// setPlay
			// 
			this.setPlay.Location = new System.Drawing.Point(13, 101);
			this.setPlay.Name = "setPlay";
			this.setPlay.Size = new System.Drawing.Size(42, 23);
			this.setPlay.TabIndex = 0;
			this.setPlay.Text = "Play";
			this.setPlay.UseVisualStyleBackColor = true;
			this.setPlay.Click += new System.EventHandler(this.SetPlayClick);
			// 
			// setSave
			// 
			this.setSave.Location = new System.Drawing.Point(13, 131);
			this.setSave.Name = "setSave";
			this.setSave.Size = new System.Drawing.Size(42, 23);
			this.setSave.TabIndex = 1;
			this.setSave.Text = "Save";
			this.setSave.UseVisualStyleBackColor = true;
			this.setSave.Click += new System.EventHandler(this.SetSaveClick);
			// 
			// setLeft
			// 
			this.setLeft.Location = new System.Drawing.Point(13, 161);
			this.setLeft.Name = "setLeft";
			this.setLeft.Size = new System.Drawing.Size(42, 23);
			this.setLeft.TabIndex = 2;
			this.setLeft.Text = "Left";
			this.setLeft.UseVisualStyleBackColor = true;
			this.setLeft.Click += new System.EventHandler(this.SetLeftClick);
			// 
			// setRight
			// 
			this.setRight.Location = new System.Drawing.Point(13, 191);
			this.setRight.Name = "setRight";
			this.setRight.Size = new System.Drawing.Size(42, 23);
			this.setRight.TabIndex = 3;
			this.setRight.Text = "Right";
			this.setRight.UseVisualStyleBackColor = true;
			this.setRight.Click += new System.EventHandler(this.SetRightClick);
			// 
			// setYellowPlay
			// 
			this.setYellowPlay.Location = new System.Drawing.Point(13, 220);
			this.setYellowPlay.Name = "setYellowPlay";
			this.setYellowPlay.Size = new System.Drawing.Size(69, 20);
			this.setYellowPlay.TabIndex = 4;
			this.setYellowPlay.Text = "Yellow play";
			this.setYellowPlay.UseVisualStyleBackColor = true;
			this.setYellowPlay.Click += new System.EventHandler(this.SetYellowPlayClick);
			// 
			// setLoad
			// 
			this.setLoad.Location = new System.Drawing.Point(13, 247);
			this.setLoad.Name = "setLoad";
			this.setLoad.Size = new System.Drawing.Size(42, 21);
			this.setLoad.TabIndex = 5;
			this.setLoad.Text = "Load";
			this.setLoad.UseVisualStyleBackColor = true;
			this.setLoad.Click += new System.EventHandler(this.SetLoadClick);
			// 
			// setPiano
			// 
			this.setPiano.Location = new System.Drawing.Point(148, 101);
			this.setPiano.Name = "setPiano";
			this.setPiano.Size = new System.Drawing.Size(51, 23);
			this.setPiano.TabIndex = 6;
			this.setPiano.Text = "Piano";
			this.setPiano.UseVisualStyleBackColor = true;
			this.setPiano.Click += new System.EventHandler(this.SetPianoClick);
			// 
			// setPianoSharp
			// 
			this.setPianoSharp.Location = new System.Drawing.Point(148, 131);
			this.setPianoSharp.Name = "setPianoSharp";
			this.setPianoSharp.Size = new System.Drawing.Size(75, 23);
			this.setPianoSharp.TabIndex = 7;
			this.setPianoSharp.Text = "Piano sharp";
			this.setPianoSharp.UseVisualStyleBackColor = true;
			this.setPianoSharp.Click += new System.EventHandler(this.SetPianoSharpClick);
			// 
			// setPianoFlat
			// 
			this.setPianoFlat.Location = new System.Drawing.Point(148, 161);
			this.setPianoFlat.Name = "setPianoFlat";
			this.setPianoFlat.Size = new System.Drawing.Size(75, 23);
			this.setPianoFlat.TabIndex = 8;
			this.setPianoFlat.Text = "Piano flat";
			this.setPianoFlat.UseVisualStyleBackColor = true;
			this.setPianoFlat.Click += new System.EventHandler(this.SetPianoFlatClick);
			// 
			// setBass
			// 
			this.setBass.Location = new System.Drawing.Point(148, 191);
			this.setBass.Name = "setBass";
			this.setBass.Size = new System.Drawing.Size(51, 23);
			this.setBass.TabIndex = 9;
			this.setBass.Text = "Bass";
			this.setBass.UseVisualStyleBackColor = true;
			this.setBass.Click += new System.EventHandler(this.SetBassClick);
			// 
			// setBassSharp
			// 
			this.setBassSharp.Location = new System.Drawing.Point(148, 220);
			this.setBassSharp.Name = "setBassSharp";
			this.setBassSharp.Size = new System.Drawing.Size(75, 23);
			this.setBassSharp.TabIndex = 10;
			this.setBassSharp.Text = "Bass sharp";
			this.setBassSharp.UseVisualStyleBackColor = true;
			this.setBassSharp.Click += new System.EventHandler(this.SetBassSharpClick);
			// 
			// setBassFlat
			// 
			this.setBassFlat.Location = new System.Drawing.Point(148, 249);
			this.setBassFlat.Name = "setBassFlat";
			this.setBassFlat.Size = new System.Drawing.Size(60, 23);
			this.setBassFlat.TabIndex = 11;
			this.setBassFlat.Text = "Bass flat";
			this.setBassFlat.UseVisualStyleBackColor = true;
			this.setBassFlat.Click += new System.EventHandler(this.SetBassFlatClick);
			// 
			// setDrums
			// 
			this.setDrums.Location = new System.Drawing.Point(242, 170);
			this.setDrums.Name = "setDrums";
			this.setDrums.Size = new System.Drawing.Size(75, 23);
			this.setDrums.TabIndex = 12;
			this.setDrums.Text = "Drums";
			this.setDrums.UseVisualStyleBackColor = true;
			this.setDrums.Click += new System.EventHandler(this.SetDrumsClick);
			// 
			// doneButton
			// 
			this.doneButton.Location = new System.Drawing.Point(242, 46);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 13;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new System.EventHandler(this.DoneButtonClick);
			// 
			// HotkeyConfig
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(329, 291);
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
	}
}
