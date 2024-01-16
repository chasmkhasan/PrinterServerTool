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
				sharedPrinters = await ExecutePowerShellScriptAsync(script, selectedServer, credential);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

			return sharedPrinters;
		}

		private async Task<List<string>> ExecutePowerShellScriptAsync(string script, string computerName, PSCredential credential)
		{
			List<string> output = new List<string>();

			await Task.Run(() =>
			{
				// Your existing synchronous PowerShell execution code
				output = ExecutePowerShellScript(script, computerName, credential);
			});

			return output;
		}


		// Update ExecutePowerShellScript to handle errors
		private List<string> ExecutePowerShellScript(string script, string computerName, PSCredential credential)
		{
			List<string> output = new List<string>();

			try
			{
				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					// Set PowerShell credentials
					PowerShellInstance.AddScript(script).AddParameter("ComputerName", computerName).AddParameter("Credential", credential);

					Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

					if (PowerShellInstance.HadErrors)
					{
						foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
						{
							output.Add($"PowerShell Error: {error.Exception.Message}");
						}
					}
					else
					{
						// Process the output
						foreach (PSObject obj in PSOutput)
						{
							output.Add(obj.ToString());
						}
					}
				}
			}
			catch (Exception ex)
			{
				output.Add($"C# Error: {ex.Message}");
			}

			return output;
		}

		private PSCredential GetCredentials(string selectedServer)
		{
			// Create an instance of UserInfo form
			UserInfo userInfoForm = new UserInfo();

			userInfoForm.SetRemoteInformation(selectedServer);

			// Show the form as a dialog to get user input
			if (userInfoForm.ShowDialog() == DialogResult.OK)
			{
				// Get username and password from the form
				string username = userInfoForm.GetRemoteUsername();
				SecureString password = userInfoForm.GetRemotePassword();

				// Create a PSCredential object
				PSCredential credential = new PSCredential(username, password);

				return credential;
			}

			return null; // Handle the case where the user cancels the input
		}
	}
}
