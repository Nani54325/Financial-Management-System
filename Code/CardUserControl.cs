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
    public partial class CardUserControl : UserControl
    {
        private static CardUserControl _instance;
        public static CardUserControl Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CardUserControl();
                return _instance;

            }
        }
        public CardUserControl()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear1()
        {
            
            textBox2.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please Fill all aspects");
                
            }
            else
            {
                
                cm.Open();
                
                SqlCommand com1 = new SqlCommand("select * from account where account_number = '" + textBox2.Text.ToString() + "'", cm);
                SqlDataReader reader1 = com1.ExecuteReader();
                reader1.Read();
                if(reader1.HasRows)
                {
                    SqlCommand sqlcmd = new SqlCommand("Add_Card", cm);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@default_pin", textBox1.Text.Trim());
                    sqlcmd.Parameters.AddWithValue("@account_number", textBox2.Text.Trim());
                    sqlcmd.ExecuteNonQuery();
                    label3.Visible = true;
                    label5.Visible = true;
                    reader1.Close();
                    SqlCommand com = new SqlCommand("select * from Card where card_number=(select max(card_number) from Card)", cm);
                    SqlDataReader reader = com.ExecuteReader();
                    reader.Read();
                    if (reader.HasRows)
                    {
                        label3.Show();
                        label5.Show();
                        label5.Text = reader["card_number"].ToString();
                        reader.Close();
                        clear1();
                    }
                }
                else
                {
                    MessageBox.Show("Enter Valid Account Number");
                    textBox2.Text = "";
                }
                
                cm.Close();
            }
        }
        private void CardUserControl_Load(object sender, EventArgs e)
        {
            label3.Hide();
            label5.Hide();
            

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
    }
}
