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

    public partial class accountcheckUserControl1 : UserControl
    {
        private static accountcheckUserControl1 _instance;
        public static accountcheckUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new accountcheckUserControl1();
                return _instance;

            }
        }
        public accountcheckUserControl1()
        {
            InitializeComponent();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void accountcheckUserControl1_Load(object sender, EventArgs e)
        {
            label18.Hide();
            label19.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            label6.Hide();
            label7.Hide();
            label8.Hide();
            label9.Hide();
            label10.Hide();
            label11.Hide();
            label12.Hide();
            label13.Hide();
            richTextBox1.Hide();
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Enter Account Number");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("Select * from userinfo1 where User_id=(select userid1 from account where account_number= '" + textBox1.Text + "')", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label9.Show();
                    label10.Show();
                    label3.Show();
                    label4.Show();
                    label7.Show();
                    label8.Show();
                    label5.Show();
                    label4.Text = reader["First_Name"].ToString();
                    label8.Text = reader["Last_Name"].ToString();
                    label10.Text = reader["Monthly_income"].ToString();
                    label11.Show();
                    label12.Show();
                    label12.Text = "+91" + reader["Mobile_Number"].ToString();
                    label13.Show();
                    richTextBox1.Show();
                    richTextBox1.Text = reader["Address"].ToString();
                    reader.Close();
                    SqlCommand com3 = new SqlCommand("select balance from account where account_number= '" + textBox1.Text + "'", cm);
                    SqlDataReader reader3 = com3.ExecuteReader();
                    reader3.Read();
                    if(reader3.HasRows)
                    {
                        label18.Show();
                        label19.Show();
                        label19.Text = reader3["balance"].ToString();
                        reader3.Close();
                        SqlCommand com1 = new SqlCommand("select count(loan_id) as cloan from loan where account_id='" + textBox1.Text + "'", cm);
                        SqlDataReader reader1 = com1.ExecuteReader();
                        reader1.Read();
                        if (reader1.HasRows)
                        {
                            label6.Show();
                            label6.Text = reader1["cloan"].ToString();
                            reader1.Close();
                            SqlCommand com2 = new SqlCommand("select * from loan where account_id='" + textBox1.Text + "'", cm);
                            SqlDataReader reader2 = com2.ExecuteReader();
                            reader2.Read();
                            if (reader2.HasRows)
                            {
                                label14.Show();
                                label15.Show();
                                label16.Show();
                                label17.Show();
                                label15.Text = reader2["last_date"].ToString();
                                label17.Text = reader2["total_amount"].ToString();
                            }
                            else
                            {
                                label14.Hide();
                                label15.Hide();
                                label16.Hide();
                                label17.Hide();
                            }
                        }
                        else
                        {
                            label6.Text = "0";
                        }
                    }  
                }
                else
                {
                    MessageBox.Show("Account number Does Not Exist");
                }
            }
            
            cm.Close();
        }
    }
}
