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
    public partial class deactivateUserControl1 : UserControl
    {
        private static deactivateUserControl1 _instance;
        public static deactivateUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new deactivateUserControl1();
                return _instance;
            }
        }
        public deactivateUserControl1()
        {
            InitializeComponent();
        }

        private void deactivateUserControl1_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            label5.Hide();
            textBox1.Hide();
            textBox2.Hide();
            textBox4.Hide();
            button1.Hide();
            button3.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");


        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                SqlDataAdapter da;
                cm.Open();
                da = new SqlDataAdapter("Select * from deactivate where card_number = '" + textBox1.Text.ToString() + "'", cm);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show("This Account is Already Deactivated");
                }
                else
                {
                    string accno;
                    string car;
                    SqlCommand com = new SqlCommand("select * from Card where card_number = '" + textBox1.Text.ToString() + "'", cm);
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                    if(reader.HasRows)
                    {
                        accno = reader["account_number"].ToString();
                        car = reader["card_number"].ToString();
                        reader.Close();
                        if(accno == textBox2.Text && car == textBox1.Text)
                        {
                            SqlCommand sqlcmd = new SqlCommand("Deactivate_account", cm);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@card_number", textBox1.Text.Trim());
                            sqlcmd.Parameters.AddWithValue("@Account_number", textBox2.Text.Trim());
                            sqlcmd.ExecuteNonQuery();
                            MessageBox.Show("Account Deactivated");
                            textBox1.Text = "";
                            textBox2.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Invalid Credentials");
                        }
                    }
                }
                cm.Close();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                label2.Show();
                label3.Show();
                textBox1.Show();
                textBox2.Show();
                button1.Show();
                button3.Hide();
                label5.Hide();
                textBox4.Hide();
            }
            if(radioButton2.Checked)
            {
                label2.Show();
                label3.Show();
                textBox1.Show();
                textBox2.Show();
                button1.Hide();
                button3.Show();
                label5.Show();
                textBox4.Show();
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

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                cm.Open();
                string accno;
                string car;
                SqlCommand com = new SqlCommand("select * from deactivate where card_number = '" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if(reader.HasRows)
                {
                    accno = reader["Account_number"].ToString();
                    car = reader["card_number"].ToString();
                    reader.Close();
                    if(accno == textBox2.Text && textBox1.Text == car)
                    {
                        SqlCommand com1 = new SqlCommand("delete from deactivate where card_number = '" + textBox1.Text.ToString() + "'", cm);
                        SqlDataReader reader1 = com1.ExecuteReader();
                        reader1.Read();
                        reader1.Close();
                        SqlCommand sqlcmd = new SqlCommand("changing_pin", cm);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@card_number", textBox1.Text.Trim());
                        sqlcmd.Parameters.AddWithValue("@pin", textBox4.Text.Trim());
                        sqlcmd.ExecuteNonQuery();
                        MessageBox.Show("Account Activated");
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Enter Valid account number");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Valid Card Number");
                }
                
            }
            cm.Close();
        }
    }
}
