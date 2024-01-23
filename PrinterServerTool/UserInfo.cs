using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PrinterServerTool
{
	public partial class UserInfo : Form
	{

		private string enteredUsername;
		private SecureString enteredPassword;

		public UserInfo()
		{
			InitializeComponent();

			if (Properties.Settings.Default.Username != string.Empty)
			{
				txtRemoteUser.Text = Properties.Settings.Default.Username;
				txtRemotePass.Text = Properties.Settings.Default.Password;
				ChkRemember.Checked = true;
			}
		}

		public string GetRemoteUsername()
		{
			//return txtRemoteUser.Text;
			return enteredUsername;
		}

		public SecureString GetRemotePassword()
		{
			//return GetSecurePasswordFromUser(txtRemotePass.Text);
			return enteredPassword;
		}

		public void SetRemoteInformation(string text)
		{
			lblRemoteInformation.Text = text;
		}

		private SecureString GetSecurePasswordFromUser(string password)
		{
			SecureString securePassword = new SecureString();
			foreach (char c in password)
			{
				securePassword.AppendChar(c);
			}
			securePassword.MakeReadOnly();
			return securePassword;
		}

		private void ShowPassWord_CheckedChanged(object sender, EventArgs e)
		{
			if (ShowPassWord.Checked == true)
			{
				txtRemotePass.PasswordChar = '\0'; // '\0' represents no masking
			}
			else
			{
				txtRemotePass.PasswordChar = '*';
			}
		}

		private void ChkRemember_CheckedChanged(object sender, EventArgs e)
		{
			if (ChkRemember.Checked)
			{
				enteredUsername = txtRemoteUser.Text;
				enteredPassword = GetSecurePasswordFromUser(txtRemotePass.Text);
			}
			else
			{
				enteredUsername = string.Empty;
				enteredPassword = null; // Clear the SecureString
			}

			Properties.Settings.Default.Username = enteredUsername;
			Properties.Settings.Default.Password = ConvertSecureStringToString(enteredPassword);

			Properties.Settings.Default.Save();
		}

		private void BtnCancle_Click(object sender, EventArgs e)
		{
			// Set the DialogResult to Cancel to indicate user cancellation
			DialogResult = DialogResult.Cancel;

			//// Close the form
			//Close();

			//// Hide the form instead of closing it
			//this.Hide();

			// Close the form and exit the application
			Application.Exit();
		}

		private void BtnRemoteLogIn_Click(object sender, EventArgs e)
		{
			enteredUsername = txtRemoteUser.Text;
			enteredPassword = GetSecurePasswordFromUser(txtRemotePass.Text);

			DialogResult = DialogResult.OK;

			Close();
		}

		private string ConvertSecureStringToString(SecureString secureString)
		{
			IntPtr ptr = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(secureString);
			try
			{
				return System.Runtime.InteropServices.Marshal.PtrToStringBSTR(ptr);
			}
			finally
			{
				System.Runtime.InteropServices.Marshal.ZeroFreeBSTR(ptr);
			}
		}
	}
}
