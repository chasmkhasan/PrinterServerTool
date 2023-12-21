using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrinterServerTool
{
	internal class WaitFormFunc
	{
		PreLoaderForm wait;
		Thread loadthread;

		public void Show()
		{
			loadthread = new Thread(new ThreadStart(LoadingProcess));
			loadthread.Start();
		}

		public void Show(Form parent)
		{
			loadthread = new Thread(new ParameterizedThreadStart(LoadingProcess));
			loadthread.Start(parent);
		}

		public void Close()
		{
			if (wait != null)
			{
				wait.BeginInvoke(new System.Threading.ThreadStart(wait.CloseWaitForm));
				wait = null;
				loadthread = null;
			}
		}

		private void LoadingProcess()
		{
			wait = new PreLoaderForm();
			wait.ShowDialog();
		}

		private void LoadingProcess(object parent)
		{
			Form parent1 = parent as Form;
			wait = new PreLoaderForm(parent1);
			wait.ShowDialog();
		}
	}
}
