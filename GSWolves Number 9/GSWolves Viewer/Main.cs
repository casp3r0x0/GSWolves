using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace GSWolves_Viewer
{
    public partial class Main : Form
    {
        

        //corner
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
      (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // width of ellipse
          int nHeightEllipse // height of ellipse
      );
        //corner
        const uint WDA_NONE = 0;
        const uint WDA_MONITOR = 1;

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);
        public Main()
        {
            InitializeComponent();
            //MessageBox.Show(Properties.Settings.Default.viewed); 
            this.SetStyle(ControlStyles.ResizeRedraw, true);  
            SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
           
            //make
            this.FormBorderStyle = FormBorderStyle.None;
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            //make 
            //change font  
            PrivateFontCollection PFC = new PrivateFontCollection();
            PFC.AddFontFile(Application.StartupPath + @"\Font\Redressed-Regular.ttf");
            //foreach (Control c in this.Controls)
            //{
            label1.Font = new Font(PFC.Families[0], 15, FontStyle.Regular);
            label2.Font = new Font(PFC.Families[0], 15, FontStyle.Regular);
            //}
        }
        private void customDesign()
        {
            panel5.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panel5.Visible == true)
                panel5.Visible = false;
        }
        private void showSubmenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;  

            }
        }
        private const int cGrip = 16;      // Grip size
        private const int cCaption = 32;   // Caption bar height;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point p = new Point(m.LParam.ToInt32());
                p = this.PointToClient(p);
                if (p.Y <= cCaption && p.Y >= cGrip)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (p.X >= this.ClientSize.Width - cGrip && p.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
                if (p.X <= cGrip && p.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)16;
                    return;
                }
                if (p.X <= cGrip)
                {
                    m.Result = (IntPtr)10;
                    return;
                }
                if  (p.X >= ClientSize.Width -cGrip)
                {
                    m.Result = (IntPtr)11;
                    return; 
                }
            }
            base.WndProc(ref m);
        }
        private void Main_Load(object sender, EventArgs e)
        {
            label2.Text = "Level " + Properties.Settings.Default.l;
            label1.Text = "wellcom " + Properties.Settings.Default.username;
            WebClient wc = new WebClient();
            RichTextBox rh = new RichTextBox();  
            rh.Text = wc.DownloadString("http://" + Properties.Settings.Default.domain + "/index/levels/getlevels.php").Replace("getlevels.php", "").Replace(".txt", "").Replace(" ", "").Replace("\n\n", "");
            rh.Text = rh.Text.Trim();
            //MessageBox.Show(rh.Text);
            //make buttons 
            Panel safe = new Panel();
            safe.Size = new Size(194, 1);
            safe.Dock = DockStyle.Top;
            panel5.Controls.Add(safe);
            foreach (string level in rh.Lines)
            {
                PrivateFontCollection PFC = new PrivateFontCollection();
                PFC.AddFontFile(Application.StartupPath + @"\Font\Redressed-Regular.ttf");
                Button levelbutton = new Button();
                levelbutton.Text = level;
                levelbutton.Name = level;  
                //levelbutton.Location = new Point(70, 70);
                levelbutton.Size = new Size(173, 59);
                levelbutton.Visible = true;
                levelbutton.Enabled = false; 
                //levelbutton.BringToFront();
                levelbutton.Dock = DockStyle.Bottom;
                levelbutton.BackColor = Color.FromArgb(36, 32, 41);
                levelbutton.FlatStyle = FlatStyle.Flat;
                levelbutton.Font = new Font("French Script MT", 18);
                //levelbutton.ForeColor = Color.FromArgb(43, 145, 175);
                levelbutton.MouseEnter += new EventHandler(this.button_MouseEnter);
                levelbutton.MouseLeave += new EventHandler(this.button_MouseLeave);
                levelbutton.Click += new EventHandler(this.button_click); 
                panel5.Controls.Add(levelbutton);
            }

            //make buttons 
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           try
            {
                //corner  
                this.FormBorderStyle = FormBorderStyle.None;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 40, 40));
                //just vewied vedios  
                
                foreach (Control c in flowLayoutPanel1.Controls)
                {
                    if (c.Name.Contains("panel "))
                    {
                        string[] allx = c.Name.Split(' ');
                        string name = allx[0];
                        int number = Convert.ToInt32(allx[1]);
                        if (number <= Convert.ToInt32(Properties.Settings.Default.viewed))
                        {
                            c.Enabled = true;
                        }
                    }
                   if  (c.Name.Contains("exam"))
                    {
                        c.Enabled = true;  
                    }
                }
           }
           catch { } 


        }
        //move
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //move
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            // this.Close(); 
            //set the user is online 
            string temp = "";
            WebClient g = new WebClient();
            temp = g.DownloadString("http://" + Properties.Settings.Default.domain + "/index/changestatus.php?session_id=" + Properties.Settings.Default.session_id + "&s=off");
            System.Windows.Forms.Application.Exit();
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

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Panel1.Visible)
            {
                splitContainer1.Panel1Collapsed = true;
            }
            else
            {
                splitContainer1.Panel1Collapsed = false;
            }






        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            showSubmenu(panel5);
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        
        void button_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(116, 82, 166);

        }
        void button_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(36, 32, 41);
        }
        void button_click(object sender, EventArgs e)
        {

            Button btn = sender as Button;
            //MessageBox.Show(btn.Name + " Clicked");
            flowLayoutPanel1.Controls.Clear();
            WebClient wc = new WebClient();
            RichTextBox rh = new RichTextBox();
            rh.Text = wc.DownloadString("http://" + Properties.Settings.Default.domain + "/index/levels/" + btn.Name + ".txt");
            string id;
            string vediourl;
            string imageurl;
            string Duration;  
            foreach (string line in rh.Lines)
            {
                string[] all = line.Split('#');
                id = all[0];
                vediourl = all[1];
                imageurl = all[2];
                Duration = all[3]; 
                Panel pan = new Panel();
                //pan
                //pan.Name = "panel " + id;
                if (id.Contains("exam"))
                {
                    pan.Name = id;
                }
                else
                {
                    pan.Name = "panel " + id;
                }
               // MessageBox.Show(pan.Name);
                pan.BackColor = Color.FromArgb(38, 137, 175);
                pan.Width = 194;
                pan.Height = 232;
                pan.Enabled = false; 
                pan.Margin = new Padding(5);
                //button 
                Button butn = new Button();
                butn.Name = vediourl;
                if (id == "exam")
                {
                    butn.Text = "Take";
                    butn.Name = "exam#" + vediourl ; 
                }
                else
                {
                    butn.Text = "view";
                }

                butn.Size = new Size(194, 39);
                butn.Font = new Font("Century Gothic", 18);
                butn.BackColor = Color.FromArgb(26, 30, 28);
                butn.Dock = DockStyle.Bottom;
                butn.FlatStyle = FlatStyle.Flat;
                butn.ForeColor = Color.White;
                butn.Tag = id + "#" + Duration;
                butn.Click += new EventHandler(this.buttonview_click);
                pan.Controls.Add(butn);
                //picture  
                try
                {
                    PictureBox imag = new PictureBox();
                    imag.Dock = DockStyle.Fill;
                    imag.SizeMode = PictureBoxSizeMode.StretchImage; 
                    var request = WebRequest.Create(imageurl);
                    using (var response = request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    {
                        imag.Image = Bitmap.FromStream(stream);
                    }
                    imag.Dock = DockStyle.Fill;
                    pan.Controls.Add(imag);
                }
                catch { }
                //label
                Label lab = new Label();
                if (id == "exam")
                {
                    lab.Text = id;
                }
                else
                {
                    lab.Text = "Vedio Number : " + id;
                }

                lab.Dock = DockStyle.Top;
                lab.Font = new Font("Century Gothic", 12);
                pan.Controls.Add(lab);
                flowLayoutPanel1.Controls.Add(pan);
                hideSubMenu();
            }
        }
        void buttonview_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            //MessageBox.Show(btn.Name);
            if (btn.Name.Contains("exam"))
            {
                string[] sd = btn.Name.Split('#');
                string examurl = sd[1];
                examurllabel.Text = examurl;
                exam exa = new exam(this);
                this.Hide(); 
                exa.Show();  

            }else
            {
                vedioidtitle.Text = btn.Tag.ToString(); 
                vediourllabel.Text = btn.Name;   
                viewer v = new viewer (this);
                v.Show();
                this.Hide(); 
            }
        }

        private void vediourllabel_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            try
            {
                label2.Text = "Level " + Properties.Settings.Default.l;
                foreach (Control levelbutn in panel5.Controls)
                {
                    levelbutn.Enabled = false; 
                    if (levelbutn.Name == "level" + label2.Text.Replace("Level ", ""))
                    {
                        levelbutn.Enabled = true;
                    }
                }
                
            }
            catch{  }
        }
    }
}
