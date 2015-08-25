namespace PictureScanner
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.btnGo = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.buttonConfirmMode = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.labelPicture1 = new System.Windows.Forms.Label();
            this.labelPicture2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(226, 10);
            this.btnGo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(56, 19);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(9, 10);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(204, 20);
            this.txtPath.TabIndex = 1;
            this.txtPath.Text = "d:\\michael\\bilder";
            // 
            // buttonConfirmMode
            // 
            this.buttonConfirmMode.Location = new System.Drawing.Point(307, 10);
            this.buttonConfirmMode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConfirmMode.Name = "buttonConfirmMode";
            this.buttonConfirmMode.Size = new System.Drawing.Size(92, 19);
            this.buttonConfirmMode.TabIndex = 2;
            this.buttonConfirmMode.Text = "Confirm mode";
            this.buttonConfirmMode.UseVisualStyleBackColor = true;
            this.buttonConfirmMode.Click += new System.EventHandler(this.buttonConfirmMode_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 50);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.labelPicture1);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.labelPicture2);
            this.splitContainer1.Panel2.Controls.Add(this.pictureBox2);
            this.splitContainer1.Size = new System.Drawing.Size(570, 523);
            this.splitContainer1.SplitterDistance = 300;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 523);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(267, 523);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(461, 27);
            this.buttonConfirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(56, 19);
            this.buttonConfirm.TabIndex = 5;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.Location = new System.Drawing.Point(523, 27);
            this.buttonNo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(56, 19);
            this.buttonNo.TabIndex = 6;
            this.buttonNo.Text = "No!";
            this.buttonNo.UseVisualStyleBackColor = true;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // labelPicture1
            // 
            this.labelPicture1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPicture1.AutoSize = true;
            this.labelPicture1.Location = new System.Drawing.Point(4, 507);
            this.labelPicture1.Name = "labelPicture1";
            this.labelPicture1.Size = new System.Drawing.Size(0, 13);
            this.labelPicture1.TabIndex = 5;
            // 
            // labelPicture2
            // 
            this.labelPicture2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPicture2.AutoSize = true;
            this.labelPicture2.Location = new System.Drawing.Point(4, 508);
            this.labelPicture2.Name = "labelPicture2";
            this.labelPicture2.Size = new System.Drawing.Size(0, 13);
            this.labelPicture2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 583);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.buttonConfirmMode);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnGo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button buttonConfirmMode;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Button buttonConfirm;
		private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Label labelPicture1;
        private System.Windows.Forms.Label labelPicture2;
    }
}

