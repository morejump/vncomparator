namespace VnSentencesConparator
{
    partial class FrmProgressDialog
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
            this.progressBar = new MetroFramework.Controls.MetroProgressBar();
            this.lbMsg = new MetroFramework.Controls.MetroLabel();
            this.picLoading = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 72);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(319, 18);
            this.progressBar.TabIndex = 0;
            // 
            // lbMsg
            // 
            this.lbMsg.AutoSize = true;
            this.lbMsg.Location = new System.Drawing.Point(18, 53);
            this.lbMsg.Name = "lbMsg";
            this.lbMsg.Size = new System.Drawing.Size(154, 19);
            this.lbMsg.TabIndex = 1;
            this.lbMsg.Text = "In Progress, please wait...";
            // 
            // picLoading
            // 
            this.picLoading.Image = global::VnSentencesConparator.Properties.Resources.booking_loading;
            this.picLoading.Location = new System.Drawing.Point(160, 73);
            this.picLoading.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(43, 33);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 2;
            this.picLoading.TabStop = false;
            this.picLoading.Visible = false;
            // 
            // FrmProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 126);
            this.ControlBox = false;
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.lbMsg);
            this.Controls.Add(this.progressBar);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(363, 126);
            this.MinimumSize = new System.Drawing.Size(363, 126);
            this.Name = "FrmProgressDialog";
            this.Padding = new System.Windows.Forms.Padding(20, 56, 20, 18);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Processing";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmProgressDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar progressBar;
        private MetroFramework.Controls.MetroLabel lbMsg;
        private System.Windows.Forms.PictureBox picLoading;
    }
}