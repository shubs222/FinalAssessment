namespace UploadFolder
{
    partial class Main
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
            this.SharepointTabController = new System.Windows.Forms.TabControl();
            this.SlectFolderTab = new System.Windows.Forms.TabPage();
            this.UploadFolderTab = new System.Windows.Forms.TabPage();
            this.UploadButton = new System.Windows.Forms.Button();
            this.ReportsTab = new System.Windows.Forms.TabPage();
            this.UploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.SharepointTabController.SuspendLayout();
            this.UploadFolderTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // SharepointTabController
            // 
            this.SharepointTabController.Controls.Add(this.SlectFolderTab);
            this.SharepointTabController.Controls.Add(this.UploadFolderTab);
            this.SharepointTabController.Controls.Add(this.ReportsTab);
            this.SharepointTabController.Location = new System.Drawing.Point(25, 3);
            this.SharepointTabController.Name = "SharepointTabController";
            this.SharepointTabController.Padding = new System.Drawing.Point(10, 10);
            this.SharepointTabController.SelectedIndex = 0;
            this.SharepointTabController.Size = new System.Drawing.Size(763, 415);
            this.SharepointTabController.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.SharepointTabController.TabIndex = 0;
            // 
            // SlectFolderTab
            // 
            this.SlectFolderTab.Location = new System.Drawing.Point(4, 36);
            this.SlectFolderTab.Name = "SlectFolderTab";
            this.SlectFolderTab.Padding = new System.Windows.Forms.Padding(3);
            this.SlectFolderTab.Size = new System.Drawing.Size(755, 375);
            this.SlectFolderTab.TabIndex = 0;
            this.SlectFolderTab.Text = "SlectFolder";
            this.SlectFolderTab.UseVisualStyleBackColor = true;
            // 
            // UploadFolderTab
            // 
            this.UploadFolderTab.Controls.Add(this.UploadProgressBar);
            this.UploadFolderTab.Controls.Add(this.UploadButton);
            this.UploadFolderTab.Location = new System.Drawing.Point(4, 36);
            this.UploadFolderTab.Name = "UploadFolderTab";
            this.UploadFolderTab.Padding = new System.Windows.Forms.Padding(3);
            this.UploadFolderTab.Size = new System.Drawing.Size(755, 375);
            this.UploadFolderTab.TabIndex = 1;
            this.UploadFolderTab.Text = "UploadFolder";
            this.UploadFolderTab.UseVisualStyleBackColor = true;
            // 
            // UploadButton
            // 
            this.UploadButton.ForeColor = System.Drawing.Color.Black;
            this.UploadButton.Location = new System.Drawing.Point(269, 275);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(121, 48);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ReportsTab
            // 
            this.ReportsTab.Location = new System.Drawing.Point(4, 36);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReportsTab.Size = new System.Drawing.Size(755, 375);
            this.ReportsTab.TabIndex = 0;
            this.ReportsTab.Text = "Reports";
            this.ReportsTab.UseVisualStyleBackColor = true;
            // 
            // UploadProgressBar
            // 
            this.UploadProgressBar.Location = new System.Drawing.Point(239, 341);
            this.UploadProgressBar.Name = "UploadProgressBar";
            this.UploadProgressBar.Size = new System.Drawing.Size(196, 28);
            this.UploadProgressBar.TabIndex = 1;
            this.UploadProgressBar.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(808, 450);
            this.Controls.Add(this.SharepointTabController);
            this.ForeColor = System.Drawing.Color.PaleGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Main";
            this.Text = "Sharepoint";
            this.SharepointTabController.ResumeLayout(false);
            this.UploadFolderTab.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SharepointTabController;
        private System.Windows.Forms.TabPage SlectFolderTab;
        
        private System.Windows.Forms.TabPage UploadFolderTab;
        private System.Windows.Forms.TabPage ReportsTab;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.ProgressBar UploadProgressBar;
    }
}

