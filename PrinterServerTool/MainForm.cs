using System;
using System.Drawing.Printing;
using System.Windows.Forms;

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

	waitForm.Show();

	await Task.Run(() => SearchForPrinters());
	MessageBox.Show("Search Completed successfully.", "Search Result");
}

private async Task<bool> SearchForPrinters()
{
	bool result = false;

	List<string> sharedPrinters = await readPrinter.GetSharedPrinters();

	waitForm.Close();

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

		private void btnInstallPrinter_Click(object sender, EventArgs e)
		{
			if (printerMgt != null)
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
