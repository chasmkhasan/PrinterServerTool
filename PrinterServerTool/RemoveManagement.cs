using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class RemoveManagement
	{
		public void RemovePrinter(string selectedPrinterName, PSCredential credential)
		{
			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				PowerShellInstance.AddScript("Import-Module PrintManagement");

				string removePrinterCommand = $"Remove-Printer -Name '{selectedPrinterName}'";

				PowerShellInstance.AddScript(removePrinterCommand);

				PowerShellInstance.AddParameter("credential", credential);

				Collection<PSObject> result = PowerShellInstance.Invoke();

				if (PowerShellInstance.HadErrors)
				{
					string errorMessage = string.Join("\n", PowerShellInstance.Streams.Error.Select(error => error.ToString()));
					MessageBox.Show($"Error removing printer: {errorMessage}", "Error");
				}
				else
				{
					MessageBox.Show($"Printer '{selectedPrinterName}' removed successfully.", "Removal Result");
				}
			}
		}
	}
}
