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
    public partial class lastdateUserControl1 : UserControl
    {
        private static lastdateUserControl1 _instance;
        public static lastdateUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new lastdateUserControl1();
                return _instance;

            }
        }
        public lastdateUserControl1()
        {
            InitializeComponent();
        }

        private void lastdateUserControl1_Load(object sender, EventArgs e)
        {
            cm.Open();

            SqlDataAdapter sqlda = new SqlDataAdapter("select account_id, loan_id, loan_amount, tenure, last_date, total_amount from loan where account_id = (select account_number from Card where card_number = '" + starting.recby.ToString() + "')", cm);
            DataTable dtbl = new DataTable();
            sqlda.Fill(dtbl);
            dataGridView1.DataSource = dtbl;
            cm.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void clear()
        {
            
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
