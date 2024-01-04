using System;
using System.Drawing.Printing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		PrinterManagement readPrinter = new PrinterManagement();

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

			lstOfPrinterName.Items.Clear();

			//// Start the spinning progress GIF
			gifBox.Image = Properties.Resources.Spinning_fangs; // "loading" is the name of your GIF resource
			gifBox.SizeMode = PictureBoxSizeMode.CenterImage;
			gifBox.Visible = true;

			//var watch = System.Diagnostics.Stopwatch.StartNew(); // Timing Start

			_ = Task.Run(async () =>
			{
				await SearchForPrintersAsync();
			});

			//watch.Stop(); // timing end
			//var elapsedMs = watch.ElapsedMilliseconds; // Calculating time Will delete on demand
			//lstOfPrinterName.Items.Add($"Total execution time: {elapsedMs}");
		}

		private async Task<bool> SearchForPrintersAsync()
		{
			bool result = false;

			try
			{
				List<PrinterDataModel> sharedPrinterData = await readPrinter.GetSharedPrintersAsync();

				PrinterDataModel printerDataModelInstance = new PrinterDataModel(); // Replace this with the actual instance

				List<string> sharedPrinters = sharedPrinterData.Select(printerDataModel =>
					//$"Server: {printerDataModel.ShareName}, Printer: {printerDataModel.PrinterName}, DriverName: {printerDataModel.DriverName}, PortName: {printerDataModel.PortName}, Location: {printerDataModel.Location}")
					$"Printer: {printerDataModel.PrinterName}, DriverName: {printerDataModel.DriverName}, PortName: {printerDataModel.PortName}")
						.ToList();

				foreach (string printerInfo in sharedPrinters)
				{
					if (lstOfPrinterName.InvokeRequired)
					{
						lstOfPrinterName.Invoke(new Action(() => lstOfPrinterName.Items.Add(printerInfo)));
					}
					else
					{
						lstOfPrinterName.Items.Add(printerInfo);
					}
				}


				if (gifBox.InvokeRequired)
				{
					gifBox.Invoke(new Action(() => gifBox.Visible = false));
				}
				else
				{
					gifBox.Visible = false;
				}

				MessageBox.Show("Search Completed successfully.", "Search Result");

				result = true;
			}

			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}", "Error");
			}

			return result;
		}


		private async void btnInstall_Click(object sender, EventArgs e)
		{
			
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
