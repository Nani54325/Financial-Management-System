namespace ATM_SYSTEM
{
    partial class Dashboard
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Spanel = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel.SuspendLayout();
            this.Spanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.panel1.Controls.Add(this.panel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(33, 715);
            this.panel1.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.panel.Controls.Add(this.button1);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(33, 715);
            this.panel.TabIndex = 0;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.Spanel_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(33, 116);
            this.button1.TabIndex = 0;
            this.button1.Text = "M\r\nE\r\nN\r\nU";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Spanel
            // 
            this.Spanel.BackColor = System.Drawing.Color.White;
            this.Spanel.Controls.Add(this.button4);
            this.Spanel.Controls.Add(this.button3);
            this.Spanel.Controls.Add(this.button2);
            this.Spanel.Controls.Add(this.button8);
            this.Spanel.Controls.Add(this.button11);
            this.Spanel.Controls.Add(this.button12);
            this.Spanel.Controls.Add(this.button13);
            this.Spanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Spanel.Location = new System.Drawing.Point(33, 0);
            this.Spanel.Name = "Spanel";
            this.Spanel.Size = new System.Drawing.Size(200, 715);
            this.Spanel.TabIndex = 1;
            this.Spanel.Paint += new System.Windows.Forms.PaintEventHandler(this.Spanel_Paint_1);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Location = new System.Drawing.Point(30, 447);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 43);
            this.button4.TabIndex = 11;
            this.button4.Text = "Loan";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(30, 333);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(141, 53);
            this.button3.TabIndex = 10;
            this.button3.Text = "Balance\r\nEnquiry";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(30, 646);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 43);
            this.button2.TabIndex = 9;
            this.button2.Text = "Logout";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.White;
            this.button8.Location = new System.Drawing.Point(30, 544);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(141, 43);
            this.button8.TabIndex = 8;
            this.button8.Text = "ChangePIN";
            this.button8.UseVisualStyleBackColor = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button11
            // 
            this.button11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.Color.White;
            this.button11.Location = new System.Drawing.Point(30, 232);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(141, 43);
            this.button11.TabIndex = 5;
            this.button11.Text = "Transaction";
            this.button11.UseVisualStyleBackColor = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button12
            // 
            this.button12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.ForeColor = System.Drawing.Color.White;
            this.button12.Location = new System.Drawing.Point(30, 133);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(141, 43);
            this.button12.TabIndex = 6;
            this.button12.Text = "Deposit";
            this.button12.UseVisualStyleBackColor = false;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.ForeColor = System.Drawing.Color.White;
            this.button13.Location = new System.Drawing.Point(30, 32);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(141, 43);
            this.button13.TabIndex = 7;
            this.button13.Text = "WithDraw";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(438, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(142)))), ((int)(((byte)(87)))));
            this.panel2.Location = new System.Drawing.Point(444, 73);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 2);
            this.panel2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ATM_SYSTEM.Properties.Resources.Bank_Logo;
            this.pictureBox1.Location = new System.Drawing.Point(230, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(144, 107);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(230, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(792, 602);
            this.panel3.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(194, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(336, 87);
            this.label3.TabIndex = 13;
            this.label3.Text = "Our Bank is not resposible for \r\nthe loss of money\r\ndue to imperfect log out.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Orange;
            this.label2.Location = new System.Drawing.Point(193, 199);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(363, 36);
            this.label2.TabIndex = 12;
            this.label2.Text = "Please Logout Once Done";
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.Location = new System.Drawing.Point(576, 43);
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(61, 25);
            this.name.TabIndex = 0;
            this.name.Text = "name";
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 715);
            this.Controls.Add(this.name);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Spanel);
            this.Controls.Add(this.panel1);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panel1.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.Spanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel Spanel;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label name;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}