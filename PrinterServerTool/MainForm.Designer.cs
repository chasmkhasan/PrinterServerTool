namespace PrinterServerTool
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
			cmbOptions = new ComboBox();
			btnInstallPrinter = new Button();
			btnSearch = new Button();
			lstOfPrinterName = new ListBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.Red;
			label1.Location = new Point(119, 38);
			label1.Name = "label1";
			label1.Size = new Size(77, 15);
			label1.TabIndex = 0;
			label1.Text = "Printer Server";
			// 
			// cmbOptions
			// 
			cmbOptions.FormattingEnabled = true;
			cmbOptions.Location = new Point(30, 76);
			cmbOptions.Name = "cmbOptions";
			cmbOptions.Size = new Size(261, 23);
			cmbOptions.TabIndex = 1;
			// 
			// btnInstallPrinter
			// 
			btnInstallPrinter.ForeColor = Color.FromArgb(0, 192, 0);
			btnInstallPrinter.Location = new Point(101, 293);
			btnInstallPrinter.Name = "btnInstallPrinter";
			btnInstallPrinter.Size = new Size(109, 23);
			btnInstallPrinter.TabIndex = 2;
			btnInstallPrinter.Text = "Install Server";
			btnInstallPrinter.UseVisualStyleBackColor = true;
			btnInstallPrinter.Click += btnInstallPrinter_Click;
			// 
			// btnSearch
			// 
			btnSearch.Location = new Point(321, 75);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(109, 23);
			btnSearch.TabIndex = 3;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// lstOfPrinterName
			// 
			lstOfPrinterName.FormattingEnabled = true;
			lstOfPrinterName.ItemHeight = 15;
			lstOfPrinterName.Location = new Point(33, 123);
			lstOfPrinterName.Name = "lstOfPrinterName";
			lstOfPrinterName.Size = new Size(258, 154);
			lstOfPrinterName.TabIndex = 4;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(458, 347);
			Controls.Add(lstOfPrinterName);
			Controls.Add(btnSearch);
			Controls.Add(btnInstallPrinter);
			Controls.Add(cmbOptions);
			Controls.Add(label1);
			Name = "MainForm";
			Text = "Printer's Tool";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ComboBox cmbOptions;
		private Button btnInstallPrinter;
		private Button btnSearch;
		private ListBox lstOfPrinterName;
	}
}
