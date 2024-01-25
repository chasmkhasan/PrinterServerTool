using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class InstallManagement
	{

		public void InstallPrinter(string selectedPrinterName, PSCredential credential, DataModel dataModel)
		{
			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				PowerShellInstance.AddScript("Import-Module PrintManagement");

				string addPrinterCommand = $"Add-Printer " +
						   $"-Name '{dataModel.PrinterName}' " +
						   $"-ShareName '{dataModel.ShareName}' " +
						   $"-PortName '{dataModel.PortName}' " +
						   $"-DriverName '{dataModel.DriverName}' " +
						   $"-Location '{dataModel.Location}' " +
						   $"-SystemName '{dataModel.SystemName}' " +
						   $"-DriverVersion '{dataModel.DriverVersion}' " +
						   $"-PrinterModel '{dataModel.PrinterModel}' " +
						   $"-PrinterStatus '{dataModel.PrinterStatus}'";

				PowerShellInstance.AddScript(addPrinterCommand);

				PowerShellInstance.AddParameter("credential", credential);

				Collection<PSObject> result = PowerShellInstance.Invoke();

				if (PowerShellInstance.HadErrors)
				{
					string errorMessage = string.Join("\n", PowerShellInstance.Streams.Error.Select(error => error.ToString()));
					MessageBox.Show($"Error installing printer: {errorMessage}", "Error");
				}
				else
				{
					MessageBox.Show($"Printer '{selectedPrinterName}' installed successfully.", "Installation Result");
				}
			}
		}
	}
}
