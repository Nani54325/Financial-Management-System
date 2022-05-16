using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_SYSTEM
{
    public partial class admin_dashboard : Form
    {
        int PW;
        
        public admin_dashboard()
        {
            InitializeComponent();
            PW = Spanel.Width;
            
        }

        private void admin_dashboard_Load(object sender, EventArgs e)
        {
            Spanel.Hide();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        bool isShow;

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isShow)
            {
                Spanel.Width = Spanel.Width + 30;
                if (Spanel.Width >= PW)
                {
                    timer1.Stop();
                }
            }
            else
            {
                Spanel.Width = Spanel.Width - 30;
                if (Spanel.Width <= 0)
                {
                    Spanel.Hide();
                    timer1.Stop();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Spanel.Visible)
            {
                button1.Text = "M\nE\nN\nU";
                isShow = false;
                timer1.Start();
            }
            else
            {
                button1.Text = "H\nI\nD\nE";
                isShow = true;
                timer1.Start();
                Spanel.Show();
                
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(employeeUserControl1.Instance))
            {
                panel2.Controls.Add(employeeUserControl1.Instance);
                employeeUserControl1.Instance.Dock = DockStyle.Fill;
                employeeUserControl1.Instance.BringToFront();
            }
            else
            {
                employeeUserControl1.Instance.BringToFront();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(atm_balanceUserControl1.Instance))
            {
                panel2.Controls.Add(atm_balanceUserControl1.Instance);
                atm_balanceUserControl1.Instance.Dock = DockStyle.Fill;
                atm_balanceUserControl1.Instance.BringToFront();
            }
            else
            {
                atm_balanceUserControl1.Instance.BringToFront();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(changesUserControl1.Instance))
            {
                panel2.Controls.Add(changesUserControl1.Instance);
                changesUserControl1.Instance.Dock = DockStyle.Fill;
                changesUserControl1.Instance.BringToFront();
            }
            else
            {
                changesUserControl1.Instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(PinchangeUserControl1.Instance))
            {
                panel2.Controls.Add(PinchangeUserControl1.Instance);
                PinchangeUserControl1.Instance.Dock = DockStyle.Fill;
                PinchangeUserControl1.Instance.BringToFront();
            }
            else
            {
                PinchangeUserControl1.Instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panel2.Controls.Contains(PasswordchangeUserControl1.Instance))
            {
                panel2.Controls.Add(PasswordchangeUserControl1.Instance);
                PasswordchangeUserControl1.Instance.Dock = DockStyle.Fill;
                PasswordchangeUserControl1.Instance.BringToFront();
            }
            else
            {
                PasswordchangeUserControl1.Instance.BringToFront();
            }
        }
    }
}
