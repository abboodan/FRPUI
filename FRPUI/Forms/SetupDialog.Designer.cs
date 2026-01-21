namespace FRPUI.Forms
{
    partial class SetupDialog
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
            lblMessage = new Label();
            btnOpenGithub = new Button();
            btnBrowse = new Button();
            btnCreateConfig = new Button();
            btnRefresh = new Button();
            SuspendLayout();
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Location = new Point(23, 27);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(156, 20);
            lblMessage.TabIndex = 0;
            lblMessage.Text = "Missing files detected.";
            // 
            // btnOpenGithub
            // 
            btnOpenGithub.Location = new Point(23, 133);
            btnOpenGithub.Margin = new Padding(3, 4, 3, 4);
            btnOpenGithub.Name = "btnOpenGithub";
            btnOpenGithub.Size = new Size(229, 47);
            btnOpenGithub.TabIndex = 1;
            btnOpenGithub.Text = "Download from GitHub";
            btnOpenGithub.UseVisualStyleBackColor = true;
            btnOpenGithub.Click += btnOpenGithub_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(23, 200);
            btnBrowse.Margin = new Padding(3, 4, 3, 4);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(229, 47);
            btnBrowse.TabIndex = 2;
            btnBrowse.Text = "I have frpc.exe (Browse)";
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // btnCreateConfig
            // 
            btnCreateConfig.Location = new Point(269, 133);
            btnCreateConfig.Margin = new Padding(3, 4, 3, 4);
            btnCreateConfig.Name = "btnCreateConfig";
            btnCreateConfig.Size = new Size(229, 47);
            btnCreateConfig.TabIndex = 3;
            btnCreateConfig.Text = "Create Default Config";
            btnCreateConfig.UseVisualStyleBackColor = true;
            btnCreateConfig.Click += btnCreateConfig_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(269, 200);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(229, 47);
            btnRefresh.TabIndex = 4;
            btnRefresh.Text = "Check Again / Done";
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // SetupDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(549, 293);
            Controls.Add(btnRefresh);
            Controls.Add(btnCreateConfig);
            Controls.Add(btnBrowse);
            Controls.Add(btnOpenGithub);
            Controls.Add(lblMessage);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SetupDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FRP Manager Setup";
            Load += SetupDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnOpenGithub;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnCreateConfig;
        private System.Windows.Forms.Button btnRefresh;
    }
}
