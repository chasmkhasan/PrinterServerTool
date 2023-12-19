using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		//PrinterMgt printerMgt = new PrinterMgt();
		PrinterMgtShared printerMgt = new PrinterMgtShared();

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
			FillTheCombobox();
		}

		//private void FillTheCombobox()
		//{
		//	cmbOptions.Items.Clear();

		//	cmbOptions.Items.Add("Please Select Server Name");
		//	cmbOptions.Items.Add("Printer Server 01");
		//	cmbOptions.Items.Add("Printer Server 02");
		//	cmbOptions.Items.Add("Printer Server 03");
		//	cmbOptions.Items.Add("Printer Server 04");
		//	cmbOptions.Items.Add("Printer Server 05");
		//	cmbOptions.Items.Add("Printer Server 06");

		//	cmbOptions.SelectedIndex = 0;
		//}

		private void FillTheCombobox()
		{
			// Specify the path to your text file
			string fileName = "ServerList.txt"; // Activated the txt file. Project RightButton/Add/Existing File. Rightbutton on the file/Properties/CopyToOutputDirectory/CopyAlwaysORCopyIfNewer

			try
			{
				// Get the current directory
				string currentDirectory = Directory.GetCurrentDirectory();

				// Combine the current directory with the filename
				string filePath = Path.Combine(currentDirectory, fileName);

				// Read server names from the text file
				string[] serverNames = File.ReadAllLines(filePath);

				cmbOptions.Items.Clear();
				cmbOptions.Items.AddRange(serverNames);

				if (cmbOptions.Items.Count > 0)
				{
					cmbOptions.SelectedIndex = 0;
				}
			}
			catch (IOException ex)
			{
				MessageBox.Show($"Error reading the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private bool ReadChoice()
		{
			bool success = false;
			int index = cmbOptions.SelectedIndex;

			if (index >= 0)
			{
				printerMgt.SetChoice(index);
				success = true;
			}
			return success;
		}

		private async void btnSearch_Click(object sender, EventArgs e)
		{
			// Display a message to indicate that the search is in progress
			//MessageBox.Show("Searching for shared printers. Please wait...");

			//Set the initial progress bar value
			prgBar.Value = 0;

			bool ok = await Task.Run(() => SearchForPrinters());

			//bool ok = ReadChoice();

			if (ok)
			{
				MessageBox.Show("Search Completed successfully.", "Search Result");
			}
			else
			{
				// Inform the user that no shared printers were found
				MessageBox.Show("No shared printers found.", "Search Results");
			}
		}

		private async Task<bool> SearchForPrinters()
		{
			bool result = false;

			List<string> sharedPrinters = await Task.Run(() => printerMgt.GetSharedPrintersAsync());

			// Update progress bar when the search is complete
			UpdateProgressBar(100);

			// Handle the results
			if (sharedPrinters.Count > 0)
			{
				// Show the shared printers to the user
				foreach (string printerName in sharedPrinters)
				{
					// Use Invoke to add items to the ListBox on the UI thread
					if (lstOfPrinterName.InvokeRequired)
					{
						lstOfPrinterName.Invoke(new Action(() => lstOfPrinterName.Items.Add($"Server: {printerName}")));
					}
					else
					{
						lstOfPrinterName.Items.Add($"Server: {printerName}");
					}
				}

				result = true;
			}

			return result;
		}

		private void UpdateProgressBar(int value)
		{
			// Ensure the value is within the valid range for the progress bar
			value = Math.Max(0, Math.Min(100, value));

			// Use Invoke to update the progress bar on the UI thread
			if (prgBar.InvokeRequired)
			{
				prgBar.Invoke(new Action(() => prgBar.Value = value));
			}
			else
			{
				prgBar.Value = value;
			}
		}

		private void btnInstallPrinter_Click(object sender, EventArgs e)
		{
			if (printerMgt != null)
			{
				MessageBox.Show("Under Process", "Error");
			}
		}
	}
}
