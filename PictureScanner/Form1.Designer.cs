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
			this.SuspendLayout();
			// 
			// btnGo
			// 
			this.btnGo.Location = new System.Drawing.Point(366, 96);
			this.btnGo.Name = "btnGo";
			this.btnGo.Size = new System.Drawing.Size(75, 23);
			this.btnGo.TabIndex = 0;
			this.btnGo.Text = "Go!";
			this.btnGo.UseVisualStyleBackColor = true;
			this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(67, 96);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(271, 22);
			this.txtPath.TabIndex = 1;
			this.txtPath.Text = "C:\\dev\\utils";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(527, 253);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.btnGo);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnGo;
		private System.Windows.Forms.TextBox txtPath;
	}
}

