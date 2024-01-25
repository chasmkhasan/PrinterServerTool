using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class LoginStore
	{
		public class CredentialsEntry
		{
			public string Username { get; set; }
			public string Password { get; set; }
			public string Server { get; set; }
		}

		private List<CredentialsEntry> storedCredentials = new List<CredentialsEntry>();

		public List<CredentialsEntry> GetStoredCredentials()
		{
			return storedCredentials;
		}

		public void AddCredentials(CredentialsEntry credentials)
		{
			storedCredentials.Add(credentials);
		}
	}
}
