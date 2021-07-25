namespace Manager
{
    partial class Exams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.howToUseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.metroTextBox2 = new MetroFramework.Controls.MetroTextBox();
            this.t1 = new MetroFramework.Controls.MetroTextBox();
            this.t2 = new MetroFramework.Controls.MetroTextBox();
            this.t3 = new MetroFramework.Controls.MetroTextBox();
            this.t4 = new MetroFramework.Controls.MetroTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.metroTextBox7 = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this._1_ = new System.Windows.Forms.RadioButton();
            this._2_ = new System.Windows.Forms.RadioButton();
            this._3_ = new System.Windows.Forms.RadioButton();
            this._4_ = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.howToUseToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(20, 60);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(560, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // howToUseToolStripMenuItem
            // 
            this.howToUseToolStripMenuItem.Name = "howToUseToolStripMenuItem";
            this.howToUseToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.howToUseToolStripMenuItem.Text = "how to use";
            this.howToUseToolStripMenuItem.Click += new System.EventHandler(this.howToUseToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "ques=";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "image=";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(76, 106);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(39, 22);
            this.numericUpDown1.TabIndex = 5;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(132, 106);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.PromptText = "question here";
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(174, 23);
            this.metroTextBox1.TabIndex = 6;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMark = "question here";
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(118, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(12, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = ":";
            // 
            // metroTextBox2
            // 
            // 
            // 
            // 
            this.metroTextBox2.CustomButton.Image = null;
            this.metroTextBox2.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.metroTextBox2.CustomButton.Name = "";
            this.metroTextBox2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox2.CustomButton.TabIndex = 1;
            this.metroTextBox2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox2.CustomButton.UseSelectable = true;
            this.metroTextBox2.CustomButton.Visible = false;
            this.metroTextBox2.Lines = new string[0];
            this.metroTextBox2.Location = new System.Drawing.Point(132, 135);
            this.metroTextBox2.MaxLength = 32767;
            this.metroTextBox2.Name = "metroTextBox2";
            this.metroTextBox2.PasswordChar = '\0';
            this.metroTextBox2.PromptText = "image url of the question";
            this.metroTextBox2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox2.SelectedText = "";
            this.metroTextBox2.SelectionLength = 0;
            this.metroTextBox2.SelectionStart = 0;
            this.metroTextBox2.ShortcutsEnabled = true;
            this.metroTextBox2.Size = new System.Drawing.Size(174, 23);
            this.metroTextBox2.TabIndex = 8;
            this.metroTextBox2.UseSelectable = true;
            this.metroTextBox2.WaterMark = "image url of the question";
            this.metroTextBox2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // t1
            // 
            // 
            // 
            // 
            this.t1.CustomButton.Image = null;
            this.t1.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.t1.CustomButton.Name = "";
            this.t1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.t1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.t1.CustomButton.TabIndex = 1;
            this.t1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.t1.CustomButton.UseSelectable = true;
            this.t1.CustomButton.Visible = false;
            this.t1.Lines = new string[0];
            this.t1.Location = new System.Drawing.Point(132, 176);
            this.t1.MaxLength = 32767;
            this.t1.Name = "t1";
            this.t1.PasswordChar = '\0';
            this.t1.PromptText = "answer";
            this.t1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.t1.SelectedText = "";
            this.t1.SelectionLength = 0;
            this.t1.SelectionStart = 0;
            this.t1.ShortcutsEnabled = true;
            this.t1.Size = new System.Drawing.Size(174, 23);
            this.t1.TabIndex = 11;
            this.t1.UseSelectable = true;
            this.t1.WaterMark = "answer";
            this.t1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.t1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // t2
            // 
            // 
            // 
            // 
            this.t2.CustomButton.Image = null;
            this.t2.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.t2.CustomButton.Name = "";
            this.t2.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.t2.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.t2.CustomButton.TabIndex = 1;
            this.t2.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.t2.CustomButton.UseSelectable = true;
            this.t2.CustomButton.Visible = false;
            this.t2.Lines = new string[0];
            this.t2.Location = new System.Drawing.Point(132, 209);
            this.t2.MaxLength = 32767;
            this.t2.Name = "t2";
            this.t2.PasswordChar = '\0';
            this.t2.PromptText = "answer";
            this.t2.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.t2.SelectedText = "";
            this.t2.SelectionLength = 0;
            this.t2.SelectionStart = 0;
            this.t2.ShortcutsEnabled = true;
            this.t2.Size = new System.Drawing.Size(174, 23);
            this.t2.TabIndex = 12;
            this.t2.UseSelectable = true;
            this.t2.WaterMark = "answer";
            this.t2.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.t2.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // t3
            // 
            // 
            // 
            // 
            this.t3.CustomButton.Image = null;
            this.t3.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.t3.CustomButton.Name = "";
            this.t3.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.t3.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.t3.CustomButton.TabIndex = 1;
            this.t3.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.t3.CustomButton.UseSelectable = true;
            this.t3.CustomButton.Visible = false;
            this.t3.Lines = new string[0];
            this.t3.Location = new System.Drawing.Point(132, 241);
            this.t3.MaxLength = 32767;
            this.t3.Name = "t3";
            this.t3.PasswordChar = '\0';
            this.t3.PromptText = "answer";
            this.t3.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.t3.SelectedText = "";
            this.t3.SelectionLength = 0;
            this.t3.SelectionStart = 0;
            this.t3.ShortcutsEnabled = true;
            this.t3.Size = new System.Drawing.Size(174, 23);
            this.t3.TabIndex = 13;
            this.t3.UseSelectable = true;
            this.t3.WaterMark = "answer";
            this.t3.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.t3.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // t4
            // 
            // 
            // 
            // 
            this.t4.CustomButton.Image = null;
            this.t4.CustomButton.Location = new System.Drawing.Point(152, 1);
            this.t4.CustomButton.Name = "";
            this.t4.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.t4.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.t4.CustomButton.TabIndex = 1;
            this.t4.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.t4.CustomButton.UseSelectable = true;
            this.t4.CustomButton.Visible = false;
            this.t4.Lines = new string[0];
            this.t4.Location = new System.Drawing.Point(132, 277);
            this.t4.MaxLength = 32767;
            this.t4.Name = "t4";
            this.t4.PasswordChar = '\0';
            this.t4.PromptText = "answer";
            this.t4.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.t4.SelectedText = "";
            this.t4.SelectionLength = 0;
            this.t4.SelectionStart = 0;
            this.t4.ShortcutsEnabled = true;
            this.t4.Size = new System.Drawing.Size(174, 23);
            this.t4.TabIndex = 14;
            this.t4.UseSelectable = true;
            this.t4.WaterMark = "answer";
            this.t4.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.t4.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 326);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "points:";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(73, 324);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(39, 22);
            this.numericUpDown3.TabIndex = 18;
            // 
            // metroTextBox7
            // 
            // 
            // 
            // 
            this.metroTextBox7.CustomButton.Image = null;
            this.metroTextBox7.CustomButton.Location = new System.Drawing.Point(266, 1);
            this.metroTextBox7.CustomButton.Name = "";
            this.metroTextBox7.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox7.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox7.CustomButton.TabIndex = 1;
            this.metroTextBox7.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox7.CustomButton.UseSelectable = true;
            this.metroTextBox7.CustomButton.Visible = false;
            this.metroTextBox7.Lines = new string[0];
            this.metroTextBox7.Location = new System.Drawing.Point(20, 384);
            this.metroTextBox7.MaxLength = 32767;
            this.metroTextBox7.Name = "metroTextBox7";
            this.metroTextBox7.PasswordChar = '\0';
            this.metroTextBox7.PromptText = "description";
            this.metroTextBox7.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox7.SelectedText = "";
            this.metroTextBox7.SelectionLength = 0;
            this.metroTextBox7.SelectionStart = 0;
            this.metroTextBox7.ShortcutsEnabled = true;
            this.metroTextBox7.Size = new System.Drawing.Size(288, 23);
            this.metroTextBox7.TabIndex = 19;
            this.metroTextBox7.UseSelectable = true;
            this.metroTextBox7.WaterMark = "description";
            this.metroTextBox7.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox7.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(104, 422);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(350, 70);
            this.metroButton1.TabIndex = 20;
            this.metroButton1.Text = "save";
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // _1_
            // 
            this._1_.AutoSize = true;
            this._1_.Location = new System.Drawing.Point(5, 178);
            this._1_.Name = "_1_";
            this._1_.Size = new System.Drawing.Size(110, 21);
            this._1_.TabIndex = 21;
            this._1_.TabStop = true;
            this._1_.Text = "radioButton1";
            this._1_.UseVisualStyleBackColor = true;
            // 
            // _2_
            // 
            this._2_.AutoSize = true;
            this._2_.Location = new System.Drawing.Point(5, 211);
            this._2_.Name = "_2_";
            this._2_.Size = new System.Drawing.Size(110, 21);
            this._2_.TabIndex = 22;
            this._2_.TabStop = true;
            this._2_.Text = "radioButton2";
            this._2_.UseVisualStyleBackColor = true;
            // 
            // _3_
            // 
            this._3_.AutoSize = true;
            this._3_.Location = new System.Drawing.Point(5, 243);
            this._3_.Name = "_3_";
            this._3_.Size = new System.Drawing.Size(110, 21);
            this._3_.TabIndex = 23;
            this._3_.TabStop = true;
            this._3_.Text = "radioButton3";
            this._3_.UseVisualStyleBackColor = true;
            // 
            // _4_
            // 
            this._4_.AutoSize = true;
            this._4_.Location = new System.Drawing.Point(5, 279);
            this._4_.Name = "_4_";
            this._4_.Size = new System.Drawing.Size(110, 21);
            this._4_.TabIndex = 24;
            this._4_.TabStop = true;
            this._4_.Text = "radioButton4";
            this._4_.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Exams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 524);
            this.Controls.Add(this._4_);
            this.Controls.Add(this._3_);
            this.Controls.Add(this._2_);
            this.Controls.Add(this._1_);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.metroTextBox7);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.t4);
            this.Controls.Add(this.t3);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.metroTextBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.metroTextBox1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Exams";
            this.Text = "Exams";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem howToUseToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private System.Windows.Forms.Label label5;
        private MetroFramework.Controls.MetroTextBox metroTextBox2;
        private MetroFramework.Controls.MetroTextBox t1;
        private MetroFramework.Controls.MetroTextBox t2;
        private MetroFramework.Controls.MetroTextBox t3;
        private MetroFramework.Controls.MetroTextBox t4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private MetroFramework.Controls.MetroTextBox metroTextBox7;
        private MetroFramework.Controls.MetroButton metroButton1;
        private System.Windows.Forms.RadioButton _1_;
        private System.Windows.Forms.RadioButton _2_;
        private System.Windows.Forms.RadioButton _3_;
        private System.Windows.Forms.RadioButton _4_;
        private System.Windows.Forms.Timer timer1;
    }
}