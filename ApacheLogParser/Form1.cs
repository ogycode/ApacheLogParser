using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace ApacheLogParser
{
    public partial class Form1 : Form
    {
        //common sql connection string
        string sqlConnectionString;

        //for load tables
        string currentTable = "Main";
        string currentWhere = "";

        //for search and filtering
        string[] columnName;

        bool IpProcessed;
        bool FileProcessed;

        //collections for storing temp data when processed file
        List<IpUnit> ips = new List<IpUnit>();
        List<FileUnit> files = new List<FileUnit>();
        List<LogUnit> units = new List<LogUnit>();

        //patterns for regex
        string ipPatern = @"(?<=org\"":).*?(?=,\"")";
        string typePatern = "^(\\S+) (\\S+) (\\S+)";
        string logPatern = "^(\\S+) (\\S+) (\\S+) \\[([\\w:/]+\\s[+\\-]\\d{4})\\] \"(.+?)\" (\\d{3}) (\\d+) \"([^\"]+)\" \"([^\"]+)\"";

        Regex regexIp;
        Regex regexLog;
        Regex regexType;

        Thread ThreadIp;
        Thread ThreadFile;

        public Form1()
        {
            InitializeComponent();

            sqlConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={Path.GetDirectoryName(GetType().Assembly.Location)}\storage.mdf;Integrated Security=True";

            regexLog = new Regex(logPatern);
            regexType = new Regex(typePatern);
            regexIp = new Regex(ipPatern);
        }

        /// <summary>
        /// Getting api's organization name
        /// </summary>
        /// <param name="ip">ip</param>
        /// <returns>organization name</returns>
        string GetIpOwner(WebClient wcIP, string ip)
        {
            string url = $"http://ip-api.com/json/{ip}";
            string str = wcIP.DownloadString(url);

            Match mt = regexIp.Match(str);
            string org = mt.Value.Replace("\"", "");
            Thread.Sleep(400);

            return org;
        }
        /// <summary>
        /// Get file name from select dialog
        /// </summary>
        /// <returns>selected file name</returns>
        string GetFileName()
        {
            OpenFileDialog open = new OpenFileDialog
            {
                Filter = "Apache log file|*.log",
                Title = "Select a log file",
                FilterIndex = 2,
                Multiselect = false
            };

            return open.ShowDialog() == DialogResult.OK ? open.FileName : "";
        }
        /// <summary>
        /// Get information about file
        /// </summary>
        /// <param name="file">Url to file</param>
        /// <returns>Tuple with title and size in butes</returns>
        Tuple<string, int> GetFileInfo(WebClient wcFile, string file)
        {
            string text = wcFile.DownloadString($"{tbBase.Text}/{file}");
            string title = Regex.Match(text, @"\<title\b[^>]*\>\s*(?<Title>[\s\S]*?)\</title\>", RegexOptions.IgnoreCase).Groups["Title"].Value;
            int size = text.Length * sizeof(char);

            return new Tuple<string, int>(string.IsNullOrWhiteSpace(title) ? Path.GetFileNameWithoutExtension(file) : title, size);
        }

        /// <summary>
        /// Getting and setting file info (size and title)
        /// </summary>
        void SetFileTitle()
        {
            try
            {
                Invoke((MethodInvoker)delegate { lblStatusFile.Visible = true; });

                if (loadFileInformationToolStripMenuItem.Checked)
                {
                    using (WebClient wcFile = new WebClient())
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        wcFile.Encoding = Encoding.UTF8;

                        wcFile.Headers.Add("Accept-Charset", "utf-8");

                        conn.Open();

                        int i = 0;
                        foreach (var item in files)
                        {
                            i++;

                            if (!IsExist(conn, "FILEList", "PATH", item.Path))
                            {
                                var info = GetFileInfo(wcFile, item.Path);
                                item.HTMLTitle = info.Item1;
                                item.Size = info.Item2;
                            }

                            Invoke((MethodInvoker)delegate { lblStatusFile.Text = $"[Get file name: {i}/{files.Count}]"; });
                        }

                        conn.Close();
                    }
                }

                Invoke((MethodInvoker)delegate { lblStatusFile.Visible = false; });

                FileProcessed = true;
                SaveDB();
            }
            catch (ThreadAbortException)
            {
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Setting org name for ips
        /// </summary>
        void SetIpOwner()
        {
            try
            {
                Invoke((MethodInvoker)delegate { lblStatusIP.Visible = true; });

                if (loadIpsOwnerToolStripMenuItem.Checked)
                {
                    using (WebClient wcIP = new WebClient())
                    using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                    {
                        conn.Open();

                        int i = 0;
                        foreach (var item in ips)
                        {
                            i++;
                            if (!IsExist(conn, "IPList", "IP", item.Ip))
                                item.NetName = GetIpOwner(wcIP, item.Ip);

                            Invoke((MethodInvoker)delegate { lblStatusIP.Text = $"[Get ip organization: {i}/{ips.Count}]"; });
                        }

                        conn.Close();
                    }
                }

                Invoke((MethodInvoker)delegate { lblStatusIP.Visible = false; });

                IpProcessed = true;
                SaveDB();
            }
            catch (ThreadAbortException)
            {
                Environment.Exit(0);
            }
        }
        /// <summary>
        /// Load records from file
        /// </summary>
        /// <param name="lines"></param>
        void LoadFile(string[] lines)
        {
            int linesCount = 0;
            string buffer = "";

            pgLinesProcessed.Visible = true;

            foreach (var line in lines)
            {
                pgLinesProcessed.Value = (100 * linesCount++) / lines.Length;

                Match log = regexLog.Match(line);
                Match file = regexType.Match(log.Groups[5].Value);

                /////////////////////
                //FILE
                ////////////////////
                Uri ur = new Uri($"{tbBase.Text}{file.Groups[2].Value}");
                buffer = ur.AbsolutePath;
                var ex = Path.GetExtension(buffer);
                if (string.IsNullOrWhiteSpace(ex) ||
                   ex == ".css" ||
                   ex == ".ico" ||
                   ex == ".jpg" ||
                   ex == ".jpeg" ||
                   ex == ".png" ||
                   ex == ".bmp" ||
                   ex == ".gif" ||
                   ex == ".js" ||
                   file.Groups[2].Value.EndsWith("robots.txt") ||
                   file.Groups[2].Value.EndsWith("robot.txt"))
                    continue;

                FileUnit fileunit = new FileUnit(buffer);
                if (!files.Contains(fileunit))
                {
                    //ip.NetName = Whois.NET.WhoisClient.Query(ip.Ip).OrganizationName;
                    files.Add(fileunit);
                }

                /////////////////////////
                //IP
                /////////////////////////
                IpUnit ip = new IpUnit(log.Groups[1].Value);
                if (!ips.Contains(ip))
                {
                    //ip.NetName = Whois.NET.WhoisClient.Query(ip.Ip).OrganizationName;
                    ips.Add(ip);
                }

                /////////////////////////
                //UNITS
                /////////////////////////
                LogUnit unit = new LogUnit()
                {
                    Response = Convert.ToInt32(log.Groups[6].Value),
                    ResponseSize = Convert.ToUInt64(log.Groups[7].Value),
                    Type = file.Groups[1].Value,
                    DateString = log.Groups[4].Value,
                    Ip = ips.First((cip) => cip.Ip == log.Groups[1].Value),
                    File = files.First((cfile) => cfile.Path == buffer)
                };

                units.Add(unit);
            }


            ThreadIp.Start();
            ThreadFile.Start();

            pgLinesProcessed.Visible = false;
        }

        /// <summary>
        /// Saving ips, files, and main table to BD
        /// </summary>
        void SaveDB()
        {
            if (FileProcessed && IpProcessed)
            {
                FileProcessed = false;
                IpProcessed = false;

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    connection.Open();

                    SaveIP(connection);
                    SaveFILE(connection);

                    SaveMain(connection);

                    connection.Close();
                }

                Invoke((MethodInvoker)delegate { lblReady.Visible = true; });

                ips.Clear();
                files.Clear();
                units.Clear();

                GC.Collect();
                GC.WaitForPendingFinalizers();

                Invoke((MethodInvoker)delegate
                {
                    tsmiOpen.Enabled = true;
                    LoadTable();
                });
            }
        }
        /// <summary>
        /// Load concrete table to DataGridView
        /// </summary>
        void LoadTable()
        {
            using (SqlConnection conn = new SqlConnection(sqlConnectionString))
            {
                conn.Open();

                string sqlQuery = (currentTable == "IPList" || currentTable == "FILEList") ?
                    $"select * " +
                    $"from {currentTable} "
                    :
                    "select Main.Id as 'Id', Main.DATE as 'Date', Main.TYPE as 'Request type', " +
                    "Main.RESPONSE as 'Response', Main.RESPONSE_SIZE as 'Response size', " +
                    "FILEList.PATH as 'File', IPList.IP as 'Ip' from  Main " +
                    "join FILEList on FILEList.Id=Main.FILE_ID " +
                    "join IPList on IPList.Id=Main.IP_ID ";


                using (SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, conn))
                {
                    DataTable table = new DataTable
                    {
                        Locale = System.Globalization.CultureInfo.InvariantCulture
                    };
                    adapter.Fill(table);

                    var a = table.AsDataView();
                    a.RowFilter = currentWhere;

                    bindingSource.DataSource = a.ToTable();

                    List<string> n = new List<string>();
                    foreach (DataColumn col in table.Columns)
                        n.Add(col.ColumnName);

                    columnName = n.ToArray();
                }

                conn.Close();
            }
        }
        /// <summary>
        /// Exist record in table
        /// </summary>
        /// <param name="sqlConnection">Connection</param>
        /// <param name="tableName">Table name</param>
        /// <param name="columnName">Column name</param>
        /// <param name="value">Value of searched column</param>
        /// <returns>True - exist</returns>
        bool IsExist(SqlConnection sqlConnection, string tableName, string columnName, string value)
        {
            SqlCommand cmd = new SqlCommand
            {
                CommandText = $"SELECT COUNT(*) from {tableName} where {columnName}='{value}'",
                CommandType = CommandType.Text,
                Connection = sqlConnection
            };

            return (int)cmd.ExecuteScalar() > 0;
        }

        /// <summary>
        /// Saving ip to DB
        /// </summary>
        /// <param name="sqlConnection">SqlConnection</param>
        void SaveIP(SqlConnection sqlConnection)
        {
            Invoke((MethodInvoker)delegate { lblSaveIp.Visible = true; });

            SqlCommand cmd = new SqlCommand();

            int i = 0;
            foreach (var item in ips)
            {
                i++;

                cmd.CommandText = $"INSERT IPList (IP, ORGANIZATION) " +
                                  "output INSERTED.ID " +
                                 $"SELECT '{item.Ip}','{item.NetName}' " +
                                  $"WHERE NOT EXISTS(SELECT * FROM IPList WHERE IP = '{item.Ip}')";


                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;

                object retData = cmd.ExecuteScalar();

                if (retData == null)
                {
                    cmd.CommandText = "SELECT Id " +
                                      "from IPList " +
                                     $"WHERE IP like '%{item.Ip}%'";

                    item.Id = (int?)cmd.ExecuteScalar() ?? -1;
                }
                else
                    item.Id = (int)retData;

                Invoke((MethodInvoker)delegate { lblSaveIp.Text = $"[Save ip to DB: {i}/{ips.Count}]"; });
            }

            Invoke((MethodInvoker)delegate { lblSaveIp.Visible = false; });
        }
        /// <summary>
        /// Saving files to DB
        /// </summary>
        /// <param name="sqlConnection">SqlConnection</param>
        void SaveFILE(SqlConnection sqlConnection)
        {
            Invoke((MethodInvoker)delegate { lblSaveFile.Visible = true; });

            SqlCommand cmd = new SqlCommand();

            int i = 0;
            foreach (var item in files)
            {
                i++;

                cmd.CommandText = $"INSERT FILEList (PATH, TITLE, SIZE) " +
                                  "output INSERTED.ID " +
                                  $"SELECT '{item.Path}', N'{item.HTMLTitle}', {item.Size} " +
                                  $"WHERE NOT EXISTS(SELECT * FROM FILEList WHERE PATH = '{item.Path}')";

                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;

                object retData = cmd.ExecuteScalar();

                if (retData == null)
                {
                    cmd.CommandText = "SELECT Id " +
                                      "from IPList " +
                                     $"WHERE IP like '%{item.Path}%'";

                    item.Id = (int?)cmd.ExecuteScalar() ?? -1;
                }
                else
                    item.Id = (int)retData;

                Invoke((MethodInvoker)delegate { lblSaveFile.Text = $"[Save file to DB: {i}/{files.Count}]"; });
            }

            Invoke((MethodInvoker)delegate { lblSaveFile.Visible = false; });
        }
        /// <summary>
        /// Saving Main table to DB
        /// </summary>
        /// <param name="sqlConnection">SqlConnection</param>
        void SaveMain(SqlConnection sqlConnection)
        {
            Invoke((MethodInvoker)delegate { lblMainSaving.Visible = true; });

            SqlCommand cmd = new SqlCommand();

            int i = 0;
            foreach (var item in units)
            {
                i++;

                if (item.Ip.Id == -1 || item.File.Id == -1)
                    continue;

                cmd.CommandType = CommandType.Text;
                cmd.Connection = sqlConnection;

                cmd.CommandText = $"INSERT Main (DATE, TYPE, RESPONSE, RESPONSE_SIZE, IP_ID, FILE_ID)" +
                                   $"SELECT '{item.DateString}','{item.Type}', {item.Response}, {item.ResponseSize}, {item.Ip.Id}, {item.File.Id}";

                cmd.ExecuteNonQuery();

                Invoke((MethodInvoker)delegate { lblMainSaving.Text = $"[Save main to DB: {i}/{units.Count}]"; });
            }

            Invoke((MethodInvoker)delegate { lblMainSaving.Visible = false; });
        }

        #region event section
        private void OpenClick(object sender, EventArgs e)
        {
            string FileName = GetFileName();
            if (!string.IsNullOrWhiteSpace(FileName))
            {
                tsmiOpen.Enabled = false;
                lblReady.Visible = false;

                string text = File.ReadAllText(FileName);

                string[] lines = text.Split('\n');

                ThreadIp = new Thread(new ThreadStart(SetIpOwner));
                ThreadFile = new Thread(new ThreadStart(SetFileTitle));

                LoadFile(lines);
            }
        }
        private void FormClosingEvent(object sender, FormClosingEventArgs e)
        {
            if (ThreadIp != null && ThreadIp.IsAlive)
                ThreadIp.Abort();

            if (ThreadFile != null && ThreadFile.IsAlive)
                ThreadFile.Abort();
        }
        private void FormLoad(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bindingSource;

            LoadTable();
        }
        private void loadIpsOwnerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadIpsOwnerToolStripMenuItem.Checked = !loadIpsOwnerToolStripMenuItem.Checked;
        }
        private void loadFileInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFileInformationToolStripMenuItem.Checked = !loadFileInformationToolStripMenuItem.Checked;
        }
        private void treeViewAfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode == null)
                return;

            if (currentTable != treeView1.SelectedNode.Tag.ToString())
            {
                treeView1.Nodes[0].Text = treeView1.Nodes[0].Text.Replace(" >", "");
                treeView1.Nodes[1].Text = treeView1.Nodes[1].Text.Replace(" >", "");
                treeView1.Nodes[2].Text = treeView1.Nodes[2].Text.Replace(" >", "");

                e.Node.Text += " >";

                currentTable = treeView1.SelectedNode.Tag.ToString();
                LoadTable();
            }
        }
        private void btnRefrechClick(object sender, EventArgs e)
        {
            LoadTable();
        }
        private void btnClearClick(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Clear this table?", "Alert!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(sqlConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand
                    {
                        CommandText = $"delete from {currentTable}",
                        CommandType = CommandType.Text,
                        Connection = conn
                    };

                    cmd.ExecuteNonQuery();

                    conn.Close();
                }

                LoadTable();
            }
        }
        private void AboutApacheLogParserClick(object sender, EventArgs e)
        {
            new AboutBox().ShowDialog();
        }
        private void websiteClick(object sender, EventArgs e)
        {
            Process.Start("https://verloka.github.io");
        }
        private void btnSearchClick(object sender, EventArgs e)
        {
            currentWhere = new Search().ShowSearchDialog(columnName);

            LoadTable();

            currentWhere = "";
        }
        private void ExitClic(object sender, EventArgs e)
        {
            Close();
        }
        private void btnFilteringClick(object sender, EventArgs e)
        {
            currentWhere = new Filtering().ShowSearchDialog(columnName);

            LoadTable();

            currentWhere = "";
        }
        #endregion
    }
}
