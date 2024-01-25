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
			// Check if the driver is installed; if not, install it
			InstallPrinterDriver(dataModel.DriverName);

			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				// Explicitly load the necessary modules
				PowerShellInstance.AddScript("Import-Module PrintManagement -Force");

				// Use the fully qualified path to Add-Printer cmdlet
				string addPrinterCommand = $"Add-Printer " +
						   $"-Name '{dataModel.PrinterName}' " +
						   $"-ShareName '{dataModel.ShareName}' " +
						   $"-PortName '{dataModel.PortName}' " +
						   $"-DriverName '{dataModel.DriverName}' ";

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


		public void InstallPrinterDriver(string driverName)
		{
			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				// Explicitly load the necessary modules
				PowerShellInstance.AddScript("Import-Module PrintManagement -Force");

				// Use the fully qualified path to Add-PrinterDriver cmdlet
				string addPrinterDriverCommand = $"Add-PrinterDriver -Name '{driverName}'";

				PowerShellInstance.AddScript(addPrinterDriverCommand);

				Collection<PSObject> result = PowerShellInstance.Invoke();

				if (PowerShellInstance.HadErrors)
				{
					string errorMessage = string.Join("\n", PowerShellInstance.Streams.Error.Select(error => error.ToString()));
					MessageBox.Show($"Error installing printer driver: {errorMessage}", "Error");
				}
				else
				{
					MessageBox.Show($"Printer driver '{driverName}' installed successfully.", "Installation Result");
				}
			}
		}
	}
}
