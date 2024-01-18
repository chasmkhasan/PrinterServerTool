﻿namespace PrinterServerTool
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
			lstOfPrinterName = new ListBox();
			label1 = new Label();
			tableLayoutPanel3 = new TableLayoutPanel();
			btnInstallPrinter = new Button();
			btnPrinterRemove = new Button();
			gifBox = new PictureBox();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
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
			tableLayoutPanel1.Size = new Size(657, 354);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.Anchor = AnchorStyles.None;
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.84553F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.1544724F));
			tableLayoutPanel2.Controls.Add(dropDownOptions, 0, 1);
			tableLayoutPanel2.Controls.Add(btnSearch, 1, 1);
			tableLayoutPanel2.Controls.Add(lstOfPrinterName, 0, 2);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 3);
			tableLayoutPanel2.Controls.Add(gifBox, 1, 2);
			tableLayoutPanel2.Location = new Point(30, 20);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 4;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 47.0588226F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 52.9411774F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 193F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
			tableLayoutPanel2.Size = new Size(603, 310);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// dropDownOptions
			// 
			dropDownOptions.Anchor = AnchorStyles.None;
			dropDownOptions.Cursor = Cursors.Hand;
			dropDownOptions.FormattingEnabled = true;
			dropDownOptions.Location = new Point(77, 45);
			dropDownOptions.Name = "dropDownOptions";
			dropDownOptions.Size = new Size(315, 23);
			dropDownOptions.TabIndex = 1;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.None;
			btnSearch.Cursor = Cursors.Hand;
			btnSearch.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSearch.Location = new Point(489, 42);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(93, 29);
			btnSearch.TabIndex = 2;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// lstOfPrinterName
			// 
			lstOfPrinterName.Anchor = AnchorStyles.None;
			lstOfPrinterName.Cursor = Cursors.Hand;
			lstOfPrinterName.FormattingEnabled = true;
			lstOfPrinterName.HorizontalScrollbar = true;
			lstOfPrinterName.ItemHeight = 15;
			lstOfPrinterName.Location = new Point(5, 81);
			lstOfPrinterName.Name = "lstOfPrinterName";
			lstOfPrinterName.Size = new Size(458, 184);
			lstOfPrinterName.TabIndex = 4;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(146, 8);
			label1.Name = "label1";
			label1.Size = new Size(177, 19);
			label1.TabIndex = 0;
			label1.Text = "Welcome To Shared Printer";
			// 
			// tableLayoutPanel3
			// 
			tableLayoutPanel3.ColumnCount = 2;
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Controls.Add(btnInstallPrinter, 0, 0);
			tableLayoutPanel3.Controls.Add(btnPrinterRemove, 1, 0);
			tableLayoutPanel3.Dock = DockStyle.Fill;
			tableLayoutPanel3.Location = new Point(3, 273);
			tableLayoutPanel3.Name = "tableLayoutPanel3";
			tableLayoutPanel3.RowCount = 1;
			tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel3.Size = new Size(463, 34);
			tableLayoutPanel3.TabIndex = 6;
			// 
			// btnInstallPrinter
			// 
			btnInstallPrinter.Anchor = AnchorStyles.None;
			btnInstallPrinter.Location = new Point(63, 3);
			btnInstallPrinter.Name = "btnInstallPrinter";
			btnInstallPrinter.Size = new Size(105, 28);
			btnInstallPrinter.TabIndex = 0;
			btnInstallPrinter.Text = "Install";
			btnInstallPrinter.UseVisualStyleBackColor = true;
			btnInstallPrinter.Click += btnInstallPrinter_Click;
			// 
			// btnPrinterRemove
			// 
			btnPrinterRemove.Anchor = AnchorStyles.None;
			btnPrinterRemove.Location = new Point(286, 3);
			btnPrinterRemove.Name = "btnPrinterRemove";
			btnPrinterRemove.Size = new Size(121, 28);
			btnPrinterRemove.TabIndex = 1;
			btnPrinterRemove.Text = "Remove";
			btnPrinterRemove.UseVisualStyleBackColor = true;
			btnPrinterRemove.Click += btnPrinterRemove_Click;
			// 
			// gifBox
			// 
			gifBox.Anchor = AnchorStyles.None;
			gifBox.Image = Properties.Resources.Spinning_fangs;
			gifBox.Location = new Point(503, 140);
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
			ClientSize = new Size(657, 354);
			Controls.Add(tableLayoutPanel1);
			Name = "MainForm";
			Text = "Printer's Tool";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gifBox).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label1;
		private ComboBox dropDownOptions;
		private Button btnSearch;
		private ListBox lstOfPrinterName;
		private PictureBox gifBox;
		private TableLayoutPanel tableLayoutPanel3;
		private Button btnInstallPrinter;
		private Button btnPrinterRemove;
	}
}
