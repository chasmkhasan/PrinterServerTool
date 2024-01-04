using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
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

		public async Task<List<PrinterDataModel>> GetSharedPrintersAsync()
		{
			List<PrinterDataModel> sharedPrinters = new List<PrinterDataModel>();

			try
			{
				string script = @"Get-CimInstance -ClassName Win32_Printer |
								Where-Object { $_.Shared -eq $true } |
								Select-Object Name, ShareName, DriverName, PortName, Location";

				sharedPrinters = ExecutePowerShellScript(script)
					.Select(printerData => new PrinterDataModel
					{
						PrinterName = printerData["Name"] as string,
						ShareName = printerData["ShareName"] as string,
						DriverName = printerData["DriverName"] as string,
						PortName = printerData["PortName"] as string,
						Location = printerData["Location"] as string
					})
					.ToList();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}

			return sharedPrinters;
		}

		private List<Dictionary<string, object>> ExecutePowerShellScript(string script)
		{
			List<Dictionary<string, object>> results = new List<Dictionary<string, object>>();

			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				try
				{
					PowerShellInstance.AddScript(script);
					Collection<PSObject> psDataCollection = PowerShellInstance.Invoke();

					foreach (PSObject outputItem in psDataCollection)
					{
						Dictionary<string, object> properties = outputItem.Properties
							.ToDictionary(p => p.Name, p => p.Value);

						results.Add(properties);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("PowerShell Error: " + ex.Message);
				}
			}

			return results;
		}
	}
}
