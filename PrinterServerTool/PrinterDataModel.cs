using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	public class PrinterDataModel
	{

		public string PrinterName { get; set; }
		public string ShareName { get; set; }
		public string DriverName { get; set; }
		public string PortName { get; set; }
		public string Location { get; set; }

		public override string ToString()
		{
			// Implement the ToString() method to display relevant information
			return $"Printer: {PrinterName}, Server: {ShareName}, Driver: {DriverName}, Port: {PortName}, Location: {Location}";
		}
	}
}
