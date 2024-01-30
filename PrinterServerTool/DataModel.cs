using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	public class DataModel
	{
		public string _printerName;
		public string _shareName;
		public string _driverName;
		public string _portName;
		public string _location;
		public string _systemName;
		public string _driverVersion;
		public string _printerModel;
		public string _ipAddress;
		public string _printerStatus;

		public string PrinterName
		{
			get { return _printerName; }
			set 
			{ 
				_printerName = value; 
			}
		}

		public string ShareName
		{
			get { return _shareName; }
			set 
			{ 
				_shareName = value; 
			}
		}

		public string DriverName
		{
			get { return _driverName; }
			set 
			{ 
				_driverName = value; 
			}
		}

		public string PortName
		{
			get { return _portName; }
			set 
			{ 
				_portName = value; 
			}
		}

		public string Location
		{
			get { return _location; }
			set 
			{ 
				_location = value; 
			}
		}

		public string SystemName
		{
			get { return _systemName; }
			set 
			{ 
				_systemName = value; 
			}
		}

		public string DriverVersion
		{
			get { return _driverVersion; }
			set 
			{ 
				_driverVersion = value; 
			}
		}

		public string PrinterModel
		{
			get { return _printerModel; }
			set 
			{ 
				_printerModel = value; 
			}
		}

		public string IPAddress
		{
			get { return _ipAddress; }
			set
			{
				_ipAddress = value;
			}
		}

		public string PrinterStatus
		{
			get { return _printerStatus; }
			set 
			{ 
				_printerStatus = value; 
			}
		}
	}
}
