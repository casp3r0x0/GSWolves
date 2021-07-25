using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient; 
namespace Manager
{
    public partial class edit : MetroFramework.Forms.MetroForm
    {
        public edit(string q0, string q1, string q2, string q3, string q4, string q5)
        {
            InitializeComponent();
            metroTextBox1.Text = q0;
            metroTextBox2.Text = q1;
            metroTextBox3.Text = q2;
            metroTextBox4.Text = q3;
            metroTextBox5.Text = q4;
            metroTextBox6.Text = q5; 

        }



        private void edit_Load(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + Properties.Settings.Default.domain + ";user=" + Properties.Settings.Default.sqlusername + ";database=" + Properties.Settings.Default.sqldatabase + ";port=3306;password=" + Properties.Settings.Default.sqlpassword;
            MySqlConnection conn = new MySqlConnection(connStr);
            //try to connect S
            string hash = CreateMD5(metroTextBox2.Text);
            try
            {
                conn.Open();

                string sql = "UPDATE status SET client_level='"+metroTextBox3.Text+"',client_status='"+metroTextBox4.Text+"',last_video_viewed='"+metroTextBox5.Text+"'WHERE session_id='"+metroTextBox6.Text+"'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //MessageBox.Show(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                conn.Open();

                string sql = "UPDATE clients SET username='" + metroTextBox1.Text + "' ,password = '" + metroTextBox2.Text + "'  WHERE session_id='" + metroTextBox6.Text + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //MessageBox.Show(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
                conn.Close();
                Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
