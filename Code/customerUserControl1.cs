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
    public partial class customerUserControl1 : UserControl
    {

        private static customerUserControl1 _instance;
        public static customerUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new customerUserControl1();
                return _instance;
             
            }
        }
        public customerUserControl1()
        {
            InitializeComponent();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void customerUserControl1_Load(object sender, EventArgs e)
        {
            
        }
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
                string u;
                cm.Open();
                SqlCommand com = new SqlCommand("select * from Card where card_number='" + starting.recby.ToString()+"'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    u = reader["account_number"].ToString();
                    if (textBox1.Text == reader["default_pin"].ToString())
                    {
                        reader.Close();

                        if (textBox2.Text == textBox3.Text)
                        {

                            SqlCommand sqlcmd = new SqlCommand("changing_pin", cm);
                            sqlcmd.CommandType = CommandType.StoredProcedure;
                            sqlcmd.Parameters.AddWithValue("@card_number", starting.recby);
                            sqlcmd.Parameters.AddWithValue("@pin", textBox2.Text);
                            sqlcmd.ExecuteNonQuery();
                            string mob;
                            SqlCommand com2 = new SqlCommand("select Mobile_Number from userinfo1 where User_id=(select userid1 from account where account_number=(select account_number from Card where card_number='" + starting.recby.ToString() + "'))", cm);
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
                                    {"message" , "VIT BANK\nAccount Number: "+u.ToString()+"\nSuccessfully Changed your Account Pin.\nYou can use your new pin.\nContact Number: +916300189494"},
                                    });
                                    
                                    string result = System.Text.Encoding.UTF8.GetString(response);

                                    reader2.Close();
                                }
                            }
                            MessageBox.Show("Changed Successfully");
                            clear();
                           
                        }

                        else
                        {
                            MessageBox.Show("New Pin and confirmation Pins didn't match");
                            clear();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Check your old pin entered");
                        clear();
                    }
                    

              
               }
                cm.Close();
            }
            


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

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
