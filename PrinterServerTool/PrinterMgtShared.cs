using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class PrinterMgtShared
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

		public async Task<List<string>> ShowPrinterMgtAsync()
		{
			List<string> printerList = new List<string>();

			switch (choice)
			{
				case 0:
					printerList = await GetSharedPrintersByServerAsync(choice);
					break;
				case 1:
					printerList = await GetSharedPrintersByServerAsync(choice);
					break;
				case 2:
					printerList = await GetSharedPrintersByServerAsync(choice);
					break;
				case 3:
					printerList = await GetSharedPrintersByServerAsync(choice);
					break;
				case 4:
					printerList = await GetSharedPrintersByServerAsync(choice);
					break;
				default:
					MessageBox.Show("Invalid Choice!", "Error");
					break;
			}
			return printerList;
		}

		private async Task<List<string>> GetSharedPrintersByServerAsync(int serverNumber)
		{
			List<string> sharedPrinters = await GetSharedPrinters();

			if (sharedPrinters.Count <= 0)
			{
				MessageBox.Show("No shared printers found!");
				return sharedPrinters;
			}

			List<string> serverPrinters = new List<string>();

			foreach (string printer in sharedPrinters)
			{
				// Modify the serverPrinters list or perform other actions as needed
				serverPrinters.Add($"Server {serverNumber}: {printer}");
			}

			return serverPrinters;
		}

		static async Task<List<string>> GetSharedPrinters()
		{
			List<string> sharedPrinters = new List<string>();

			using (Process PowerShellProcess = new Process())
			{
				try
				{
					PowerShellProcess.StartInfo.FileName = "powershell.exe";
					PowerShellProcess.StartInfo.RedirectStandardOutput = true;
					PowerShellProcess.StartInfo.UseShellExecute = false;
					PowerShellProcess.StartInfo.CreateNoWindow = true;
					PowerShellProcess.StartInfo.Arguments = "Get-WmiObject -Query 'SELECT * FROM Win32_Printer WHERE Shared=True' | ForEach-Object { $_.Name }";

					PowerShellProcess.Start();

					while (!PowerShellProcess.StandardOutput.EndOfStream)
					{
						string line = await PowerShellProcess.StandardOutput.ReadLineAsync();
						if (!string.IsNullOrEmpty(line))
						{
							sharedPrinters.Add(line);
						}
					}

					await PowerShellProcess.WaitForExitAsync();
				}
				catch (Exception ex)
				{
					Console.WriteLine("Error: " + ex.Message);
					// Handle the exception appropriately
				}
			}
			return sharedPrinters;
		}
	}
}
