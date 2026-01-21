namespace FRPUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tabControlMain = new TabControl();
            tabDashboard = new TabPage();
            splitContainer1 = new SplitContainer();
            grpInfo = new GroupBox();
            btnOpenFolder = new Button();
            lblProxies = new Label();
            lblServerPort = new Label();
            lblServerAddr = new Label();
            grpStatus = new GroupBox();
            lblUptime = new Label();
            lblStatus = new Label();
            btnStop = new Button();
            btnStart = new Button();
            rtbLogs = new RichTextBox();
            panelLogControls = new Panel();
            btnClearLogs = new Button();
            chkAutoScroll = new CheckBox();
            tabEditor = new TabPage();
            txtEditor = new TextBox();
            panelEditorControls = new Panel();
            btnSaveRestart = new Button();
            btnSave = new Button();
            btnReload = new Button();
            tabTools = new TabPage();
            grpPortChecker = new GroupBox();
            lblCheckResult = new Label();
            btnCheckPort = new Button();
            numCheckPort = new NumericUpDown();
            txtCheckHost = new TextBox();
            lblCheckPort = new Label();
            grpLocalServer = new GroupBox();
            lblServerStatus = new Label();
            btnServerAction = new Button();
            numServerPort = new NumericUpDown();
            lblServerPortInput = new Label();
            grpDiagnostics = new GroupBox();
            lblPingResult = new Label();
            btnPingServer = new Button();
            lblPublicIp = new Label();
            btnPublicIp = new Button();
            grpMonitor = new GroupBox();
            lblCpuTime = new Label();
            lblRamUsage = new Label();
            tmrUptime = new System.Windows.Forms.Timer(components);
            tmrMonitor = new System.Windows.Forms.Timer(components);
            tabControlMain.SuspendLayout();
            tabDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            grpInfo.SuspendLayout();
            grpStatus.SuspendLayout();
            panelLogControls.SuspendLayout();
            tabEditor.SuspendLayout();
            panelEditorControls.SuspendLayout();
            tabTools.SuspendLayout();
            grpPortChecker.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCheckPort).BeginInit();
            grpLocalServer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numServerPort).BeginInit();
            grpDiagnostics.SuspendLayout();
            grpMonitor.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabDashboard);
            tabControlMain.Controls.Add(tabEditor);
            tabControlMain.Controls.Add(tabTools);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Margin = new Padding(3, 4, 3, 4);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(914, 667);
            tabControlMain.TabIndex = 0;
            // 
            // tabDashboard
            // 
            tabDashboard.Controls.Add(splitContainer1);
            tabDashboard.Location = new Point(4, 29);
            tabDashboard.Margin = new Padding(3, 4, 3, 4);
            tabDashboard.Name = "tabDashboard";
            tabDashboard.Padding = new Padding(3, 4, 3, 4);
            tabDashboard.Size = new Size(906, 634);
            tabDashboard.TabIndex = 0;
            tabDashboard.Text = "Dashboard";
            tabDashboard.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.FixedPanel = FixedPanel.Panel1;
            splitContainer1.Location = new Point(3, 4);
            splitContainer1.Margin = new Padding(3, 4, 3, 4);
            splitContainer1.Name = "splitContainer1";
            splitContainer1.Orientation = Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(grpInfo);
            splitContainer1.Panel1.Controls.Add(grpStatus);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(rtbLogs);
            splitContainer1.Panel2.Controls.Add(panelLogControls);
            splitContainer1.Size = new Size(900, 626);
            splitContainer1.SplitterDistance = 187;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 0;
            // 
            // grpInfo
            // 
            grpInfo.Controls.Add(btnOpenFolder);
            grpInfo.Controls.Add(lblProxies);
            grpInfo.Controls.Add(lblServerPort);
            grpInfo.Controls.Add(lblServerAddr);
            grpInfo.Location = new Point(366, 13);
            grpInfo.Margin = new Padding(3, 4, 3, 4);
            grpInfo.Name = "grpInfo";
            grpInfo.Padding = new Padding(3, 4, 3, 4);
            grpInfo.Size = new Size(526, 160);
            grpInfo.TabIndex = 1;
            grpInfo.TabStop = false;
            grpInfo.Text = "Configuration Info";
            // 
            // btnOpenFolder
            // 
            btnOpenFolder.Location = new Point(343, 40);
            btnOpenFolder.Margin = new Padding(3, 4, 3, 4);
            btnOpenFolder.Name = "btnOpenFolder";
            btnOpenFolder.Size = new Size(160, 40);
            btnOpenFolder.TabIndex = 3;
            btnOpenFolder.Text = "Open FRP Folder";
            btnOpenFolder.UseVisualStyleBackColor = true;
            btnOpenFolder.Click += btnOpenFolder_Click;
            // 
            // lblProxies
            // 
            lblProxies.AutoSize = true;
            lblProxies.Location = new Point(23, 107);
            lblProxies.Name = "lblProxies";
            lblProxies.Size = new Size(69, 20);
            lblProxies.TabIndex = 2;
            lblProxies.Text = "Proxies: -";
            // 
            // lblServerPort
            // 
            lblServerPort.AutoSize = true;
            lblServerPort.Location = new Point(23, 73);
            lblServerPort.Name = "lblServerPort";
            lblServerPort.Size = new Size(93, 20);
            lblServerPort.TabIndex = 1;
            lblServerPort.Text = "Server Port: -";
            // 
            // lblServerAddr
            // 
            lblServerAddr.AutoSize = true;
            lblServerAddr.Location = new Point(23, 40);
            lblServerAddr.Name = "lblServerAddr";
            lblServerAddr.Size = new Size(100, 20);
            lblServerAddr.TabIndex = 0;
            lblServerAddr.Text = "Server Addr: -";
            // 
            // grpStatus
            // 
            grpStatus.Controls.Add(lblUptime);
            grpStatus.Controls.Add(lblStatus);
            grpStatus.Controls.Add(btnStop);
            grpStatus.Controls.Add(btnStart);
            grpStatus.Location = new Point(11, 13);
            grpStatus.Margin = new Padding(3, 4, 3, 4);
            grpStatus.Name = "grpStatus";
            grpStatus.Padding = new Padding(3, 4, 3, 4);
            grpStatus.Size = new Size(343, 160);
            grpStatus.TabIndex = 0;
            grpStatus.TabStop = false;
            grpStatus.Text = "Control";
            // 
            // lblUptime
            // 
            lblUptime.AutoSize = true;
            lblUptime.Location = new Point(126, 113);
            lblUptime.Name = "lblUptime";
            lblUptime.Size = new Size(119, 20);
            lblUptime.TabIndex = 3;
            lblUptime.Text = "Uptime: 00:00:00";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Red;
            lblStatus.Location = new Point(23, 107);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(90, 28);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Stopped";
            // 
            // btnStop
            // 
            btnStop.Enabled = false;
            btnStop.Location = new Point(126, 40);
            btnStop.Margin = new Padding(3, 4, 3, 4);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(91, 53);
            btnStop.TabIndex = 1;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(23, 40);
            btnStart.Margin = new Padding(3, 4, 3, 4);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(91, 53);
            btnStart.TabIndex = 0;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // rtbLogs
            // 
            rtbLogs.BackColor = Color.Black;
            rtbLogs.Dock = DockStyle.Fill;
            rtbLogs.Font = new Font("Consolas", 10F);
            rtbLogs.ForeColor = Color.LightGray;
            rtbLogs.Location = new Point(0, 40);
            rtbLogs.Margin = new Padding(3, 4, 3, 4);
            rtbLogs.Name = "rtbLogs";
            rtbLogs.ReadOnly = true;
            rtbLogs.Size = new Size(900, 394);
            rtbLogs.TabIndex = 1;
            rtbLogs.Text = "";
            // 
            // panelLogControls
            // 
            panelLogControls.Controls.Add(btnClearLogs);
            panelLogControls.Controls.Add(chkAutoScroll);
            panelLogControls.Dock = DockStyle.Top;
            panelLogControls.Location = new Point(0, 0);
            panelLogControls.Margin = new Padding(3, 4, 3, 4);
            panelLogControls.Name = "panelLogControls";
            panelLogControls.Size = new Size(900, 40);
            panelLogControls.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            btnClearLogs.Location = new Point(114, 4);
            btnClearLogs.Margin = new Padding(3, 4, 3, 4);
            btnClearLogs.Name = "btnClearLogs";
            btnClearLogs.Size = new Size(86, 31);
            btnClearLogs.TabIndex = 1;
            btnClearLogs.Text = "Clear";
            btnClearLogs.UseVisualStyleBackColor = true;
            btnClearLogs.Click += btnClearLogs_Click;
            // 
            // chkAutoScroll
            // 
            chkAutoScroll.AutoSize = true;
            chkAutoScroll.Checked = true;
            chkAutoScroll.CheckState = CheckState.Checked;
            chkAutoScroll.Location = new Point(11, 7);
            chkAutoScroll.Margin = new Padding(3, 4, 3, 4);
            chkAutoScroll.Name = "chkAutoScroll";
            chkAutoScroll.Size = new Size(104, 24);
            chkAutoScroll.TabIndex = 0;
            chkAutoScroll.Text = "Auto Scroll";
            chkAutoScroll.UseVisualStyleBackColor = true;
            // 
            // tabEditor
            // 
            tabEditor.Controls.Add(txtEditor);
            tabEditor.Controls.Add(panelEditorControls);
            tabEditor.Location = new Point(4, 29);
            tabEditor.Margin = new Padding(3, 4, 3, 4);
            tabEditor.Name = "tabEditor";
            tabEditor.Padding = new Padding(3, 4, 3, 4);
            tabEditor.Size = new Size(906, 634);
            tabEditor.TabIndex = 1;
            tabEditor.Text = "Config Editor";
            tabEditor.UseVisualStyleBackColor = true;
            // 
            // txtEditor
            // 
            txtEditor.AcceptsReturn = true;
            txtEditor.AcceptsTab = true;
            txtEditor.Dock = DockStyle.Fill;
            txtEditor.Font = new Font("Consolas", 11F);
            txtEditor.Location = new Point(3, 4);
            txtEditor.Margin = new Padding(3, 4, 3, 4);
            txtEditor.Multiline = true;
            txtEditor.Name = "txtEditor";
            txtEditor.ScrollBars = ScrollBars.Both;
            txtEditor.Size = new Size(900, 559);
            txtEditor.TabIndex = 1;
            txtEditor.WordWrap = false;
            // 
            // panelEditorControls
            // 
            panelEditorControls.Controls.Add(btnSaveRestart);
            panelEditorControls.Controls.Add(btnSave);
            panelEditorControls.Controls.Add(btnReload);
            panelEditorControls.Dock = DockStyle.Bottom;
            panelEditorControls.Location = new Point(3, 563);
            panelEditorControls.Margin = new Padding(3, 4, 3, 4);
            panelEditorControls.Name = "panelEditorControls";
            panelEditorControls.Size = new Size(900, 67);
            panelEditorControls.TabIndex = 0;
            // 
            // btnSaveRestart
            // 
            btnSaveRestart.Location = new Point(720, 13);
            btnSaveRestart.Margin = new Padding(3, 4, 3, 4);
            btnSaveRestart.Name = "btnSaveRestart";
            btnSaveRestart.Size = new Size(171, 40);
            btnSaveRestart.TabIndex = 2;
            btnSaveRestart.Text = "Save & Restart";
            btnSaveRestart.UseVisualStyleBackColor = true;
            btnSaveRestart.Click += btnSaveRestart_Click;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(594, 13);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(114, 40);
            btnSave.TabIndex = 1;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnReload
            // 
            btnReload.Location = new Point(11, 13);
            btnReload.Margin = new Padding(3, 4, 3, 4);
            btnReload.Name = "btnReload";
            btnReload.Size = new Size(114, 40);
            btnReload.TabIndex = 0;
            btnReload.Text = "Reload File";
            btnReload.UseVisualStyleBackColor = true;
            btnReload.Click += btnReload_Click;
            // 
            // tabTools
            // 
            tabTools.Controls.Add(grpPortChecker);
            tabTools.Controls.Add(grpLocalServer);
            tabTools.Controls.Add(grpDiagnostics);
            tabTools.Controls.Add(grpMonitor);
            tabTools.Location = new Point(4, 29);
            tabTools.Margin = new Padding(3, 4, 3, 4);
            tabTools.Name = "tabTools";
            tabTools.Padding = new Padding(3, 4, 3, 4);
            tabTools.Size = new Size(906, 634);
            tabTools.TabIndex = 2;
            tabTools.Text = "Tools";
            tabTools.UseVisualStyleBackColor = true;
            // 
            // grpPortChecker
            // 
            grpPortChecker.Controls.Add(lblCheckResult);
            grpPortChecker.Controls.Add(btnCheckPort);
            grpPortChecker.Controls.Add(numCheckPort);
            grpPortChecker.Controls.Add(txtCheckHost);
            grpPortChecker.Controls.Add(lblCheckPort);
            grpPortChecker.Location = new Point(457, 27);
            grpPortChecker.Margin = new Padding(3, 4, 3, 4);
            grpPortChecker.Name = "grpPortChecker";
            grpPortChecker.Padding = new Padding(3, 4, 3, 4);
            grpPortChecker.Size = new Size(400, 200);
            grpPortChecker.TabIndex = 1;
            grpPortChecker.TabStop = false;
            grpPortChecker.Text = "Port Checker";
            // 
            // lblCheckResult
            // 
            lblCheckResult.AutoSize = true;
            lblCheckResult.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCheckResult.Location = new Point(23, 147);
            lblCheckResult.Name = "lblCheckResult";
            lblCheckResult.Size = new Size(67, 20);
            lblCheckResult.TabIndex = 5;
            lblCheckResult.Text = "Result: -";
            // 
            // btnCheckPort
            // 
            btnCheckPort.Location = new Point(183, 87);
            btnCheckPort.Margin = new Padding(3, 4, 3, 4);
            btnCheckPort.Name = "btnCheckPort";
            btnCheckPort.Size = new Size(114, 37);
            btnCheckPort.TabIndex = 4;
            btnCheckPort.Text = "Check";
            btnCheckPort.UseVisualStyleBackColor = true;
            btnCheckPort.Click += btnCheckPort_Click;
            // 
            // numCheckPort
            // 
            numCheckPort.Location = new Point(69, 91);
            numCheckPort.Margin = new Padding(3, 4, 3, 4);
            numCheckPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numCheckPort.Name = "numCheckPort";
            numCheckPort.Size = new Size(91, 27);
            numCheckPort.TabIndex = 3;
            numCheckPort.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // txtCheckHost
            // 
            txtCheckHost.Location = new Point(69, 43);
            txtCheckHost.Margin = new Padding(3, 4, 3, 4);
            txtCheckHost.Name = "txtCheckHost";
            txtCheckHost.Size = new Size(171, 27);
            txtCheckHost.TabIndex = 1;
            txtCheckHost.Text = "127.0.0.1";
            // 
            // lblCheckPort
            // 
            lblCheckPort.AutoSize = true;
            lblCheckPort.Location = new Point(23, 93);
            lblCheckPort.Name = "lblCheckPort";
            lblCheckPort.Size = new Size(38, 20);
            lblCheckPort.TabIndex = 2;
            lblCheckPort.Text = "Port:";
            // 
            // grpLocalServer
            // 
            grpLocalServer.Controls.Add(lblServerStatus);
            grpLocalServer.Controls.Add(btnServerAction);
            grpLocalServer.Controls.Add(numServerPort);
            grpLocalServer.Controls.Add(lblServerPortInput);
            grpLocalServer.Location = new Point(23, 27);
            grpLocalServer.Margin = new Padding(3, 4, 3, 4);
            grpLocalServer.Name = "grpLocalServer";
            grpLocalServer.Padding = new Padding(3, 4, 3, 4);
            grpLocalServer.Size = new Size(400, 200);
            grpLocalServer.TabIndex = 0;
            grpLocalServer.TabStop = false;
            grpLocalServer.Text = "Local Test HTTP Server";
            // 
            // lblServerStatus
            // 
            lblServerStatus.AutoSize = true;
            lblServerStatus.Location = new Point(23, 93);
            lblServerStatus.Name = "lblServerStatus";
            lblServerStatus.Size = new Size(113, 20);
            lblServerStatus.TabIndex = 3;
            lblServerStatus.Text = "Status: Stopped";
            // 
            // btnServerAction
            // 
            btnServerAction.Location = new Point(183, 40);
            btnServerAction.Margin = new Padding(3, 4, 3, 4);
            btnServerAction.Name = "btnServerAction";
            btnServerAction.Size = new Size(114, 37);
            btnServerAction.TabIndex = 2;
            btnServerAction.Text = "Start Server";
            btnServerAction.UseVisualStyleBackColor = true;
            btnServerAction.Click += btnServerAction_Click;
            // 
            // numServerPort
            // 
            numServerPort.Location = new Point(69, 43);
            numServerPort.Margin = new Padding(3, 4, 3, 4);
            numServerPort.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numServerPort.Name = "numServerPort";
            numServerPort.Size = new Size(91, 27);
            numServerPort.TabIndex = 1;
            numServerPort.Value = new decimal(new int[] { 9000, 0, 0, 0 });
            // 
            // lblServerPortInput
            // 
            lblServerPortInput.AutoSize = true;
            lblServerPortInput.Location = new Point(23, 47);
            lblServerPortInput.Name = "lblServerPortInput";
            lblServerPortInput.Size = new Size(38, 20);
            lblServerPortInput.TabIndex = 0;
            lblServerPortInput.Text = "Port:";
            // 
            // grpDiagnostics
            // 
            grpDiagnostics.Controls.Add(lblPingResult);
            grpDiagnostics.Controls.Add(btnPingServer);
            grpDiagnostics.Controls.Add(lblPublicIp);
            grpDiagnostics.Controls.Add(btnPublicIp);
            grpDiagnostics.Location = new Point(23, 253);
            grpDiagnostics.Margin = new Padding(3, 4, 3, 4);
            grpDiagnostics.Name = "grpDiagnostics";
            grpDiagnostics.Padding = new Padding(3, 4, 3, 4);
            grpDiagnostics.Size = new Size(400, 200);
            grpDiagnostics.TabIndex = 2;
            grpDiagnostics.TabStop = false;
            grpDiagnostics.Text = "Network Diagnostics";
            // 
            // lblPingResult
            // 
            lblPingResult.AutoSize = true;
            lblPingResult.Location = new Point(171, 117);
            lblPingResult.Name = "lblPingResult";
            lblPingResult.Size = new Size(72, 20);
            lblPingResult.TabIndex = 3;
            lblPingResult.Text = "Latency: -";
            // 
            // btnPingServer
            // 
            btnPingServer.Location = new Point(23, 107);
            btnPingServer.Margin = new Padding(3, 4, 3, 4);
            btnPingServer.Name = "btnPingServer";
            btnPingServer.Size = new Size(137, 40);
            btnPingServer.TabIndex = 2;
            btnPingServer.Text = "Ping FRP Server";
            btnPingServer.UseVisualStyleBackColor = true;
            btnPingServer.Click += btnPingServer_Click;
            // 
            // lblPublicIp
            // 
            lblPublicIp.AutoSize = true;
            lblPublicIp.Location = new Point(171, 51);
            lblPublicIp.Name = "lblPublicIp";
            lblPublicIp.Size = new Size(62, 20);
            lblPublicIp.TabIndex = 1;
            lblPublicIp.Text = "Result: -";
            // 
            // btnPublicIp
            // 
            btnPublicIp.Location = new Point(23, 40);
            btnPublicIp.Margin = new Padding(3, 4, 3, 4);
            btnPublicIp.Name = "btnPublicIp";
            btnPublicIp.Size = new Size(137, 40);
            btnPublicIp.TabIndex = 0;
            btnPublicIp.Text = "Get Public IP";
            btnPublicIp.UseVisualStyleBackColor = true;
            btnPublicIp.Click += btnPublicIp_Click;
            // 
            // grpMonitor
            // 
            grpMonitor.Controls.Add(lblCpuTime);
            grpMonitor.Controls.Add(lblRamUsage);
            grpMonitor.Location = new Point(457, 253);
            grpMonitor.Margin = new Padding(3, 4, 3, 4);
            grpMonitor.Name = "grpMonitor";
            grpMonitor.Padding = new Padding(3, 4, 3, 4);
            grpMonitor.Size = new Size(400, 200);
            grpMonitor.TabIndex = 3;
            grpMonitor.TabStop = false;
            grpMonitor.Text = "Process Monitor (frpc)";
            // 
            // lblCpuTime
            // 
            lblCpuTime.AutoSize = true;
            lblCpuTime.Font = new Font("Segoe UI", 10F);
            lblCpuTime.Location = new Point(23, 107);
            lblCpuTime.Name = "lblCpuTime";
            lblCpuTime.Size = new Size(101, 23);
            lblCpuTime.TabIndex = 1;
            lblCpuTime.Text = "CPU Time: -";
            // 
            // lblRamUsage
            // 
            lblRamUsage.AutoSize = true;
            lblRamUsage.Font = new Font("Segoe UI", 10F);
            lblRamUsage.Location = new Point(23, 53);
            lblRamUsage.Name = "lblRamUsage";
            lblRamUsage.Size = new Size(114, 23);
            lblRamUsage.TabIndex = 0;
            lblRamUsage.Text = "RAM Usage: -";
            // 
            // tmrUptime
            // 
            tmrUptime.Interval = 1000;
            tmrUptime.Tick += tmrUptime_Tick;
            // 
            // tmrMonitor
            // 
            tmrMonitor.Interval = 1000;
            tmrMonitor.Tick += tmrMonitor_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 667);
            Controls.Add(tabControlMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "MainForm";
            Text = "FRP Client Manager";
            tabControlMain.ResumeLayout(false);
            tabDashboard.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            grpInfo.ResumeLayout(false);
            grpInfo.PerformLayout();
            grpStatus.ResumeLayout(false);
            grpStatus.PerformLayout();
            panelLogControls.ResumeLayout(false);
            panelLogControls.PerformLayout();
            tabEditor.ResumeLayout(false);
            tabEditor.PerformLayout();
            panelEditorControls.ResumeLayout(false);
            tabTools.ResumeLayout(false);
            grpPortChecker.ResumeLayout(false);
            grpPortChecker.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCheckPort).EndInit();
            grpLocalServer.ResumeLayout(false);
            grpLocalServer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numServerPort).EndInit();
            grpDiagnostics.ResumeLayout(false);
            grpDiagnostics.PerformLayout();
            grpMonitor.ResumeLayout(false);
            grpMonitor.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabDashboard;
        private System.Windows.Forms.TabPage tabEditor;
        private System.Windows.Forms.TabPage tabTools;
        private System.Windows.Forms.GroupBox grpLocalServer;
        private System.Windows.Forms.GroupBox grpPortChecker;
        private System.Windows.Forms.Label lblServerStatus;
        private System.Windows.Forms.Button btnServerAction;
        private System.Windows.Forms.NumericUpDown numServerPort;
        private System.Windows.Forms.Label lblServerPortInput;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.Button btnCheckPort;
        private System.Windows.Forms.NumericUpDown numCheckPort;
        private System.Windows.Forms.TextBox txtCheckHost;
        private System.Windows.Forms.Label lblCheckPort;
        private System.Windows.Forms.Label lblCheckHost;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblUptime;
        private System.Windows.Forms.GroupBox grpInfo;
        private System.Windows.Forms.Label lblServerAddr;
        private System.Windows.Forms.Label lblServerPort;
        private System.Windows.Forms.Label lblProxies;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Panel panelLogControls;
        private System.Windows.Forms.CheckBox chkAutoScroll;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnOpenFolder;
        private System.Windows.Forms.TextBox txtEditor;
        private System.Windows.Forms.Panel panelEditorControls;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSaveRestart;
        private System.Windows.Forms.GroupBox grpDiagnostics;
        private System.Windows.Forms.Button btnPublicIp;
        private System.Windows.Forms.Label lblPublicIp;
        private System.Windows.Forms.Button btnPingServer;
        private System.Windows.Forms.Label lblPingResult;
        private System.Windows.Forms.GroupBox grpMonitor;
        private System.Windows.Forms.Label lblRamUsage;
        private System.Windows.Forms.Label lblCpuTime;
        private System.Windows.Forms.Timer tmrMonitor;
        private System.Windows.Forms.Timer tmrUptime;
    }
}
