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
			label1 = new Label();
			dataGridPrinter = new DataGridView();
			tableLayoutPanel5 = new TableLayoutPanel();
			btnPrinterRemove = new Button();
			btnInstallPrinter = new Button();
			spiningBarBox = new PictureBox();
			tableLayoutPanel6 = new TableLayoutPanel();
			btnSearch = new Button();
			tableLayoutPanel4 = new TableLayoutPanel();
			button1 = new Button();
			button2 = new Button();
			tableLayoutPanel1.SuspendLayout();
			tableLayoutPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dataGridPrinter).BeginInit();
			tableLayoutPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)spiningBarBox).BeginInit();
			tableLayoutPanel6.SuspendLayout();
			tableLayoutPanel4.SuspendLayout();
			SuspendLayout();
			// 
			// tableLayoutPanel1
			// 
			tableLayoutPanel1.ColumnCount = 3;
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 2.67175579F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 97.32825F));
			tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 8F));
			tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 1);
			tableLayoutPanel1.Dock = DockStyle.Fill;
			tableLayoutPanel1.Location = new Point(0, 0);
			tableLayoutPanel1.Name = "tableLayoutPanel1";
			tableLayoutPanel1.RowCount = 3;
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 5.214724F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 94.78528F));
			tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel1.Size = new Size(1057, 380);
			tableLayoutPanel1.TabIndex = 0;
			// 
			// tableLayoutPanel2
			// 
			tableLayoutPanel2.ColumnCount = 2;
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85.44727F));
			tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 14.5527372F));
			tableLayoutPanel2.Controls.Add(dropDownOptions, 0, 1);
			tableLayoutPanel2.Controls.Add(label1, 0, 0);
			tableLayoutPanel2.Controls.Add(dataGridPrinter, 0, 2);
			tableLayoutPanel2.Controls.Add(tableLayoutPanel5, 1, 2);
			tableLayoutPanel2.Controls.Add(tableLayoutPanel6, 1, 1);
			tableLayoutPanel2.Dock = DockStyle.Fill;
			tableLayoutPanel2.Location = new Point(31, 21);
			tableLayoutPanel2.Name = "tableLayoutPanel2";
			tableLayoutPanel2.RowCount = 3;
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 43.636364F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 56.363636F));
			tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 256F));
			tableLayoutPanel2.Size = new Size(1014, 335);
			tableLayoutPanel2.TabIndex = 0;
			// 
			// dropDownOptions
			// 
			dropDownOptions.Anchor = AnchorStyles.None;
			dropDownOptions.Cursor = Cursors.Hand;
			dropDownOptions.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			dropDownOptions.FormattingEnabled = true;
			dropDownOptions.IntegralHeight = false;
			dropDownOptions.Location = new Point(3, 44);
			dropDownOptions.Name = "dropDownOptions";
			dropDownOptions.Size = new Size(860, 23);
			dropDownOptions.TabIndex = 1;
			// 
			// label1
			// 
			label1.Anchor = AnchorStyles.None;
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(342, 7);
			label1.Name = "label1";
			label1.Size = new Size(181, 19);
			label1.TabIndex = 0;
			label1.Text = "Welcome To Queue Installer";
			// 
			// dataGridPrinter
			// 
			dataGridPrinter.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			dataGridPrinter.BackgroundColor = SystemColors.ControlLightLight;
			dataGridPrinter.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dataGridPrinter.Location = new Point(3, 81);
			dataGridPrinter.MultiSelect = false;
			dataGridPrinter.Name = "dataGridPrinter";
			dataGridPrinter.Size = new Size(860, 251);
			dataGridPrinter.TabIndex = 7;
			// 
			// tableLayoutPanel5
			// 
			tableLayoutPanel5.ColumnCount = 1;
			tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel5.Controls.Add(btnPrinterRemove, 0, 1);
			tableLayoutPanel5.Controls.Add(btnInstallPrinter, 0, 0);
			tableLayoutPanel5.Controls.Add(spiningBarBox, 0, 4);
			tableLayoutPanel5.Location = new Point(869, 81);
			tableLayoutPanel5.Name = "tableLayoutPanel5";
			tableLayoutPanel5.RowCount = 5;
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 49.35065F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Percent, 50.64935F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 29F));
			tableLayoutPanel5.RowStyles.Add(new RowStyle(SizeType.Absolute, 115F));
			tableLayoutPanel5.Size = new Size(142, 251);
			tableLayoutPanel5.TabIndex = 8;
			// 
			// btnPrinterRemove
			// 
			btnPrinterRemove.Dock = DockStyle.Fill;
			btnPrinterRemove.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnPrinterRemove.Location = new Point(3, 41);
			btnPrinterRemove.Name = "btnPrinterRemove";
			btnPrinterRemove.Size = new Size(136, 33);
			btnPrinterRemove.TabIndex = 1;
			btnPrinterRemove.Text = "Remove";
			btnPrinterRemove.UseVisualStyleBackColor = true;
			btnPrinterRemove.Visible = false;
			btnPrinterRemove.Click += btnPrinterRemove_Click;
			// 
			// btnInstallPrinter
			// 
			btnInstallPrinter.Dock = DockStyle.Fill;
			btnInstallPrinter.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnInstallPrinter.Location = new Point(3, 3);
			btnInstallPrinter.Name = "btnInstallPrinter";
			btnInstallPrinter.Size = new Size(136, 32);
			btnInstallPrinter.TabIndex = 0;
			btnInstallPrinter.Text = "Install";
			btnInstallPrinter.UseVisualStyleBackColor = true;
			btnInstallPrinter.Visible = false;
			btnInstallPrinter.Click += btnInstallPrinter_Click;
			// 
			// spiningBarBox
			// 
			spiningBarBox.Anchor = AnchorStyles.Bottom;
			spiningBarBox.Image = Properties.Resources.Spinning_fangs;
			spiningBarBox.Location = new Point(38, 182);
			spiningBarBox.Name = "spiningBarBox";
			spiningBarBox.Size = new Size(66, 66);
			spiningBarBox.TabIndex = 6;
			spiningBarBox.TabStop = false;
			spiningBarBox.Visible = false;
			// 
			// tableLayoutPanel6
			// 
			tableLayoutPanel6.ColumnCount = 1;
			tableLayoutPanel6.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel6.Controls.Add(btnSearch, 0, 0);
			tableLayoutPanel6.Location = new Point(869, 37);
			tableLayoutPanel6.Name = "tableLayoutPanel6";
			tableLayoutPanel6.RowCount = 1;
			tableLayoutPanel6.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
			tableLayoutPanel6.Size = new Size(142, 38);
			tableLayoutPanel6.TabIndex = 9;
			// 
			// btnSearch
			// 
			btnSearch.Cursor = Cursors.Hand;
			btnSearch.Dock = DockStyle.Fill;
			btnSearch.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			btnSearch.Location = new Point(3, 3);
			btnSearch.Name = "btnSearch";
			btnSearch.Size = new Size(136, 32);
			btnSearch.TabIndex = 2;
			btnSearch.Text = "Search";
			btnSearch.UseVisualStyleBackColor = true;
			btnSearch.Click += btnSearch_Click;
			// 
			// tableLayoutPanel4
			// 
			tableLayoutPanel4.ColumnCount = 2;
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
			tableLayoutPanel4.Controls.Add(button1, 1, 0);
			tableLayoutPanel4.Dock = DockStyle.Fill;
			tableLayoutPanel4.Location = new Point(0, 0);
			tableLayoutPanel4.Name = "tableLayoutPanel4";
			tableLayoutPanel4.RowCount = 1;
			tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
			tableLayoutPanel4.Size = new Size(200, 100);
			tableLayoutPanel4.TabIndex = 0;
			// 
			// button1
			// 
			button1.Anchor = AnchorStyles.None;
			button1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button1.Location = new Point(103, 36);
			button1.Name = "button1";
			button1.Size = new Size(94, 28);
			button1.TabIndex = 1;
			button1.Text = "Remove";
			button1.UseVisualStyleBackColor = true;
			// 
			// button2
			// 
			button2.Anchor = AnchorStyles.None;
			button2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			button2.Location = new Point(3, 36);
			button2.Name = "button2";
			button2.Size = new Size(94, 28);
			button2.TabIndex = 0;
			button2.Text = "Install";
			button2.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = SystemColors.ControlLightLight;
			ClientSize = new Size(1057, 380);
			Controls.Add(tableLayoutPanel1);
			Name = "MainForm";
			tableLayoutPanel1.ResumeLayout(false);
			tableLayoutPanel2.ResumeLayout(false);
			tableLayoutPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)dataGridPrinter).EndInit();
			tableLayoutPanel5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)spiningBarBox).EndInit();
			tableLayoutPanel6.ResumeLayout(false);
			tableLayoutPanel4.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TableLayoutPanel tableLayoutPanel1;
		private TableLayoutPanel tableLayoutPanel2;
		private Label label1;
		private ComboBox dropDownOptions;
		private DataGridView dataGridPrinter;
		private TableLayoutPanel tableLayoutPanel4;
		private Button button1;
		private Button button2;
		private TableLayoutPanel tableLayoutPanel5;
		private Button btnPrinterRemove;
		private Button btnInstallPrinter;
		private PictureBox spiningBarBox;
		private TableLayoutPanel tableLayoutPanel6;
		private Button btnSearch;
	}
}
