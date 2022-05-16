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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cust_login_Click(object sender, EventArgs e)
        {
            starting obj = new starting ();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void admin_login_Click(object sender, EventArgs e)
        {
            admin_login obj = new admin_login();
            obj.Show();
            this.Hide();
        }

        private void emp_login_Click(object sender, EventArgs e)
        {
            Employee_login obj = new Employee_login();
            obj.Show();
            this.Hide();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void cust_login_Click_1(object sender, EventArgs e)
        {
            starting obj = new starting();
            obj.Show();
            this.Hide();
        }

        private void admin_login_Click_1(object sender, EventArgs e)
        {
            admin_login obj = new admin_login();
            obj.Show();
            this.Hide();
        }

        private void emp_login_Click_1(object sender, EventArgs e)
        {
            Employee_login obj = new Employee_login();
            obj.Show();
            this.Hide();
        }
    }
}
