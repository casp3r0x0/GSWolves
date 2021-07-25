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
using System.Data.SqlClient;

namespace Manager
{
    public partial class add : MetroFramework.Forms.MetroForm
    {
        public add()
        {
            InitializeComponent();
        }

        private void add_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connStr = "server=" + Properties.Settings.Default.domain + ";user=" + Properties.Settings.Default.sqlusername + ";database=" + Properties.Settings.Default.sqldatabase + ";port=3306;password=" + Properties.Settings.Default.sqlpassword;
            MySqlConnection conn = new MySqlConnection(connStr);
            //try to connect S
            string hash = CreateMD5(metroTextBox2.Text + metroTextBox1.Text);
            try
            {
                conn.Open();

                string sql = "INSERT INTO clients (username, password, session_id) VALUES ('" + metroTextBox1.Text + "', '" + CreateMD5(metroTextBox2.Text) + "', '" + hash + "')";
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

            //2
            try
            {
                conn.Open();

                string sql = "INSERT INTO status (session_id , client_level , client_status , last_video_viewed ) values('" + hash + "', '1', 'off', '1')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //MessageBox.Show(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();
                conn.Close();
                MessageBox.Show("Done");
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
