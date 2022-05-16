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
    public partial class BalanceUserControl1 : UserControl
    {
        private static BalanceUserControl1 _instance;
        public static BalanceUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new BalanceUserControl1();
                return _instance;

            }
        }
        public BalanceUserControl1()
        {
            InitializeComponent();
        }
        
        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void BalanceUserControl1_Load(object sender, EventArgs e)
        {
            SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
            cm.Open();
            SqlCommand com = new SqlCommand("select * from account where account_number=(select account_number from Card where card_number ='"+starting.recby.ToString() + "')", cm);
            SqlDataReader reader = com.ExecuteReader();
            reader.Read();
            if (reader.HasRows)
            {
                label3.Text = reader["balance"].ToString();
                reader.Close();
            }
            cm.Close();
        }
    }
}
