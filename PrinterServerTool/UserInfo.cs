using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
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
		private string selectedServer;
		private PSCredential autoLoginCredential;

		private List<LoginStore.CredentialsEntry> storedCredentials = new List<LoginStore.CredentialsEntry>();

		public UserInfo()
		{
			InitializeComponent();
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
			selectedServer = text;
		}

		private void BtnRemoteLogIn_Click(object sender, EventArgs e)
		{
			LoginStore loginStore = new LoginStore();

			enteredUsername = txtRemoteUser.Text;
			enteredPassword = GetSecurePasswordFromUser(txtRemotePass.Text);

			// Store the entered credentials in the list
			loginStore.AddCredentials(new LoginStore.CredentialsEntry
			{
				Username = enteredUsername,
				Password = ConvertSecureStringToString(enteredPassword),
				Server = selectedServer
			});

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

		public SecureString GetSecurePasswordFromUser(string password)
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

		private void BtnCancle_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;

			Application.Exit();
		}
	}
}
