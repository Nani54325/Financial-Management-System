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
    public partial class Changing_passwordUserControl1 : UserControl
    {
        private static Changing_passwordUserControl1 _instance;
        public static Changing_passwordUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Changing_passwordUserControl1();
                return _instance;

            }
        }
        public Changing_passwordUserControl1()
        {
            InitializeComponent();
        }

        
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please Fill all aspects");

            }
            else
            {
                cm.Open();
                int num1 = new Random().Next(1000, 9999);
                label6.Text = num1.ToString();
                MessageBox.Show(num1.ToString());
                string mob;
                SqlCommand com2 = new SqlCommand("select mobile_number from employee where Employee_id='" + Employee_login.recby.ToString() + "'", cm);
                SqlDataReader reader2 = com2.ExecuteReader();
                reader2.Read();
                if (reader2.HasRows)
                {
                    mob = reader2["mobile_number"].ToString();
                    using (var wb = new WebClient())
                    {
                        byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                        {
                        {"apikey" , "TQYPZV3sjH0-1q5LmkniE0gQNtPOQOBA695SsGs2uR"},
                        {"numbers" , "91" + mob },

                        {"message" , "VIT BANK\nTo change password your OTP is: "+num1.ToString()},

                        });
                        MessageBox.Show("OTP Sent to your mobile");
                        label5.Show();
                        textBox4.Show();
                        button2.Show();
                        string result = System.Text.Encoding.UTF8.GetString(response);

                        reader2.Close();
                    }
                }
            }
            cm.Close();
        }

        private void Changing_passwordUserControl1_Load(object sender, EventArgs e)
        {
            label5.Hide();
            textBox4.Hide();
            button2.Hide();
            label6.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cm.Open();
            SqlCommand com = new SqlCommand("select * from employee where Employee_id='" + Employee_login.recby.ToString() + "'", cm);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            
            if (reader.HasRows)
            {
                if (textBox1.Text == reader["password"].ToString())
                {
                    reader.Close();

                    if (textBox2.Text == textBox3.Text)
                    {
                        if(label6.Text == textBox4.Text)
                        {
                            SqlCommand sqlcmd = new SqlCommand("changing_password", cm);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@Employee_id", Employee_login.recby);
                            sqlcmd.Parameters.AddWithValue("@password", textBox2.Text);
                            sqlcmd.ExecuteNonQuery();
                            MessageBox.Show("Password Changed Successfully");
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";


                        }
                        else
                        {
                            MessageBox.Show("Enter Correct OTP");
                            textBox4.Text = "";
                            MessageBox.Show("If you Entered mobile number wrong\nContact the admin");
                        }
                    }
                    else
                    {
                        MessageBox.Show("New Password and conformation password are not same");
                    }
                }
                else
                {
                    MessageBox.Show("Please Enter correct old Password");
                }
                cm.Close();
            }
        }
    }
}
