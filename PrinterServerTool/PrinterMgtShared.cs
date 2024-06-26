﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management.Automation;
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

		//public async Task<List<string>> ShowPrinterMgtAsync()
		//{
		//	List<string> printerList = new List<string>();

		//	switch (choice)
		//	{
		//		case 0:
		//			printerList = await GetSharedPrintersByServerAsync(choice);
		//			break;
		//		case 1:
		//			printerList = await GetSharedPrintersByServerAsync(choice);
		//			break;
		//		case 2:
		//			printerList = await GetSharedPrintersByServerAsync(choice);
		//			break;
		//		case 3:
		//			printerList = await GetSharedPrintersByServerAsync(choice);
		//			break;
		//		case 4:
		//			printerList = await GetSharedPrintersByServerAsync(choice);
		//			break;
		//		default:
		//			MessageBox.Show("Invalid Choice!", "Error");
		//			break;
		//	}
		//	return printerList;
		//}

		//public List<string> GetSharedPrintersByServer()
		//{
		//	List<string> sharedPrinters = GetSharedPrinters();

		//	if (sharedPrinters.Count <= 0)
		//	{
		//		MessageBox.Show("No shared printers found!");
		//		return sharedPrinters;
		//	}

		//	List<string> serverPrinters = new List<string>();

		//	foreach (string printer in sharedPrinters)
		//	{
		//		// Modify the serverPrinters list or perform other actions as needed
		//		serverPrinters.Add($"Server: {printer}");
		//	}

		//	return serverPrinters;
		//}

		//static List<string> GetSharedPrinters()
		//{
		//	List<string> sharedPrinters = new List<string>();

		//	using (Process PowerShellProcess = new Process())
		//	{
		//		try
		//		{
		//			PowerShellProcess.StartInfo.FileName = "powershell.exe";
		//			PowerShellProcess.StartInfo.RedirectStandardOutput = true;
		//			PowerShellProcess.StartInfo.UseShellExecute = false;
		//			PowerShellProcess.StartInfo.CreateNoWindow = true;
		//			PowerShellProcess.StartInfo.Arguments = "Get-WmiObject -Query 'SELECT * FROM Win32_Printer WHERE Shared=True' | ForEach-Object { $_.Name }";

		//			PowerShellProcess.Start();

		//			while (!PowerShellProcess.StandardOutput.EndOfStream)
		//			{
		//				string line = PowerShellProcess.StandardOutput.ReadLine();
		//				if (!string.IsNullOrEmpty(line))
		//				{
		//					sharedPrinters.Add(line);
		//				}
		//			}

		//			PowerShellProcess.WaitForExit();
		//		}
		//		catch (Exception ex)
		//		{
		//			Console.WriteLine("Error: " + ex.Message);
		//			// Handle the exception appropriately
		//		}
		//	}
		//	return sharedPrinters;
		//}

		//static List<string> GetSharedPrinters()
		//{
		//	List<string> sharedPrinters = new List<string>();

		//	using (PowerShell PowerShellInstance = PowerShell.Create())
		//	{
		//		try
		//		{
		//			// Use AddScript to add the PowerShell command
		//			//PowerShellInstance.AddScript("Get-WmiObject -Query 'SELECT * FROM Win32_Printer WHERE Shared=True' | Select-Object -ExpandProperty Name");
		//			//PowerShellInstance.AddScript("Get-WmiObject -PrinterServerTool 'root\\cimv2' -Query 'SELECT * FROM Win32_Printer WHERE Shared=True' | Select-Object -ExpandProperty Name"); // Get-WMIObject is for powshell 3.1.0.0 version or later
		//			PowerShellInstance.AddScript("Get-CimInstance -ClassName Win32_Printer | Where-Object { $_.Shared -eq $true } | Select-Object -ExpandProperty Name"); // Get-CimInstance is for powershell 7.1.0.0 or later version.


		//			// Invoke execution on PowerShell
		//			Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

		//			// Check for errors
		//			if (PowerShellInstance.HadErrors)
		//			{
		//				foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
		//				{
		//					MessageBox.Show("PowerShell Error: " + error.Exception.Message);
		//				}
		//			}
		//			else
		//			{
		//				// Extract results from the PSObject collection
		//				foreach (PSObject outputItem in PSOutput)
		//				{
		//					// Assuming the output is a string, change this according to your actual output type
		//					string printerName = outputItem.ToString();
		//					sharedPrinters.Add(printerName);
		//				}
		//			}
		//		}
		//		catch (Exception ex)
		//		{
		//			MessageBox.Show("Error: " + ex.Message);
		//			// Handle the exception appropriately
		//		}
		//	}

		//	return sharedPrinters;
		//}

		public async Task<List<string>> GetSharedPrintersAsync()
		{
			List<string> sharedPrinters = new List<string>();

			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				try
				{
					PowerShellInstance.AddScript("Get-CimInstance -ClassName Win32_Printer | Where-Object { $_.Shared -eq $true } | Select-Object -ExpandProperty Name");

					// Explicitly cast the result of InvokeAsync to Collection<PSObject>

					//Collection<PSObject> PSOutput = await PowerShellInstance.InvokeAsync(); // Cannot implicitly convert issue - 
					//Cannot implicitly convert type 'system.Management.Automation.PSDataCollection<System.Management.Automation.PSObject>' to 'System.Collections.ObjectModel.Collection<System.Management.Automation.PsObject>'

					PSDataCollection<PSObject> psDataCollection = await PowerShellInstance.InvokeAsync(); //convert issue solve: reaching the data collection and through psObject.
					Collection<PSObject> PSOutput = new Collection<PSObject>(psDataCollection);


					if (PowerShellInstance.HadErrors)
					{
						foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
						{
							MessageBox.Show("PowerShell Error: " + error.Exception.Message);
						}
					}
					else
					{
						foreach (PSObject outputItem in PSOutput)
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

			return sharedPrinters;
		}
	}
}
