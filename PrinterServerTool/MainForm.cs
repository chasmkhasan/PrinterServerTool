using System;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace PrinterServerTool
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			InitializeGUI();
		}
		private void InitializeGUI()
		{
			//change the title of the form.

			this.Text += "Owned by Caironite";
			PopulatePrinterList();
		}

		private void PopulatePrinterList()
		{
			drpPrinterList.Items.Clear();

			if (PrinterSettings.InstalledPrinters.Count <= 0)
			{
				MessageBox.Show("Printer not found!");
				return;
			}

			foreach (string printer in PrinterSettings.InstalledPrinters)
			{
				drpPrinterList.Items.Add(printer);
			}

			if (drpPrinterList.Items.Count > 0)
			{
				drpPrinterList.SelectedIndex = 0;
			}
		}
	}
}
