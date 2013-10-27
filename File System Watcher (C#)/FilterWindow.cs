// Title:   File System Watcher w/GUI
// Author:  Zachariah Kendall
// Date:    Oct 25, 2013
//

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysFileWatch
{
    public partial class wn_Filters : Form
    {
        // Backend Members
        //File Type Extension arrays.
        private string[] m_textFiles = {".doc", ".docx", ".log", ".msg", ".odt", ".pages", ".rtf", ".tex", ".txt", ".wpd", ".wps", ".xls", ".xlr", ".xlsx", ".cfg", ".ini"};
        private string[] m_dataFiles = {".csv", ".dat", ".gbr", ".ged", ".ibooks", ".key", ".keychain", ".pps", ".ppt", ".pptx", ".sdf", ".tar", ".tax2012", ".vcf", ".xml"};
        private string[] m_audioFiles = {".aif",".iff",".m3u",".m4a",".mid",".mp3",".mpa",".ra",".wav",".wma"};
        private string[] m_videoFiles = {".3g2",".3gp",".asf",".asx",".avi",".flv",".m4v",".mov",".mp4",".mpg",".rm",".srt",".swf",".vob",".wmv"};
        private string[] m_imageFiles = {".bmp", ".dds", ".gif", ".jpg", ".png", ".psd", ".pspimage", ".tga", ".thm", ".tif", ".tiff", ".yuv"};
        private string[] m_designFiles= {".ai", ".eps", ".ps", ".svg", ".indd", ".pct", ".pdf", ".dwg", ".dxf", ".3dm", ".3ds", ".max", ".obj"};
        private string[] m_executableFiles = {".apk", ".app", ".bat", ".cgi", ".com", ".exe", ".gadget", ".jar", ".pif", ".vb", ".wsf", ".msi"};
        private string[] m_webFiles = {".asp", ".aspx", ".cer", ".cfm", ".csr", ".css", ".htm", ".html", ".js", ".jsp", ".php", ".rss", ".xhtml"};
        private string[] m_systemFiles = {".cab", ".cpl", ".cur", ".deskthemepack", ".dll", ".dmp", ".drv", ".icns", ".ico", ".lnk", ".sys", ".bak", ".tmp" };
        private string[] m_compressedFiles = {".7z", ".cbr", ".deb", ".gz", ".pkg", ".rar", ".rpm", ".sitx", ".tar", ".zip", ".zipx"};
        private string[] m_diskImageFiles = {".bin", ".cue", ".dmg", ".iso", ".mdf", ".toast", ".vcd"};
        private string[] m_developerFiles = {".c", ".class", ".cpp", ".cs", ".dtd", ".fla", ".h", ".java", ".lua", ".m", ".pl", ".py", ".sh", ".sln", ".vcxproj", ".xcodeproj"};

        public wn_Filters()
        {
            InitializeComponent();
        }

        // Return string of extensions
        public string getFilter()
        {
            return txBx_extFilters.Text;
        }

        // Add array of filters to filter string
        private void addFilters(string[] extentions)
        {
            txBx_extFilters.Text += String.Join(", ", extentions);
        }

        // Remove array of filters from filter string
        private void removeFilters(string[] extentions)
        {
            string result = txBx_extFilters.Text;
            foreach (string ext in extentions)
            {
                // Regex //
                // Check for preceeding comma and space; Make extension '.' literal
                string r1 = ".? ?\\";
                // Match length
                string r2 = "\\b";
                Regex regexp = new Regex(r1 + ext + r2);
                result = regexp.Replace(result, "");
            }
            txBx_extFilters.Text = result;
        }

        //
        // UI checkbox actions
        //
        private void chBx_audioFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_audioFiles.Checked)
                addFilters(m_audioFiles);
            else
                removeFilters(m_audioFiles);
        }

        private void chBx_compressedFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_compressedFiles.Checked)
                addFilters(m_compressedFiles);
            else
                removeFilters(m_compressedFiles);
        }

        private void chBx_dataFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_dataFiles.Checked)
                addFilters(m_dataFiles);
            else
                removeFilters(m_dataFiles);
        }

        private void chBx_designFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_designFiles.Checked)
                addFilters(m_designFiles);
            else
                removeFilters(m_designFiles);
        }

        private void chBx_developerFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_developerFiles.Checked)
                addFilters(m_developerFiles);
            else
                removeFilters(m_developerFiles);
        }

        private void chBx_diskImageFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_diskImageFiles.Checked)
                addFilters(m_diskImageFiles);
            else
                removeFilters(m_diskImageFiles);
        }

        private void chBx_imageFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_imageFiles.Checked)
                addFilters(m_imageFiles);
            else
                removeFilters(m_imageFiles);
        }

        private void chBx_executableFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_executableFiles.Checked)
                addFilters(m_executableFiles);
            else
                removeFilters(m_executableFiles);
        }

        private void chBx_systemFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_systemFiles.Checked)
                addFilters(m_systemFiles);
            else
                removeFilters(m_systemFiles);
        }

        private void chBx_textFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_textFiles.Checked)
                addFilters(m_textFiles);
            else
                removeFilters(m_textFiles);
        }

        private void chBx_videoFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_videoFiles.Checked)
                addFilters(m_videoFiles);
            else
                removeFilters(m_videoFiles);
        }

        private void chBx_webFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (chBx_webFiles.Checked)
                addFilters(m_webFiles);
            else
                removeFilters(m_webFiles);
        }

    }
}
