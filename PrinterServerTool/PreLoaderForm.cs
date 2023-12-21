using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrinterServerTool
{
	public partial class PreLoaderForm : Form
	{
		public PreLoaderForm()
		{
			InitializeComponent();
			this.StartPosition = FormStartPosition.CenterParent;
		}

		public PreLoaderForm(Form Parent)
		{
			InitializeComponent();
			if (Parent != null)
			{
				this.StartPosition = FormStartPosition.Manual;
				this.Location = new Point(Parent.Location.X + Parent.Width / 2 - this.Width / 2,
					Parent.Location.Y + Parent.Height / 2 - this.Height / 2);
			}
			else
			{
				this.StartPosition = FormStartPosition.CenterParent;
			}
		}
		public void CloseWaitForm()
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
			if (gifBox.Image != null)
			{
				gifBox.Image.Dispose();
				gifBox.Image = null;
			}
		}
	}
}
