using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Security;

namespace PrinterServerTool
{
	internal class PrinterManagement
	{
		private int choice;

		public int GetChoice()
		{
			return choice;
		}
		public void SetChoice(int newChoice)
		{
			choice = newChoice;
		}

		public async Task<List<string>> GetSharedPrintersAsync(string selectedServer)
		{
			List<string> sharedPrinters = new List<string>();

			try
			{
				// Prompt the user for credentials
				PSCredential credential = GetCredentials(selectedServer);

				// PowerShell script to get shared printers
				string script = "Get-CimInstance -ClassName Win32_Printer | Where-Object { $_.Shared -eq $true } | Select-Object -ExpandProperty Name";

				// Execute the PowerShell script asynchronously
				sharedPrinters = ExecutePowerShellScript(script, selectedServer, credential);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

			return sharedPrinters;
		}

		private PSCredential GetCredentials(string selectedServer)
		{
			// Prompt the user for username and password
			string username = "hasan"; // Provide a default username if needed
			SecureString password = GetSecurePasswordFromUser(selectedServer);

			// Create a PSCredential object
			PSCredential credential = new PSCredential(username, password);

			return credential;
		}

		private SecureString GetSecurePasswordFromUser(string selectedServer)
		{
			SecureString securePassword = new SecureString();

			// PowerShell script to read password using Read-Host on the remote server
			string script = "$password = Read-Host 'Enter password' -AsSecureString; $password | ConvertFrom-SecureString";

			// Execute PowerShell script on the remote server
			List<string> result = ExecutePowerShellScript(script, selectedServer);

			if (result.Count > 0)
			{
				// Convert the encrypted password back to SecureString
				string encryptedPassword = result[0];
				securePassword = ConvertToSecureString(encryptedPassword);
			}

			return securePassword;
		}

		public List<string> ExecutePowerShellScript(string script, string selectedServer, PSCredential credential)
		{
			List<string> results = new List<string>();

			using (Runspace runspace = RunspaceFactory.CreateRunspace())
			{
				runspace.Open();

				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					PowerShellInstance.Runspace = runspace;

					try
					{
						PowerShellInstance.AddScript(script);

						// Use the provided credential
						PowerShellInstance.AddParameter("Credential", credential);

						Collection<PSObject> psDataCollection = PowerShellInstance.Invoke();

						foreach (PSObject outputItem in psDataCollection)
						{
							results.Add(outputItem.ToString());
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("PowerShell Error: " + ex.Message);
					}
				}

				runspace.Close();
			}

			return results;
		}

		public List<string> ExecutePowerShellScript(string script, string selectedServer)
		{
			List<string> results = new List<string>();

			using (Runspace runspace = RunspaceFactory.CreateRunspace())
			{
				runspace.Open();

				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					PowerShellInstance.Runspace = runspace;

					try
					{
						PowerShellInstance.AddScript(script);
						Collection<PSObject> psDataCollection = PowerShellInstance.Invoke();

						foreach (PSObject outputItem in psDataCollection)
						{
							results.Add(outputItem.ToString());
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("PowerShell Error: " + ex.Message);
					}
				}

				runspace.Close();
			}

			return results;
		}

		private SecureString ConvertToSecureString(string encryptedPassword)
		{
			SecureString secureString = new SecureString();

			// Convert the Base64 encoded string to a byte array
			byte[] encryptedData = Convert.FromBase64String(encryptedPassword);

			// Decrypt the byte array to get the original secure string
			foreach (byte b in encryptedData)
			{
				secureString.AppendChar((char)b);
			}

			return secureString;
		}


	}
}
