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
    public partial class Createaccount_UserControl : UserControl
    { 
    

    private static Createaccount_UserControl _instance;

        public static Createaccount_UserControl Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Createaccount_UserControl();
                }
                return _instance;
            }
        }
        public Createaccount_UserControl()
        {
            InitializeComponent();
        }
        
        private void Createaccount_UserControl_Load(object sender, EventArgs e)
        {
            label13.Hide();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text=="" || textBox5.Text=="" || textBox6.Text=="" || textBox7.Text=="" || richTextBox1.Text=="")

            {
                MessageBox.Show("Please Fill all aspects");
                
            }
            else 
            {
                SqlCommand sqlcmd = new SqlCommand("Add_customer", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@First_name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Last_name", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Mobile_number", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Email", textBox4.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@address", richTextBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Monthly_income", textBox5.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Occupation", textBox6.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@Father_name", textBox7.Text.Trim());
                cm.Open();
                sqlcmd.ExecuteNonQuery();
                MessageBox.Show("Customer Added");
                
                SqlCommand com = new SqlCommand("select * from userinfo1 where User_id=(select max(User_id) from userinfo1)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label13.Show();
                    label13.Text = reader["User_id"].ToString();
                    reader.Close();
                }
                cm.Close();
            }
           
        }
        private void clear1()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            richTextBox1.Text = "";
            textBox8.Text = "";
            comboBox2.Text = "";
        }


            private void button1_Click(object sender, EventArgs e)
        {
          if (textBox8.Text == "" || comboBox2.Text == "")
            {
                MessageBox.Show("Please Fill all aspects");
                
            }
            else
            {
                SqlCommand sqlcmd = new SqlCommand("Add_account", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@account_type", comboBox2.Text);
                sqlcmd.Parameters.AddWithValue("@Balance", textBox8.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@userid1", label13.Text);
                cm.Open();
                sqlcmd.ExecuteNonQuery();
                
                
                label14.Visible = true;
                label15.Visible = true;

                SqlCommand com = new SqlCommand("select * from account where account_number=(select max(account_number) from account)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label15.Text = reader["account_number"].ToString();
                    reader.Close();
                    
                        using (var wb = new WebClient())
                        {
                            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                            {
                            {"apikey" , "TQYPZV3sjH0-1q5LmkniE0gQNtPOQOBA695SsGs2uR"},
                            {"numbers" , "91" + textBox3.Text.ToString() },
                            {"message" , "Welcome To VIT BANK \n Thank you for creating a account.\n Vit bank gives all the best features\n your User ID is :" + label13.Text.ToString() +"\nYour Account Number is: " + label15.Text.ToString() + "\n Your card will be activated soon. \n Contact Number: 6300189494.\nTHANK YOU"},
                                   
                            });
                            MessageBox.Show("Account Added");
                            string result = System.Text.Encoding.UTF8.GetString(response);
                        }
                    clear1();
                }

                cm.Close();
            }
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
