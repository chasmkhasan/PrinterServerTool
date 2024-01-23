using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Net;
using System.Windows.Forms;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		PrinterManagement readPrinter = new PrinterManagement();
		PowerShellManagement powerShellManagement = new PowerShellManagement();
		LoginManagement loginManagement = new LoginManagement();
		InstallManagement installManagement = new InstallManagement();
		RemoveManagement removeManagement = new RemoveManagement();
		DataModel dataModel = new DataModel();

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

			dataGridPrinter.Rows.Clear();

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

				List<DataModel> sharedPrinters = await readPrinter.GetPrintersAsync(selectedServer);

				if (sharedPrinters.Count > 0)
				{
					UpdateUIWithPrintersInfo(sharedPrinters);

					SpiningBar();

					MessageBox.Show($"{selectedServer} has {sharedPrinters.Count} number of shared printer.", "Search Result");

					result = true;
				}
				else
				{
					SpiningBar();

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

		private void UpdateUIWithPrintersInfo(List<DataModel> printers)
		{
			if (dataGridPrinter.InvokeRequired)
			{
				dataGridPrinter.Invoke(new Action(() =>
				{
					dataGridPrinter.Rows.Clear();
					dataGridPrinter.Columns.Clear();

					// Add columns
					dataGridPrinter.Columns.Add("PrinterName", "Printer Name");
					dataGridPrinter.Columns.Add("ShareName", "Share Name");
					dataGridPrinter.Columns.Add("DriverName", "Driver Name");
					dataGridPrinter.Columns.Add("PortName", "Port Name");
					dataGridPrinter.Columns.Add("Location", "Location");
					dataGridPrinter.Columns.Add("SystemName", "System Name");
					dataGridPrinter.Columns.Add("DriverVersion", "Driver Version");
					dataGridPrinter.Columns.Add("PrinterModel", "Printer Model");
					dataGridPrinter.Columns.Add("PrinterStatus", "Printer Status");
				}));
			}

			foreach (DataModel printer in printers)
			{
				object[] row = {
								printer.PrinterName,
								printer.ShareName,
								printer.DriverName,
								printer.PortName,
								printer.Location,
								printer.SystemName,
								printer.DriverVersion,
								printer.PrinterModel,
								printer.PrinterStatus
								};

				if (dataGridPrinter.InvokeRequired)
				{
					dataGridPrinter.Invoke(new Action(() =>
					{
						dataGridPrinter.Rows.Add(row);
					}));
				}
				else
				{
					dataGridPrinter.Rows.Add(row);
				}
			}
		}

		private void SpiningBar()
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
				if (dataGridPrinter.SelectedRows == null)
				{
					MessageBox.Show("Please select a printer to install.", "Error");
					return;
				}

				string selectedPrinterInfo = dataGridPrinter.SelectedRows.ToString();
				if (selectedPrinterInfo == null)
				{
					MessageBox.Show("Error: selectedPrinterInfo is null.", "Error");
					return;
				}

				string selectedPrinterName = selectedPrinterInfo.Replace("Printer: ", "");
				if (selectedPrinterName == null)
				{
					MessageBox.Show("Error: selectedPrinterName is null.", "Error");
					return;
				}

				// Get credentials from the user
				PSCredential credential = loginManagement.GetCredentials(selectedPrinterName);
				if (credential == null)
				{
					MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
					return;
				}

				installManagement.InstallPrinter(selectedPrinterName, credential);
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
				if (dataGridPrinter.SelectedRows == null)
				{
					MessageBox.Show("Please select a printer to install.", "Error");
					return;
				}

				string selectedPrinterInfo = dataGridPrinter.SelectedRows.ToString();
				if (selectedPrinterInfo == null)
				{
					MessageBox.Show("Error: selectedPrinterInfo is null.", "Error");
					return;
				}

				string selectedPrinterName = selectedPrinterInfo.Replace("Printer: ", "");
				if (selectedPrinterName == null)
				{
					MessageBox.Show("Error: selectedPrinterName is null.", "Error");
					return;
				}

				// Get credentials from the user
				PSCredential credential = loginManagement.GetCredentials(selectedPrinterName);
				if (credential == null)
				{
					MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
					return;
				}

				removeManagement.RemovePrinter(selectedPrinterName, credential);
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred during installation: {ex.Message}", "Error");
			}

		}

		private void BtnExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
