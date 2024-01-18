namespace PrinterServerTool
{
	partial class UserInfo
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
			label1 = new Label();
			label2 = new Label();
			txtRemoteUser = new TextBox();
			txtRemotePass = new TextBox();
			btnRemoteLogIn = new Button();
			btnCancle = new Button();
			lblRemoteInformation = new Label();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(29, 57);
			label1.Name = "label1";
			label1.Size = new Size(109, 15);
			label1.TabIndex = 1;
			label1.Text = "Remote User Name";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(29, 85);
			label2.Name = "label2";
			label2.Size = new Size(103, 15);
			label2.TabIndex = 2;
			label2.Text = "Remote PassWord";
			// 
			// txtRemoteUser
			// 
			txtRemoteUser.Cursor = Cursors.IBeam;
			txtRemoteUser.Location = new Point(155, 54);
			txtRemoteUser.Name = "txtRemoteUser";
			txtRemoteUser.Size = new Size(188, 23);
			txtRemoteUser.TabIndex = 3;
			// 
			// txtRemotePass
			// 
			txtRemotePass.Cursor = Cursors.IBeam;
			txtRemotePass.Location = new Point(155, 85);
			txtRemotePass.Name = "txtRemotePass";
			txtRemotePass.Size = new Size(188, 23);
			txtRemotePass.TabIndex = 4;
			// 
			// btnRemoteLogIn
			// 
			btnRemoteLogIn.Cursor = Cursors.Hand;
			btnRemoteLogIn.Location = new Point(104, 128);
			btnRemoteLogIn.Name = "btnRemoteLogIn";
			btnRemoteLogIn.Size = new Size(101, 23);
			btnRemoteLogIn.TabIndex = 5;
			btnRemoteLogIn.Text = "Remote Login";
			btnRemoteLogIn.UseVisualStyleBackColor = true;
			btnRemoteLogIn.Click += btnRemoteLogIn_Click;
			// 
			// btnCancle
			// 
			btnCancle.Location = new Point(268, 128);
			btnCancle.Name = "btnCancle";
			btnCancle.Size = new Size(75, 23);
			btnCancle.TabIndex = 6;
			btnCancle.Text = "Cancle";
			btnCancle.UseVisualStyleBackColor = true;
			btnCancle.Click += btnCancle_Click;
			// 
			// lblRemoteInformation
			// 
			lblRemoteInformation.BorderStyle = BorderStyle.Fixed3D;
			lblRemoteInformation.Location = new Point(51, 19);
			lblRemoteInformation.Name = "lblRemoteInformation";
			lblRemoteInformation.Size = new Size(277, 23);
			lblRemoteInformation.TabIndex = 7;
			lblRemoteInformation.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// UserInfo
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(371, 163);
			Controls.Add(lblRemoteInformation);
			Controls.Add(btnCancle);
			Controls.Add(btnRemoteLogIn);
			Controls.Add(txtRemotePass);
			Controls.Add(txtRemoteUser);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UserInfo";
			Text = "Remote LoginForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox txtRemoteUser;
		private TextBox txtRemotePass;
		private Button btnRemoteLogIn;
		private Button btnCancle;
		private Label lblRemoteInformation;
	}
}