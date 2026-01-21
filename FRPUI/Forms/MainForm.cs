using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FRPUI.Models;
using FRPUI.Services;
using FRPUI.Utilities;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FRPUI
{
    public partial class MainForm : Form
    {
        private readonly FrpcService _frpcService;
        private readonly TomlConfigService _configService;
        private readonly string _frpDir;
        private readonly string _configPath;
        private readonly string _exePath;

        public MainForm()
        {
            InitializeComponent();
            
            // Clean up any zombie frpc processes from previous runs
            FrpcService.CleanUpExistingProcesses();

            _frpDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "frp");
            _exePath = Path.Combine(_frpDir, "frpc.exe");
            _configPath = Path.Combine(_frpDir, "frpc.toml");

            _frpcService = new FrpcService(_exePath, _configPath);
            _configService = new TomlConfigService(_configPath);

            // Wire up events
            _frpcService.OnLogReceived += FrpcService_OnLogReceived;
            _frpcService.OnStateChanged += FrpcService_OnStateChanged;
            
            this.FormClosing += MainForm_FormClosing;

            // Initial Load
            LoadConfigInfo();
            LoadEditorContent();
            
            tmrMonitor.Start();
        }

        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_frpcService.IsRunning)
            {
                e.Cancel = true; // Delay close
                this.Hide(); // Hide UI while stopping
                await _frpcService.StopAsync();
                this.FormClosing -= MainForm_FormClosing;
                this.Close();
            }
        }

        private void LoadConfigInfo()
        {
            var summary = _configService.ParseSummary();
            lblServerAddr.Text = $"Server Addr: {summary.ServerAddr}";
            lblServerPort.Text = $"Server Port: {summary.ServerPort}";
            lblProxies.Text = $"Proxies: {summary.ProxyCount}";
        }

        private void LoadEditorContent()
        {
            txtEditor.Text = _configService.Load();
        }

        private void FrpcService_OnStateChanged(AppState state)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => FrpcService_OnStateChanged(state)));
                return;
            }

            switch (state)
            {
                case AppState.Running:
                    lblStatus.Text = "Running";
                    lblStatus.ForeColor = Color.Green;
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    tmrUptime.Start();
                    break;
                case AppState.Stopped:
                    lblStatus.Text = "Stopped";
                    lblStatus.ForeColor = Color.Red;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    tmrUptime.Stop();
                    lblUptime.Text = "Uptime: 00:00:00";
                    break;
                case AppState.Crashed:
                    lblStatus.Text = "Exited";
                    lblStatus.ForeColor = Color.OrangeRed;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    tmrUptime.Stop();
                    break;
            }
        }

        private void FrpcService_OnLogReceived(string line, bool isError)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => FrpcService_OnLogReceived(line, isError)));
                return;
            }

            if (string.IsNullOrWhiteSpace(line)) return;

            string timestamp = DateTime.Now.ToString("HH:mm:ss");
            string prefix = isError ? "[ERR]" : "[OUT]";
            
            // Append Timestamp and Prefix with default colors
            rtbLogs.SelectionColor = Color.Gray; 
            rtbLogs.AppendText($"{timestamp} ");
            rtbLogs.SelectionColor = isError ? Color.Red : Color.DarkGray;
            rtbLogs.AppendText($"{prefix} ");

            // Default color for the message
            Color defaultColor = Color.LightGray;
            rtbLogs.SelectionColor = defaultColor;

            // Simple ANSI parser regex: Matches ESC [ code(s) m
            // Example match: \x1B[1;34m
            var parts = System.Text.RegularExpressions.Regex.Split(line, @"(\x1B\[[0-9;]*m)");

            foreach (var part in parts)
            {
                if (part.StartsWith("\x1B["))
                {
                    // It is a code, parse it
                    // Remove \x1B[ and m, then split by ;
                    try 
                    {
                        var codeContent = part.Substring(2, part.Length - 3);
                        var codes = codeContent.Split(';');
                        foreach (var codeStr in codes)
                        {
                            if (int.TryParse(codeStr, out int c))
                            {
                               ParseAnsiCode(c, ref defaultColor);
                            }
                        }
                    }
                    catch { /* Ignore parsing errors */ }
                }
                else
                {
                     rtbLogs.AppendText(part);
                }
            }
            
            rtbLogs.AppendText(Environment.NewLine);

            if (chkAutoScroll.Checked)
            {
                rtbLogs.SelectionStart = rtbLogs.Text.Length;
                rtbLogs.ScrollToCaret();
            }

            if (rtbLogs.Lines.Length > 2000)
            {
                 rtbLogs.Text = string.Empty; 
            }
        }
        
        private void ParseAnsiCode(int code, ref Color defaultColor)
        {
            switch(code)
            {
               case 0: rtbLogs.SelectionColor = Color.LightGray; break; // Reset
               case 1: /* Bold - could make font bold, but for now just ignore or map to bright color if needed */ break;
               
               // Standard Foreground
               case 30: rtbLogs.SelectionColor = Color.Black; break;
               case 31: rtbLogs.SelectionColor = Color.IndianRed; break;
               case 32: rtbLogs.SelectionColor = Color.LightGreen; break;
               case 33: rtbLogs.SelectionColor = Color.Yellow; break;
               case 34: rtbLogs.SelectionColor = Color.CornflowerBlue; break; 
               case 35: rtbLogs.SelectionColor = Color.Magenta; break;
               case 36: rtbLogs.SelectionColor = Color.Cyan; break;
               case 37: rtbLogs.SelectionColor = Color.White; break;
            }
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                rtbLogs.Clear();
                btnStart.Enabled = false; 
                await _frpcService.StartAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to start: {ex.Message}");
                btnStart.Enabled = true;
            }
        }

        private async void btnStop_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            await _frpcService.StopAsync();
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = _frpDir,
                UseShellExecute = true
            });
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            rtbLogs.Clear();
        }

        private void tmrUptime_Tick(object sender, EventArgs e)
        {
            if (_frpcService.IsRunning && _frpcService.StartTime.HasValue)
            {
                var span = DateTime.Now - _frpcService.StartTime.Value;
                lblUptime.Text = $"Uptime: {span:hh\\:mm\\:ss}";
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            LoadEditorContent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveConfig(false);
        }

        private async void btnSaveRestart_Click(object sender, EventArgs e)
        {
            if (_frpcService.IsRunning)
            {
                 var result = MessageBox.Show(
                     "frpc is currently running. Restart now?",
                     "Confirm Restart",
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                 
                 if (result == DialogResult.Yes)
                 {
                     if (SaveConfig(true))
                     {
                         await _frpcService.StopAsync();
                         await Task.Delay(500); // clear buffers
                         await _frpcService.StartAsync();
                     }
                 }
            }
            else
            {
                SaveConfig(false);
            }
        }

        private bool SaveConfig(bool silent)
        {
            string content = txtEditor.Text;
            try
            {
                _configService.Save(content);
                LoadConfigInfo(); // Update summary
                if (!silent) MessageBox.Show("Configuration saved successfully.");
                return true;
            }
            catch (Exception ex)
            {
                 MessageBox.Show($"Error saving config (Check TOML syntax):\n{ex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
            }
        }


        // TOOL: Local Server
        private SimpleHttpServer? _localServer;

        private void btnServerAction_Click(object sender, EventArgs e)
        {
            if (_localServer != null && _localServer.IsListening)
            {
                // Stop it
                _localServer.Stop();
                _localServer = null;
                btnServerAction.Text = "Start Server";
                lblServerStatus.Text = "Status: Stopped";
                lblServerStatus.ForeColor = Color.Black;
                numServerPort.Enabled = true;
                
                LogTool("Local Server stopped.");
            }
            else
            {
                // Start it
                int port = (int)numServerPort.Value;
                string root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot");
                if (!Directory.Exists(root)) Directory.CreateDirectory(root);

                // Create a dummy index file if empty
                if (!File.Exists(Path.Combine(root, "index.html")))
                {
                    File.WriteAllText(Path.Combine(root, "index.html"), "<h1>Hello from FRPUI Local Server</h1>");
                }

                _localServer = new SimpleHttpServer(root, port);
                
                // Optional: hook logging if we want to show requests in main log or separate?
                // For now, let's just log start/stop to main log 
                _localServer.OnLog += (msg) => LogTool($"[Server] {msg}");

                try 
                {
                    _localServer.Start();
                    btnServerAction.Text = "Stop Server";
                    lblServerStatus.Text = $"Status: Running on port {port}";
                    lblServerStatus.ForeColor = Color.Green;
                    numServerPort.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to start server: " + ex.Message);
                    _localServer = null;
                }
            }
        }

        // TOOL: Port Checker
        private async void btnCheckPort_Click(object sender, EventArgs e)
        {
            string host = txtCheckHost.Text.Trim();
            int port = (int)numCheckPort.Value;
            
            if (string.IsNullOrEmpty(host)) return;

            btnCheckPort.Enabled = false;
            lblCheckResult.Text = "Checking...";
            lblCheckResult.ForeColor = Color.Blue;

            bool isOpen = await Task.Run(() => 
            {
                try
                {
                    using (var client = new System.Net.Sockets.TcpClient())
                    {
                        var result = client.BeginConnect(host, port, null, null);
                        var success = result.AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(3));
                        if (!success) return false;
                        client.EndConnect(result);
                        return true;
                    }
                }
                catch
                {
                    return false;
                }
            });

            btnCheckPort.Enabled = true;
            if (isOpen)
            {
                lblCheckResult.Text = $"Result: {host}:{port} is OPEN";
                lblCheckResult.ForeColor = Color.Green;
                LogTool($"[PortCheck] {host}:{port} is OPEN");
            }
            else
            {
                lblCheckResult.Text = $"Result: {host}:{port} is CLOSED (or Timeout)";
                lblCheckResult.ForeColor = Color.Red;
                LogTool($"[PortCheck] {host}:{port} is CLOSED");
            }
        }

        // TOOL: Public IP
        private async void btnPublicIp_Click(object sender, EventArgs e)
        {
            btnPublicIp.Enabled = false;
            lblPublicIp.Text = "Fetching...";
            
            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(5);
                    string ip = await httpClient.GetStringAsync("https://api.ipify.org");
                    lblPublicIp.Text = $"IP: {ip}";
                    LogTool($"Public IP: {ip}");
                }
            }
            catch (Exception ex)
            {
                lblPublicIp.Text = "Error";
                MessageBox.Show("Failed to get IP: " + ex.Message);
            }
            finally
            {
                btnPublicIp.Enabled = true;
            }
        }

        // TOOL: Ping FRP Server
        private async void btnPingServer_Click(object sender, EventArgs e)
        {
             var summary = _configService.ParseSummary();
             string host = summary.ServerAddr;
             
             if (string.IsNullOrEmpty(host))
             {
                 MessageBox.Show("Server address not found in config.");
                 return;
             }

             btnPingServer.Enabled = false;
             lblPingResult.Text = "Pinging...";

             try
             {
                 using (var pinger = new System.Net.NetworkInformation.Ping())
                 {
                     var reply = await pinger.SendPingAsync(host, 2000);
                     if (reply.Status == System.Net.NetworkInformation.IPStatus.Success)
                     {
                         lblPingResult.Text = $"{reply.RoundtripTime} ms";
                         lblPingResult.ForeColor = Color.Green;
                         LogTool($"Ping {host}: {reply.RoundtripTime} ms");
                     }
                     else
                     {
                         lblPingResult.Text = reply.Status.ToString();
                         lblPingResult.ForeColor = Color.Red;
                         LogTool($"Ping {host} failed: {reply.Status}");
                     }
                 }
             }
             catch (Exception ex)
             {
                 lblPingResult.Text = "Error";
                 lblPingResult.ForeColor = Color.Red;
                 MessageBox.Show("Ping failed: " + ex.Message);
             }
             finally
             {
                 btnPingServer.Enabled = true;
             }
        }

        // TOOL: Process Monitor
        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            if (_frpcService.IsRunning)
            {
                var (mem, cpu) = _frpcService.GetProcessMetrics();
                double ramMb = mem / 1024.0 / 1024.0;
                lblRamUsage.Text = $"RAM Usage: {ramMb:F2} MB";
                lblCpuTime.Text = $"CPU Time: {cpu.Hours:00}:{cpu.Minutes:00}:{cpu.Seconds:00}";
            }
            else
            {
                lblRamUsage.Text = "RAM Usage: -";
                lblCpuTime.Text = "CPU Time: -";
            }
        }

        private void LogTool(string msg)
        {
             // Inject into main log with purple color or similar prefix
             if (InvokeRequired)
             {
                 Invoke(new Action(() => LogTool(msg)));
                 return;
             }
             
             string timestamp = DateTime.Now.ToString("HH:mm:ss");
             rtbLogs.SelectionColor = Color.Cyan; // Cyan for tools
             rtbLogs.AppendText($"{timestamp} [TOOL] {msg}{Environment.NewLine}");
             
             if (chkAutoScroll.Checked)
             {
                 rtbLogs.ScrollToCaret();
             }
        }
    }
}
