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
    public partial class starting : Form
    {
        public starting()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        public static string check = "no";
        public static string username;
        public static string recby
        {
            get { return username; }
            set { username = value; }
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter da;

        public void getdata()
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            recby = name;
            da = new SqlDataAdapter("Select card_number From Card where card_number like'" + textBox1.Text + "'and default_pin='" + textBox2.Text + "'",cm);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count == 1)
            {
                SqlDataAdapter da1 = new SqlDataAdapter("Select card_number From deactivate where card_number ='" + textBox1.Text + "'", cm);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                if(dt1.Rows.Count == 1)
                {
                    MessageBox.Show("This Account is Deactivated");
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    Dashboard obj = new Dashboard();
                    obj.Show();
                    this.Hide();
                }
                
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
                clear();
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            getdata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void starting_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
    }
}
