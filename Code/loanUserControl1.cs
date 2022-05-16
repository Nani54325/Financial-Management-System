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
    public partial class loanUserControl1 : UserControl
    {
        private static loanUserControl1 _instance;
        public static loanUserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new loanUserControl1();
                return _instance;

            }
        }
        public loanUserControl1()
        {
            InitializeComponent();
        }
        DataTable table = new DataTable();

        private void loanUserControl1_Load(object sender, EventArgs e)
        {
            button3.Hide();
            button1.Hide();
            table.Columns.Add("emi", typeof(int));
            table.Columns.Add("tenure", typeof(int));
            dataGridView1.DataSource = table;
            dataGridView1.Hide();
            label23.Hide();
            dateTimePicker1.Hide();
            label21.Hide();
            label22.Hide();
            label11.Hide();
            textBox9.Hide();
            label20.Hide();
            comboBox1.Hide();
            label5.Hide();
            label19.Hide();
            textBox10.Hide();
            button8.Hide();
            textBox7.Hide();
            label17.Hide();
            label18.Hide();
            label9.Hide();
            textBox7.Hide();
            label10.Hide();
            label16.Hide();
            textBox8.Hide();
            label12.Hide();
            label13.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        
        public void getdata()
        {
            float emi1;
            float amo = float.Parse(textBox9.Text);
            if (comboBox1.Text == "Crop")
            {
                amo = amo + (amo * 2) / 100;
                float ten = float.Parse(textBox10.Text);
                emi1 = amo / ten;
                SqlCommand sqlcmd = new SqlCommand("loans", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@income", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@loan_amount", textBox9.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@account_id", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@interest", "2%");
                sqlcmd.Parameters.AddWithValue("@type_of_loan", comboBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@total_amount", amo);
                sqlcmd.Parameters.AddWithValue("@tenure", textBox10.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@emi", emi1);
                sqlcmd.Parameters.AddWithValue("@start_date", dateTimePicker2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@last_date", dateTimePicker1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@employee_id", Employee_login.recby);

                sqlcmd.ExecuteNonQuery();
                clear();
                SqlCommand com = new SqlCommand("select * from loan where loan_id=(select max(loan_id) from loan)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    
                    label18.Show();
                    label17.Show();
                    label12.Show();
                    label13.Show();
                    label21.Show();
                    label22.Show();
                    label13.Text = reader["loan_id"].ToString();
                    label17.Text = reader["emi"].ToString();
                    label22.Text = reader["interest"].ToString();
                    reader.Close();
                }
                
                cm.Close();
            }
            else if (comboBox1.Text == "Home")
            {
                amo = amo + (amo * 5) / 100;
                float ten = float.Parse(textBox10.Text);
                emi1 = amo / ten;
                SqlCommand sqlcmd = new SqlCommand("loans", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@income", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@loan_amount", textBox9.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@account_id", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@interest", "5%");
                sqlcmd.Parameters.AddWithValue("@type_of_loan", comboBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@total_amount", amo);
                sqlcmd.Parameters.AddWithValue("@tenure", textBox10.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@emi", emi1);
                sqlcmd.Parameters.AddWithValue("@start_date", dateTimePicker2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@last_date", dateTimePicker1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@employee_id", Employee_login.recby);

                sqlcmd.ExecuteNonQuery();
                clear();
                SqlCommand com = new SqlCommand("select * from loan where loan_id=(select max(loan_id) from loan)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    
                    label18.Show();
                    label17.Show();
                    label12.Show();
                    label13.Show();
                    label13.Text = reader["loan_id"].ToString();
                    label17.Text = reader["emi"].ToString();
                    label21.Show();
                    label22.Show();
                    label22.Text = reader["interest"].ToString();
                    reader.Close();
                }
                cm.Close();
            }
            else if (comboBox1.Text == "Personal")
            {
                amo = amo + (amo * 7) / 100;
                float ten = float.Parse(textBox10.Text);
                emi1 = amo / ten;
                SqlCommand sqlcmd = new SqlCommand("loans", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@income", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@loan_amount", textBox9.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@account_id", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@interest", "7%");
                sqlcmd.Parameters.AddWithValue("@type_of_loan", comboBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@total_amount", amo);
                sqlcmd.Parameters.AddWithValue("@tenure", textBox10.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@emi", emi1);
                sqlcmd.Parameters.AddWithValue("@start_date", dateTimePicker2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@last_date", dateTimePicker1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@employee_id", Employee_login.recby);

                sqlcmd.ExecuteNonQuery();
                clear();
                SqlCommand com = new SqlCommand("select * from loan where loan_id=(select max(loan_id) from loan)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    
                    label18.Show();
                    label17.Show();
                    label12.Show();
                    label13.Show();
                    label13.Text = reader["loan_id"].ToString();
                    label17.Text = reader["emi"].ToString();
                    label21.Show();
                    label22.Show();
                    label22.Text = reader["interest"].ToString();
                    reader.Close();
                }
                cm.Close();
            }
            else if (comboBox1.Text == "Car")
            {
                amo = amo + (amo * 3) / 100;
                float ten = float.Parse(textBox10.Text);
                emi1 = amo / ten;
                SqlCommand sqlcmd = new SqlCommand("loans", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@income", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@loan_amount", textBox9.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@account_id", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@interest", "3%");
                sqlcmd.Parameters.AddWithValue("@type_of_loan", comboBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@total_amount", amo);
                sqlcmd.Parameters.AddWithValue("@tenure", textBox10.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@emi", emi1);
                sqlcmd.Parameters.AddWithValue("@start_date", dateTimePicker2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@last_date", dateTimePicker1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@employee_id", Employee_login.recby);

                sqlcmd.ExecuteNonQuery();
                clear();
                SqlCommand com = new SqlCommand("select * from loan where loan_id=(select max(loan_id) from loan)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    
                    label18.Show();
                    label17.Show();
                    label12.Show();
                    label13.Show();
                    label13.Text = reader["loan_id"].ToString();
                    label17.Text = reader["emi"].ToString();
                    label21.Show();
                    label22.Show();
                    label22.Text = reader["interest"].ToString();
                    reader.Close();
                }
                cm.Close();
            }
            else if (comboBox1.Text == "Student")
            {
                amo = amo + (amo * 1) / 100;
                float ten = float.Parse(textBox10.Text);
                emi1 = amo / ten;
                SqlCommand sqlcmd = new SqlCommand("loans", cm);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@income", textBox2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@loan_amount", textBox9.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@account_id", textBox3.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@interest", "1%");
                sqlcmd.Parameters.AddWithValue("@type_of_loan", comboBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@total_amount", amo);
                sqlcmd.Parameters.AddWithValue("@tenure", textBox10.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@emi", emi1);
                sqlcmd.Parameters.AddWithValue("@start_date", dateTimePicker2.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@last_date", dateTimePicker1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@employee_id", Employee_login.recby);

                sqlcmd.ExecuteNonQuery();
                clear();
                SqlCommand com = new SqlCommand("select * from loan where loan_id=(select max(loan_id) from loan)", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    
                    label18.Show();
                    label17.Show();
                    label12.Show();
                    label13.Show();
                    label13.Text = reader["loan_id"].ToString();
                    label17.Text = reader["emi"].ToString();
                    label21.Show();
                    label22.Show();
                    label22.Text = reader["interest"].ToString();
                    reader.Close();
                }
                cm.Close();
            }
        }
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox9.Text = "";
            comboBox1.Text = "";
            textBox10.Text = "";
            textBox8.Text = "";
            textBox7.Text = "";
           
        }
        SqlConnection cm = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Nivas\\Documents\\atm.mdf;Integrated Security=True;Connect Timeout=30");

        private void button8_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text=="")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                float amo = float.Parse(textBox9.Text);
                if (amo <= 2000000)
                {
                    if (textBox4.Text == "0")
                    {
                        cm.Open();
                        SqlCommand com = new SqlCommand("select balance from account where account_number='" + textBox3.Text + "'", cm);
                        SqlDataReader reader = com.ExecuteReader();
                        reader.Read();
                        String str;
                        String accno;
                        float balance = 0;
                        if (reader.HasRows)
                        {
                            str = reader["balance"].ToString();
                            reader.Close();
                            SqlCommand com1 = new SqlCommand("select account_number from account where account_number='" + textBox3.Text + "'", cm);
                            SqlDataReader reader1 = com1.ExecuteReader();
                            reader1.Read();
                            if (reader1.HasRows)
                            {
                                accno = reader1["account_number"].ToString();
                                balance = float.Parse(str);
                                float depo = float.Parse(textBox9.Text);
                                balance = balance + depo;

                                SqlCommand sqlcmd = new SqlCommand("loan_money", cm);
                                sqlcmd.CommandType = CommandType.StoredProcedure;
                                sqlcmd.Parameters.AddWithValue("@account_number", accno);
                                sqlcmd.Parameters.AddWithValue("@balance", balance);
                                reader1.Close();
                                sqlcmd.ExecuteNonQuery();
                                MessageBox.Show("Money transferring to his/her account");
                                
                                getdata();
                                MessageBox.Show("Money Transferred successfully");
                            }
                            
                        }
                        else
                        {
                            MessageBox.Show("Plese Enter correct Account Number");
                            textBox3.Text = "";
                        }
                        cm.Close();
                    }
                    else if (textBox4.Text == "1")
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
                        int cibil = 0;
                        int cibil1 = 0;
                        int totcibil = 0;
                        if (percentage <= 10 && percentage >= 0)
                        {
                            cibil = 500;
                        }
                        else if (percentage <= 20 && percentage > 10)
                        {
                            cibil = 450;
                        }
                        else if (percentage <= 30 && percentage > 20)
                        {
                            cibil = 400;
                        }
                        else if (percentage <= 40 && percentage > 30)
                        {
                            cibil = 350;
                        }
                        else if (percentage <= 50 && percentage > 40)
                        {
                            cibil = 300;
                        }
                        else if (percentage <= 60 && percentage > 50)
                        {
                            cibil = 250;
                        }
                        else if (percentage <= 70 && percentage > 60)
                        {
                            cibil = 200;
                        }
                        else
                        {
                            MessageBox.Show("Not Eligible For loan Because Percentage Greater Than 70");
                            cibil = 1000;
                        }
                        if (sum1 <= 12 && sum1 >= 0)
                        {
                            cibil1 = 400;
                        }
                        else if (sum1 <= 24 && sum1 > 12)
                        {
                            cibil1 = 350;
                        }
                        else if (sum1 <= 36 && sum1 > 24)
                        {
                            cibil1 = 300;
                        }
                        else if (sum1 <= 48 && sum1 > 36)
                        {
                            cibil1 = 250;
                        }
                        else if (sum1 <= 60 && sum1 > 48)
                        {
                            cibil1 = 200;
                        }
                        else if (sum1 <= 72 && sum1 > 60)
                        {
                            cibil1 = 150;
                        }
                        else if (sum1 <= 84 && sum1 > 72)
                        {
                            cibil1 = 100;
                        }
                        else
                        {
                            MessageBox.Show("Not Eligible For loan Because Tenure Greater Than 84 Months");
                            cibil1 = 1000;
                        }
                        totcibil = cibil + cibil1;
                        if (totcibil <= 900 && totcibil >= 300)
                        {
                            cm.Open();
                            SqlCommand com = new SqlCommand("select balance from account where account_number='" + textBox3.Text + "'", cm);
                            SqlDataReader reader = com.ExecuteReader();
                            reader.Read();
                            String str;
                            String accno;
                            float balance = 0;
                            if (reader.HasRows)
                            {
                                str = reader["balance"].ToString();
                                reader.Close();
                                SqlCommand com1 = new SqlCommand("select account_number from account where account_number='" + textBox3.Text + "'", cm);
                                SqlDataReader reader1 = com1.ExecuteReader();
                                reader1.Read();
                                if (reader1.HasRows)
                                {
                                    accno = reader1["account_number"].ToString();
                                    balance = float.Parse(str);
                                    float depo = float.Parse(textBox9.Text);
                                    balance = balance + depo;

                                    SqlCommand sqlcmd = new SqlCommand("loan_money", cm);
                                    sqlcmd.CommandType = CommandType.StoredProcedure;
                                    sqlcmd.Parameters.AddWithValue("@account_number", accno);
                                    sqlcmd.Parameters.AddWithValue("@balance", balance);
                                    reader1.Close();
                                    sqlcmd.ExecuteNonQuery();
                                    MessageBox.Show("Money transferring to his/her account");
                                    
                                    getdata();
                                    MessageBox.Show("Money Transferred successfully");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Plese Enter correct Account Number");
                                textBox3.Text = "";
                            }
                            cm.Close();
                            
                        }
                        else
                        {
                            MessageBox.Show("Not eligible for loan");
                        }

                    }
                    else if (textBox4.Text == "2")
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
                        int cibil = 0;
                        int cibil1 = 0;
                        int totcibil = 0;
                        if (percentage <= 10 && percentage >= 0)
                        {
                            cibil = 500;
                        }
                        else if (percentage <= 20 && percentage > 10)
                        {
                            cibil = 450;
                        }
                        else if (percentage <= 30 && percentage > 20)
                        {
                            cibil = 400;
                        }
                        else if (percentage <= 40 && percentage > 30)
                        {
                            cibil = 350;
                        }
                        else if (percentage <= 50 && percentage > 40)
                        {
                            cibil = 300;
                        }
                        else if (percentage <= 60 && percentage > 50)
                        {
                            cibil = 250;
                        }
                        else if (percentage <= 70 && percentage > 60)
                        {
                            cibil = 200;
                        }
                        else
                        {
                            MessageBox.Show("Percentage Greater Than 70");
                            cibil = 1000;
                        }
                        if (sum1 <= 12 && sum1 >= 0)
                        {
                            cibil1 = 400;
                        }
                        else if (sum1 <= 24 && sum1 > 12)
                        {
                            cibil1 = 350;
                        }
                        else if (sum1 <= 36 && sum1 > 24)
                        {
                            cibil1 = 300;
                        }
                        else if (sum1 <= 48 && sum1 > 36)
                        {
                            cibil1 = 250;
                        }
                        else if (sum1 <= 60 && sum1 > 48)
                        {
                            cibil1 = 200;
                        }
                        else if (sum1 <= 72 && sum1 > 60)
                        {
                            cibil1 = 150;
                        }
                        else if (sum1 <= 84 && sum1 > 72)
                        {
                            cibil1 = 100;
                        }
                        else
                        {
                            MessageBox.Show("Total Tenure is Greater Than 84 Months");
                            cibil1 = 1000;
                        }
                        totcibil = cibil + cibil1;
                        if (totcibil <= 900 && totcibil >= 300)
                        {
                            cm.Open();
                            SqlCommand com = new SqlCommand("select balance from account where account_number='" + textBox3.Text + "'", cm);
                            SqlDataReader reader = com.ExecuteReader();
                            reader.Read();
                            String str;
                            String accno;
                            float balance = 0;
                            if (reader.HasRows)
                            {
                                str = reader["balance"].ToString();
                                reader.Close();
                                SqlCommand com1 = new SqlCommand("select account_number from account where account_number='" + textBox3.Text + "'", cm);
                                SqlDataReader reader1 = com1.ExecuteReader();
                                reader1.Read();
                                if (reader1.HasRows)
                                {
                                    accno = reader1["account_number"].ToString();
                                    balance = float.Parse(str);
                                    float depo = float.Parse(textBox9.Text);
                                    balance = balance + depo;

                                    SqlCommand sqlcmd = new SqlCommand("loan_money", cm);
                                    sqlcmd.CommandType = CommandType.StoredProcedure;
                                    sqlcmd.Parameters.AddWithValue("@account_number", accno);
                                    sqlcmd.Parameters.AddWithValue("@balance", balance);
                                    reader1.Close();
                                    sqlcmd.ExecuteNonQuery();
                                    MessageBox.Show("Money transferring to his/her account");
                                    getdata();
                                    MessageBox.Show("Money Transferred successfully");
                                }
                                
                            }
                            else
                            {
                                MessageBox.Show("Plese Enter correct Account Number");
                                textBox3.Text = "";
                            }
                            cm.Close();

                        }
                        else
                        {
                            MessageBox.Show("Not eligible for loan");
                        }
                    }
                    else
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
                        int cibil = 0;
                        int cibil1 = 0;
                        int totcibil = 0;
                        if (percentage <= 10 && percentage >= 0)
                        {
                            cibil = 500;
                        }
                        else if (percentage <= 20 && percentage > 10)
                        {
                            cibil = 450;
                        }
                        else if (percentage <= 30 && percentage > 20)
                        {
                            cibil = 400;
                        }
                        else if (percentage <= 40 && percentage > 30)
                        {
                            cibil = 350;
                        }
                        else if (percentage <= 50 && percentage > 40)
                        {
                            cibil = 300;
                        }
                        else if (percentage <= 60 && percentage > 50)
                        {
                            cibil = 250;
                        }
                        else if (percentage <= 70 && percentage > 60)
                        {
                            cibil = 200;
                        }
                        else
                        {
                            MessageBox.Show("Percentage Greater Than 70");
                            cibil = 1000;
                        }
                        if (sum1 <= 12 && sum1 >= 0)
                        {
                            cibil1 = 400;
                        }
                        else if (sum1 <= 24 && sum1 > 12)
                        {
                            cibil1 = 350;
                        }
                        else if (sum1 <= 36 && sum1 > 24)
                        {
                            cibil1 = 300;
                        }
                        else if (sum1 <= 48 && sum1 > 36)
                        {
                            cibil1 = 250;
                        }
                        else if (sum1 <= 60 && sum1 > 48)
                        {
                            cibil1 = 200;
                        }
                        else if (sum1 <= 72 && sum1 > 60)
                        {
                            cibil1 = 150;
                        }
                        else if (sum1 <= 84 && sum1 > 72)
                        {
                            cibil1 = 100;
                        }
                        else
                        {
                            MessageBox.Show("Total Tenure is Greater Than 84 Months");
                            cibil1 = 1000;
                        }
                        totcibil = cibil + cibil1;
                        if (totcibil <= 900 && totcibil >= 300)
                        {
                            cm.Open();
                            SqlCommand com = new SqlCommand("select balance from account where account_number='" + textBox3.Text + "'", cm);
                            SqlDataReader reader = com.ExecuteReader();
                            reader.Read();
                            String str;
                            String accno;
                            float balance = 0;
                            if (reader.HasRows)
                            {
                                str = reader["balance"].ToString();
                                reader.Close();
                                SqlCommand com1 = new SqlCommand("select account_number from account where account_number='" + textBox3.Text + "'", cm);
                                SqlDataReader reader1 = com1.ExecuteReader();
                                reader1.Read();
                                if (reader1.HasRows)
                                {
                                    accno = reader1["account_number"].ToString();
                                    balance = float.Parse(str);
                                    float depo = float.Parse(textBox9.Text);
                                    balance = balance + depo;

                                    SqlCommand sqlcmd = new SqlCommand("loan_money", cm);
                                    sqlcmd.CommandType = CommandType.StoredProcedure;
                                    sqlcmd.Parameters.AddWithValue("@account_number", accno);
                                    sqlcmd.Parameters.AddWithValue("@balance", balance);
                                    reader1.Close();
                                    sqlcmd.ExecuteNonQuery();
                                    MessageBox.Show("Money transferring to his/her account");
                                    getdata();
                                    MessageBox.Show("Money Transferred successfully");
                                }

                            }
                            else
                            {
                                MessageBox.Show("Plese Enter correct Account Number");
                                textBox3.Text = "";
                            }
                            cm.Close();

                        }
                        else
                        {
                            MessageBox.Show("Not eligible for loan");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Our Bank Can Give Only 2000000");
                    textBox9.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Please Fill All Aspects");
            }
            else
            {
                cm.Open();
                string accno;
                SqlCommand com = new SqlCommand("select * from account where account_number = '" + textBox3.Text.ToString() + "'", cm);
                SqlDataReader reader = com.ExecuteReader();
                reader.Read();
                if (reader.HasRows)
                {
                    accno = reader["account_number"].ToString();
                    if (accno == textBox3.Text)
                    {
                        if (textBox4.Text == "0")
                        {
                            label23.Show();
                            dateTimePicker1.Show();
                            dataGridView1.Hide();
                            label9.Hide();
                            textBox7.Hide();
                            label10.Hide();
                            label16.Hide();
                            textBox8.Hide();
                            label11.Show();
                            textBox9.Show();
                            label20.Show();
                            label5.Show();
                            label19.Show();
                            comboBox1.Show();
                            textBox10.Show();
                            button8.Show();
                        }
                        else if (textBox4.Text == "1")
                        {
                            button3.Show();
                            label23.Show();
                            dateTimePicker1.Show();
                            button1.Show();
                            dataGridView1.Show();
                            label9.Show();
                            textBox7.Show();
                            label10.Show();
                            label16.Show();
                            textBox8.Show();
                            label11.Show();
                            textBox9.Show();
                            label20.Show();
                            label5.Show();
                            label19.Show();
                            comboBox1.Show();
                            textBox10.Show();
                            button8.Show();
                        }
                        else if (textBox4.Text == "2")
                        {
                            button3.Show();
                            label23.Show();
                            dateTimePicker1.Show();
                            button1.Show();
                            label9.Show();
                            textBox7.Show();
                            label10.Show();
                            label16.Show();
                            textBox8.Show();
                            label11.Show();
                            textBox9.Show();
                            label20.Show();
                            label5.Show();
                            label19.Show();
                            comboBox1.Show();
                            textBox10.Show();
                            button8.Show();
                        }
                        else if (textBox4.Text == "")
                        {
                            MessageBox.Show("Enter number of EMI's");
                        }
                        else
                        {
                            label23.Show();
                            dataGridView1.Show();
                            button1.Show();
                            dateTimePicker1.Show();
                            button3.Show();
                            label9.Show();
                            textBox7.Show();
                            label10.Show();
                            label16.Show();
                            textBox8.Show();
                            label11.Show();
                            textBox9.Show();
                            label20.Show();
                            label5.Show();
                            label19.Show();
                            comboBox1.Show();
                            textBox10.Show();
                            button8.Show();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Enter Valid Account Number");
                }
                cm.Close();

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            table.Rows.Add(textBox7.Text, textBox8.Text);
            dataGridView1.DataSource = table;
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                if (!row.IsNewRow) dataGridView1.Rows.Remove(row);
        }
    }
}
