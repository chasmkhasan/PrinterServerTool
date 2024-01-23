using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Net;
using System.Windows.Forms;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
        private PrinterManagement _readPrinter;
        private LoginManagement _loginManagement;
        private InstallManagement _installManagement;
        private RemoveManagement _removeManagement;
		private List<DataModel> _sharedPrinters;

		public MainForm()
		{
            _readPrinter = new PrinterManagement();
			_loginManagement = new LoginManagement();
			_installManagement = new InstallManagement();
			_removeManagement = new RemoveManagement();

			InitializeComponent();

			// Start the code.
			InitializeGUI();
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

                _sharedPrinters = await _readPrinter.GetPrintersAsync(selectedServer);

				if (_sharedPrinters.Count > 0)
				{
					UpdateUIWithPrintersInfo();

					SpiningBar();

					MessageBox.Show($"{selectedServer} has {_sharedPrinters.Count} number of shared printer.", "Search Result");

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

		private void UpdateUIWithPrintersInfo()
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

			foreach (DataModel printer in _sharedPrinters)
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

				if (dataGridPrinter.SelectedRows.Count > 0)
				{
                    DataGridViewRow selectedRow = dataGridPrinter.SelectedRows[0];
					DataModel dataModel = _sharedPrinters[selectedRow.Index];

					string selectedPrinterName = dataModel.PrinterName;

                    // Get credentials from the user
                    PSCredential credential = _loginManagement.GetCredentials(selectedPrinterName);

                    if (credential == null)
                    {
                        MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
                        return;
                    }

                    _installManagement.InstallPrinter(selectedPrinterName, credential, dataModel);
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
				PSCredential credential = _loginManagement.GetCredentials(selectedPrinterName);
				if (credential == null)
				{
					MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
					return;
				}

				_removeManagement.RemovePrinter(selectedPrinterName, credential);
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
