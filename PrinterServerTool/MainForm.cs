using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		PrinterManagement readPrinter = new PrinterManagement();
		WaitFormFunc waitForm = new WaitFormFunc();

		public MainForm()
		{
			InitializeComponent();

			// Start the code.
			InitializeGUI();
		}
		private void InitializeGUI()
		{
			//change the title of the form.

			this.Text += " Owned by Caironite";
			DropDownList();
		}

		private void DropDownList()
		{
			string fileName = "ServerList.txt"; // Activated the txt file. Rightbutton on the file/Properties/CopyToOutputDirectory/CopyAlwaysORCopyIfNewer

			try
			{
				// Get the current directory
				string currentDirectory = Directory.GetCurrentDirectory();

				// Combine the current directory with the filename
				string filePath = Path.Combine(currentDirectory, fileName);

				// Read server names from the text file
				string[] serverNames = File.ReadAllLines(filePath);

				dropDownOptions.Items.Clear();
				dropDownOptions.Items.AddRange(serverNames);

				if (dropDownOptions.Items.Count > 0)
				{

					dropDownOptions.SelectedIndex = 0;
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			//Start ProgressBar
			//waitForm.Show();

			lstOfPrinterName.Items.Clear();

			//var watch = System.Diagnostics.Stopwatch.StartNew(); // Timing Start

			_ = Task.Run(async () =>
			{
				await SearchForPrintersAsync();
			});

			//watch.Stop(); // timing end
			//var elapsedMs = watch.ElapsedMilliseconds; // Calculating time Will delete on demand
			//lstOfPrinterName.Items.Add($"Total execution time: {elapsedMs}");

			waitForm.Close();

			//MessageBox.Show("Search Completed successfully.", "Search Result");
		}

		private async Task<bool> SearchForPrintersAsync()
		{
			bool result = false;

			List<string> sharedPrinters = await readPrinter.GetSharedPrintersAsync();

			// Handle the results
			if (sharedPrinters.Count > 0)
			{
				// Show the shared printers to the user
				foreach (string printerName in sharedPrinters)
				{
					// Use Invoke to add items to the ListBox on the UI thread
					if (lstOfPrinterName.InvokeRequired)
					{
						lstOfPrinterName.Invoke(new Action(() => lstOfPrinterName.Items.Add($"Printer: {printerName}")));
					}
					else
					{
						lstOfPrinterName.Items.Add($"Printer: {printerName}");
					}
				}

				result = true;
			}

			return result;
		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			if (readPrinter != null)
			{
				MessageBox.Show("Under Process", "Error");
			}
		}


		//private bool ReadChoice() // its needed for indexing when install.
		//{
		//	bool success = false;
		//	int index = dropDownOptions.SelectedIndex;

		//	if (index >= 0)
		//	{
		//		readPrinter.SetChoice(index);
		//		success = true;
		//	}
		//	return success;
		//}
	}
}
