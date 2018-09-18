namespace ApacheLogParser
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Main Table >");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("File Table");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("IP Tables");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadIpsOwnerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadFileInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbBase = new System.Windows.Forms.ToolStripTextBox();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutApacheLogParserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.verlokagithubioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.status = new System.Windows.Forms.StatusStrip();
            this.lblReady = new System.Windows.Forms.ToolStripStatusLabel();
            this.pgLinesProcessed = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatusIP = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatusFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSaveIp = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSaveFile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMainSaving = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnFiltering = new System.Windows.Forms.Button();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.status.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpen,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tsmiOpen
            // 
            this.tsmiOpen.Name = "tsmiOpen";
            this.tsmiOpen.Size = new System.Drawing.Size(103, 22);
            this.tsmiOpen.Text = "Open";
            this.tsmiOpen.Click += new System.EventHandler(this.OpenClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitClic);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadIpsOwnerToolStripMenuItem,
            this.loadFileInformationToolStripMenuItem,
            this.toolStripSeparator1,
            this.tbBase});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // loadIpsOwnerToolStripMenuItem
            // 
            this.loadIpsOwnerToolStripMenuItem.Checked = true;
            this.loadIpsOwnerToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadIpsOwnerToolStripMenuItem.Name = "loadIpsOwnerToolStripMenuItem";
            this.loadIpsOwnerToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.loadIpsOwnerToolStripMenuItem.Text = "Load ip\'s owner";
            this.loadIpsOwnerToolStripMenuItem.Click += new System.EventHandler(this.loadIpsOwnerToolStripMenuItem_Click);
            // 
            // loadFileInformationToolStripMenuItem
            // 
            this.loadFileInformationToolStripMenuItem.Checked = true;
            this.loadFileInformationToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.loadFileInformationToolStripMenuItem.Name = "loadFileInformationToolStripMenuItem";
            this.loadFileInformationToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.loadFileInformationToolStripMenuItem.Text = "Load file information";
            this.loadFileInformationToolStripMenuItem.Click += new System.EventHandler(this.loadFileInformationToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(257, 6);
            // 
            // tbBase
            // 
            this.tbBase.AutoSize = false;
            this.tbBase.Name = "tbBase";
            this.tbBase.Size = new System.Drawing.Size(200, 23);
            this.tbBase.Text = "http://tariscope.com";
            this.tbBase.ToolTipText = "Base url";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutApacheLogParserToolStripMenuItem,
            this.toolStripMenuItem2,
            this.verlokagithubioToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // aboutApacheLogParserToolStripMenuItem
            // 
            this.aboutApacheLogParserToolStripMenuItem.Name = "aboutApacheLogParserToolStripMenuItem";
            this.aboutApacheLogParserToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.aboutApacheLogParserToolStripMenuItem.Text = "About ApacheLogParser";
            this.aboutApacheLogParserToolStripMenuItem.Click += new System.EventHandler(this.AboutApacheLogParserClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // verlokagithubioToolStripMenuItem
            // 
            this.verlokagithubioToolStripMenuItem.Name = "verlokagithubioToolStripMenuItem";
            this.verlokagithubioToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.verlokagithubioToolStripMenuItem.Text = "verloka.github.io";
            this.verlokagithubioToolStripMenuItem.Click += new System.EventHandler(this.websiteClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Size = new System.Drawing.Size(800, 426);
            this.splitContainer1.SplitterDistance = 112;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode4.Name = "Узел0";
            treeNode4.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode4.Tag = "Main";
            treeNode4.Text = "Main Table >";
            treeNode5.Name = "Узел1";
            treeNode5.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode5.Tag = "FILEList";
            treeNode5.Text = "File Table";
            treeNode6.Name = "Узел2";
            treeNode6.NodeFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            treeNode6.Tag = "IPList";
            treeNode6.Text = "IP Tables";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(112, 426);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewAfterSelect);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFiltering);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnRefresh);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 28);
            this.panel1.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnSearch.Image = global::ApacheLogParser.Properties.Resources.magnifying_glass;
            this.btnSearch.Location = new System.Drawing.Point(62, 0);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(26, 28);
            this.btnSearch.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnSearch, "Searching");
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearchClick);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(52, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 28);
            this.panel2.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnClear.Image = global::ApacheLogParser.Properties.Resources.close;
            this.btnClear.Location = new System.Drawing.Point(26, 0);
            this.btnClear.Margin = new System.Windows.Forms.Padding(1);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(26, 28);
            this.btnClear.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnClear, "Clear selected table.");
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClearClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(0, 0);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(1);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(26, 28);
            this.btnRefresh.TabIndex = 0;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh selected table.");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefrechClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(0, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(684, 376);
            this.dataGridView1.TabIndex = 2;
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblReady,
            this.pgLinesProcessed,
            this.lblStatusIP,
            this.lblStatusFile,
            this.lblSaveIp,
            this.lblSaveFile,
            this.lblMainSaving});
            this.status.Location = new System.Drawing.Point(0, 428);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(800, 22);
            this.status.TabIndex = 2;
            this.status.Text = "statusStrip1";
            // 
            // lblReady
            // 
            this.lblReady.Name = "lblReady";
            this.lblReady.Size = new System.Drawing.Size(39, 17);
            this.lblReady.Text = "Ready";
            // 
            // pgLinesProcessed
            // 
            this.pgLinesProcessed.Name = "pgLinesProcessed";
            this.pgLinesProcessed.Size = new System.Drawing.Size(100, 16);
            this.pgLinesProcessed.Step = 1;
            this.pgLinesProcessed.Visible = false;
            // 
            // lblStatusIP
            // 
            this.lblStatusIP.Name = "lblStatusIP";
            this.lblStatusIP.Size = new System.Drawing.Size(13, 17);
            this.lblStatusIP.Text = "0";
            this.lblStatusIP.Visible = false;
            // 
            // lblStatusFile
            // 
            this.lblStatusFile.Name = "lblStatusFile";
            this.lblStatusFile.Size = new System.Drawing.Size(13, 17);
            this.lblStatusFile.Text = "0";
            this.lblStatusFile.Visible = false;
            // 
            // lblSaveIp
            // 
            this.lblSaveIp.Name = "lblSaveIp";
            this.lblSaveIp.Size = new System.Drawing.Size(13, 17);
            this.lblSaveIp.Text = "0";
            this.lblSaveIp.Visible = false;
            // 
            // lblSaveFile
            // 
            this.lblSaveFile.Name = "lblSaveFile";
            this.lblSaveFile.Size = new System.Drawing.Size(13, 17);
            this.lblSaveFile.Text = "0";
            this.lblSaveFile.Visible = false;
            // 
            // lblMainSaving
            // 
            this.lblMainSaving.Name = "lblMainSaving";
            this.lblMainSaving.Size = new System.Drawing.Size(13, 17);
            this.lblMainSaving.Text = "0";
            this.lblMainSaving.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.toolTip1.ToolTipTitle = "Information";
            // 
            // btnFiltering
            // 
            this.btnFiltering.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnFiltering.Image = global::ApacheLogParser.Properties.Resources.filter;
            this.btnFiltering.Location = new System.Drawing.Point(88, 0);
            this.btnFiltering.Margin = new System.Windows.Forms.Padding(1);
            this.btnFiltering.Name = "btnFiltering";
            this.btnFiltering.Size = new System.Drawing.Size(26, 28);
            this.btnFiltering.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnFiltering, "Filtering");
            this.btnFiltering.UseVisualStyleBackColor = true;
            this.btnFiltering.Click += new System.EventHandler(this.btnFilteringClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.status);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Name = "Form1";
            this.Text = "Apache Log Parser 18.09 by Verloka Vadim";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingEvent);
            this.Load += new System.EventHandler(this.FormLoad);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutApacheLogParserToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStripProgressBar pgLinesProcessed;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusIP;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusFile;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadIpsOwnerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadFileInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox tbBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel lblSaveIp;
        private System.Windows.Forms.ToolStripStatusLabel lblSaveFile;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.ToolStripStatusLabel lblMainSaving;
        private System.Windows.Forms.ToolStripStatusLabel lblReady;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem verlokagithubioToolStripMenuItem;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Button btnFiltering;
    }
}

