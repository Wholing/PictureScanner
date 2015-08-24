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
		private ConfirmationService comparisonService;

		private ComparisonPair currentComparison;

		public Form1()
		{
			InitializeComponent();
		}

		private void btnGo_Click(object sender, EventArgs e)
		{
			btnGo.Enabled = false;
			var scanner = new DirectoryScanner(txtPath.Text);
			var scanId = scanner.Scan();
			var dups = new DuplicationScanner(scanId);
			dups.Scan();

			btnGo.Enabled = true;
		}

		private void buttonConfirmMode_Click(object sender, EventArgs e)
		{
			var scanId = DirectoryScanner.LastScanId();
			this.comparisonService = new ConfirmationService(scanId);
			PresentNext();
		}

		private void PresentNext()
		{
			currentComparison = this.comparisonService.NextComparison();
			if (currentComparison == null)
			{
				pictureBox1.Visible = false;
				pictureBox2.Visible = false;
				MessageBox.Show("Nothing more to compare", "Comparison", MessageBoxButtons.OK);
				return;
			}
			pictureBox1.LoadAsync(currentComparison.Owner.Owner.FileNameFull);
			pictureBox2.LoadAsync(currentComparison.Owner.DuplicateFiles.Single(item => item.NeedsConfirmation).DataFile.FileNameFull);
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			this.comparisonService.Confirm(currentComparison);
			PresentNext();
		}

		private void buttonNo_Click(object sender, EventArgs e)
		{
			this.comparisonService.Deny(currentComparison);
			PresentNext();
		}
	}
}
