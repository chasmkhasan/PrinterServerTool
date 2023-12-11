using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		PrinterMgt printerMgt = new PrinterMgt();

		public MainForm()
		{
			InitializeComponent();

			// Start the code.
			InitializeGUI();
		}
		private void InitializeGUI()
		{
			//change the title of the form.

			this.Text += "Owned by Caironite";
			FillTheCombobox();
		}

		private void FillTheCombobox()
		{
			cmbOptions.Items.Clear();

			cmbOptions.Items.Add("Please Select Server Name");
			cmbOptions.Items.Add("Printer Server 01");
			cmbOptions.Items.Add("Printer Server 02");
			cmbOptions.Items.Add("Printer Server 03");
			cmbOptions.Items.Add("Printer Server 04");
			cmbOptions.Items.Add("Printer Server 05");
			cmbOptions.Items.Add("Printer Server 06");

			cmbOptions.SelectedIndex = 0;
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

		private void btnSearch_Click(object sender, EventArgs e)
		{
			bool ok = ReadChoice();

			if (ok)
			{
				List<string> listOfPrinters = printerMgt.ShowPrinterMgt();

				lstOfPrinterName.Items.Clear();

				foreach (string printerName in listOfPrinters)
				{
					lstOfPrinterName.Items.Add(printerName);
				}
			}
		}

		private void btnInstallPrinter_Click(object sender, EventArgs e)
		{
			if (printerMgt != null)
			{
				MessageBox.Show("No Printer Shared in this Server", "Error");
			}
		}
	}
}
