using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureScanner
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			btnGo.Enabled = false;
			var scanner = new DirectoryScanner(txtPath.Text);
			scanner.Scan();

			btnGo.Enabled = true;
		}
	}
}
