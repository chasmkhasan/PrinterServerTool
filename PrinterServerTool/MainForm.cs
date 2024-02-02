using System.Collections.ObjectModel;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net;
using System.Reflection;
using System.Security;
using System.ServiceProcess;
using System.Windows.Forms;
using MethodInvoker = System.Windows.Forms.MethodInvoker;

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
		private PowerShellManagement _powerShellManagement;
		private string _selectedServer;

        public MainForm()
		{
			_printerManagement = new PrinterManagement();
			_loginManagement = new LoginManagement();
			_installManagement = new InstallManagement();
			_powerShellManagement = new PowerShellManagement();
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
				_selectedServer = GetSelectedServer();

				_sharedPrinters = await _printerManagement.GetPrintersAsync(_selectedServer);
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

					if (_credentials == null)
					{
						MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
						return;
					}

					InstallPrinter(selectedPrinterName, _credentials, dataModel);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred during installation: {ex.Message}", "Error");
			}
		}

		public void InstallPrinter(string selectedPrinterName, PSCredential credential, DataModel dataModel)
		{
			using (PowerShell PowerShellInstance = PowerShell.Create())
			{
				PowerShellInstance.AddScript($"winrm set winrm/config/client '@{{TrustedHosts=\"{_selectedServer}\"}}'");

				string addPrinterCommand = $@"
										$printServer = ""{_selectedServer}""
										$printerName = ""{dataModel.PrinterName}""
    
										$cimSession = New-CimSession -ComputerName $printServer -Credential $credential -Authentication Default

										try {{
										 Add-Printer -ConnectionName \\$printServer\$printerName -CimSession $cimSession
										 Write-Host ""Printer installation successful.""
										}} 
										catch {{
										 Write-Host ""Error installing printer: $($_.Exception.Message)""
										}}";

				PowerShellInstance.AddParameter("credential", credential);
				PowerShellInstance.AddScript(addPrinterCommand);
				
				Collection<PSObject> result = PowerShellInstance.Invoke();

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




		//private void InstallSelectedPrinter()
		//{
		//	DataGridViewRow selectedRow = dataGridPrinter.SelectedRows[0];
		//	DataModel dataModel = _sharedPrinters[selectedRow.Index];

		//	string selectedPrinterName = dataModel.PrinterName;
		//	string selectedServerName = dataModel.SystemName;

		//	if (_credentials == null)
		//	{
		//		MessageBox.Show("Error: Failed to retrieve credentials.", "Error");
		//		return;
		//	}

		//	InstallPrinter(selectedPrinterName, selectedServerName);
		//}

		////private void InstallPrinter(string printerName, string systemName, string portName, string driverName)
		////private void InstallPrinter(string printerName, string systemName)
		//private async Task InstallPrinterAsync(string printerName, string systemName)
		//{
		//	try
		//	{
		//		_credentials = _loginManagement.GetCredentials(systemName);

		//		if (_credentials != null)
		//		{
		//			string credentialString = _loginManagement.GetCredentialString(_credentials);
		//			string script = SharedPrinteredQuery(printerName, systemName);
		//			string fullScript = $"Invoke-Command -Credential ({credentialString}) -Authentication Default -ScriptBlock {{{script}}}";
		//			remotePrinter = await _powerShellManagement.ExecutePowerShellScriptAsync(systemName, _credentials, fullScript);
		//		}
		//		else
		//		{
		//			MessageBox.Show("Valid credentials are required to access shared printers. Please provide valid credentials and try again.", "Credentials Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"An error occurred during PowerShell execution: {ex.Message}", "Error");
		//	}

		//	return remotePrinter;
		//}

		//public string SharedPrinteredQuery(string printerName, string systemName)
		//{
		//	string script = $@"
		//					$printServer = ""{systemName}""
		//					$printerName = ""{printerName}""
		//					Add-Printer -ConnectionName \\$printServer\$printerName
		//					";

		//	return script;
		//}

		//private bool EnsurePrintSpoolerServiceRunning()
		//{
		//	if (!IsPrintSpoolerServiceRunning())
		//	{
		//		MessageBox.Show("Print Spooler service is not running. Starting the service...", "Info");
		//		StartPrintSpoolerService();
		//	}

		//	if (!IsPrintSpoolerServiceRunning())
		//	{
		//		MessageBox.Show("Unable to start Print Spooler service. Installation aborted.", "Error");
		//		return false;
		//	}

		//	return true;
		//}

		//private bool IsPrintSpoolerServiceRunning()
		//{
		//	try
		//	{
		//		ServiceController spoolerService = new ServiceController("Spooler");
		//		return spoolerService.Status == ServiceControllerStatus.Running;
		//	}
		//	catch (InvalidOperationException)
		//	{
		//		// Service not found
		//		return false;
		//	}
		//	catch (Exception)
		//	{
		//		// Other exceptions
		//		return false;
		//	}
		//}

		//private void StartPrintSpoolerService()
		//{
		//	ServiceController spoolerService = new ServiceController("Spooler");

		//	try
		//	{
		//		if (spoolerService.Status != ServiceControllerStatus.Running)
		//		{
		//			spoolerService.Start();
		//			spoolerService.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromSeconds(30));
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"Error starting Print Spooler service: {ex.Message}\n\n{ex.StackTrace}", "Error");
		//	}
		//}

		//private bool ValidateSelectedPrinter()
		//{
		//	if (dataGridPrinter.SelectedRows == null)
		//	{
		//		MessageBox.Show("Please select a printer to install.", "Error");
		//		return false;
		//	}
		//	return true;
		//}

		//private void InstallPrinter(string printerName, string systemName, string portName, string driverName)
		//{
		//	try
		//	{
		//		using (PowerShell PowerShellInstance = PowerShell.Create())
		//		{
		//			//Define the PowerShell script
		//			string script = $@"
		//							$printerServer = ""{systemName}""
		//							$printerName = ""{printerName}""
		//							$portName = ""{portName}""
		//							$driverName = ""{driverName}""

		//							# Check if the printer port already exists
		//							$existingPort = Get-PrinterPort -Name $portName

		//							# If the port doesn't exist, create it
		//							if (-not $existingPort) {{
		//							Add-PrinterPort -Name $portName
		//							}}

		//							# Add the printer using the existing or newly created port and driver
		//							Add-Printer -Name $printerName -PortName $portName -DriverName $driverName
		//							";

		//			// Load the script into the PowerShell process
		//			PowerShellInstance.AddScript(script);

		//			// Execute the script
		//			Collection<PSObject> results = PowerShellInstance.Invoke();

		//			// Check for errors
		//			if (PowerShellInstance.HadErrors)
		//			{
		//				foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
		//				{
		//					MessageBox.Show($"PowerShell error: {error.Exception.Message}", "Error");
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"An error occurred during PowerShell execution: {ex.Message}", "Error");
		//	}
		//}

		//private void InstallPrinter(string printerName, string systemName)
		//{
		//	try
		//	{
		//		// Get credentials
		//		PSCredential credential = _loginManagement.GetCredentials(systemName);

		//		if (credential != null)
		//		{
		//			using (PowerShell PowerShellInstance = PowerShell.Create())
		//			{
		//				// Define the PowerShell script
		//				string script = $@"
		//                  $printServer = ""{systemName}""
		//                  $printerName = ""{printerName}""

		//                  $username = ""{credential.UserName}""
		//                  $password = ConvertTo-SecureString ""{credential.GetNetworkCredential().Password}"" -AsPlainText -Force
		//                  $credential = New-Object System.Management.Automation.PSCredential($username, $password)

		//                  Add-Printer -ConnectionName \\$printServer\$printerName -Credential $credential
		//              ";

		//				// Load the script into the PowerShell process
		//				PowerShellInstance.AddScript(script);

		//				// Execute the script
		//				Collection<PSObject> results = PowerShellInstance.Invoke();

		//				// Check for errors
		//				if (PowerShellInstance.HadErrors)
		//				{
		//					foreach (ErrorRecord error in PowerShellInstance.Streams.Error)
		//					{
		//						MessageBox.Show($"PowerShell error: {error.Exception.Message}", "Error");
		//					}
		//				}
		//				else
		//				{
		//					// Print the results (if any)
		//					foreach (PSObject result in results)
		//					{
		//						MessageBox.Show(result.ToString(), "Result");
		//					}
		//				}
		//			}
		//		}
		//		else
		//		{
		//			MessageBox.Show("Valid credentials are required to access shared printers. Please provide valid credentials and try again.", "Credentials Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
		//		}
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show($"An error occurred during PowerShell execution: {ex.Message}", "Error");
		//	}
		//}
	}
}
