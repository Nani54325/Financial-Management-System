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

    public partial class withdrawUserControl1 : UserControl
    {
        private static withdrawUserControl1 _instance;
        public static withdrawUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new withdrawUserControl1();
                return _instance;

            }
        }


        public withdrawUserControl1()
        {
            InitializeComponent();
        }
        private void clear()
        {
            textBox2.Text = "";
        }

        private void withdrawUserControl1_Load(object sender, EventArgs e)
        {

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
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select balance from account where account_number=(select account_number from Card where card_number='" + starting.recby.ToString() + "')", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                string str;
                string bal;
                float niv = 0;
                float moh = 0;
                string accno;
                int c = 8000;
                if (reader.HasRows)
                {
                    str = reader["balance"].ToString();
                    reader.Close();
                    SqlCommand com1 = new SqlCommand("select atm_balance from atm_balance where atm_number='" + c + "'", cm);
                    SqlDataReader reader1 = com1.ExecuteReader();
                    reader1.Read();
                    if (reader1.HasRows)
                    {
                        bal = reader1["atm_balance"].ToString();
                        niv = float.Parse(str);
                        moh = float.Parse(bal);
                        float depo = float.Parse(textBox2.Text);
                        reader1.Close();
                        if (niv >= depo)
                        {
                            if (moh >= depo)
                            {
                                SqlCommand com2 = new SqlCommand("select account_number from Card where card_number='" + starting.recby.ToString() + "'", cm);
                                SqlDataReader reader2 = com2.ExecuteReader();
                                reader2.Read();
                                if (reader2.HasRows)
                                {
                                    accno = reader2["account_number"].ToString();
                                    reader2.Close();
                                    niv = niv - depo;
                                    moh = moh - depo;
                                    SqlCommand sqlcmd = new SqlCommand("withdraw", cm);
                                    sqlcmd.CommandType = CommandType.StoredProcedure;
                                    sqlcmd.Parameters.AddWithValue("@account_number", accno);
                                    sqlcmd.Parameters.AddWithValue("@balance", niv);
                                    sqlcmd.ExecuteNonQuery();
                                    SqlCommand sqlcm = new SqlCommand("atm_withdraw", cm);
                                    sqlcm.CommandType = CommandType.StoredProcedure;
                                    sqlcm.Parameters.AddWithValue("@atm_number", c);
                                    sqlcm.Parameters.AddWithValue("@atm_balance", moh);
                                    sqlcm.ExecuteNonQuery();
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
                                            {"apikey" , "TQYPZV3sjH0-1q5LmkniE0gQNtPOQOBA695SsGs2uR"},
                                            {"numbers" , "91" + mob },
                                            
                                            {"message" , "VIT BANK\nAccount Number: "+ accno +"\n" + depo + " rupees withdrawn from your account\nBalance in your account is: " + niv +"\nContact number: +916300189494"},
                                            
                                            });
                                            string result = System.Text.Encoding.UTF8.GetString(response);
                                            MessageBox.Show("Take Money");
                                            
                                            reader3.Close();
                                            textBox2.Text = "";
                                        }

                                    }
                                    

                                }
                                else
                                {
                                    MessageBox.Show("Money you have entered exceeds the money in atm");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Money you have entered is more than the money in your account");
                            }
                        }
                        cm.Close();
                    }

                }


            }
            
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

