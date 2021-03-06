﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;

namespace VRGame
{
    public partial class MainForm : Form
    {
        public Process currentProcess;
        public int currentPage;
        public int lastPage;
        public string path = Directory.GetCurrentDirectory();
        public Dictionary<int, Game> source = new Dictionary<int, Game>();
        public Log log;

        public MainForm()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackgroundImage = Image.FromFile(Path.Combine(path, "config", "img", "background.png"));
            this.BackgroundImageLayout = ImageLayout.Stretch;

            currentPage = 0;
            lastPage = deserialize();
            load(currentPage);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            excute(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            excute(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            excute(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            excute(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            excute(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            excute(6);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            excute(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            excute(8);
        }

        private void left_Click(object sender, EventArgs e)
        {
            currentPage -= 1;
            load(currentPage);
        }

        private void right_Click(object sender, EventArgs e)
        {
            currentPage += 1;
            load(currentPage);
        }

        private void kill_Click(object sender, EventArgs e)
        {
            load(currentPage);
            SendKeys.Send("{ESC}");
            Thread.Sleep(1000);
            currentProcess.Kill();
            currentProcess.Close();
            recordFinish(DateTime.Now);
        }

        private void excute(int buttonNo)
        {
            currentProcess = Process.Start(source[currentPage * 8 + buttonNo].ExcutePath);
            loadGaming();
            recordStart(buttonNo, DateTime.Now);
        }

        private void load(int page)
        {
            foreach (Control c in this.Controls)
            {
                c.Visible = true;
                if (c is Button && c.Name.StartsWith("button"))
                {
                    int key = page * 8 + int.Parse(Regex.Match(c.Name, @"\d+").Value);
                    if (source.ContainsKey(key))
                        c.BackgroundImage = Image.FromFile(Path.Combine(path, "config", source[key].ImgName));
                    else
                        c.Visible = false;
                }
            }

            kill.Visible = false;

            left.Enabled = page == 0 ? false : true;
            left.BackgroundImage = Image.FromFile(Path.Combine(path, "config", "img", page == 0 ? "left_disable.png" : "left_enable.png"));

            right.Enabled = page == lastPage ? false : true;
            right.BackgroundImage = Image.FromFile(Path.Combine(path, "config", "img", page == lastPage ? "right_disable.png" : "right_enable.png"));
        }

        private void loadGaming()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button && c.Name.Equals("kill"))
                {
                    c.BackgroundImage = Image.FromFile(Path.Combine(path, "config", "img", "kill.png"));
                    c.Visible = true;
                }
                else
                    c.Visible = false;
            }
        }

        private int deserialize()
        {
            int i = 0;
            foreach (var line in File.ReadLines(path + @"\config\conf.ini"))
            {
                if (!line.StartsWith("#"))
                {
                    Game game = new Game(line);
                    source.Add(game.No, game);
                    i++;
                }
            }

            return (i / 8) - 1;
        }

        private void recordStart(int gameid, DateTime time)
        {
            log = new Log(gameid, time);
        }

        private void recordFinish(DateTime time)
        {
            log.finish(time);

            string filePath = Path.Combine(path, "log", DateTime.Now.Date.ToString("yyyy-MM-dd") + ".csv");
            if (!File.Exists(filePath))
            {
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    sw.WriteLine(Log.titleSerialize());
                }
            }

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine(log.serialize());
            }
        }

    }
}
