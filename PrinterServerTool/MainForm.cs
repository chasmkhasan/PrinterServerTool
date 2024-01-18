using System.Collections.ObjectModel;
using System.Management.Automation;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		PrinterManagement readPrinter = new PrinterManagement();

		private UserInfo userInfoForm;

		public MainForm()
		{
			InitializeComponent();

			// Start the code.
			InitializeGUI();
			userInfoForm = new UserInfo();
		}
		private void InitializeGUI()
		{
			this.Text += " Owned by Caironite";
			ReadServerList();
		}

		private void ReadServerList()
		{
			string fileName = "ServerList.txt";

			try
			{
				string currentDirectory = Directory.GetCurrentDirectory();

				string filePath = Path.Combine(currentDirectory, fileName);

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

		private void btnSearch_Click(object sender, EventArgs e)
		{

			lstOfPrinterName.Items.Clear();

			gifBox.Image = Properties.Resources.Spinning_fangs;
			gifBox.SizeMode = PictureBoxSizeMode.CenterImage;
			gifBox.Visible = true;

			_ = Task.Run(async () =>
			{
				await ReadPrintersAsync();
			});

		}

		private async Task<bool> ReadPrintersAsync()
		{
			bool result = false;

			try
			{
				string selectedServer = GetSelectedServer();

				List<PrinterDataModel> sharedPrinters = await readPrinter.GetPrintersAsync(selectedServer);

				if (sharedPrinters.Count > 0)
				{
					UpdateUIWithPrintersInfo(sharedPrinters);

					HideGifBox();

					MessageBox.Show("Search Completed successfully.", "Search Result");

					result = true;
				}
				else
				{
					HideGifBox();

					MessageBox.Show("No Remote Shared Printer found.", "Search Result");
				}
			}
			catch (Exception ex)
			{
				ShowErrorMessageBox(ex.Message);
			}

			return result;
		}

		private string GetSelectedServer()
		{
			string selectedServer = null;

			if (dropDownOptions.InvokeRequired)
			{
				dropDownOptions.Invoke(new Action(() =>
				{
					selectedServer = dropDownOptions.SelectedItem?.ToString();
				}));
			}
			else
			{
				selectedServer = dropDownOptions.SelectedItem?.ToString();
			}

			return selectedServer;
		}

		private void UpdateUIWithPrintersInfo(List<PrinterDataModel> printers)
		{
			foreach (PrinterDataModel printer in printers)
			{
				if (lstOfPrinterName.InvokeRequired)
				{
					lstOfPrinterName.Invoke(new Action(() =>
					{
						lstOfPrinterName.Items.Add($"Printer: {printer.PrinterName}, " +
												   $"Share: {printer.ShareName}, " +
												   $"Driver: {printer.DriverName}, " +
												   $"Port: {printer.PortName}, " +
												   $"Location: {printer.Location}, " +
												   $"SystemName: {printer.SystemName}, " +
												   $"DriverVersion: {printer.DriverVersion}, " +
												   $"PrinterModel: {printer.PrinterModel},  " +
												   $"PrinterStatus: {printer.PrinterStatus}");
					}));
				}
				else
				{
					lstOfPrinterName.Items.Add($"Printer: {printer.PrinterName}, " +
											   $"Share: {printer.ShareName}, " +
											   $"Driver: {printer.DriverName}, " +
											   $"Port: {printer.PortName}, " +
											   $"Location: {printer.Location}, " +
											   $"PrinterStatus: {printer.PrinterStatus}, " +
											   $"SystemName: {printer.SystemName}, " +
											   $"DriverVersion: {printer.DriverVersion}, " +
											   $"PrinterModel: {printer.PrinterModel}");
				}
			}
		}

		private void HideGifBox()
		{
			if (gifBox.InvokeRequired)
			{
				gifBox.Invoke(new Action(() => gifBox.Visible = false));
			}
			else
			{
				gifBox.Visible = false;
			}
		}

		private void ShowErrorMessageBox(string errorMessage)
		{
			MessageBox.Show($"An error occurred: {errorMessage}", "Error");
		}



		private void btnInstallPrinter_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstOfPrinterName.SelectedItem != null)
				{
					string selectedPrinterInfo = lstOfPrinterName.SelectedItem.ToString();

					if (selectedPrinterInfo != null)
					{

						string selectedPrinterName = selectedPrinterInfo.Replace("Printer: ", "");

						if (selectedPrinterName != null)
						{

							using (PowerShell PowerShellInstance = PowerShell.Create())
							{


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
						else
						{
							MessageBox.Show("Error: selectedPrinterName is null.", "Error");
						}
					}
					else
					{
						MessageBox.Show("Error: selectedPrinterInfo is null.", "Error");
					}
				}
				else
				{
					MessageBox.Show("Please select a printer to install.", "Error");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred during installation: {ex.Message}", "Error");
			}
		}

		private void btnPrinterRemove_Click(object sender, EventArgs e)
		{
			try
			{
				if (lstOfPrinterName.SelectedItem != null)
				{
					string selectedPrinterInfo = lstOfPrinterName.SelectedItem.ToString();

					if (selectedPrinterInfo != null)
					{
						// Extract the printer name from the selected information
						string selectedPrinterName = selectedPrinterInfo.Replace("Printer: ", "");

						if (selectedPrinterName != null)
						{
							// Use PowerShell to remove the selected printer
							using (PowerShell PowerShellInstance = PowerShell.Create())
							{
								// PowerShell script to remove the printer
								string removePrinterScript = $"Remove-Printer -Name '{selectedPrinterName}'";

								// Add the script to PowerShell
								PowerShellInstance.AddScript(removePrinterScript);

								// Invoke execution on PowerShell
								Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

								// Check for errors after PowerShell execution
								if (PowerShellInstance.HadErrors)
								{
									// Handle errors
									string errorMessage = string.Join("\n", PowerShellInstance.Streams.Error.Select(error => error.ToString()));
									MessageBox.Show($"Error removing printer: {errorMessage}", "Error");
								}
								else
								{
									// Placeholder code to show a message box indicating successful removal
									MessageBox.Show($"Printer '{selectedPrinterName}' removed successfully.", "Removal Result");
								}
							}
						}
						else
						{
							MessageBox.Show("Error: selectedPrinterName is null.", "Error");
						}
					}
					else
					{
						MessageBox.Show("Error: selectedPrinterInfo is null.", "Error");
					}
				}
				else
				{
					MessageBox.Show("Please select a printer to remove.", "Error");
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred during removal: {ex.Message}", "Error");
			}

		}

	}
}
