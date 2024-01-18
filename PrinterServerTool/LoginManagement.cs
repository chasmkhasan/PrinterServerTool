using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class LoginManagement
	{
		public PSCredential GetCredentials(string selectedServer)
		{
			UserInfo userInfoForm = new UserInfo();

			userInfoForm.SetRemoteInformation(selectedServer);

			if (userInfoForm.ShowDialog() == DialogResult.OK)
			{
				string username = userInfoForm.GetRemoteUsername();
				SecureString password = userInfoForm.GetRemotePassword();

				PSCredential resultCredential = new PSCredential(username, password);

				return resultCredential;
			}

			return null;
		}

		public string GetCredentialString(PSCredential credential)
		{
			if (credential != null)
			{
				string username = credential.UserName;

				IntPtr passwordPtr = IntPtr.Zero;
				string plainTextPassword = null;

				try
				{
					passwordPtr = Marshal.SecureStringToGlobalAllocUnicode(credential.Password);
					plainTextPassword = Marshal.PtrToStringUni(passwordPtr);
				}
				finally
				{
					Marshal.ZeroFreeGlobalAllocUnicode(passwordPtr);
				}

				return $"New-Object System.Management.Automation.PSCredential('{username}', (ConvertTo-SecureString '{plainTextPassword}' -AsPlainText -Force))";
			}

			return null;
		}
	}
}
