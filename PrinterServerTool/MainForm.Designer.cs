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
			tableLayoutPanel1 = new TableLayoutPanel();
			tableLayoutPanel2 = new TableLayoutPanel();
			dropDownOptions = new ComboBox();
			btnSearch = new Button();
			btnInstall = new Button();
			lstOfPrinterName = new ListBox();
			label1 = new Label();
			gifBox = new PictureBox();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gifBox).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 4.347826F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 95.6521759F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.214724F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.78528F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(458, 347);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 67.47573F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32.5242729F));
			tableLayoutPanel2.Controls.Add(dropDownOptions, 0, 1);
			tableLayoutPanel2.Controls.Add(btnSearch, 1, 1);
			tableLayoutPanel2.Controls.Add(btnInstall, 0, 3);
			tableLayoutPanel2.Controls.Add(lstOfPrinterName, 0, 2);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(gifBox, 1, 2);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(22, 20);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 4;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 47.0588226F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 52.9411774F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 221F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
			tableLayoutPanel2.Size = new Size(412, 303);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// dropDownOptions
			// 
			dropDownOptions.Anchor = AnchorStyles.None;
			dropDownOptions.Cursor = Cursors.Hand;
			dropDownOptions.FormattingEnabled = true;
			dropDownOptions.Location = new Point(40, 27);
			dropDownOptions.Name = "dropDownOptions";
			dropDownOptions.Size = new Size(197, 23);
			dropDownOptions.TabIndex = 1;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.None;
			btnSearch.Cursor = Cursors.Hand;
			btnSearch.Location = new Point(307, 27);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(75, 21);
			btnSearch.TabIndex = 2;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// btnInstall
			// 
			btnInstall.Anchor = AnchorStyles.None;
			btnInstall.Cursor = Cursors.Hand;
			btnInstall.Location = new Point(101, 276);
			btnInstall.Name = "btnInstall";
			btnInstall.Size = new Size(75, 23);
			btnInstall.TabIndex = 3;
			btnInstall.Text = "Install";
			btnInstall.UseVisualStyleBackColor = true;
			btnInstall.Click += btnInstall_Click;
			// 
			// lstOfPrinterName
			// 
			lstOfPrinterName.Anchor = AnchorStyles.None;
			lstOfPrinterName.Cursor = Cursors.Hand;
			lstOfPrinterName.FormattingEnabled = true;
			lstOfPrinterName.ItemHeight = 15;
			lstOfPrinterName.Location = new Point(41, 69);
			lstOfPrinterName.Name = "lstOfPrinterName";
			lstOfPrinterName.Size = new Size(196, 184);
			lstOfPrinterName.TabIndex = 4;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Location = new Point(64, 4);
			label1.Name = "label1";
			label1.Size = new Size(149, 15);
			label1.TabIndex = 0;
			label1.Text = "Welcome To Shared Printer";
			// 
			// gifBox
			// 
			gifBox.Anchor = AnchorStyles.None;
			gifBox.Image = Properties.Resources.Spinning_fangs;
			gifBox.Location = new Point(312, 128);
			gifBox.Name = "gifBox";
			gifBox.Size = new Size(66, 66);
			gifBox.TabIndex = 5;
			gifBox.TabStop = false;
			gifBox.Visible = false;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLightLight;
			ClientSize = new Size(458, 347);
			Controls.Add(tableLayoutPanel1);
			Name = "MainForm";
			Text = "Printer's Tool";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)gifBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label1;
		private ComboBox dropDownOptions;
		private Button btnSearch;
		private Button btnInstall;
		private ListBox lstOfPrinterName;
		private ProgressBar prgBar;
		private PictureBox gifBox;
	}
}
