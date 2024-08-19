namespace DOTRMap.DOTRMap
{
    partial class frmAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAbout));
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAboutText = new System.Windows.Forms.Label();
            this.lblSupport = new System.Windows.Forms.Label();
            this.llblSupport = new System.Windows.Forms.LinkLabel();
            this.lblGithub = new System.Windows.Forms.Label();
            this.llblGitHub = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(13, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(189, 29);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "About DOTRMap";
            // 
            // lblAboutText
            // 
            this.lblAboutText.AutoSize = true;
            this.lblAboutText.Location = new System.Drawing.Point(18, 46);
            this.lblAboutText.Name = "lblAboutText";
            this.lblAboutText.Size = new System.Drawing.Size(0, 13);
            this.lblAboutText.TabIndex = 1;
            // 
            // lblSupport
            // 
            this.lblSupport.AutoSize = true;
            this.lblSupport.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupport.Location = new System.Drawing.Point(14, 144);
            this.lblSupport.Name = "lblSupport";
            this.lblSupport.Size = new System.Drawing.Size(138, 19);
            this.lblSupport.TabIndex = 2;
            this.lblSupport.Text = "Support my work:";
            // 
            // llblSupport
            // 
            this.llblSupport.AutoSize = true;
            this.llblSupport.Location = new System.Drawing.Point(15, 163);
            this.llblSupport.Name = "llblSupport";
            this.llblSupport.Size = new System.Drawing.Size(189, 13);
            this.llblSupport.TabIndex = 3;
            this.llblSupport.TabStop = true;
            this.llblSupport.Text = "https://buymeacoffee.com/hippochan";
            this.llblSupport.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblSupport_LinkClicked);
            // 
            // lblGithub
            // 
            this.lblGithub.AutoSize = true;
            this.lblGithub.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGithub.Location = new System.Drawing.Point(14, 99);
            this.lblGithub.Name = "lblGithub";
            this.lblGithub.Size = new System.Drawing.Size(180, 19);
            this.lblGithub.TabIndex = 4;
            this.lblGithub.Text = "View project on GitHub:";
            // 
            // llblGitHub
            // 
            this.llblGitHub.AutoSize = true;
            this.llblGitHub.Location = new System.Drawing.Point(15, 118);
            this.llblGitHub.Name = "llblGitHub";
            this.llblGitHub.Size = new System.Drawing.Size(183, 13);
            this.llblGitHub.TabIndex = 5;
            this.llblGitHub.TabStop = true;
            this.llblGitHub.Text = "https://github.com/rjoken/DOTRMap";
            this.llblGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llblGitHub_LinkClicked);
            // 
            // frmAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 211);
            this.Controls.Add(this.llblGitHub);
            this.Controls.Add(this.lblGithub);
            this.Controls.Add(this.llblSupport);
            this.Controls.Add(this.lblSupport);
            this.Controls.Add(this.lblAboutText);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAbout";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "About DOTRMap";
            this.Load += new System.EventHandler(this.frmAbout_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAboutText;
        private System.Windows.Forms.Label lblSupport;
        private System.Windows.Forms.LinkLabel llblSupport;
        private System.Windows.Forms.Label lblGithub;
        private System.Windows.Forms.LinkLabel llblGitHub;
    }
}