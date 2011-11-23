namespace ImageDateUtility
{
    partial class frmImageDateUtility
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.dlgFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.txtBatchFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectSourceBatch = new System.Windows.Forms.Button();
            this.dtpBatchTime = new System.Windows.Forms.DateTimePicker();
            this.btnStartBatch = new System.Windows.Forms.Button();
            this.dtpBatchDate = new System.Windows.Forms.DateTimePicker();
            this.chkRandomize = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.chkRandomize);
            this.groupBox2.Controls.Add(this.dtpBatchDate);
            this.groupBox2.Controls.Add(this.btnStartBatch);
            this.groupBox2.Controls.Add(this.dtpBatchTime);
            this.groupBox2.Controls.Add(this.btnSelectSourceBatch);
            this.groupBox2.Controls.Add(this.txtBatchFilePath);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(522, 128);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Batch Processing";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(6, 99);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(509, 23);
            this.progressBar1.TabIndex = 0;
            // 
            // txtBatchFilePath
            // 
            this.txtBatchFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchFilePath.Location = new System.Drawing.Point(6, 19);
            this.txtBatchFilePath.Name = "txtBatchFilePath";
            this.txtBatchFilePath.Size = new System.Drawing.Size(374, 20);
            this.txtBatchFilePath.TabIndex = 1;
            // 
            // btnSelectSourceBatch
            // 
            this.btnSelectSourceBatch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectSourceBatch.Location = new System.Drawing.Point(386, 17);
            this.btnSelectSourceBatch.Name = "btnSelectSourceBatch";
            this.btnSelectSourceBatch.Size = new System.Drawing.Size(128, 23);
            this.btnSelectSourceBatch.TabIndex = 2;
            this.btnSelectSourceBatch.Text = "Select Source Directory";
            this.btnSelectSourceBatch.UseVisualStyleBackColor = true;
            this.btnSelectSourceBatch.Click += new System.EventHandler(this.btnSelectSourceBatch_Click);
            // 
            // dtpBatchTime
            // 
            this.dtpBatchTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpBatchTime.Location = new System.Drawing.Point(212, 45);
            this.dtpBatchTime.Name = "dtpBatchTime";
            this.dtpBatchTime.ShowUpDown = true;
            this.dtpBatchTime.Size = new System.Drawing.Size(100, 20);
            this.dtpBatchTime.TabIndex = 3;
            // 
            // btnStartBatch
            // 
            this.btnStartBatch.Location = new System.Drawing.Point(6, 71);
            this.btnStartBatch.Name = "btnStartBatch";
            this.btnStartBatch.Size = new System.Drawing.Size(508, 23);
            this.btnStartBatch.TabIndex = 4;
            this.btnStartBatch.Text = "Start Processing";
            this.btnStartBatch.UseVisualStyleBackColor = true;
            this.btnStartBatch.Click += new System.EventHandler(this.btnStartBatch_Click);
            // 
            // dtpBatchDate
            // 
            this.dtpBatchDate.Location = new System.Drawing.Point(6, 45);
            this.dtpBatchDate.Name = "dtpBatchDate";
            this.dtpBatchDate.Size = new System.Drawing.Size(200, 20);
            this.dtpBatchDate.TabIndex = 5;
            // 
            // chkRandomize
            // 
            this.chkRandomize.AutoSize = true;
            this.chkRandomize.Location = new System.Drawing.Point(318, 46);
            this.chkRandomize.Name = "chkRandomize";
            this.chkRandomize.Size = new System.Drawing.Size(157, 17);
            this.chkRandomize.TabIndex = 6;
            this.chkRandomize.Text = "Randomize time within day?";
            this.chkRandomize.UseVisualStyleBackColor = true;
            // 
            // frmImageDateUtility
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 152);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmImageDateUtility";
            this.Text = "Image Date Utility";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;
        private System.Windows.Forms.FolderBrowserDialog dlgFolderBrowser;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnSelectSourceBatch;
        private System.Windows.Forms.TextBox txtBatchFilePath;
        private System.Windows.Forms.DateTimePicker dtpBatchTime;
        private System.Windows.Forms.Button btnStartBatch;
        private System.Windows.Forms.DateTimePicker dtpBatchDate;
        private System.Windows.Forms.CheckBox chkRandomize;
    }
}

