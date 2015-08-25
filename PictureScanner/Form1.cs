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
            var file1 = currentComparison.Owner.Owner.FileNameFull;
            var file2 = currentComparison.Owner.DuplicateFiles.Single(item => item.NeedsConfirmation).DataFile.FileNameFull;
            labelPicture1.Text = file1;
            labelPicture2.Text = file2;
            LoadPicture(pictureBox1, file1);
            LoadPicture(pictureBox2, file2);
        }

        private void LoadPicture(PictureBox pictureBox, string fileName)
        {
            try
            {
                pictureBox.Load(fileName);
            }
            catch (ArgumentException)
            {
                pictureBox.Image = null;
            }
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            SelectFileInExplorer(labelPicture1.Text);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            SelectFileInExplorer(labelPicture2.Text);
        }

        private static void SelectFileInExplorer(string filePath)
        {
            string argument = @"/select, " + filePath.Replace('/', '\\');

            System.Diagnostics.Process.Start("explorer.exe", argument);
        }

    }
}
