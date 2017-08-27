/*
 * User: knoob
 * Date: 8/27/2017
 * Time: 12:53 PM
 */
namespace GrowtopiaMusicSimulatorReborn
{
	partial class EditAudioRack
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button doneButton;
		private System.Windows.Forms.TextBox growtopiaText;
		
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
			this.doneButton = new System.Windows.Forms.Button();
			this.growtopiaText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// doneButton
			// 
			this.doneButton.Location = new System.Drawing.Point(58, 485);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 0;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new System.EventHandler(this.DoneButtonClick);
			// 
			// growtopiaText
			// 
			this.growtopiaText.Location = new System.Drawing.Point(13, 514);
			this.growtopiaText.Name = "growtopiaText";
			this.growtopiaText.Size = new System.Drawing.Size(167, 20);
			this.growtopiaText.TabIndex = 1;
			this.growtopiaText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GrowtopiaTextKeyDown);
			// 
			// EditAudioRack
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(192, 546);
			this.Controls.Add(this.growtopiaText);
			this.Controls.Add(this.doneButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "EditAudioRack";
			this.Text = "EditAudioRack";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditAudioRackFormClosing);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.EditAudioRackPaint);
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EditAudioRackMouseDown);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
