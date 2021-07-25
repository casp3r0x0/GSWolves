using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GSWolves_Viewer
{
    public partial class exam : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        //
        const uint WDA_NONE = 0;
        const uint WDA_MONITOR = 1;

        [DllImport("user32.dll")]

        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);

        Main f1;
        public exam(Main frm1)
        {

            SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
            InitializeComponent();
            this.f1 = frm1;


        }
        public static String betweenStrings(String text, String start, String end)
        {
            int p1 = text.IndexOf(start) + start.Length;
            int p2 = text.IndexOf(end, p1);

            if (end == "") return (text.Substring(p1));
            else return text.Substring(p1, p2 - p1);
        }
        private void exam_Load(object sender, EventArgs e)
        {
            int radstart = 100;
            int radend = 1;
            RadioButton addradio(string i, string text, int end, string tags)
            {
                RadioButton rdo = new RadioButton();
                rdo.Name = "RadioButton" + i.ToString();
                rdo.Text = text;
                rdo.Tag = tags;
                rdo.Font = new Font("Century Gothic", 12, FontStyle.Bold); ;
                rdo.Location = new Point(50, 40 * end);
                //rdo.Click += new EventHandler(this.radio_click);
                return rdo;
            }
            Panel addquestionpannel(int i, int start, int end)
            {
                Panel pl = new Panel();
                pl.Name = "panel" + i.ToString();
                pl.BackColor = Color.Green;
                pl.Width = 600;
                pl.Height = 300;
                pl.Location = new Point(start, end);
                pl.Margin = new Padding(5);
                pl.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
                pl.AutoScroll = true;
                return pl;
            }
            string examurl = f1.examurllabel.Text;
            //WebClient wc = new WebClient();
            //RichTextBox rh = new RichTextBox();
            //wc.Encoding = System.Text.Encoding.GetEncoding(1256);
            //rh.Text = wc.DownloadString(examurl);
            //rh.Text = rh.Text.Trim();
            WebClient wc = new WebClient();
            label2.Text += wc.DownloadString(examurl + "mark.txt");
            //pannels  
            //function  for  creating  the  render
            int startposition = 10;
            int endposotion = 10;
            for (int i = 0; i <= 9; i++)
            {
                Panel l = addquestionpannel(i, startposition, endposotion);
                panel2.Controls.Add(l);
                endposotion += 310;
            }
            //
            List<int> listNumbers = new List<int>();
            int number;
            for (int i = 0; i < 10; i++)
            {
                do
                {
                    Random rand = new Random();
                    number = rand.Next(1, 30);
                } while (listNumbers.Contains(number));
                listNumbers.Add(number);
            }//creating the  random  numbers  
            //get the urls of the  questions  
            RichTextBox questionslist = new RichTextBox();
            List<string> all = new List<string>();
            foreach (int n in listNumbers)
            {
                string lll = "";
                lll = questionslist.Text + examurl + n.ToString() + ".txt";
                all.Add(lll);
            }
            questionslist.Lines = all.ToArray();
            //MessageBox.Show(questionslist.Text);
            //get the  text  from  url  and  rendreing it into  the pannels 
            RichTextBox r1 = new RichTextBox();
            RichTextBox r2 = new RichTextBox();
            RichTextBox r3 = new RichTextBox();
            RichTextBox r4 = new RichTextBox();
            RichTextBox r5 = new RichTextBox();
            RichTextBox r6 = new RichTextBox();
            RichTextBox r7 = new RichTextBox();
            RichTextBox r8 = new RichTextBox();
            RichTextBox r9 = new RichTextBox();
            RichTextBox r10 = new RichTextBox();
            for(int y  = 0;  y <= 9; y++)
            {
                WebClient g = new WebClient();
                r1.Text = g.DownloadString(questionslist.Lines[0]);
                r2.Text = g.DownloadString(questionslist.Lines[1]);
                r3.Text = g.DownloadString(questionslist.Lines[2]);
                r4.Text = g.DownloadString(questionslist.Lines[3]);
                r5.Text = g.DownloadString(questionslist.Lines[4]);
                r6.Text = g.DownloadString(questionslist.Lines[5]);
                r7.Text = g.DownloadString(questionslist.Lines[6]);
                r8.Text = g.DownloadString(questionslist.Lines[7]);
                r9.Text = g.DownloadString(questionslist.Lines[8]);
                r10.Text = g.DownloadString(questionslist.Lines[9]);
            }
            foreach (Control pannel in panel2.Controls)
            {
                if (pannel is Panel)
                {
                    if (pannel.Name == "panel0")
                    {

                        foreach (string line in r1.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //2
                    if (pannel.Name == "panel1")
                    {

                        foreach (string line in r2.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //3
                    if (pannel.Name == "panel2")
                    {

                        foreach (string line in r3.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //4
                    if (pannel.Name == "panel3")
                    {

                        foreach (string line in r4.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //5
                    if (pannel.Name == "panel4")
                    {

                        foreach (string line in r5.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //6
                    if (pannel.Name == "panel5")
                    {

                        foreach (string line in r6.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //7
                    if (pannel.Name == "panel6")
                    {

                        foreach (string line in r7.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //8
                    if (pannel.Name == "panel7")
                    {

                        foreach (string line in r8.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //9
                    if (pannel.Name == "panel8")
                    {

                        foreach (string line in r9.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                    //10
                    if (pannel.Name == "panel9")
                    {

                        foreach (string line in r10.Lines)
                        {
                            if (line.StartsWith("ques="))
                            {
                                Label lab = new Label();
                                lab.Text = line.Replace("ques=", "");
                                lab.Font = new Font("Century Gothic", 24, FontStyle.Bold);
                                lab.AutoSize = true;
                                pannel.Controls.Add(lab);
                            }
                            if (line.Contains("$$$$$"))
                            {
                                string[] i = line.Split('~');
                                string tags = i[4] + "~" + i[5];
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("~") && !(line.Contains("$$$$$")))
                            {
                                string[] i = line.Split('~');
                                string tags = "false";
                                RadioButton rad = addradio(i[1], i[2], radend, tags);
                                pannel.Controls.Add(rad);
                                radend += 1;
                            }
                            if (line.StartsWith("image="))
                            {
                                string image;
                                image = line.Replace("image=", "");

                                try
                                {
                                    PictureBox imag = new PictureBox();
                                    imag.Dock = DockStyle.Fill;
                                    var request = WebRequest.Create(image);
                                    using (var response = request.GetResponse())
                                    using (var stream = response.GetResponseStream())
                                    {
                                        imag.Image = Bitmap.FromStream(stream);
                                    }
                                    imag.Dock = DockStyle.Bottom;
                                    imag.SizeMode = PictureBoxSizeMode.Zoom;
                                    imag.Name = image;
                                    imag.Size = new Size(100, 200);
                                    imag.Click += new EventHandler(this.imageclicked);
                                    pannel.Controls.Add(imag);
                                }
                                catch { }
                            }

                        }
                        radend = 1;
                    }
                }
            }



        }
        void imageclicked(object sender, EventArgs e)
        {
            PictureBox btn = sender as PictureBox;
            //MessageBox.Show(btn.Name); 
            pictureboxv frm2 = new pictureboxv(btn.Name);
            frm2.Show();
        }
        private void exam_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        protected override void WndProc(ref Message m)
        {
            const int RESIZE_HANDLE_SIZE = 10;

            switch (m.Msg)
            {
                case 0x0084/*NCHITTEST*/ :
                    base.WndProc(ref m);

                    if ((int)m.Result == 0x01/*HTCLIENT*/)
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32());
                        Point clientPoint = this.PointToClient(screenPoint);
                        if (clientPoint.Y <= RESIZE_HANDLE_SIZE)
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)13/*HTTOPLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)12/*HTTOP*/ ;
                            else
                                m.Result = (IntPtr)14/*HTTOPRIGHT*/ ;
                        }
                        else if (clientPoint.Y <= (Size.Height - RESIZE_HANDLE_SIZE))
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)10/*HTLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)2/*HTCAPTION*/ ;
                            else
                                m.Result = (IntPtr)11/*HTRIGHT*/ ;
                        }
                        else
                        {
                            if (clientPoint.X <= RESIZE_HANDLE_SIZE)
                                m.Result = (IntPtr)16/*HTBOTTOMLEFT*/ ;
                            else if (clientPoint.X < (Size.Width - RESIZE_HANDLE_SIZE))
                                m.Result = (IntPtr)15/*HTBOTTOM*/ ;
                            else
                                m.Result = (IntPtr)17/*HTBOTTOMRIGHT*/ ;
                        }
                    }
                    return;
            }
            base.WndProc(ref m);
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style |= 0x20000; // <--- use 0x20000
                return cp;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            f1.Show(); 
            this.Close();  
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("are you sure ? ", "Warning", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int mark = Convert.ToInt32(label2.Text.Replace("Mark  :  ", ""));
                foreach (Control pannel in panel2.Controls)
                {

                    foreach (Control rad in pannel.Controls)
                    {
                        if (rad is RadioButton)
                        {
                            RadioButton rb = new RadioButton();
                            rb = (RadioButton)rad;

                            if (rb.Tag.ToString().Contains("points:"))
                            {
                                if (rb.Checked)
                                {

                                }
                                else
                                {
                                    string[] i = rb.Tag.ToString().Split('~');

                                    MessageBox.Show( "you have wrong answer \n" + i[1]);
                                    mark = mark - Convert.ToInt32(i[0].Replace("points:", ""));
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("your mark is  :  " + mark.ToString());
                if  (mark < 18)
                {
                    MessageBox.Show("you have been faild "); 
                }else
                {
                    MessageBox.Show("You have been Success \n your ready to go to the next  level ");
                    Properties.Settings.Default.l = Convert.ToString(Convert.ToInt32(Properties.Settings.Default.l) + 1); 
                    WebClient f = new WebClient();
                    string x = f.DownloadString("http://" + Properties.Settings.Default.domain + "/index/changelevel.php?session_id=" + Properties.Settings.Default.session_id + "&v=" + Properties.Settings.Default.l);
                    Properties.Settings.Default.viewed = "1";
                    string put;
                    WebClient wc = new WebClient();
                    put = wc.DownloadString("http://" + Properties.Settings.Default.domain + "/index/changeveiwed.php?session_id=" + Properties.Settings.Default.session_id + "&v=" + Properties.Settings.Default.viewed);
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }
        }
    }
}
