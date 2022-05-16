using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_SYSTEM
{
    public partial class atm_balanceUserControl1 : UserControl
    {
        private static atm_balanceUserControl1 _instance;
        public static atm_balanceUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new atm_balanceUserControl1();
                return _instance;

            }
        }
        public atm_balanceUserControl1()
        {
            InitializeComponent();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void atm_balanceUserControl1_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            label5.Hide();
            textBox2.Hide();
            button3.Hide();
            label6.Hide();
            label7.Hide();
        }
        private void clear()
        {
            textBox1.Text = "";
            
        }
        
        public void getdata()
        {
            cm.Open();
            SqlCommand com = new SqlCommand("select * from atm_balance where atm_number='" + textBox1.Text + "'", cm);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                label2.Show();
                label3.Show();
                label5.Show();
                textBox2.Show();
                button3.Show();
                label3.Text = reader["atm_balance"].ToString();
                reader.Close();
            }

            else
            {
                MessageBox.Show("Invalid Credentials");
                clear();
            }
            cm.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Enter ATM Number");
            }
            else
            {
                getdata();
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string str;
            float bal;
            cm.Open();
            if(textBox2.Text == "")
            {
                MessageBox.Show("Please Enter Money to add");
            }
            else
            {
                SqlCommand com = new SqlCommand("select * from atm_balance where atm_number='" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    str = reader["atm_balance"].ToString();
                    bal = float.Parse(str);
                    reader.Close();
                    string depo = textBox2.Text;
                    float dep = float.Parse(depo);
                    reader.Close();
                    bal = bal + dep;
                    if (bal > 5000000)
                    {
                        MessageBox.Show("Maximum limit is 50,00,000");
                    }
                    else
                    {
                        SqlCommand sqlcmd = new SqlCommand("atm_withdraw", cm);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@atm_number", textBox1.Text);
                        sqlcmd.Parameters.AddWithValue("@atm_balance", bal);
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Money added Succesfully");
                        label6.Show();
                        label7.Show();
                        label7.Text = bal.ToString();
                        cm.Close();
                    }
                    textBox1.Text = "";
                    textBox2.Text = "";

                }
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
