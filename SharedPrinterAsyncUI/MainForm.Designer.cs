namespace SharedPrinterAsyncUI
{
	partial class MainForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			label1 = new Label();
			lstOfSharedPrinter = new ListBox();
			btnInstall = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(121, 23);
			label1.Name = "label1";
			label1.Size = new Size(121, 15);
			label1.TabIndex = 0;
			label1.Text = "List of Shared Printers";
			// 
			// lstOfSharedPrinter
			// 
			lstOfSharedPrinter.FormattingEnabled = true;
			lstOfSharedPrinter.ItemHeight = 15;
			lstOfSharedPrinter.Location = new Point(55, 51);
			lstOfSharedPrinter.Name = "lstOfSharedPrinter";
			lstOfSharedPrinter.Size = new Size(260, 94);
			lstOfSharedPrinter.TabIndex = 1;
			// 
			// btnInstall
			// 
			btnInstall.Location = new Point(131, 160);
			btnInstall.Name = "btnInstall";
			btnInstall.Size = new Size(101, 22);
			btnInstall.TabIndex = 2;
			btnInstall.Text = "Install";
			btnInstall.UseVisualStyleBackColor = true;
			btnInstall.Click += btnInstall_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(374, 219);
			Controls.Add(btnInstall);
			Controls.Add(lstOfSharedPrinter);
			Controls.Add(label1);
			Name = "MainForm";
			Text = "Printer's Tool";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ListBox lstOfSharedPrinter;
		private Button btnInstall;
	}
}
