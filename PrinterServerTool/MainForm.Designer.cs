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
			label1 = new Label();
			tableLayoutPanel3 = new TableLayoutPanel();
			btnInstallPrinter = new Button();
			btnPrinterRemove = new Button();
			gifBox = new PictureBox();
			dataGridPrinter = new DataGridView();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			tableLayoutPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)gifBox).BeginInit();
			((System.ComponentModel.ISupportInitialize)dataGridPrinter).BeginInit();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.01567745F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 97.98432F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.214724F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.78528F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(742, 354);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.4472656F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5527372F));
			tableLayoutPanel2.Controls.Add(dropDownOptions, 0, 1);
			tableLayoutPanel2.Controls.Add(btnSearch, 1, 1);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 3);
			tableLayoutPanel2.Controls.Add(gifBox, 1, 2);
			tableLayoutPanel2.Controls.Add(dataGridPrinter, 0, 2);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(17, 20);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 4;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 43.636364F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 56.363636F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 205F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 39F));
			tableLayoutPanel2.Size = new Size(701, 310);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// dropDownOptions
			// 
			dropDownOptions.Anchor = AnchorStyles.None;
			dropDownOptions.Cursor = Cursors.Hand;
			dropDownOptions.FormattingEnabled = true;
			dropDownOptions.Location = new Point(141, 35);
			dropDownOptions.Name = "dropDownOptions";
			dropDownOptions.Size = new Size(315, 23);
			dropDownOptions.TabIndex = 1;
			// 
			// btnSearch
			// 
			btnSearch.Anchor = AnchorStyles.None;
			btnSearch.Cursor = Cursors.Hand;
			btnSearch.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSearch.Location = new Point(603, 32);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(93, 29);
			btnSearch.TabIndex = 2;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(210, 4);
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
			tableLayoutPanel3.Size = new Size(592, 34);
			tableLayoutPanel3.TabIndex = 6;
			// 
			// btnInstallPrinter
			// 
			btnInstallPrinter.Anchor = AnchorStyles.None;
			btnInstallPrinter.Location = new Point(95, 3);
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
			btnPrinterRemove.Location = new Point(383, 3);
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
			gifBox.Location = new Point(616, 134);
			gifBox.Name = "gifBox";
			gifBox.Size = new Size(66, 66);
			gifBox.TabIndex = 5;
			gifBox.TabStop = false;
			gifBox.Visible = false;
			// 
			// dataGridPrinter
			// 
			dataGridPrinter.BackgroundColor = SystemColors.ControlLightLight;
			dataGridPrinter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridPrinter.Location = new Point(3, 68);
			dataGridPrinter.Name = "dataGridPrinter";
			dataGridPrinter.Size = new Size(592, 199);
			dataGridPrinter.TabIndex = 7;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLightLight;
			ClientSize = new Size(742, 354);
			Controls.Add(tableLayoutPanel1);
			Name = "MainForm";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Printer's Tool";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			tableLayoutPanel3.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)gifBox).EndInit();
			((System.ComponentModel.ISupportInitialize)dataGridPrinter).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label1;
		private ComboBox dropDownOptions;
		private Button btnSearch;
		private PictureBox gifBox;
		private TableLayoutPanel tableLayoutPanel3;
		private Button btnInstallPrinter;
		private Button btnPrinterRemove;
		private DataGridView dataGridPrinter;
	}
}
