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
    public partial class Employee_login : Form
    {
        public Employee_login()
        {
            InitializeComponent();
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
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter da;
        public void getdata()
        {
            string name = textBox1.Text;
            string pass = textBox2.Text;
            recby = name;
            da = new SqlDataAdapter("Select Employee_id From employee where Employee_id like'" + textBox1.Text + "'and password='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Employee_dashboard obj = new Employee_dashboard();
                obj.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Credentials");
                clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getdata();
        }

        private void Employee_login_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
