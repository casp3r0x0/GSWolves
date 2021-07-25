using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Manager
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this is  metro  button "); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Properties.Settings.Default.domain = toolStripTextBox1.Text;
                MessageBox.Show("Saved ");
            }
            
        }

        private void toolStripTextBox1_MouseEnter(object sender, EventArgs e)
        {
            toolStripTextBox1.Text = Properties.Settings.Default.domain; 
        }

        

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            Users userfrm = new Users();
            userfrm.Show(); 
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            Levels levelfrm = new Levels();
            levelfrm.Show(); 
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            Exams examfrm = new Exams();
            examfrm.Show(); 
        }

        private void adminAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Properties.Settings.Default.sqlpassword = toolStripTextBox2.Text;
                MessageBox.Show("Saved ");
            }
        }

        private void toolStripTextBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Properties.Settings.Default.sqlusername = toolStripTextBox3.Text;
                MessageBox.Show("Saved ");
            }
        }

        private void toolStripTextBox4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                Properties.Settings.Default.sqldatabase = toolStripTextBox4.Text;
                MessageBox.Show("Saved ");
            }
        }

        private void toolStripTextBox2_MouseEnter(object sender, EventArgs e)
        {
            toolStripTextBox2.Text = Properties.Settings.Default.sqlpassword;
        }

        private void toolStripTextBox3_MouseEnter(object sender, EventArgs e)
        {
            toolStripTextBox3.Text = Properties.Settings.Default.sqlusername;
        }

        private void toolStripTextBox4_MouseEnter(object sender, EventArgs e)
        {
            toolStripTextBox4.Text = Properties.Settings.Default.sqldatabase;
        }
    }
}
