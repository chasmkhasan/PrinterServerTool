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

		public async Task<List<string>> GetSharedPrintersAsync()
		{
			List<string> sharedPrinters = new List<string>();

			try
			{
				string script = "Get-CimInstance -ClassName Win32_Printer | Where-Object { $_.Shared -eq $true } | Select-Object -ExpandProperty Name";

				var tasks = new List<Task<List<string>>>();

				for (int i = 0; i < Environment.ProcessorCount; i++)
				{
					tasks.Add(new Task<List<string>>(() => ExecutePowerShellScript(script)));
				}

				foreach (var task in tasks)
				{
					task.Start();
				}

				await Task.WhenAll(tasks).ConfigureAwait(false);

				// Combine and deduplicate results from all tasks into a single list
				var uniqueResults = tasks.SelectMany(task => task.Result).Distinct();

				// Add the unique results to the sharedPrinters list
				sharedPrinters.AddRange(uniqueResults);
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

			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
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

			return results;
		}
	}
}
