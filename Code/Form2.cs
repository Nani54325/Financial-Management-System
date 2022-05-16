using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ATM_SYSTEM
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void button2_Click(object sender, EventArgs e)
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
                label13.Text = reader["User_id"].ToString();
                reader.Close();
            }
            cm.Close();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
          
            

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcmd = new SqlCommand("Add_account", cm);
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.Parameters.AddWithValue("@account_type", comboBox2.Text);
            sqlcmd.Parameters.AddWithValue("@Balance", textBox8.Text.Trim());
            sqlcmd.Parameters.AddWithValue("@userid1", label13.Text);
            cm.Open();
            sqlcmd.ExecuteNonQuery();
            MessageBox.Show("Account Added");
            label14.Visible = true;
            label15.Visible = true;

            SqlCommand com = new SqlCommand("select * from account where account_number=(select max(account_number) from account)", cm);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                label15.Text = reader["account_number"].ToString();
                reader.Close();
            }
            cm.Close();

           


        }
    }
}
