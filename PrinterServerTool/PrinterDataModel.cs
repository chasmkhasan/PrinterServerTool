using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
		public string SystemName { get; set; }
		public string DriverVersion { get; set; }
		public string PrinterModel { get; set; }
		public string PrinterStatus { get; set; }
		
	}

}
