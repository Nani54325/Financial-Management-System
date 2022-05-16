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
using System.Net;
using System.Collections.Specialized;



namespace ATM_SYSTEM
{
    public partial class employeeUserControl1 : UserControl
    {
        private static employeeUserControl1 _instance;
        public static employeeUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new employeeUserControl1();
                return _instance;

            }
        }
        public employeeUserControl1()
        {
            InitializeComponent();
        }

        private void employeeUserControl1_Load(object sender, EventArgs e)
        {
            label9.Hide();
            label10.Hide();
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text=="" || textBox5.Text=="" || textBox6.Text=="" || textBox7.Text=="")
            {
                MessageBox.Show("Please Fill all aspects");
            }
            else
            {
                SqlCommand sqlcmd = new SqlCommand("Add_employee", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Employee_name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@father_name", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@mobile_number", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@email", textBox4.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@salary", textBox7.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@designation", textBox6.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", textBox5.Text.Trim());
                cm.Open();
                sqlcmd.ExecuteNonQuery();
                

                clear();
                SqlCommand com = new SqlCommand("select * from employee where Employee_id=(select max(Employee_id) from employee)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    label9.Show();
                    label10.Show();
                    label10.Text = reader["Employee_id"].ToString();
                    reader.Close();
                    
                }
                string mob;
                mob = textBox3.Text.ToString();
                using (var wb = new WebClient())
                {

                    byte[] response = wb.UploadValues("https://api.textlocal.in/send/", new NameValueCollection()
                    {
                    {"apikey" , "TQYPZV3sjH0-1q5LmkniE0gQNtPOQOBA695SsGs2uR"},
                    {"numbers" , "91" + mob },

                    {"message" , "VIT BANK\n This Bank Accepts you to be :"+textBox6.Text.ToString()+"\nWith Employee ID: "+label10.Text.ToString()+"Contact Number: +916300189494"},

                    });
                    string result = System.Text.Encoding.UTF8.GetString(response);
                }
                MessageBox.Show("Employee is Added");
                cm.Close();
            }
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
