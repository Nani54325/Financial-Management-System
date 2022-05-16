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
using System.Net;
using System.Collections.Specialized;

namespace ATM_SYSTEM
{
    public partial class transactionUserControl1 : UserControl
    {
        private static transactionUserControl1 _instance;
        public static transactionUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new transactionUserControl1();
                return _instance;

            }
        }
        public transactionUserControl1()
        {
            InitializeComponent();
        }
        private void clear()
        {
            
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void transactionUserControl1_Load(object sender, EventArgs e)
        {
            label5.Hide();
            label6.Hide();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Fill all Aspects");
            }
            else
            {
                cm.Open();
                string str;
                string bal;
                float b1;
                float a1;
                string accno;
                float niv = 0;
                float moh = 0;
                SqlCommand com3 = new SqlCommand("select * from account where account_number=(select account_number from Card where card_number='" + starting.recby.ToString() + "')", cm);
                SqlDataReader reader = com3.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    str = reader["balance"].ToString();
                    accno = reader["account_number"].ToString();
                    reader.Close();
                    SqlCommand com1 = new SqlCommand("select balance from account where account_number='" + textBox2.Text + "'", cm);
                    SqlDataReader reader1 = com1.ExecuteReader();
                    reader1.Read();
                    if (reader1.HasRows)
                    {
                        bal = reader1["balance"].ToString();
                        niv = float.Parse(str);
                        a1 = float.Parse(str);
                        moh = float.Parse(bal);
                        b1 = float.Parse(bal);
                        float depo = float.Parse(textBox3.Text);
                        reader1.Close();
                        if (niv >= depo)
                        {
                            niv = niv - depo;
                            moh = moh + depo;
                            SqlCommand sqlcmd = new SqlCommand("Transaction_reciever", cm);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@account_number", textBox2.Text);
                            sqlcmd.Parameters.AddWithValue("@balance", moh);
                            sqlcmd.ExecuteNonQuery();
                            SqlCommand sqlcm = new SqlCommand("Transaction_sender", cm);
                            sqlcm.CommandType = CommandType.StoredProcedure;
                            sqlcm.Parameters.AddWithValue("@account_number", accno);
                            sqlcm.Parameters.AddWithValue("@balance", niv);
                            sqlcm.ExecuteNonQuery();
                            SqlCommand sqlc = new SqlCommand("Transaction", cm);
                            sqlc.CommandType = CommandType.StoredProcedure;
                            sqlc.Parameters.AddWithValue("@sender_account", accno);
                            sqlc.Parameters.AddWithValue("@money_before", a1);
                            sqlc.Parameters.AddWithValue("@money_after", niv);
                            sqlc.Parameters.AddWithValue("@reciever_account", textBox2.Text.Trim());
                            sqlc.Parameters.AddWithValue("@reciever_before", b1);
                            sqlc.Parameters.AddWithValue("@reciever_after", moh);
                            sqlc.Parameters.AddWithValue("@money_transferred", textBox3.Text.Trim());
                            sqlc.ExecuteNonQuery();
                            
                            clear();
                            SqlCommand com2 = new SqlCommand("select * from Transactionid where transaction_id=(select max(transaction_id) from Transactionid)", cm);
                            SqlDataReader reader2 = com2.ExecuteReader();
                            reader2.Read();
                            if (reader2.HasRows)
                            {
                                label5.Show();
                                label6.Show();
                                label6.Text = reader2["transaction_id"].ToString();
                                reader2.Close();
                            }
                            MessageBox.Show("Amount Transferred");
                        }
                        else
                        {
                            MessageBox.Show("Money Entered is more than the money in your account");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Enter Valid Account Number");

                    }
                }
                cm.Close();
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
