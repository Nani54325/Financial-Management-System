using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_SYSTEM
{
    public partial class admin_login : Form
    {
        public admin_login()
        {
            InitializeComponent();
        }

        private void admin_login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 obj = new Form1();
            obj.Show();
            this.Hide();
        }
        private void clear() 
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "nivas" && textBox2.Text == "2002")
            {
                admin_dashboard obj = new admin_dashboard();
                obj.Show();
                this.Hide();
            }
            else 
            {
                MessageBox.Show("Invalid Credentials");
                clear();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
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
