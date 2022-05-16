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
    public partial class depositUserControl1 : UserControl
    {
        private static depositUserControl1 _instance;
        public static depositUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new depositUserControl1();
                return _instance;
            }
        }
        
        private void clear()
        {
            textBox1.Text = "";
        }
        public depositUserControl1()
        {
            InitializeComponent();
        }

        private void depositUserControl1_Load(object sender, EventArgs e)
        {

        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select balance from account where account_number=(select account_number from Card where card_number='" + starting.recby.ToString() + "')", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                String str;
                String accno;
                float balance = 0;
                if (reader.HasRows)
                {
                    str = reader["balance"].ToString();
                    reader.Close();
                    SqlCommand com1 = new SqlCommand("select account_number from Card where card_number='" + starting.recby.ToString() + "'", cm);
                    SqlDataReader reader1 = com1.ExecuteReader();
                    reader1.Read();
                    if (reader1.HasRows)
                    {
                        accno = reader1["account_number"].ToString();
                        balance = float.Parse(str);
                        float depo = float.Parse(textBox1.Text);
                        balance = balance + depo;

                        SqlCommand sqlcmd = new SqlCommand("deposit", cm);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@account_number", accno);
                        sqlcmd.Parameters.AddWithValue("@balance", balance);
                        reader1.Close();
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

                                {"message" , "VIT BANK\nAccount Number: "+accno+"\n" + depo + " rupees deposited into your account\nBalance in your account is: " + balance + "\nContact number: +916300189494"},

                                });
                                MessageBox.Show("Deposited");
                                string result = System.Text.Encoding.UTF8.GetString(response);

                                reader2.Close();
                            }
                        }

                    }
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
    }
}
