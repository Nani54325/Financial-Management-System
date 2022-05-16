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
    public partial class changesUserControl1 : UserControl
    {
        private static changesUserControl1 _instance;
        public static changesUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new changesUserControl1();
                return _instance;

            }
        }
        public changesUserControl1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void changesUserControl1_Load(object sender, EventArgs e)
        {
            label1.Hide();
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
            label14.Hide();
            label15.Hide();
            label16.Hide();
            label17.Hide();
            label18.Hide();
            label19.Hide();
            label21.Hide();
            label22.Hide();
            label23.Hide();
            label24.Hide();
            label25.Hide();
            label26.Hide();
            label20.Hide();
            button1.Hide();
            textBox2.Hide();
            textBox3.Hide();
            textBox4.Hide();
            textBox5.Hide();
            textBox6.Hide();
            textBox8.Hide();
            textBox9.Hide();
            richTextBox1.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");


        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                MessageBox.Show("Please Enter User ID");
            }
            else
            {
                SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
                cm.Open();
                SqlCommand com = new SqlCommand("select * from userinfo1 where User_id ='" + textBox1.Text + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label1.Show();
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    label7.Show();
                    label8.Show();
                    label9.Show();
                    label10.Show();
                    label11.Show();
                    label12.Show();
                    label13.Show();
                    label14.Show();
                    label15.Show();
                    label16.Show();
                    label17.Show();
                    label18.Show();
                    label19.Show();
                    label21.Show();
                    label22.Show();
                    label23.Show();
                    label24.Show();
                    label6.Show();
                    label25.Show();
                    label26.Show();
                    label20.Show();
                    button1.Show();
                    textBox2.Show();
                    textBox3.Show();
                    textBox4.Show();
                    textBox5.Show();
                    textBox6.Show();
                    textBox8.Show();
                    textBox9.Show();
                    richTextBox1.Show();
                    label11.Text = reader["First_Name"].ToString();
                    label26.Text = reader["Last_Name"].ToString();
                    label25.Text = reader["Mobile_Number"].ToString();
                    label24.Text = reader["Address"].ToString();
                    label23.Text = reader["Email_id"].ToString();
                    label22.Text = reader["Occupation"].ToString();
                    label21.Text = reader["Father_name"].ToString();
                    label20.Text = reader["Monthly_income"].ToString();
                    reader.Close();
                }
                else
                {
                    MessageBox.Show("Enter Correct User ID");
                    textBox1.Text = "";
                }
                cm.Close();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string first;
            string last;
            string mobile;
            string address;
            string email;
            string father;
            string occupation;
            string income;
            if(textBox2.Text == "")
            {
                first = label11.Text.ToString();
            }
            else
            {
                first = textBox2.Text.ToString();
            }
            if(textBox9.Text == "")
            {
                last = label26.Text.ToString();
            }
            else
            {
                last = textBox9.Text.ToString();
            }
            if (textBox8.Text == "")
            {
                mobile = label25.Text.ToString();
            }
            else
            {
                mobile = textBox8.Text.ToString();
            }
            if (richTextBox1.Text == "")
            {
                address = label24.Text.ToString();
            }
            else
            {
                address = richTextBox1.Text.ToString();
            }
            if(textBox6.Text == "")
            {
                email = label23.Text.ToString();
            }
            else
            {
                email = textBox6.Text.ToString();
            }
            if(textBox5.Text == "")
            {
                occupation = label22.Text.ToString();
            }
            else
            {
                occupation = textBox5.Text.ToString();
            }
            if(textBox4.Text == "")
            {
                father = label21.Text.ToString();
            }
            else
            {
                father = textBox4.Text.ToString();
            }
            if(textBox3.Text == "")
            {
                income = label20.Text.ToString();
            }
            else
            {
                income = textBox3.Text.ToString();
            }
            cm.Open();
            SqlCommand sqlcm = new SqlCommand("changes", cm);
            sqlcm.CommandType = CommandType.StoredProcedure;
            sqlcm.Parameters.AddWithValue("@User_id", textBox1.Text);
            sqlcm.Parameters.AddWithValue("@First_Name", first);
            sqlcm.Parameters.AddWithValue("@Last_Name", last);
            sqlcm.Parameters.AddWithValue("@Mobile_Number", mobile);
            sqlcm.Parameters.AddWithValue("@Address", address);
            sqlcm.Parameters.AddWithValue("@Email_id", email);
            sqlcm.Parameters.AddWithValue("@Occupation", occupation);
            sqlcm.Parameters.AddWithValue("@Father_name", father);
            sqlcm.Parameters.AddWithValue("@Monthly_income", income);
            sqlcm.ExecuteNonQuery();
            MessageBox.Show("Successfully changed");
            cm.Close();
            textBox2.Text = "";
            textBox9.Text = "";
            textBox8.Text = "";
            richTextBox1.Text = "";
            textBox6.Text = "";
            textBox5.Text = "";
            textBox4.Text = "";
            textBox3.Text = "";
        }
    }
}
