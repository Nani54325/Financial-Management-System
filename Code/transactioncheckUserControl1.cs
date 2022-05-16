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
    public partial class transactioncheckUserControl1 : UserControl
    {
        private static transactioncheckUserControl1 _instance;
        public static transactioncheckUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new transactioncheckUserControl1();
                return _instance;

            }
        }
        public transactioncheckUserControl1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Transaction ID");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select * from Transactionid where transaction_id='" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label3.Show();
                    label10.Show();
                    label4.Show();
                    label5.Show();
                    label6.Show();
                    label7.Show();
                    label8.Show();
                    label9.Show();
                    label11.Show();
                    label12.Show();
                    label13.Show();
                    label14.Show();
                    label15.Show();
                    label16.Show();
                    label10.Text = reader["sender_account"].ToString();
                    label5.Text = reader["money_before"].ToString();
                    label7.Text = reader["money_after"].ToString();
                    label9.Text = reader["reciever_account"].ToString();
                    label12.Text = reader["reciever_before"].ToString();
                    label14.Text = reader["reciever_after"].ToString();
                    label16.Text = reader["money_transferred"].ToString();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("No Transaction Happened");
                }
            }
            
            cm.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void transactioncheckUserControl1_Load(object sender, EventArgs e)
        {
            label3.Hide();
            label10.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
        }
    }
}
