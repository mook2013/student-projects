namespace SysFileWatch
{
    partial class MainWindow
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hELPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.btn_run = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.watcherFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_exportToDb = new System.Windows.Forms.ToolStripButton();
            this.btn_reloadDb = new System.Windows.Forms.ToolStripButton();
            this.btn_clearDb = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tbCtrl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.grp_controls = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_selectDirectory = new System.Windows.Forms.Button();
            this.txBx_directory = new System.Windows.Forms.TextBox();
            this.rTxBx_log = new System.Windows.Forms.RichTextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView_db = new System.Windows.Forms.DataGridView();
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.tbCtrl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.grp_controls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_db)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(583, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::SysFileWatch.Properties.Resources._new;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.new_MenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::SysFileWatch.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exit_MenuItem_Click);
            // 
            // hELPToolStripMenuItem
            // 
            this.hELPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.hELPToolStripMenuItem.Name = "hELPToolStripMenuItem";
            this.hELPToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.hELPToolStripMenuItem.Text = "&HELP!";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::SysFileWatch.Properties.Resources.about;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.SplitButton;
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_run,
            this.toolStripDropDownButton1,
            this.btn_exportToDb,
            this.btn_reloadDb,
            this.btn_clearDb});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip.Size = new System.Drawing.Size(583, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // btn_run
            // 
            this.btn_run.ForeColor = System.Drawing.Color.Green;
            this.btn_run.Image = global::SysFileWatch.Properties.Resources.start;
            this.btn_run.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_run.Name = "btn_run";
            this.btn_run.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btn_run.Size = new System.Drawing.Size(46, 22);
            this.btn_run.Text = "Run";
            this.btn_run.Click += new System.EventHandler(this.toolStripBn_Run_Click);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.watcherFiltersToolStripMenuItem,
            this.databaseFiltersToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::SysFileWatch.Properties.Resources.filter;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(65, 22);
            this.toolStripDropDownButton1.Text = "Filters";
            // 
            // watcherFiltersToolStripMenuItem
            // 
            this.watcherFiltersToolStripMenuItem.Name = "watcherFiltersToolStripMenuItem";
            this.watcherFiltersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.watcherFiltersToolStripMenuItem.Text = "Watcher Filters";
            this.watcherFiltersToolStripMenuItem.Click += new System.EventHandler(this.watcherFilters_MenuItem_Click);
            // 
            // databaseFiltersToolStripMenuItem
            // 
            this.databaseFiltersToolStripMenuItem.Name = "databaseFiltersToolStripMenuItem";
            this.databaseFiltersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.databaseFiltersToolStripMenuItem.Text = "Database Filters";
            this.databaseFiltersToolStripMenuItem.Click += new System.EventHandler(this.databaseFilters_MenuItem_Click);
            // 
            // btn_exportToDb
            // 
            this.btn_exportToDb.Image = global::SysFileWatch.Properties.Resources.export;
            this.btn_exportToDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_exportToDb.Name = "btn_exportToDb";
            this.btn_exportToDb.Size = new System.Drawing.Size(88, 22);
            this.btn_exportToDb.Text = "Export to Db";
            this.btn_exportToDb.Click += new System.EventHandler(this.btn_exportToDb_Click);
            // 
            // btn_reloadDb
            // 
            this.btn_reloadDb.Image = global::SysFileWatch.Properties.Resources.refresh;
            this.btn_reloadDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_reloadDb.Name = "btn_reloadDb";
            this.btn_reloadDb.Size = new System.Drawing.Size(81, 22);
            this.btn_reloadDb.Text = "Refresh Db";
            this.btn_reloadDb.Click += new System.EventHandler(this.btn_reloadDb_Click);
            // 
            // btn_clearDb
            // 
            this.btn_clearDb.Image = global::SysFileWatch.Properties.Resources.clear;
            this.btn_clearDb.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_clearDb.Name = "btn_clearDb";
            this.btn_clearDb.Size = new System.Drawing.Size(68, 22);
            this.btn_clearDb.Text = "Clear Db";
            this.btn_clearDb.Click += new System.EventHandler(this.btn_Clear_Click);
            // 
            // folderBrowserDialog
            // 
            this.folderBrowserDialog.Description = "Select directory to watch.";
            // 
            // tbCtrl
            // 
            this.tbCtrl.Controls.Add(this.tabPage1);
            this.tbCtrl.Controls.Add(this.tabPage2);
            this.tbCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbCtrl.Location = new System.Drawing.Point(0, 49);
            this.tbCtrl.Name = "tbCtrl";
            this.tbCtrl.SelectedIndex = 0;
            this.tbCtrl.Size = new System.Drawing.Size(583, 385);
            this.tbCtrl.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(575, 359);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event Watcher";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.grp_controls, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.rTxBx_log, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(569, 353);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // grp_controls
            // 
            this.grp_controls.AutoSize = true;
            this.grp_controls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grp_controls.Controls.Add(this.tableLayoutPanel1);
            this.grp_controls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_controls.Location = new System.Drawing.Point(3, 3);
            this.grp_controls.Name = "grp_controls";
            this.grp_controls.Size = new System.Drawing.Size(563, 54);
            this.grp_controls.TabIndex = 7;
            this.grp_controls.TabStop = false;
            this.grp_controls.Text = "Watched Directory";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.Controls.Add(this.btn_selectDirectory, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txBx_directory, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(557, 26);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // btn_selectDirectory
            // 
            this.btn_selectDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_selectDirectory.Location = new System.Drawing.Point(520, 3);
            this.btn_selectDirectory.Name = "btn_selectDirectory";
            this.btn_selectDirectory.Size = new System.Drawing.Size(34, 20);
            this.btn_selectDirectory.TabIndex = 6;
            this.btn_selectDirectory.Text = ". . .";
            this.btn_selectDirectory.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_selectDirectory.UseVisualStyleBackColor = true;
            this.btn_selectDirectory.Click += new System.EventHandler(this.btn_selectDirectory_Click);
            // 
            // txBx_directory
            // 
            this.txBx_directory.AllowDrop = true;
            this.txBx_directory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txBx_directory.Location = new System.Drawing.Point(3, 3);
            this.txBx_directory.MaxLength = 255;
            this.txBx_directory.Name = "txBx_directory";
            this.txBx_directory.Size = new System.Drawing.Size(511, 20);
            this.txBx_directory.TabIndex = 2;
            this.txBx_directory.Text = "c:\\";
            this.txBx_directory.Leave += new System.EventHandler(this.txBx_directory_Leave);
            // 
            // rTxBx_log
            // 
            this.rTxBx_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rTxBx_log.Location = new System.Drawing.Point(3, 63);
            this.rTxBx_log.Name = "rTxBx_log";
            this.rTxBx_log.ReadOnly = true;
            this.rTxBx_log.Size = new System.Drawing.Size(563, 287);
            this.rTxBx_log.TabIndex = 8;
            this.rTxBx_log.Text = "";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView_db);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(575, 359);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Db Viewer";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView_db
            // 
            this.dataGridView_db.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_db.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_db.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_db.Name = "dataGridView_db";
            this.dataGridView_db.ReadOnly = true;
            this.dataGridView_db.Size = new System.Drawing.Size(569, 353);
            this.dataGridView_db.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 434);
            this.Controls.Add(this.tbCtrl);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainWindow";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "File System Watcher";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainWindow_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tbCtrl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.grp_controls.ResumeLayout(false);
            this.grp_controls.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_db)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hELPToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton btn_run;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btn_exportToDb;
        private System.Windows.Forms.TabControl tbCtrl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripButton btn_reloadDb;
        private System.Windows.Forms.DataGridView dataGridView_db;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox grp_controls;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_selectDirectory;
        private System.Windows.Forms.TextBox txBx_directory;
        private System.Windows.Forms.RichTextBox rTxBx_log;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem watcherFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btn_clearDb;
    }
}

