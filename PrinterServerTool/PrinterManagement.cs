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

		public Task<List<string>> GetSharedPrinters()
		{
			List<string> sharedPrinters = new List<string>();

			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				try
				{
					PowerShellInstance.AddScript("Get-CimInstance -ClassName Win32_Printer | Where-Object { $_.Shared -eq $true } | Select-Object -ExpandProperty Name");

					Collection<PSObject> psDataCollection = PowerShellInstance.Invoke();

					if (PowerShellInstance.HadErrors)
					{
						foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
						{
							MessageBox.Show("PowerShell Error: " + error.Exception.Message);
						}
					}
					else
					{
						foreach (PSObject outputItem in psDataCollection)
						{
							string printerName = outputItem.ToString();
							sharedPrinters.Add(printerName);
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
				}
			}

			return Task.FromResult(sharedPrinters);
		}
	}
}
