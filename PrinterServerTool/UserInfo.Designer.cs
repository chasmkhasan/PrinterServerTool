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
			BtnRemoteLogIn = new Button();
			BtnCancle = new Button();
			lblRemoteInformation = new Label();
			ShowPassWord = new CheckBox();
			SuspendLayout();
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label1.Location = new Point(29, 57);
			label1.Name = "label1";
			label1.Size = new Size(121, 19);
			label1.TabIndex = 1;
			label1.Text = "Remote Username";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			label2.Location = new Point(29, 95);
			label2.Name = "label2";
			label2.Size = new Size(120, 19);
			label2.TabIndex = 2;
			label2.Text = "Remote Password";
			// 
			// txtRemoteUser
			// 
			txtRemoteUser.Cursor = Cursors.IBeam;
			txtRemoteUser.Location = new Point(182, 57);
			txtRemoteUser.Name = "txtRemoteUser";
			txtRemoteUser.Size = new Size(188, 23);
			txtRemoteUser.TabIndex = 3;
			// 
			// txtRemotePass
			// 
			txtRemotePass.Cursor = Cursors.IBeam;
			txtRemotePass.Location = new Point(182, 91);
			txtRemotePass.Name = "txtRemotePass";
			txtRemotePass.PasswordChar = '*';
			txtRemotePass.Size = new Size(188, 23);
			txtRemotePass.TabIndex = 4;
			// 
			// BtnRemoteLogIn
			// 
			BtnRemoteLogIn.Cursor = Cursors.Hand;
			BtnRemoteLogIn.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			BtnRemoteLogIn.Location = new Point(100, 159);
			BtnRemoteLogIn.Name = "BtnRemoteLogIn";
			BtnRemoteLogIn.Size = new Size(121, 35);
			BtnRemoteLogIn.TabIndex = 5;
			BtnRemoteLogIn.Text = "Remote Login";
			BtnRemoteLogIn.UseVisualStyleBackColor = true;
			BtnRemoteLogIn.Click += BtnRemoteLogIn_Click;
			// 
			// BtnCancle
			// 
			BtnCancle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			BtnCancle.Location = new Point(295, 159);
			BtnCancle.Name = "BtnCancle";
			BtnCancle.Size = new Size(75, 35);
			BtnCancle.TabIndex = 6;
			BtnCancle.Text = "Cancle";
			BtnCancle.UseVisualStyleBackColor = true;
			BtnCancle.Click += BtnCancle_Click;
			// 
			// lblRemoteInformation
			// 
			lblRemoteInformation.BorderStyle = BorderStyle.Fixed3D;
			lblRemoteInformation.Location = new Point(29, 19);
			lblRemoteInformation.Name = "lblRemoteInformation";
			lblRemoteInformation.Size = new Size(373, 23);
			lblRemoteInformation.TabIndex = 7;
			lblRemoteInformation.TextAlign = ContentAlignment.MiddleCenter;
			// 
			// ShowPassWord
			// 
			ShowPassWord.AutoSize = true;
			ShowPassWord.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
			ShowPassWord.Location = new Point(182, 120);
			ShowPassWord.Name = "ShowPassWord";
			ShowPassWord.Size = new Size(127, 23);
			ShowPassWord.TabIndex = 8;
			ShowPassWord.Text = "Show Password";
			ShowPassWord.UseVisualStyleBackColor = true;
			ShowPassWord.CheckedChanged += ShowPassWord_CheckedChanged;
			// 
			// UserInfo
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(416, 203);
			Controls.Add(ShowPassWord);
			Controls.Add(lblRemoteInformation);
			Controls.Add(BtnCancle);
			Controls.Add(BtnRemoteLogIn);
			Controls.Add(txtRemotePass);
			Controls.Add(txtRemoteUser);
			Controls.Add(label2);
			Controls.Add(label1);
			Name = "UserInfo";
			StartPosition = FormStartPosition.CenterScreen;
			Text = "Remote LoginForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label label1;
		private Label label2;
		private TextBox txtRemoteUser;
		private TextBox txtRemotePass;
		private Button BtnRemoteLogIn;
		private Button BtnCancle;
		private Label lblRemoteInformation;
		private CheckBox ShowPassWord;
	}
}