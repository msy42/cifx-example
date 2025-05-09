namespace cifXTest
{
    partial class cifXMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cifXMain));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StatusText = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.applicationReadyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.busStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configLockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.watchdogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.informationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mailboxStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTransferToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pcketDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iODataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusText});
            this.statusStrip.Location = new System.Drawing.Point(0, 503);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(648, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // StatusText
            // 
            this.StatusText.Name = "StatusText";
            this.StatusText.Size = new System.Drawing.Size(39, 17);
            this.StatusText.Text = "Status";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.deviceToolStripMenuItem,
            this.informationToolStripMenuItem,
            this.dataTransferToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(648, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.MenuActivate += new System.EventHandler(this.menuStrip1_MenuActivate);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.quitToolStripMenuItem.Text = "&Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // deviceToolStripMenuItem
            // 
            this.deviceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem,
            this.toolStripSeparator1,
            this.resetToolStripMenuItem,
            this.applicationReadyToolStripMenuItem,
            this.busStateToolStripMenuItem,
            this.configLockToolStripMenuItem,
            this.watchdogToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.fileExplorerToolStripMenuItem});
            this.deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            this.deviceToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.deviceToolStripMenuItem.Text = "&Device";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.closeToolStripMenuItem.Text = "&Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.resetToolStripMenuItem.Text = "&Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // applicationReadyToolStripMenuItem
            // 
            this.applicationReadyToolStripMenuItem.Name = "applicationReadyToolStripMenuItem";
            this.applicationReadyToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.applicationReadyToolStripMenuItem.Text = "Application R&eady";
            this.applicationReadyToolStripMenuItem.Click += new System.EventHandler(this.applicationReadyToolStripMenuItem_Click_1);
            // 
            // busStateToolStripMenuItem
            // 
            this.busStateToolStripMenuItem.Name = "busStateToolStripMenuItem";
            this.busStateToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.busStateToolStripMenuItem.Text = "B&us State";
            this.busStateToolStripMenuItem.Click += new System.EventHandler(this.busStateToolStripMenuItem_Click);
            // 
            // configLockToolStripMenuItem
            // 
            this.configLockToolStripMenuItem.Name = "configLockToolStripMenuItem";
            this.configLockToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.configLockToolStripMenuItem.Text = "Config &Lock";
            this.configLockToolStripMenuItem.Click += new System.EventHandler(this.configLockToolStripMenuItem_Click);
            // 
            // watchdogToolStripMenuItem
            // 
            this.watchdogToolStripMenuItem.Name = "watchdogToolStripMenuItem";
            this.watchdogToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.watchdogToolStripMenuItem.Text = "&Watchdog";
            this.watchdogToolStripMenuItem.Click += new System.EventHandler(this.watchdogToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.downloadToolStripMenuItem.Text = "&Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // fileExplorerToolStripMenuItem
            // 
            this.fileExplorerToolStripMenuItem.Name = "fileExplorerToolStripMenuItem";
            this.fileExplorerToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.fileExplorerToolStripMenuItem.Text = "&File Explorer";
            this.fileExplorerToolStripMenuItem.Click += new System.EventHandler(this.fileExplorerToolStripMenuItem_Click);
            // 
            // informationToolStripMenuItem
            // 
            this.informationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driverInformationToolStripMenuItem,
            this.channelInformationToolStripMenuItem,
            this.mailboxStateToolStripMenuItem});
            this.informationToolStripMenuItem.Name = "informationToolStripMenuItem";
            this.informationToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.informationToolStripMenuItem.Text = "&Information";
            // 
            // driverInformationToolStripMenuItem
            // 
            this.driverInformationToolStripMenuItem.Name = "driverInformationToolStripMenuItem";
            this.driverInformationToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.driverInformationToolStripMenuItem.Text = "&Driver Information";
            this.driverInformationToolStripMenuItem.Click += new System.EventHandler(this.driverInformationToolStripMenuItem_Click);
            // 
            // channelInformationToolStripMenuItem
            // 
            this.channelInformationToolStripMenuItem.Name = "channelInformationToolStripMenuItem";
            this.channelInformationToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.channelInformationToolStripMenuItem.Text = "&Channel Information";
            this.channelInformationToolStripMenuItem.Click += new System.EventHandler(this.channelInformationToolStripMenuItem_Click);
            // 
            // mailboxStateToolStripMenuItem
            // 
            this.mailboxStateToolStripMenuItem.Name = "mailboxStateToolStripMenuItem";
            this.mailboxStateToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.mailboxStateToolStripMenuItem.Text = "&Mailbox State";
            this.mailboxStateToolStripMenuItem.Click += new System.EventHandler(this.mailboxStateToolStripMenuItem_Click);
            // 
            // dataTransferToolStripMenuItem
            // 
            this.dataTransferToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pcketDataToolStripMenuItem,
            this.iODataToolStripMenuItem});
            this.dataTransferToolStripMenuItem.Name = "dataTransferToolStripMenuItem";
            this.dataTransferToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.dataTransferToolStripMenuItem.Text = "D&ata Transfer";
            // 
            // pcketDataToolStripMenuItem
            // 
            this.pcketDataToolStripMenuItem.Name = "pcketDataToolStripMenuItem";
            this.pcketDataToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.pcketDataToolStripMenuItem.Text = "&Packet Data";
            this.pcketDataToolStripMenuItem.Click += new System.EventHandler(this.pcketDataToolStripMenuItem_Click);
            // 
            // iODataToolStripMenuItem
            // 
            this.iODataToolStripMenuItem.Name = "iODataToolStripMenuItem";
            this.iODataToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.iODataToolStripMenuItem.Text = "I/O Da&ta";
            this.iODataToolStripMenuItem.Click += new System.EventHandler(this.iODataToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem,
            this.toolStripSeparator2,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "&?";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(104, 6);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // cifXMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 525);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "cifXMain";
            this.Text = "cifXMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.cifXMain_FormClosing);
            this.Load += new System.EventHandler(this.cifXMain_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel StatusText;
        private System.Windows.Forms.ToolTip ToolTip;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem applicationReadyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem busStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configLockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem watchdogToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem informationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mailboxStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataTransferToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pcketDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iODataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}



