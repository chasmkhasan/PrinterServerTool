namespace PrinterServerTool
{
	partial class PreLoaderForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			panel1 = new Panel();
			label1 = new Label();
			gifBox = new PictureBox();
			panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gifBox).BeginInit();
			SuspendLayout();
			// 
			// panel1
			// 
			panel1.BackColor = SystemColors.ControlLightLight;
			panel1.Controls.Add(gifBox);
			panel1.Controls.Add(label1);
			panel1.Dock = DockStyle.Fill;
			panel1.Location = new Point(0, 0);
			panel1.Name = "panel1";
			panel1.Size = new Size(238, 126);
			panel1.TabIndex = 0;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(12, 88);
			label1.Name = "label1";
			label1.Size = new Size(222, 15);
			label1.TabIndex = 0;
			label1.Text = "Retrieving shared printers from server . . .";
			// 
			// gifBox
			// 
			gifBox.Image = Properties.Resources.Spinning_fangs;
			gifBox.Location = new Point(84, 12);
			gifBox.Name = "gifBox";
			gifBox.Size = new Size(70, 63);
			gifBox.TabIndex = 1;
			gifBox.TabStop = false;
			// 
			// PreLoaderForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(238, 126);
			Controls.Add(panel1);
			FormBorderStyle = FormBorderStyle.None;
			Name = "PreLoaderForm";
			Text = "PreLoaderForm";
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)gifBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private Panel panel1;
		private Label label1;
		private PictureBox gifBox;
	}
}