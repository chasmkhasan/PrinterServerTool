using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

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
				string script = $"Invoke-Command -ComputerName {selectedServer} -Credential $YourCredentials -ScriptBlock {{Get-CimInstance -ClassName Win32_Printer | Where-Object {{ $_.Shared -eq $true }} | Select-Object -ExpandProperty Name}}";

				// Execute the PowerShell script asynchronously
				sharedPrinters = ExecutePowerShellScript(script);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

			return sharedPrinters;
		}

		private List<string> ExecutePowerShellScript(string script)
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

	}
}
