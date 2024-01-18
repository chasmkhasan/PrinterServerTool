using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class PowerShellManagement
	{
		public async Task<List<PrinterDataModel>> ExecutePowerShellScriptAsync(string selectedServer, PSCredential credential, string fullScript)
		{
			List<PrinterDataModel> output = new List<PrinterDataModel>();

			await Task.Run(() =>
			{
				output = ExecutePowerShellScript(selectedServer, credential, fullScript);
			});

			return output;
		}

		private List<PrinterDataModel> ExecutePowerShellScript(string selectedServer, PSCredential credential, string fullScript)
		{
			List<PrinterDataModel> output = new List<PrinterDataModel>();

			try
			{
				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					PowerShellInstance.AddScript(fullScript);

					PowerShellInstance.AddParameter("credential", credential);

					Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

					if (PowerShellInstance.HadErrors)
					{
						foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
						{
							LogException(new Exception($"PowerShell Error: {error.Exception.Message}"));
						}
					}
					else
					{
						output = ProcessPSOutput(PSOutput);
					}
				}
			}
			catch (Exception ex)
			{
				LogException(new Exception($"C# Error: {ex.Message}"));
			}

			return output;
		}

		private List<PrinterDataModel> ProcessPSOutput(Collection<PSObject> psOutput)
		{
			List<PrinterDataModel> output = new List<PrinterDataModel>();

			foreach (PSObject obj in psOutput)
			{
				PrinterDataModel printerData = new PrinterDataModel
				{
					PrinterName = obj.Properties["Name"]?.Value?.ToString(),
					ShareName = obj.Properties["ShareName"]?.Value?.ToString(),
					DriverName = obj.Properties["DriverName"]?.Value?.ToString(),
					PortName = obj.Properties["PortName"]?.Value?.ToString(),
					Location = obj.Properties["Location"]?.Value?.ToString(),
					SystemName = obj.Properties["SystemName"]?.Value?.ToString(),
					DriverVersion = obj.Properties["DriverVersion"]?.Value?.ToString(),
					PrinterModel = obj.Properties["PrinterModel"]?.Value?.ToString(),
					PrinterStatus = obj.Properties["PrinterStatus"]?.Value?.ToString()
				};

				output.Add(printerData);
			}

			return output;
		}

		private void LogException(Exception ex)
		{
			MessageBox.Show($"An exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
