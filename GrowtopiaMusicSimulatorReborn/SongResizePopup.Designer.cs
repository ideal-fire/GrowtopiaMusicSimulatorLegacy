/*
 * User: admin
 * Date: 7/27/2016
 * Time: 1:25 AM
 */
namespace GrowtopiaMusicSimulatorReborn
{
	partial class SongResizePopup
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.NumericUpDown songLengthBox;
		private System.Windows.Forms.Button doneButton;
		private System.Windows.Forms.Label label3;
	
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
		/// This method is required for Win{
		private void InitializeComponent() {
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.doneButton = new System.Windows.Forms.Button();
			this.songLengthBox = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.songLengthBox)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(13, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(259, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Enter how long you want your song to be. ";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(13, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(215, 23);
			this.label2.TabIndex = 1;
			this.label2.Text = "400 is the most that can fit in one world.";
			// 
			// doneButton
			// 
			this.doneButton.Location = new System.Drawing.Point(110, 78);
			this.doneButton.Name = "doneButton";
			this.doneButton.Size = new System.Drawing.Size(75, 23);
			this.doneButton.TabIndex = 2;
			this.doneButton.Text = "Done";
			this.doneButton.UseVisualStyleBackColor = true;
			this.doneButton.Click += new System.EventHandler(this.DoneButtonClick);
			// 
			// songLengthBox
			// 
			this.songLengthBox.Location = new System.Drawing.Point(12, 81);
			this.songLengthBox.Maximum = new decimal(new int[] {
			9975,
			0,
			0,
			0});
			this.songLengthBox.Minimum = new decimal(new int[] {
			1,
			0,
			0,
			0});
			this.songLengthBox.Name = "songLengthBox";
			this.songLengthBox.Size = new System.Drawing.Size(92, 20);
			this.songLengthBox.TabIndex = 4;
			this.songLengthBox.Value = new decimal(new int[] {
			400,
			0,
			0,
			0});
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(13, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(128, 16);
			this.label3.TabIndex = 5;
			this.label3.Text = "Must be a multiple of 25.";
			// 
			// SongResizePopup
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(226, 113);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.songLengthBox);
			this.Controls.Add(this.doneButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "SongResizePopup";
			this.Text = "Resize Song";
			this.Load += new System.EventHandler(this.SongResizePopupLoad);
			((System.ComponentModel.ISupportInitialize)(this.songLengthBox)).EndInit();
			this.ResumeLayout(false);

		}

	}
}
