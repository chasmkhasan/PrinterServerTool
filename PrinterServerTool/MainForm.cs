using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Net;
using System.Security;
using System.ServiceProcess;
using System.Windows.Forms;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		private PrinterManagement _printerManagement;
		private LoginManagement _loginManagement;
		private InstallManagement _installManagement;
		private List<DataModel> _sharedPrinters;
		private UserInfo _userInfo;
		private PSCredential _credentials;

		public MainForm()
		{
			_printerManagement = new PrinterManagement();
			_loginManagement = new LoginManagement();
			_installManagement = new InstallManagement();
			_userInfo = new UserInfo();

			InitializeComponent();

			// Start the code.
			InitializeGUI();
		}
		private void InitializeGUI()
		{
			this.Text += " Queue installer";
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

			spiningBarBox.Image = Properties.Resources.Spinning_fangs;
			spiningBarBox.SizeMode = PictureBoxSizeMode.CenterImage;
			spiningBarBox.Visible = true;

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

				_sharedPrinters = await _printerManagement.GetPrintersAsync(selectedServer);
				_credentials = _printerManagement.Credentials;

				if (_sharedPrinters.Count > 0)
				{
					UpdateUIWithPrintersInfo();

					SpiningBar();

					result = true;

					this.Invoke((MethodInvoker)delegate
					{
						btnInstallPrinter.Visible = true;
					});
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

		public string GetSelectedServer()
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
					//dataGridPrinter.Columns.Add("IPAddress", "IP Address");
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
					//printer.IPAddress, // Add IPAddress value
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
			if (spiningBarBox.InvokeRequired)
			{
				spiningBarBox.Invoke(new Action(() => spiningBarBox.Visible = false));
			}
			else
			{
				spiningBarBox.Visible = false;
			}
		}

		private void ShowErrorMessageBox(string errorMessage)
		{
			MessageBox.Show($"An error occurred: {errorMessage}", "Error");
		}

		//private void btnInstallPrinter_Click(object sender, EventArgs e)
		//{
		//	try
		//	{
		//		if (dataGridPrinter.SelectedRows == null)
		//		{
		//			MessageBox.Show("Please select a printer to install.", "Error");
		//			return;
		//		}

		//		if (dataGridPrinter.SelectedRows.Count > 0)
		//		{
		//			DataGridViewRow selectedRow = dataGridPrinter.SelectedRows[0];
		//			DataModel dataModel = _sharedPrinters[selectedRow.Index];

		//			string selectedPrinterName = dataModel.PrinterName;

		//			if (_credentials == null)
		//			{
		//				MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
		//				return;
		//			}

		//			//_installManagement.InstallPrinter(selectedPrinterName, _credentials, dataModel);
		//			InstallPrinter(selectedPrinterName, _credentials, dataModel);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"An error occurred during installation: {ex.Message}", "Error");
		//	}
		//}

		private void btnInstallPrinter_Click(object sender, EventArgs e)
		{
			try
			{
				if (!EnsurePrintSpoolerServiceRunning())
					return;

				if (!ValidateSelectedPrinter())
					return;


				// Show installation in progress message
				MessageBox.Show("Installing printer. Please wait...", "Info");

				InstallSelectedPrinter();

				// Show installation completed message
				MessageBox.Show("Printer installation completed successfully.", "Info");
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred during installation: {ex.Message}", "Error");
			}
		}

		private bool ValidateSelectedPrinter()
		{
			if (dataGridPrinter.SelectedRows == null)
			{
				MessageBox.Show("Please select a printer to install.", "Error");
				return false;
			}

			return true;
		}

		private void InstallSelectedPrinter()
		{
			DataGridViewRow selectedRow = dataGridPrinter.SelectedRows[0];
			DataModel dataModel = _sharedPrinters[selectedRow.Index];

			string selectedPrinterName = dataModel.PrinterName;
			string selectedServerName = dataModel.SystemName;
			string selectedPortName = dataModel.PortName;
			string selectedDriverName = dataModel.DriverName;

			if (_credentials == null)
			{
				MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
				return;
			}

			// Install the printer using PowerShell
			InstallPrinter(selectedPrinterName, selectedServerName, selectedPortName, selectedDriverName);
		}

		private void InstallPrinter(string printerName, string systemName, string portName, string driverName)
		{
			try
			{
				using (PowerShell PowerShellInstance = PowerShell.Create())
				{
					// Define the PowerShell script
					string script = $@"
									$printerServer = ""{systemName}""
									$printerName = ""{printerName}""
									$portName = ""{portName}""
									$driverName = ""{driverName}""

									# Check if the printer port already exists
									$existingPort = Get-PrinterPort -Name $portName

									# If the port doesn't exist, create it
									if (-not $existingPort) {{
									Add-PrinterPort -Name $portName
									}}

									# Add the printer using the existing or newly created port and driver
									Add-Printer -Name $printerName -PortName $portName -DriverName $driverName
									";

					// Load the script into the PowerShell process
					PowerShellInstance.AddScript(script);

					// Execute the script
					Collection<PSObject> results = PowerShellInstance.Invoke();

					// Check for errors
					if (PowerShellInstance.HadErrors)
					{
						foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
						{
							MessageBox.Show($"PowerShell error: {error.Exception.Message}", "Error");
						}
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred during PowerShell execution: {ex.Message}", "Error");
			}
		}

		private bool EnsurePrintSpoolerServiceRunning()
		{
			if (!IsPrintSpoolerServiceRunning())
			{
				MessageBox.Show("Print Spooler service is not running. Starting the service...", "Info");
				StartPrintSpoolerService();
			}

			if (!IsPrintSpoolerServiceRunning())
			{
				MessageBox.Show("Unable to start Print Spooler service. Installation aborted.", "Error");
				return false;
			}

			return true;
		}

		private bool IsPrintSpoolerServiceRunning()
		{
			try
			{
				ServiceController spoolerService = new ServiceController("Spooler");
				return spoolerService.Status == ServiceControllerStatus.Running;
			}
			catch (InvalidOperationException)
			{
				// Service not found
				return false;
			}
			catch (Exception)
			{
				// Other exceptions
				return false;
			}
		}

		private void StartPrintSpoolerService()
		{
			ServiceController spoolerService = new ServiceController("Spooler");

			try
			{
				if (spoolerService.Status != ServiceControllerStatus.Running)
				{
					spoolerService.Start();
					spoolerService.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"Error starting Print Spooler service: {ex.Message}\n\n{ex.StackTrace}", "Error");
			}
		}
	}
}
