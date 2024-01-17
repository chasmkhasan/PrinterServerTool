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
using Microsoft.Management.Infrastructure;
using Microsoft.VisualBasic.Devices;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using System.Net;
using System.Xml.Linq;
using Microsoft.VisualBasic.Logging;
using System.Runtime.InteropServices;

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
				PSCredential credential = GetCredentials(selectedServer);

				if (credential != null)
				{
					//string script = $@"Invoke-Command -ComputerName {selectedServer} -ScriptBlock {{
					//                              Get-CimInstance -ClassName Win32_Printer |
					//                              Where-Object {{ $_.Shared -eq $true }} |
					//                              Select-Object -ExpandProperty Name
					//                          }}";

					string script = "Get-CimInstance -ClassName Win32_Printer | Where-Object { $_.Shared -eq $true } | Select-Object -ExpandProperty Name";

					sharedPrinters = await ExecutePowerShellScriptAsync(selectedServer, credential, script);
				}
				else
				{
					// Handle the case where the user cancels credential input
					// or improve the user experience based on your application logic
					MessageBox.Show("Valid credentials are required to access shared printers. Please provide valid credentials and try again.", "Credentials Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (PipelineStoppedException ex)
			{
				// Handle specific exception if needed
				LogException(ex);
			}
			catch (RuntimeException ex)
			{
				// Handle specific exception if needed
				LogException(ex);
			}
			catch (Exception ex)
			{
				// Catch unexpected exceptions
				LogException(ex);
			}

			return sharedPrinters;
		}

		private void LogException(Exception ex)
		{
			EventLog.WriteEntry("YourApplication", $"An exception occurred: {ex.Message}", EventLogEntryType.Error);
		}

		//private async Task<List<string>> ExecutePowerShellScriptAsync(string script, string selectedServer, PSCredential credential)
		private async Task<List<string>> ExecutePowerShellScriptAsync(string selectedServer, PSCredential credential, string script)
		{
			List<string> output = new List<string>();

			await Task.Run(() =>
			{
				// Your existing synchronous PowerShell execution code
				output = ExecutePowerShellScript(selectedServer, credential, script);
			});

			return output;
		}


		private List<string> ExecutePowerShellScript(string selectedServer, PSCredential credential, string script)
		{
			List<string> output = new List<string>();

			try
			{
				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					////Set PowerShell credentials
					//PowerShellInstance.AddScript(script).AddParameter("SelectedServer", selectedServer).AddParameter("Credential", credential);
					////PowerShellInstance.AddParameter("SelectedServer", selectedServer)
					////					.AddParameter("Credential", credential)
					////					.AddScript(script);

					////Alternatively, you can use the AddCommand method to set the script and parameters separately:
					//PowerShellInstance.AddCommand("Invoke-Command")
					//				.AddParameter("ComputerName", selectedServer)
					//				.AddParameter("Credential", credential)
					//				.AddScript(script);

					// Combine the entire script into one string
					//string fullScript = $@"Invoke-Command -ComputerName {selectedServer} -Credential {credential} -ScriptBlock {{{script}}}";

					//string fullScript = $@"Invoke-Command -ComputerName {selectedServer} -Credential $credential -Authentication Default -ScriptBlock {{{script}}}";

					//string credentialString = $"\"{credential.UserName}\", (ConvertTo-SecureString \"{credential.Password}\" -AsPlainText -Force)";
					//string fullScript = $"Invoke-Command -ComputerName {selectedServer} -Credential (New-Object System.Management.Automation.PSCredential({credentialString})) -Authentication Default -ScriptBlock {{{script}}}";

					// Extract username from PSCredential
					string username = credential.UserName;

					// Extract password from PSCredential
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

					// Construct the credential string
					string credentialString = $"New-Object System.Management.Automation.PSCredential('{username}', (ConvertTo-SecureString '{plainTextPassword}' -AsPlainText -Force))";

					// Construct the full Invoke-Command script
					string fullScript = $"Invoke-Command -ComputerName {selectedServer} -Credential ({credentialString}) -Authentication Default -ScriptBlock {{{script}}}";


					PowerShellInstance.AddScript(fullScript);

					// Add the credential as a variable
					PowerShellInstance.AddParameter("credential", credential);

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
				PSCredential resultCredential = new PSCredential(username, password);

				return resultCredential;
			}

			return null; // Handle the case where the user cancels the input
		}
	}
}
