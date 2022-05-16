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
    public partial class PinchangeUserControl1 : UserControl
    {
        private static PinchangeUserControl1 _instance;
        public static PinchangeUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PinchangeUserControl1();
                return _instance;

            }
        }
        public PinchangeUserControl1()
        {
            InitializeComponent();
        }

        private void PinchangeUserControl1_Load(object sender, EventArgs e)
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
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please Fill all Aspects");
            }
            else
            {
                string p;
                cm.Open();
                SqlCommand com = new SqlCommand("select * from Card where card_number='" + textBox1.Text.ToString() + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    p = reader["default_pin"].ToString();
                    reader.Close();
                    SqlCommand sqlcmd = new SqlCommand("changing_pin", cm);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@card_number", textBox1.Text);
                    sqlcmd.Parameters.AddWithValue("@pin", textBox2.Text);
                    sqlcmd.ExecuteNonQuery();
                    string mob;
                    SqlCommand com3 = new SqlCommand("select Mobile_Number from userinfo1 where User_id=(select userid1 from account where account_number=(select account_number from Card where card_number='" + starting.recby.ToString() + "'))", cm);
                    SqlDataReader reader3 = com3.ExecuteReader();
                    reader3.Read();
                    if (reader3.HasRows)
                    {
                        mob = reader3["Mobile_Number"].ToString();
                        using (var wb = new WebClient())
                        {
                            byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                            {
                            {"apikey" , "CslUtwemFaw-jXEHf7tF7LEbJPCNdJ3m3qG2sb5Kg8"},
                            {"numbers" , "91" + mob },

                            {"message" , "VIT BANK\n Your PIN has been changed successfully\n you can use your new PIN\nContact number: +916300189494"},

                            });
                            string result = System.Text.Encoding.UTF8.GetString(response);
                            MessageBox.Show("Take Money");

                            reader3.Close();
                            textBox2.Text = "";
                        }

                    }
                    MessageBox.Show("Pin Changed Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Card Number");
                }
            }
            cm.Close();
        }
    }
}
