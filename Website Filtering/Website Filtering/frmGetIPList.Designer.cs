namespace Website_Filtering
{
    partial class frmGetIPList
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
            this.lbURL = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnGetIP = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // lbURL
            // 
            this.lbURL.AutoSize = true;
            this.lbURL.Location = new System.Drawing.Point(29, 29);
            this.lbURL.Name = "lbURL";
            this.lbURL.Size = new System.Drawing.Size(82, 17);
            this.lbURL.TabIndex = 0;
            this.lbURL.Text = "Địa chỉ URL:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(137, 26);
            this.txtURL.Multiline = true;
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(328, 99);
            this.txtURL.TabIndex = 1;
            // 
            // btnGetIP
            // 
            this.btnGetIP.Location = new System.Drawing.Point(177, 156);
            this.btnGetIP.Name = "btnGetIP";
            this.btnGetIP.Size = new System.Drawing.Size(125, 37);
            this.btnGetIP.TabIndex = 3;
            this.btnGetIP.Text = "Tải danh sách IP";
            this.btnGetIP.Click += new System.EventHandler(this.btnGetIP_Click);
            // 
            // frmGetIPList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 222);
            this.Controls.Add(this.btnGetIP);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.lbURL);
            this.Name = "frmGetIPList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Địa chỉ IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbURL;
        private System.Windows.Forms.TextBox txtURL;
        private DevExpress.XtraEditors.SimpleButton btnGetIP;
    }
}