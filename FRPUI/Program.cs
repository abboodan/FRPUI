using System;
using System.IO;
using System.Windows.Forms;
using FRPUI.Forms;
using FRPUI.Services;

namespace FRPUI
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Handle global exceptions
            Application.ThreadException += (s, e) => MessageBox.Show($"Unexpected error: {e.Exception.Message}", "Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);
            AppDomain.CurrentDomain.UnhandledException += (s, e) => MessageBox.Show($"Fatal error: {(e.ExceptionObject as Exception)?.Message}", "Crash", MessageBoxButtons.OK, MessageBoxIcon.Error);

            string frpDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frp");
            var checkService = new FileCheckService(frpDir);

            if (checkService.AreFilesMissing())
            {
                var setup = new SetupDialog(frpDir);
                var result = setup.ShowDialog();
                if (result != DialogResult.OK)
                {
                    // User cancelled or didn't resolve
                    return;
                }
            }

            // Re-check just in case
            if (checkService.AreFilesMissing())
            {
                MessageBox.Show("Files required to run are still missing. Exiting.");
                return;
            }

            Application.Run(new MainForm());
        }
    }
}