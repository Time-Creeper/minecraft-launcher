using System;
using System.Diagnostics;
using System.Net;
using System.Windows.Forms;

namespace MinecraftLauncher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            string url = "https://example.com/minecraftpe.exe"; // URL to download
            string filename = "minecraftpe.exe"; // Destination filename
            using (WebClient webClient = new WebClient())
            {
                webClient.DownloadFileCompleted += (s, ev) =>
                {
                    lblStatus.Text = "Download complete!";
                };
                lblStatus.Text = "Downloading...";
                webClient.DownloadFileAsync(new Uri(url), filename);
            }
        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("minecraftpe.exe"); // Launch the game
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Error launching the game: " + ex.Message;
            }
        }

        private void InitializeComponent()
        {
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(50, 50);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(200, 30);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Download Minecraft PE";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new EventHandler(btnDownload_Click);
            // 
            // btnLaunch
            // 
            this.btnLaunch.Location = new System.Drawing.Point(50, 100);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(200, 30);
            this.btnLaunch.TabIndex = 1;
            this.btnLaunch.Text = "Launch Minecraft PE";
            this.btnLaunch.UseVisualStyleBackColor = true;
            this.btnLaunch.Click += new EventHandler(btnLaunch_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(50, 150);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 13);
            this.lblStatus.TabIndex = 2;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.btnDownload);
            this.Name = "MainForm";
            this.Text = "Minecraft PE Launcher";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label lblStatus;
}