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
			drpPrinterList = new ComboBox();
			btnInstallServer = new Button();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.ForeColor = Color.Red;
			label1.Location = new Point(78, 39);
			label1.Name = "label1";
			label1.Size = new Size(77, 15);
			label1.TabIndex = 0;
			label1.Text = "Printer Server";
			// 
			// drpPrinterList
			// 
			drpPrinterList.FormattingEnabled = true;
			drpPrinterList.Location = new Point(30, 76);
			drpPrinterList.Name = "drpPrinterList";
			drpPrinterList.Size = new Size(175, 23);
			drpPrinterList.TabIndex = 1;
			// 
			// btnInstallServer
			// 
			btnInstallServer.Location = new Point(243, 78);
			btnInstallServer.Name = "btnInstallServer";
			btnInstallServer.Size = new Size(109, 23);
			btnInstallServer.TabIndex = 2;
			btnInstallServer.Text = "Install Server";
			btnInstallServer.UseVisualStyleBackColor = true;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(377, 173);
			Controls.Add(btnInstallServer);
			Controls.Add(drpPrinterList);
			Controls.Add(label1);
			Name = "MainForm";
			Text = "Printer's Tool";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private ComboBox drpPrinterList;
		private Button btnInstallServer;
	}
}
