using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharedPrinterAsyncUI
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			// Start the code.
			InitializeGUI();
		}

		private void InitializeGUI()
		{
			//change the title of the form.
			this.Text += " ";

			_ = GetAndDisplaySharedPrinters(); // Since its async method. Dont need to use await instead of _.
		}

		private async Task GetAndDisplaySharedPrinters()
		{
			List<string> listOfSharedPrinters = await GetSharedPrinters();

			// Check if ListBox exists
			if (lstOfSharedPrinter != null && listOfSharedPrinters != null)
			{
				// Use Invoke to update UI controls from a different thread
				lstOfSharedPrinter.Invoke(new Action(() =>
				{
					lstOfSharedPrinter.Items.Clear();

					foreach (string sharedPrinterName in listOfSharedPrinters)
					{
						lstOfSharedPrinter.Items.Add(sharedPrinterName);
					}
				}));
			}
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

					// Await the exit of the process
					await PowerShellProcess.WaitForExitAsync();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error: " + ex.Message);
					// Handle the exception appropriately
				}
			}
			return sharedPrinters;
		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			MessageBox.Show("Under Construction", "Error");
		}
	}
}
