using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRGame
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
        }
        Dictionary<DateTime, int> result = new Dictionary<DateTime, int>();

        Regex r = new Regex(@"\w+年\s*\w+月\s*\w+日");

        private void findfile_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "c:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            using (StreamReader sr = new StreamReader(myStream))
                            {
                                string line;
                                // Read and display lines from the file until the end of 
                                // the file is reached.
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if(line.StartsWith("时间"))
                                    {
                                        DateTime time = DateTime.Parse(r.Match(line).ToString());
                                        if (result.ContainsKey(time))
                                            result[time] += 1;
                                        else
                                            result.Add(time, 1);
                                    }
                                    //Console.WriteLine(line);
                                }
                            }
                            // Insert code to read the stream here.
                        }
                    }

                    filePath.Text = openFileDialog1.FileName;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }
        
        private void generalResult_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<DateTime,int> item in result)
            {
                sb.AppendLine(item.Key.ToString("yyyy-MM-dd") + "," + item.Value);
            }

            result = new Dictionary<DateTime, int>();

            Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = saveFileDialog1.OpenFile()) != null)
                {
                    using (StreamWriter sw = new StreamWriter(myStream))
                    {
                        sw.Write(sb.ToString());
                    }
                    // Code to write the stream goes here.
                    myStream.Close();
                }
            }

            resultllabel.Text = saveFileDialog1.FileName;
        }
    }
}
