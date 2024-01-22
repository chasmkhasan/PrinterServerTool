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
		public void InstallPrinter(string selectedPrinterName, PSCredential credential)
		{
			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				PowerShellInstance.AddScript("Import-Module PrintManagement");

				DataModel printerData = new DataModel
				{
					PrinterName = selectedPrinterName,
					ShareName = selectedPrinterName,
					PortName = selectedPrinterName,
					DriverName = selectedPrinterName,
					Location = selectedPrinterName,
					SystemName = selectedPrinterName,
					DriverVersion = selectedPrinterName,
					PrinterModel = selectedPrinterName,
					PrinterStatus = selectedPrinterName
				};

				string addPrinterCommand = $"Add-Printer " +
						   $"-Name '{printerData.PrinterName}' " +
						   $"-ShareName '{printerData.ShareName}' " +
						   $"-PortName '{printerData.PortName}' " +
						   $"-DriverName '{printerData.DriverName}' " +
						   $"-Location '{printerData.Location}' " +
						   $"-SystemName '{printerData.SystemName}' " +
						   $"-DriverVersion '{printerData.DriverVersion}' " +
						   $"-PrinterModel '{printerData.PrinterModel}' " +
						   $"-PrinterStatus '{printerData.PrinterStatus}'";

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
