using Microsoft.Management.Infrastructure;
using System;
using System.Collections.ObjectModel;
using System.Drawing.Printing;
using System.Management.Automation;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		PrinterManagement readPrinter = new PrinterManagement();
		//PrinterDataModel model = new PrinterDataModel();

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
				string selectedServer = null;

				// Use Invoke to access the dropDownOptions control from the UI thread
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
				List<string> sharedPrinters = await readPrinter.GetSharedPrintersAsync(selectedServer);

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

				else
				{
					if (gifBox.InvokeRequired)
					{
						gifBox.Invoke(new Action(() => gifBox.Visible = false));
					}
					else
					{
						gifBox.Visible = false;
					}

					MessageBox.Show("No Remote Shared Printer found.", "Search Result");
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show($"An error occurred: {ex.Message}", "Error");
			}

			return result;
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
						// Extract the printer name from the selected information
						string selectedPrinterName = selectedPrinterInfo.Replace("Printer: ", "");

						if (selectedPrinterName != null)
						{
							// Use PowerShell to install the selected printer
							using (PowerShell PowerShellInstance = PowerShell.Create())
							{
								
								//// PowerShell script to install the printer
								//string installPrinterScript = $"Add-Printer -Name '{selectedPrinterName}'";

								//// Add the script to PowerShell
								//PowerShellInstance.AddScript(installPrinterScript);

								//// Invoke execution on PowerShell
								//Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

								// Check for errors after PowerShell execution
								if (PowerShellInstance.HadErrors)
								{
									// Handle errors
									string errorMessage = string.Join("\n", PowerShellInstance.Streams.Error.Select(error => error.ToString()));
									MessageBox.Show($"Error installing printer: {errorMessage}", "Error");
								}
								else
								{
									// Placeholder code to show a message box indicating successful installation
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
