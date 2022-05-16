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
    public partial class moneyUserControl1 : UserControl
    {
        private static moneyUserControl1 _instance;
        public static moneyUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new moneyUserControl1();
                return _instance;

            }
        }
        public moneyUserControl1()
        {
            InitializeComponent();
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void moneyUserControl1_Load(object sender, EventArgs e)
        {
            label2.Hide();
            label3.Hide();
            textBox1.Hide();
            textBox2.Hide();
            button8.Hide();
            button2.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text =="" || textBox2.Text == "")
            {
                MessageBox.Show("Please Fill All Aspect");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select balance from account where account_number='" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                String str;
                float balance = 0;
                if (reader.HasRows)
                {

                    str = reader["balance"].ToString();
                    reader.Close();
                    balance = float.Parse(str);
                    float depo = float.Parse(textBox2.Text);
                    balance = balance + depo;
                    SqlCommand sqlcmd = new SqlCommand("deposit", cm);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@account_number", textBox1.Text);
                    sqlcmd.Parameters.AddWithValue("@balance", balance);
                    sqlcmd.ExecuteNonQuery();
                    

                }
                else
                {
                    MessageBox.Show("No Account for Account Number Entered");
                }
                cm.Close();
                clear();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                label2.Show();
                label3.Show();
                textBox1.Show();
                textBox2.Show();
                button8.Show();
                button2.Hide();
            }
            if(radioButton1.Checked)
            {
                label2.Show();
                label3.Show();
                textBox1.Show();
                textBox2.Show();
                button2.Show();
                button8.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please Fill All Aspect");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select balance from account where account_number='" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                String str;
                float balance = 0;
                if (reader.HasRows)
                {

                    str = reader["balance"].ToString();
                    reader.Close();
                    balance = float.Parse(str);
                    float depo = float.Parse(textBox2.Text);
                    balance = balance - depo;
                    SqlCommand sqlcmd = new SqlCommand("withdraw", cm);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@account_number", textBox1.Text);
                    sqlcmd.Parameters.AddWithValue("@balance", balance);
                    sqlcmd.ExecuteNonQuery();
                    string mob;
                    SqlCommand com2 = new SqlCommand("select Mobile_Number from userinfo1 where User_id=(select userid1 from account where account_number='" + textBox1.Text.ToString() + "')", cm);
                    SqlDataReader reader2 = com2.ExecuteReader();
                    reader2.Read();
                    if (reader2.HasRows)
                    {
                        mob = reader2["Mobile_Number"].ToString();
                        using (var wb = new WebClient())
                        {

                            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                            {
                            {"apikey" , "TQYPZV3sjH0-1q5LmkniE0gQNtPOQOBA695SsGs2uR"},
                            {"numbers" , "91" + mob },

                            {"message" , "VIT BANK\nAccount Number: "+ textBox1.Text.ToString() +"\n" + depo + " rupees withdrawn from your account\nBalance in your account is: " + balance + "\nContact number: +916300189494"},

                            });
                            MessageBox.Show("Money Withdrawn");
                            string result = System.Text.Encoding.UTF8.GetString(response);

                            reader2.Close();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("No Account for Account Number Entered");
                }
                cm.Close();
                clear();
            }
        }
    }
}
