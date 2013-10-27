// Title:   File System Watcher w/GUI
// Author:  Zachariah Kendall
// Date:    Oct 25, 2013
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysFileWatch
{
    public partial class MainWindow : Form
    {
        // Subwindow
        wn_Filters gl_wn_watchFilter;
        wn_Filters gl_wn_dbFilter;

        // Backend Members
        FileSystemWatcher gl_watcher;
        string[] gl_watcherFilter = {""};
        string[] gl_dbFilter = {""};
        SQLiteConnection gl_sqlite;
        Queue<string> gl_db_buffer;
        

        // Properties
        string LOG_FILE_NAME = "watcherEventLog.db";

        public MainWindow()
        {
            //// Windows Forms ////
            InitializeComponent();
            gl_wn_watchFilter = new wn_Filters();
            gl_wn_dbFilter = new wn_Filters();
            
            ////  Backend  ////

            // Database
            initDB();
            gl_db_buffer = new Queue<string>();

            // File Watcher
            gl_watcher = new FileSystemWatcher();
            gl_watcher.SynchronizingObject = this; // Don't use alternate system threads
            gl_watcher.Path = "C:\\";
            gl_watcher.IncludeSubdirectories = true;
            gl_watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName
                                    | NotifyFilters.DirectoryName;
            // Add event handlers.
            gl_watcher.Changed += new FileSystemEventHandler(OnWatcherEvent);
            gl_watcher.Created += new FileSystemEventHandler(OnWatcherEvent);
            gl_watcher.Deleted += new FileSystemEventHandler(OnWatcherEvent);
            gl_watcher.Renamed += new RenamedEventHandler(OnWatcherEvent);

            gl_watcher.EnableRaisingEvents = false; // Start disabled
            

        }

        // Handle file event of any type!
        private void OnWatcherEvent(object sender, FileSystemEventArgs e)
        {
            // Don't log changes to log!
            if (Path.GetFileName(e.Name) == LOG_FILE_NAME ||
                Path.GetFileName(e.Name) == LOG_FILE_NAME + "-journal")
                return;

            
            // Make sure event comes from watched extensions
            string ext = Path.GetExtension(e.Name);

            if (! (gl_watcherFilter.Length == 1 && gl_watcherFilter[0] == ""))
            { // Filter set more than empty string
                if (!gl_watcherFilter.Contains(ext.ToUpper()))
                    return;
            }

            // Prepare message
            string fn = Path.GetFileName(e.Name);
            string pth = e.FullPath;
            string tm = DateTime.Now.ToString("yy-MM-dd HH:mm:ss");
            string evnt = e.ChangeType.ToString();

            // Deselect to preserve existing text color
            rTxBx_log.DeselectAll();

            // Set font color
            switch(evnt)
            {
                case "Deleted":
                    rTxBx_log.SelectionColor = System.Drawing.Color.FromArgb(0xA0, 0x10, 0x10);
                    break;
                case "Changed":
                    rTxBx_log.SelectionColor = System.Drawing.Color.FromArgb(0x10, 0x1A, 0xAA);
                    break;
                case "Created":
                    rTxBx_log.SelectionColor = Color.DarkGreen;
                    break;
                default:
                    rTxBx_log.SelectionColor = Color.Black;
                    break;
            }
            
            // Log to window
            rTxBx_log.AppendText(string.Format("{0, -35} {1, -35} {2, -35} {3}\n\n"
                                 , "File: " + fn, "Time: " + tm, "Event: " + evnt, "\nPath: " + pth));
            
            // Add to db buffer for eventual export to db
            string query = String.Format("insert into log (extension, file, path, time, event)"
                                            + "values ('{0}', '{1}', '{2}', '{3}', '{4}')"
                                            , ext, fn, pth, tm, evnt);
            gl_db_buffer.Enqueue(query);

        } // End OnWatcherEvent()

        // Setup the database
        private void initDB()
        {
            try
            {
                gl_sqlite = new SQLiteConnection("Data Source=" + LOG_FILE_NAME);

                gl_sqlite.Open();

                SQLiteCommand cmd = gl_sqlite.CreateCommand();
                cmd.CommandText = "CREATE TABLE IF NOT EXISTS log ( " +
                                    "extension CHAR( 50 )," +
                                    "file      CHAR( 100 )," +
                                    "path      CHAR( 255 )," +
                                    "time      CHAR( 50 )," +
                                    "event     CHAR( 50 )" +
                                    ");";
                cmd.ExecuteNonQuery();

                gl_sqlite.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                this.Close();
            }

        }

        // Get data from the database and desplay it in the grid view
        private void getData(string query)
        {
            gl_sqlite.Open();
            SQLiteCommand cmd = new SQLiteCommand(query, gl_sqlite);
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView_db.DataSource = ds.Tables[0];
            gl_sqlite.Close();
        }

        // Get db data onLoad
        private void Form1_Load(object sender, EventArgs e)
        {
            getData("select * from log");
        }

        // Handle Run button
        private void toolStripBn_Run_Click(object sender, EventArgs e)
        {
            // Toggle
            gl_watcher.EnableRaisingEvents = !gl_watcher.EnableRaisingEvents;
            if (gl_watcher.EnableRaisingEvents == false)
            {
                btn_run.Text = "Run";
                btn_run.ForeColor = Color.Green;
                btn_run.Image = SysFileWatch.Properties.Resources.start;
            }
            else
            {
                btn_run.Text = "Stop";
                btn_run.ForeColor = Color.Red;
                btn_run.Image = SysFileWatch.Properties.Resources.stop;
            }
        }

        // Handle directory selection button
        private void btn_selectDirectory_Click(object sender, EventArgs e)
        {
            folderBrowserDialog.ShowDialog();
            txBx_directory.Text = folderBrowserDialog.SelectedPath;
            setDirectory(txBx_directory.Text);
        }

        // Directory field lost focus
        private void txBx_directory_Leave(object sender, EventArgs e)
        {
            setDirectory(txBx_directory.Text);
        }

        // Give watcher new directory to watch
        private void setDirectory(string dir)
        {
            try
            {
                gl_watcher.Path = dir;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        // Handle export button
        private void btn_exportToDb_Click(object sender, EventArgs e)
        {
            ExportToDb();
        }

        // Export logged data to db
        private void ExportToDb()
        {
            // This method bulk inserts the linked list of log items to the database.
            // It uses a transation to improve speed significantly.

            gl_sqlite.Open();

            using (var cmd = new SQLiteCommand(gl_sqlite))
            {
                using (var transaction = gl_sqlite.BeginTransaction())
                {
                    // Get logged saved as sql in queue
                    while (gl_db_buffer.Count != 0)
                    {
                        cmd.CommandText = gl_db_buffer.Dequeue();
                        cmd.ExecuteNonQuery();
                    }
                    transaction.Commit();
                }
            }

            gl_sqlite.Close();
        }

        // Handle refresh button
        private void btn_reloadDb_Click(object sender, EventArgs e)
        {
            refreshDb();
        }

        // Load msgs, according to filter, from database
        private void refreshDb()
        {
            string query = "select * from log";
            string filter = " ";
            if (!(gl_dbFilter.Length == 1 && gl_dbFilter[0] == ""))
            {
                filter += "where extension in (\"";
                filter += String.Join("\", \"", gl_dbFilter);
                filter += "\")";
            }
            getData(query + filter);
        }

        // Handle watcher's filter menu
        private void watcherFilters_MenuItem_Click(object sender, EventArgs e)
        {
            gl_wn_watchFilter.ShowDialog(this);
            gl_watcherFilter = gl_wn_watchFilter.getFilter().Replace(" ", "").ToUpper().Split(',');
        }

        // Handle db's filter menu
        private void databaseFilters_MenuItem_Click(object sender, EventArgs e)
        {
            gl_wn_watchFilter.ShowDialog(this);
            gl_dbFilter = gl_wn_watchFilter.getFilter().Replace(" ", "").Split(',');
        }

        // Handle about menu
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new About().Show();
        }

        // Handle close
        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gl_db_buffer.Count > 0)
            {
                if( DialogResult.Yes == MessageBox.Show("Export log to database before closing?", "Save?", MessageBoxButtons.YesNo))
                    ExportToDb();
            }            
        }

        // Handle new button. Stop watcher and reset text fields
        private void new_MenuItem_Click(object sender, EventArgs e)
        {
            // Easiest to remake window. And no collateral.
            gl_wn_watchFilter = new wn_Filters();
            gl_wn_dbFilter = new wn_Filters();

            // Empty strings
            rTxBx_log.Text = "";
            gl_watcherFilter = new string[1];
            gl_watcherFilter[0] = "";
            gl_dbFilter = new string[1];
            gl_dbFilter[0] = "";
            gl_db_buffer = new Queue<string>();

            // Stop watcher, reset path
            gl_watcher.EnableRaisingEvents = false;
            //gl_watcher.Path = "C:\\";

            // Reset toolbar icon
            btn_run.Text = "Run";
            btn_run.ForeColor = Color.Green;
            btn_run.Image = SysFileWatch.Properties.Resources.start;

            MessageBox.Show("File Watcher reset. Database unchanged.", "New", MessageBoxButtons.OK);
        }

        // Handle exit option
        private void exit_MenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Handle clear db button
        private void btn_Clear_Click(object sender, EventArgs e)
        {
            gl_sqlite.Open();

            // Remove table
            SQLiteCommand cmd = new SQLiteCommand("DROP TABLE IF EXISTS log", gl_sqlite);
            cmd.ExecuteNonQuery();
            
            // Recreate table
            cmd.CommandText = "CREATE TABLE IF NOT EXISTS log ( " +
                    "extension CHAR( 50 )," +
                    "file      CHAR( 100 )," +
                    "path      CHAR( 255 )," +
                    "time      CHAR( 50 )," +
                    "event     CHAR( 50 )" +
                    ");";
            cmd.ExecuteNonQuery();

            gl_sqlite.Close();

            refreshDb();
        }

    }
}
