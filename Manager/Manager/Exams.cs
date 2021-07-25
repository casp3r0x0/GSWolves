using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Manager
{
    public partial class Exams : MetroFramework.Forms.MetroForm
    {
        public Exams()
        {
            InitializeComponent();
        }

        private void howToUseToolStripMenuItem_Click(object sender, EventArgs e)
        {
           MessageBox.Show("1- make folder called exam + num in exams folder (server) \n 2- add 30 question \n -3 add text file caled mark.txt contains the full mark "); 
           // MessageBox.Show(_1_.Name);

        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            RichTextBox rh = new RichTextBox();
            rh.Text = label1.Text + Convert.ToString(numericUpDown1.Value) + ":"+ metroTextBox1.Text+"\n";
            rh.Text = rh.Text + label2.Text + metroTextBox2.Text + "\n";

            foreach(Control c in this.Controls)
            {
                if  (c is RadioButton)
                {
                    if (((RadioButton)c).Checked == true)
                    {
                        rh.Text = rh.Text + ((RadioButton)c).Name.Replace("_", "~") + ((RadioButton)c).Text + "~$$$$$~" + "points:" + Convert.ToString(numericUpDown3.Value) + "~" + metroTextBox7.Text+"\n";
                    }
                    else {
                        string labelname = ((RadioButton)c).Name.Replace("_", "~"); 
                        rh.Text = rh.Text + labelname + ((RadioButton)c).Text+"\n"; 
                    }
                }
            }

            //remove empty lines 
            rh.Text = Regex.Replace(rh.Text, @"(^\p{Zs}*\r\n){2,}", "\r\n", RegexOptions.Multiline);
            //MessageBox.Show(rh.Text); //save to  : 
            string filename = "";
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.Title = "SaveFileDialog Export2File";
            sfd.Filter = "Text File (.txt) | *.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                filename = sfd.FileName.ToString();
                if (filename != "")
                {
                    using (StreamWriter sw = new StreamWriter(filename))
                    {
                        foreach ( string line in rh.Lines)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                _1_.Text = t1.Text;
                _2_.Text = t2.Text;
                _3_.Text = t3.Text;
                _4_.Text = t4.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }




        }
    }
}
