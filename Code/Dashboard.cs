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
    public partial class Dashboard : Form
    {
        int PW;
        
        public Dashboard()
        {
            InitializeComponent();
            PW = Spanel.Width;
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

        private void Spanel_Paint(object sender, PaintEventArgs e)
        {

        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void Dashboard_Load(object sender, EventArgs e)
        {
            Spanel.Hide();
            cm.Open();
            SqlCommand com = new SqlCommand("select First_name from [userinfo1] where User_id=(select userid1 from account where account_number=(select account_number from Card where card_number='" + starting.recby.ToString() + "'))", cm);
            SqlDataReader reader = com.ExecuteReader();
            

            reader.Read();
            if(reader.HasRows)
            {
                name.Text = reader["First_Name"].ToString();
               
                reader.Close();
            }

            SqlCommand com1 = new SqlCommand("select last_date from loan where account_id=(select account_number from Card where card_number='" + starting.recby.ToString() + "')", cm);
            SqlDataReader reader1 = com1.ExecuteReader();
            reader1.Read();

            if (reader1.HasRows)
            {
                try
                {
                    DateTime today = DateTime.Now;
                    DateTime da = DateTime.Parse(reader1["last_date"].ToString());
                    int result = DateTime.Compare(today, da);
                    if (result == 0)
                    {
                        MessageBox.Show("Today is the last date to pay your loan");
                    }
                    else if (result > 0)
                    {
                        MessageBox.Show("It,s high time please pay the loan \n Your last date is: " + da);
                    }
                    else if (result < 0)
                    {
                        MessageBox.Show("Last date to pay loan is: " + da);
                    }
                    else
                    {
                        throw new IndexOutOfRangeException();
                    }


                }
                catch (IndexOutOfRangeException)
                {

                }

            }
            cm.Close();
        }

        private void Spanel_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(!panel3.Controls.Contains(customerUserControl1.Instance))
            {
                panel3.Controls.Add(customerUserControl1.Instance);
                customerUserControl1.Instance.Dock = DockStyle.Fill;
                customerUserControl1.Instance.BringToFront();
            }
            else
            {
                customerUserControl1.Instance.BringToFront();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(BalanceUserControl1.Instance))
            {
                panel3.Controls.Add(BalanceUserControl1.Instance);
                BalanceUserControl1.Instance.Dock = DockStyle.Fill;
                BalanceUserControl1.Instance.BringToFront();
            }
            else
            {
                BalanceUserControl1.Instance.BringToFront();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(withdrawUserControl1.Instance))
            {
                panel3.Controls.Add(withdrawUserControl1.Instance);
                withdrawUserControl1.Instance.Dock = DockStyle.Fill;
                withdrawUserControl1.Instance.BringToFront();
            }
            else
            {
                withdrawUserControl1.Instance.BringToFront();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(depositUserControl1.Instance))
            {
                panel3.Controls.Add(depositUserControl1.Instance);
                depositUserControl1.Instance.Dock = DockStyle.Fill;
                depositUserControl1.Instance.BringToFront();
            }
            else
            {
                depositUserControl1.Instance.BringToFront();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(transactionUserControl1.Instance))
            {
                panel3.Controls.Add(transactionUserControl1.Instance);
                transactionUserControl1.Instance.Dock = DockStyle.Fill;
                transactionUserControl1.Instance.BringToFront();
            }
            else
            {
                transactionUserControl1.Instance.BringToFront();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(lastdateUserControl1.Instance))
            {
                panel3.Controls.Add(lastdateUserControl1.Instance);
                lastdateUserControl1.Instance.Dock = DockStyle.Fill;
                lastdateUserControl1.Instance.BringToFront();
            }
            else
            {
                lastdateUserControl1.Instance.BringToFront();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (!panel3.Controls.Contains(lastdateUserControl1.Instance))
            {
                panel3.Controls.Add(lastdateUserControl1.Instance);
                lastdateUserControl1.Instance.Dock = DockStyle.Fill;
                lastdateUserControl1.Instance.BringToFront();
            }
            else
            {
                lastdateUserControl1.Instance.BringToFront();
            }
        }
    }
}

