using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Text;
using System.Threading;
using System.Net;

namespace GSWolves_Viewer
{
    public partial class login : Form

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
        //flashing  

        List<Color> colors = new List<Color>();
        //flashing  
      
        const uint WDA_NONE = 0;
        const uint WDA_MONITOR = 1;

        [DllImport("user32.dll")]
        public static extern uint SetWindowDisplayAffinity(IntPtr hWnd, uint dwAffinity);
        public login()
        {
            //flashing 
            colors.Add(Color.FromArgb(0, 158, 71));
            colors.Add(Color.FromArgb(112, 191, 83));
            colors.Add(Color.FromArgb(216, 155, 40));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(217, 102, 41));
            colors.Add(Color.FromArgb(235, 83, 104));
            colors.Add(Color.FromArgb(223, 128, 255));
            colors.Add(Color.FromArgb(112, 48, 160));
            colors.Add(Color.FromArgb(107, 122, 187));
            colors.Add(Color.FromArgb(95, 136, 176));
            colors.Add(Color.FromArgb(70, 175, 227));
            colors.Add(Color.FromArgb(0, 158, 71));
            //flashing 
            InitializeComponent();
            SetWindowDisplayAffinity(this.Handle, WDA_MONITOR);
            //Change  Font Type  :  
            PrivateFontCollection PFC = new PrivateFontCollection();
            PFC.AddFontFile( Application.StartupPath + @"\Font\Redressed-Regular.ttf");
            //foreach (Control c in this.Controls)
            //{
               label1.Font = new Font(PFC.Families[0], 36, FontStyle.Regular);
            //}
 

        }

       

        private void Form1_Load(object sender, EventArgs e)

        {
           
            //button1.Parent = login();
            //label1.BackColor = Color.Transparent; 
        }
        //flashing
        int curcolor = 0;
        int loop = 0;  
        //flashing
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (curcolor < colors.Count - 1)
            {
                this.BackColor = Bunifu.Framework.UI.BunifuColorTransition.getColorScale(loop, colors[curcolor], colors[curcolor + 1]);
                if (loop < 100)
                {
                    loop++;
                }
                else
                {
                    loop = 0;
                    curcolor++;
                }
                timer1.Enabled = true;
            }
            else
            {
                loop = 0;
                curcolor = 0;
                timer1.Enabled = true;  
                //MessageBox.Show("ss");
            }
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            //this.Close();
            System.Windows.Forms.Application.Exit();

        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            //var myForm = new Main();
            //myForm.Show();
            
            string  check;  
            WebClient wc = new WebClient();
            check = wc.DownloadString("http://" + Properties.Settings.Default.domain + "/index/check.php?user=" + bunifuMetroTextbox1.Text + "&pass=" + CreateMD5( bunifuMetroTextbox2.Text));
            Properties.Settings.Default.session_id = check.Replace("  ", "");  
            //Clipboard.SetText(check);  
            if (check.Contains("fail"))
            {
                MessageBox.Show("username or password is wrong ");
               
            }
            else
            {
                WebClient le = new WebClient();
                string lev;
                lev = wc.DownloadString("http://" + Properties.Settings.Default.domain + "/index/getlevel.php?session_id=" + Properties.Settings.Default.session_id);
                Properties.Settings.Default.username = bunifuMetroTextbox1.Text;
                Properties.Settings.Default.password = bunifuMetroTextbox2.Text;
                string[] splits = lev.Split('#');
                Properties.Settings.Default.l = splits[0]; //level of the  user 
                Properties.Settings.Default.viewed = splits[1];
                var myForm = new Main();

                //check user status
                string c = "";
                WebClient t = new WebClient();
                c = t.DownloadString("http://" + Properties.Settings.Default.domain + "/index/getstatus.php?session_id=" + Properties.Settings.Default.session_id);
                if (c.Contains("on"))
                {
                    MessageBox.Show("this User is opend on another Device \n " + "Sorry  *_*");
                    Application.Exit();
                }
                else
                {
                    //set the user is online 
                    string temp = "";
                    WebClient g = new WebClient();
                    temp = g.DownloadString("http://" + Properties.Settings.Default.domain + "/index/changestatus.php?session_id=" + Properties.Settings.Default.session_id + "&s=on");
                    //Clipboard.SetText("http://" + Properties.Settings.Default.domain + "/index/changestatus.php?session_id=" + Properties.Settings.Default.session_id + "&s=on"); 
                    //
                    this.Hide();
                    myForm.Show();
                }
            }

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //corner  
            try
            {
                this.FormBorderStyle = FormBorderStyle.None;
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
                //corner  
            }catch { }
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {

        }
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
