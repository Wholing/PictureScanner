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
        private IProgress progress;

        private ComparisonPair currentComparison;

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnGo_Click(object sender, EventArgs e)
        {
            btnGo.Enabled = false;
            labelProgress.Text = string.Empty;
            labelProgress.Visible = true;
            timer1.Enabled = true;

            var scanner = new DirectoryScanner(txtPath.Text);
            progress = scanner;
            var scanId = await scanner.ScanAsync();
            var scanId2 = await scanner.HashAsync(scanId);
            var dups = new DuplicationScanner(scanId);
            var result = await dups.ScanAsync();

            var message = string.Format("Count: {0}\nUnique:{1}\nDuplicates:{2}\nConflicts:{3}", result.Count, result.UniqueCount, result.DuplicationCount, result.Multiprocessed);
            MessageBox.Show(message);

            timer1.Enabled = false;
            btnGo.Enabled = true;
            labelProgress.Visible = false;
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelProgress.Text = progress.Value.ToString();
        }

        private async void buttonDups_Click(object sender, EventArgs e)
        {
            buttonDups.Enabled = false;
            labelProgress.Text = string.Empty;
            labelProgress.Visible = true;
            timer1.Enabled = true;

            var scanId = DirectoryScanner.LastScanId();
            var dups = new DuplicationScanner(scanId);
            var result = await dups.ScanAsync();

            var message = string.Format("Count: {0}\nUnique:{1}\nDuplicates:{2}\nConflicts:{3}", result.Count, result.UniqueCount, result.DuplicationCount, result.Multiprocessed);
            MessageBox.Show(message);

            timer1.Enabled = false;
            buttonDups.Enabled = true;
            labelProgress.Visible = false;
        }

        private async void buttonHash_Click(object sender, EventArgs e)
        {
            buttonHash.Enabled = false;
            labelProgress.Text = string.Empty;
            labelProgress.Visible = true;
            timer1.Enabled = true;

            var scanner = new DirectoryScanner(txtPath.Text);
            progress = scanner;
            var scanId = DirectoryScanner.LastScanId();
            var scanId2 = await scanner.HashAsync(scanId);
            var dups = new DuplicationScanner(scanId);
            var result = await dups.ScanAsync();

            var message = string.Format("Count: {0}\nUnique:{1}\nDuplicates:{2}\nConflicts:{3}", result.Count, result.UniqueCount, result.DuplicationCount, result.Multiprocessed);
            MessageBox.Show(message);

            timer1.Enabled = false;
            buttonHash.Enabled = true;
            labelProgress.Visible = false;
        }
    }
}
