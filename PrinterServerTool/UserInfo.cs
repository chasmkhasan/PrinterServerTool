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

namespace PrinterServerTool
{
	public partial class UserInfo : Form
	{

		private string enteredUsername;
		private SecureString enteredPassword;

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

		private void btnRemoteLogIn_Click(object sender, EventArgs e)
		{
			// Get username and password from the form
			enteredUsername = txtRemoteUser.Text;
			enteredPassword = GetSecurePasswordFromUser(txtRemotePass.Text);

			// Set the DialogResult to OK to indicate successful login
			DialogResult = DialogResult.OK;

			// Close the form
			Close();
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			// Set the DialogResult to Cancel to indicate user cancellation
			DialogResult = DialogResult.Cancel;

			// Close the form
			Close();
		}
	}
}
