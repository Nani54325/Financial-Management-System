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
    public partial class Employee_dashboard : Form
    {
        int PW;
        
        public Employee_dashboard()
        {
            InitializeComponent();
            PW = Spanel.Width;
            
        }
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void Employee_dashboard_Load(object sender, EventArgs e)
        {
            Spanel.Hide();
            con.Open();
            SqlCommand com = new SqlCommand("select * from employee where Employee_id='" + Employee_login.recby.ToString() + "'", con);
            SqlDataReader reader = com.ExecuteReader();

            reader.Read();
            if (reader.HasRows)
            {
                label2.Text = reader["Employee_name"].ToString();
                reader.Close();
            }
            con.Close();
            con.Open();
            
            SqlDataAdapter sqlda = new SqlDataAdapter("select account_id from loan where last_date < GETDATE() and employee_id = '" +Employee_login.recby+"'", con);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            con.Close();
            
        }
        bool isShow;
        private void button1_Click(object sender, EventArgs e)
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
                Spanel.Show();
                timer1.Start();
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Createaccount_UserControl.Instance))
            {
                panel3.Controls.Add(Createaccount_UserControl.Instance);
                Createaccount_UserControl.Instance.Dock = DockStyle.Fill;
                Createaccount_UserControl.Instance.BringToFront();
            }
            else
            {
                Createaccount_UserControl.Instance.BringToFront();
            }
        }

        private void contentpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(CardUserControl.Instance))
            {
                panel3.Controls.Add(CardUserControl.Instance);
                CardUserControl.Instance.Dock = DockStyle.Fill;
                CardUserControl.Instance.BringToFront();
            }
            else
            {
                CardUserControl.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void createaccount_UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void createaccount_UserControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void cardUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(Changing_passwordUserControl1.Instance))
            {
                panel3.Controls.Add(Changing_passwordUserControl1.Instance);
                Changing_passwordUserControl1.Instance.Dock = DockStyle.Fill;
                Changing_passwordUserControl1.Instance.BringToFront();
            }
            else
            {
                Changing_passwordUserControl1.Instance.BringToFront();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(transactioncheckUserControl1.Instance))
            {
                panel3.Controls.Add(transactioncheckUserControl1.Instance);
                transactioncheckUserControl1.Instance.Dock = DockStyle.Fill;
                transactioncheckUserControl1.Instance.BringToFront();
            }
            else
            {
                transactioncheckUserControl1.Instance.BringToFront();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(moneyUserControl1.Instance))
            {
                panel3.Controls.Add(moneyUserControl1.Instance);
                moneyUserControl1.Instance.Dock = DockStyle.Fill;
                moneyUserControl1.Instance.BringToFront();
            }
            else
            {
                moneyUserControl1.Instance.BringToFront();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(loanUserControl1.Instance))
            {
                panel3.Controls.Add(loanUserControl1.Instance);
                loanUserControl1.Instance.Dock = DockStyle.Fill;
                loanUserControl1.Instance.BringToFront();
            }
            else
            {
                loanUserControl1.Instance.BringToFront();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(accountcheckUserControl1.Instance))
            {
                panel3.Controls.Add(accountcheckUserControl1.Instance);
                accountcheckUserControl1.Instance.Dock = DockStyle.Fill;
                accountcheckUserControl1.Instance.BringToFront();
            }
            else
            {
                accountcheckUserControl1.Instance.BringToFront();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(PaymentUserControl1.Instance))
            {
                panel3.Controls.Add(PaymentUserControl1.Instance);
                PaymentUserControl1.Instance.Dock = DockStyle.Fill;
                PaymentUserControl1.Instance.BringToFront();
            }
            else
            {
                PaymentUserControl1.Instance.BringToFront();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(deactivateUserControl1.Instance))
            {
                panel3.Controls.Add(deactivateUserControl1.Instance);
                deactivateUserControl1.Instance.Dock = DockStyle.Fill;
                deactivateUserControl1.Instance.BringToFront();
            }
            else
            {
                deactivateUserControl1.Instance.BringToFront();
            }
        }

        private void Spanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
