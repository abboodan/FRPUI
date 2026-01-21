using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FRPUI.Services;

namespace FRPUI.Forms
{
    public partial class SetupDialog : Form
    {
        private readonly FileCheckService _fileService;

        public SetupDialog(string frpDir)
        {
            InitializeComponent();
            _fileService = new FileCheckService(frpDir);
            UpdateStatus();
        }

        private void UpdateStatus()
        {
            var (missingExe, missingConfig) = _fileService.GetMissingStatus();

            string msg = "Required files are missing:\n";
            if (missingExe) msg += "- frpc.exe\n";
            if (missingConfig) msg += "- frpc.toml\n";

            lblMessage.Text = msg;

            btnCreateConfig.Enabled = missingConfig;
            btnBrowse.Enabled = missingExe;

            if (!missingExe && !missingConfig)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnOpenGithub_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/fatedier/frp/releases",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Could not open browser: " + ex.Message);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Executables (*.exe)|*.exe";
                ofd.Title = "Locate frpc.exe";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Copy to valid location or just verify?
                    // User requirements say: Default layout is /frp next to app.
                    // So we probably want to COPY it there.
                    try
                    {
                        string destDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frp");
                        if (!Directory.Exists(destDir)) Directory.CreateDirectory(destDir);

                        string destPath = Path.Combine(destDir, "frpc.exe");
                        File.Copy(ofd.FileName, destPath, true);
                        MessageBox.Show("Copied frpc.exe successfully!");
                        UpdateStatus();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error copying file: " + ex.Message);
                    }
                }
            }
        }

        private void btnCreateConfig_Click(object sender, EventArgs e)
        {
            try
            {
                _fileService.CreateDefaultConfig();
                MessageBox.Show("Created default frpc.toml");
                UpdateStatus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error creating config: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UpdateStatus();
            if (_fileService.AreFilesMissing())
            {
                MessageBox.Show("Files are still missing. Please resolve before continuing.");
            }
        }

        private void SetupDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
