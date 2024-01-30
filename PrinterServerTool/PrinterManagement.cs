﻿using Microsoft.Management.Infrastructure;
using System.Collections.ObjectModel;
using System.Linq.Expressions;
using System.Management.Automation;
using System.Net;
using System.Runtime.InteropServices;
using System.Security;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace PrinterServerTool
{
	internal class PrinterManagement
	{
		private PowerShellManagement _powerShellManagement;
		private LoginManagement _loginManagement;
		private PSCredential _psCredential;

		public PrinterManagement()
		{
			_powerShellManagement = new PowerShellManagement();
			_loginManagement = new LoginManagement();
		}

		public PSCredential Credentials
		{
			get
			{
				return _psCredential;
			}
		}

		public async Task<List<DataModel>> GetPrintersAsync(string selectedServer)
		{
			List<DataModel> sharedPrinters = new List<DataModel>();

			try
			{
				_psCredential = _loginManagement.GetCredentials(selectedServer);

				string credentialString = _loginManagement.GetCredentialString(_psCredential);

				if (_psCredential != null)
				{
					string script = SystemQuery();

					string fullScript = $"Invoke-Command -ComputerName {selectedServer} -Credential ({credentialString}) -Authentication Default -ScriptBlock {{{script}}}";

					sharedPrinters = await _powerShellManagement.ExecutePowerShellScriptAsync(selectedServer, _psCredential, fullScript);
				}
				else
				{
					MessageBox.Show("Valid credentials are required to access shared printers. Please provide valid credentials and try again.", "Credentials Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}
			}
			catch (PipelineStoppedException ex)
			{
				LogException(ex);
			}
			catch (RuntimeException ex)
			{
				LogException(ex);
			}
			catch (Exception ex)
			{
				LogException(ex);
			}

			return sharedPrinters;
		}

		private string SystemQuery()
		{
			string script = @"Get-CimInstance -ClassName Win32_Printer | 
						Where-Object { $_.Shared -eq $true } | 
					Select-Object Name, ShareName, DriverName, PortName, Location, SystemName, DriverVersion, PrinterStatus
				";

			//string script = @"Get-CimInstance -ClassName Win32_Printer |
			//                 Where-Object { $_.Shared -eq $true } |
			//                 Select-Object Name, ShareName, DriverName, PortName, Location, SystemName, DriverVersion, PrinterStatus
			//                 @{ Name='IPAddress'; Expression={ (Test-Connection -ComputerName $_.SystemName -Count 1 -ErrorAction SilentlyContinue).IPAddress} }";

			return script;
		}

		private void LogException(Exception ex)
		{
			MessageBox.Show($"An exception occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}