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
    public partial class loansUserControl1 : UserControl
    {
        private static loansUserControl1 _instance;
        public static loansUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new loansUserControl1();
                return _instance;

            }
        }
        public loansUserControl1()
        {
            InitializeComponent();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        DataTable table = new DataTable();
        private void loansUserControl1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("emi", typeof(int));
            table.Columns.Add("tenure", typeof(int));
            dataGridView1.DataSource = table;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            table.Rows.Add(textBox1.Text, textBox2.Text);
            dataGridView1.DataSource = table;
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            float result = 0;
            int sum;
            int ten;
            float sum1 = 0;
            float income = float.Parse(textBox2.Text);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                sum = Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value);
                ten = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                sum1 = sum1 + ten;
                result = result + (sum * ten);
            }
            double per;
            double percentage;
            per = result / income;
            percentage = per * 100;
            MessageBox.Show(result.ToString());
        }
    }
}
