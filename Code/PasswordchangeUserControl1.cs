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
    public partial class PasswordchangeUserControl1 : UserControl
    {
        private static PasswordchangeUserControl1 _instance;
        public static PasswordchangeUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PasswordchangeUserControl1();
                return _instance;

            }
        }
        public PasswordchangeUserControl1()
        {
            InitializeComponent();
        }

        private void PasswordchangeUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                cm.Open();
                SqlCommand com = new SqlCommand("select * from employee where Employee_id = " + textBox1.Text.ToString(), cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if(reader.HasRows)
                {
                    reader.Close();
                    SqlCommand sqlcmd = new SqlCommand("changing_password", cm);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@Employee_id", textBox1.Text);
                    sqlcmd.Parameters.AddWithValue("@password", textBox2.Text);
                    sqlcmd.ExecuteNonQuery();
                    MessageBox.Show("Password Changed Successfully");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Enter Valid Employee ID");
                }
            }
            cm.Close();
        }
    }
}
