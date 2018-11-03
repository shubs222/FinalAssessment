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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.SharepointTabController = new System.Windows.Forms.TabControl();
            this.SlectFolderTab = new System.Windows.Forms.TabPage();
            this.UploadFolderTab = new System.Windows.Forms.TabPage();
            this.UploadButton = new System.Windows.Forms.Button();
            this.ReportsTab = new System.Windows.Forms.TabPage();
            this.UploadProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressBarTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ExitPitcherBox = new System.Windows.Forms.PictureBox();
            this.MaximizePitcherBox = new System.Windows.Forms.PictureBox();
            this.MinimizePitcherBox = new System.Windows.Forms.PictureBox();
            this.SharepointTabController.SuspendLayout();
            this.SlectFolderTab.SuspendLayout();
            this.UploadFolderTab.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExitPitcherBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizePitcherBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePitcherBox)).BeginInit();
            this.SuspendLayout();
            // 
            // SharepointTabController
            // 
            this.SharepointTabController.Controls.Add(this.SlectFolderTab);
            this.SharepointTabController.Controls.Add(this.UploadFolderTab);
            this.SharepointTabController.Controls.Add(this.ReportsTab);
            this.SharepointTabController.Location = new System.Drawing.Point(25, 48);
            this.SharepointTabController.Name = "SharepointTabController";
            this.SharepointTabController.Padding = new System.Drawing.Point(10, 10);
            this.SharepointTabController.SelectedIndex = 0;
            this.SharepointTabController.Size = new System.Drawing.Size(700, 390);
            this.SharepointTabController.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.SharepointTabController.TabIndex = 0;
            // 
            // SlectFolderTab
            // 
            this.SlectFolderTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.SlectFolderTab.Controls.Add(this.panel1);
            this.SlectFolderTab.ForeColor = System.Drawing.Color.Ivory;
            this.SlectFolderTab.Location = new System.Drawing.Point(4, 36);
            this.SlectFolderTab.Name = "SlectFolderTab";
            this.SlectFolderTab.Padding = new System.Windows.Forms.Padding(3);
            this.SlectFolderTab.Size = new System.Drawing.Size(692, 350);
            this.SlectFolderTab.TabIndex = 0;
            this.SlectFolderTab.Text = "SlectFolder";
            // 
            // UploadFolderTab
            // 
            this.UploadFolderTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.UploadFolderTab.Controls.Add(this.UploadProgressBar);
            this.UploadFolderTab.Controls.Add(this.UploadButton);
            this.UploadFolderTab.Location = new System.Drawing.Point(4, 36);
            this.UploadFolderTab.Name = "UploadFolderTab";
            this.UploadFolderTab.Padding = new System.Windows.Forms.Padding(3);
            this.UploadFolderTab.Size = new System.Drawing.Size(1292, 350);
            this.UploadFolderTab.TabIndex = 1;
            this.UploadFolderTab.Text = "UploadFolder";
            // 
            // UploadButton
            // 
            this.UploadButton.ForeColor = System.Drawing.Color.Black;
            this.UploadButton.Location = new System.Drawing.Point(279, 268);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(121, 48);
            this.UploadButton.TabIndex = 0;
            this.UploadButton.Text = "Upload";
            this.UploadButton.UseVisualStyleBackColor = true;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // ReportsTab
            // 
            this.ReportsTab.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ReportsTab.Location = new System.Drawing.Point(4, 36);
            this.ReportsTab.Name = "ReportsTab";
            this.ReportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReportsTab.Size = new System.Drawing.Size(1292, 350);
            this.ReportsTab.TabIndex = 0;
            this.ReportsTab.Text = "Reports";
            // 
            // UploadProgressBar
            // 
            this.UploadProgressBar.Location = new System.Drawing.Point(228, 335);
            this.UploadProgressBar.Name = "UploadProgressBar";
            this.UploadProgressBar.Size = new System.Drawing.Size(222, 23);
            this.UploadProgressBar.TabIndex = 1;
            this.UploadProgressBar.Visible = false;
            // 
            // ProgressBarTimer
            // 
            this.ProgressBarTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-30, -85);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(485, 43);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(200)))));
            this.panel2.Controls.Add(this.MinimizePitcherBox);
            this.panel2.Controls.Add(this.MaximizePitcherBox);
            this.panel2.Controls.Add(this.ExitPitcherBox);
            this.panel2.Location = new System.Drawing.Point(-2, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(750, 41);
            this.panel2.TabIndex = 1;
            // 
            // ExitPitcherBox
            // 
            this.ExitPitcherBox.Image = ((System.Drawing.Image)(resources.GetObject("ExitPitcherBox.Image")));
            this.ExitPitcherBox.Location = new System.Drawing.Point(1247, 11);
            this.ExitPitcherBox.Name = "ExitPitcherBox";
            this.ExitPitcherBox.Size = new System.Drawing.Size(43, 27);
            this.ExitPitcherBox.TabIndex = 0;
            this.ExitPitcherBox.TabStop = false;
            // 
            // MaximizePitcherBox
            // 
            this.MaximizePitcherBox.Location = new System.Drawing.Point(1198, 11);
            this.MaximizePitcherBox.Name = "MaximizePitcherBox";
            this.MaximizePitcherBox.Size = new System.Drawing.Size(43, 27);
            this.MaximizePitcherBox.TabIndex = 1;
            this.MaximizePitcherBox.TabStop = false;
            // 
            // MinimizePitcherBox
            // 
            this.MinimizePitcherBox.Location = new System.Drawing.Point(1149, 11);
            this.MinimizePitcherBox.Name = "MinimizePitcherBox";
            this.MinimizePitcherBox.Size = new System.Drawing.Size(43, 27);
            this.MinimizePitcherBox.TabIndex = 2;
            this.MinimizePitcherBox.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(750, 650);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.SharepointTabController);
            this.ForeColor = System.Drawing.Color.PaleGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "Sharepoint";
            this.Load += new System.EventHandler(this.Main_Load);
            this.SharepointTabController.ResumeLayout(false);
            this.SlectFolderTab.ResumeLayout(false);
            this.UploadFolderTab.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ExitPitcherBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaximizePitcherBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinimizePitcherBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl SharepointTabController;
        private System.Windows.Forms.TabPage SlectFolderTab;
        
        private System.Windows.Forms.TabPage UploadFolderTab;
        private System.Windows.Forms.TabPage ReportsTab;
        private System.Windows.Forms.Button UploadButton;
        private System.Windows.Forms.ProgressBar UploadProgressBar;
        private System.Windows.Forms.Timer ProgressBarTimer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox MinimizePitcherBox;
        private System.Windows.Forms.PictureBox MaximizePitcherBox;
        private System.Windows.Forms.PictureBox ExitPitcherBox;
    }
}

