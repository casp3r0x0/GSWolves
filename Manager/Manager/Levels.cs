using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class Levels : MetroFramework.Forms.MetroForm
    {
        public Levels()
        {
            InitializeComponent();
        }

        private void howToAddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("please  copy the  level  .txt in  into \n the levels dir in server  ");
            MessageBox.Show("id you want to add exam the make the \n video url  = exam url \n video image  = exam image \n  num  =  exam  \n and the duration = blah"); 
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string[] row = { metroTextBox1.Text, metroTextBox2.Text, metroTextBox3.Text, metroTextBox4.Text };
            var listViewItem = new ListViewItem(row);
            metroListView1.Items.Add(listViewItem);
        }
        private void export2File(ListView lv, string splitter)
        {
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
                        foreach (ListViewItem item in lv.Items)
                        {
                            sw.WriteLine("{0}{1}{2}{3}{4}{5}{6}", item.SubItems[0].Text, splitter, item.SubItems[1].Text , splitter , item.SubItems[2].Text , splitter , item.SubItems[3].Text);
                        }
                    }
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            export2File(metroListView1, "#"); 
        }
    }
}
