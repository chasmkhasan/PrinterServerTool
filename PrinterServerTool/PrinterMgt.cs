using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class PrinterMgt
	{

		private int choice;

		public int GetChoice()
		{
			return choice;
		}
		public void SetChoice(int newChoice)
		{
			choice = newChoice;
		}

		public List<string> ShowPrinterMgt()
		{
			List<string> printerList = new List<string>();

			switch (choice)
			{
				case 0:
					printerList = PrinterServerOne().ToList();
					break;
				case 1:
					printerList = PrinterServerTwo().ToList();
					break;
				case 2:
					printerList = PrinterServerThree().ToList();
					break;
				case 3:
					printerList = PrinterServerFour().ToList();
					break;
				case 4:
					printerList = PrinterServerFive().ToList();
					break;
			}
			return printerList;
		}

		private List<string> PrinterServerOne()
		{
			List<string> printerFloorOne = new List<string>();

			if (PrinterSettings.InstalledPrinters.Count <= 0)
			{
				MessageBox.Show("Printer not found!");
				return printerFloorOne;
			}

			foreach (string printer in PrinterSettings.InstalledPrinters)
			{
				printerFloorOne.Add(printer);
			}

			return printerFloorOne;
		}

		private List<string> PrinterServerTwo()
		{
			List<string> printerFloorTwo = new List<string>();

			if (PrinterSettings.InstalledPrinters.Count <= 0)
			{
				MessageBox.Show("Printer not found!");
				return printerFloorTwo;
			}

			foreach (string printer in PrinterSettings.InstalledPrinters)
			{
				printerFloorTwo.Add(printer);
			}

			return printerFloorTwo;
		}

		private List<string> PrinterServerThree()
		{
			List<string> printerFloorThree = new List<string>();

			if (PrinterSettings.InstalledPrinters.Count <= 0)
			{
				MessageBox.Show("Printer not found!");
				return printerFloorThree;
			}

			foreach (string printer in PrinterSettings.InstalledPrinters)
			{
				printerFloorThree.Add(printer);
			}

			return printerFloorThree;
		}

		private List<string> PrinterServerFour()
		{
			List<string> printerFloorFour = new List<string>();

			if (PrinterSettings.InstalledPrinters.Count <= 0)
			{
				MessageBox.Show("Printer not found!");
				return printerFloorFour;
			}

			foreach (string printer in PrinterSettings.InstalledPrinters)
			{
				printerFloorFour.Add(printer);
			}

			return printerFloorFour;
		}

		private List<string> PrinterServerFive()
		{
			List<string> printerFloorFive = new List<string>
			{
				"Floor Five Printer One",
				"Floor Five Printer Two",
				"Floor Five Printer Three",
				"Floor Five Printer Four",
				"Floor Five Printer Five",
				"Floor Five Printer Six"
			};

			return printerFloorFive;
		}

		private List<string> PrinterServerSix()
		{
			List<string> printerFloorSix = new List<string>
			{
				"Floor Six Printer One",
				"Floor Six Printer Two",
				"Floor Six Printer Three",
				"Floor Six Printer Four",
				"Floor Six Printer Five",
				"Floor Six Printer Six"
			};

			return printerFloorSix;
		}
	}
}
