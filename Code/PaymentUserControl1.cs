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
    public partial class PaymentUserControl1 : UserControl
    {
        private static PaymentUserControl1 _instance;
        public static PaymentUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PaymentUserControl1();
                return _instance;

            }
        }
        public PaymentUserControl1()
        {
            InitializeComponent();
        }

        private void PaymentUserControl1_Load(object sender, EventArgs e)
        {
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label20.Hide();
            label4.Hide();
            label5.Hide();
            label3.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            textBox2.Hide();
            button1.Hide();
            label12.Hide();
            label13.Hide();
            label14.Hide();
            label16.Hide();
            label15.Hide();
            button2.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select * from loan where loan_id='" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label4.Show();
                    label5.Show();
                    label3.Show();
                    label6.Show();
                    label7.Show();
                    label8.Show();
                    label9.Show();
                    label10.Show();
                    label11.Show();
                    label17.Show();
                    label18.Show();
                    label19.Show();
                    label20.Show();
                    button1.Show();
                    radioButton1.Show();
                    radioButton2.Show();
                    
                    label5.Text = reader["name"].ToString();
                    label8.Text = reader["emi"].ToString();
                    label6.Text = reader["account_id"].ToString();
                    label10.Text = reader["total_amount"].ToString();
                    label18.Text = reader["start_date"].ToString();
                    label20.Text = reader["last_date"].ToString();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Enter Valid Loan ID");
                    textBox1.Text = "";
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

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(radioButton1.Checked)
            {
                label14.Show();
                textBox2.Show();
                button2.Show();

            }
            if(radioButton2.Checked)
            {
                label14.Show();
                textBox2.Show();
                button2.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if(textBox2.Text == "")
                {
                    MessageBox.Show("Please Fill All Aspects");
                }
                else
                {
                    cm.Open();
                    SqlCommand com = new SqlCommand("select * from account where account_number=(select account_id from loan where loan_id='" + textBox1.Text + "')", cm);
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                    String str;
                    String accno;
                    float balance = 0;
                    string bal;
                    String loanid;
                    float balance1 = 0;
                    if (reader.HasRows)
                    {
                        str = reader["balance"].ToString();
                        accno = reader["account_number"].ToString();
                        balance = float.Parse(str);
                        float depo = float.Parse(textBox2.Text);
                        reader.Close();
                        bal = label10.Text;
                        balance1 = float.Parse(bal);
                        loanid = textBox1.Text;
                        if (depo > balance)
                        {
                            MessageBox.Show("Entered Money is more than money in his/her account");
                            textBox2.Text = "";
                        }
                        else if (depo > balance1)
                        {
                            MessageBox.Show("Entered money is more than the money he/she has taken for loan");
                            textBox2.Text = "";
                        }
                        else
                        {
                            balance = balance - depo;
                            balance1 = balance1 - depo;
                            SqlCommand sqlcmd = new SqlCommand("withdraw", cm);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@account_number", accno);
                            sqlcmd.Parameters.AddWithValue("@balance", balance);
                            sqlcmd.ExecuteNonQuery();
                            MessageBox.Show("Money withdrawn from his/her account");
                            SqlCommand sqlcm = new SqlCommand("payment", cm);
                            sqlcm.CommandType = CommandType.StoredProcedure;
                            sqlcm.Parameters.AddWithValue("@loan_id", loanid);
                            sqlcm.Parameters.AddWithValue("@total_amount", balance1);
                            sqlcm.ExecuteNonQuery();
                            if (balance1 == 0)
                            {
                                MessageBox.Show("He/She has paid all the money taken for loan");
                                label13.Show();
                                label15.Show();
                                label12.Show();
                                label16.Show();
                                label13.Text = balance.ToString();
                                label15.Text = 0.ToString();
                                SqlCommand com1 = new SqlCommand("delete from loan where loan_id = '" + textBox1.Text + "'", cm);
                                SqlDataReader reader1 = com1.ExecuteReader();

                            }
                            else
                            {
                                label13.Show();
                                label15.Show();
                                label12.Show();
                                label16.Show();
                                label13.Text = balance.ToString();
                                label15.Text = balance1.ToString();
                            }
                        }
                        cm.Close();
                    }
                }
            }
            if (radioButton2.Checked)
            {
                cm.Open();
                label14.Show();
                textBox2.Show();
                button2.Show();
                string bal;
                String loanid;
                float balance1 = 0;
                bal = label10.Text;
                balance1 = float.Parse(bal);
                loanid = textBox1.Text;
                float depo = float.Parse(textBox2.Text);
                if (depo > balance1)
                {
                    MessageBox.Show("Entered money is more than the money he/she has taken for loan");
                    textBox2.Text = "";
                }
                else
                {
                    balance1 = balance1 - depo;
                    SqlCommand sqlcm = new SqlCommand("payment", cm);
                    sqlcm.CommandType = CommandType.StoredProcedure;
                    sqlcm.Parameters.AddWithValue("@loan_id", loanid);
                    sqlcm.Parameters.AddWithValue("@total_amount", balance1);
                    sqlcm.ExecuteNonQuery();
                    if (balance1 == 0)
                    {
                        MessageBox.Show("He/She ha paid all the money taken for loan");
                        label15.Show();
                        label16.Show();
                        label15.Text = 0.ToString();
                        SqlCommand com1 = new SqlCommand("delete from loan where loan_id = '" + textBox1.Text + "'", cm);
                        SqlDataReader reader1 = com1.ExecuteReader();
                    }
                    else
                    {
                        label15.Show();
                        label16.Show();
                        label15.Text = balance1.ToString();
                    }
                }

            }
            cm.Close();
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
