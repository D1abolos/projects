using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace tp_interface
{
    public partial class Form2 : Form
    {
        string s1, s2;
        private BindingSource bs = new BindingSource();
        DataSet dset = new DataSet();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        public Form2(string st1, string st2)
        {
            InitializeComponent();
            s1 = st1;
            s2 = st2;
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                con.Open();
                string reqstr1 = "SELECT name FROM acs13.dep";
                command1 = new MySqlCommand(reqstr1, con);
                MySqlDataAdapter ad = new MySqlDataAdapter(command1);
                adapter = ad;
                adapter.Fill(dset);
                bs.DataSource = dset.Tables[0];
                comboBox1.DataSource = bs;
                comboBox1.DisplayMember = "name";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;            
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                   

                    MySqlCommand cmd = new MySqlCommand("ins", new MySqlConnection(mysqlCSB.ConnectionString));
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new MySqlParameter("surname", textBox1.Text));
                    cmd.Parameters.Add(new MySqlParameter("name", textBox2.Text));
                    cmd.Parameters.Add(new MySqlParameter("mname", textBox3.Text));
                    cmd.Parameters.Add(new MySqlParameter("birthday", textBox4.Text));
                    cmd.Parameters.Add(new MySqlParameter("department", comboBox1.Text));
                    cmd.Parameters.Add(new MySqlParameter("phone", textBox6.Text));
                    cmd.Parameters.Add(new MySqlParameter("adress", textBox7.Text));
                    cmd.Connection.Open();
                using (cmd.Connection)
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }                    
            
            this.Refresh();
            }
        

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 fr1 = new Form1(s1,s2);
            fr1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            if (textBox11.Text != "" && textBox12.Text != "" && textBox8.Text != "" && textBox9.Text != "" && textBox10.Text != "")
            {


                MySqlCommand cmd = new MySqlCommand("ins3", new MySqlConnection(mysqlCSB.ConnectionString));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("surname", textBox8.Text));
                cmd.Parameters.Add(new MySqlParameter("name", textBox9.Text));
                cmd.Parameters.Add(new MySqlParameter("mname", textBox10.Text));
                cmd.Parameters.Add(new MySqlParameter("adress", textBox11.Text));
                cmd.Parameters.Add(new MySqlParameter("keypassword", textBox12.Text));
                cmd.Connection.Open();
                using (cmd.Connection)
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }

            this.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            if (textBox13.Text != "" && textBox14.Text != "" && textBox5.Text != "" )
            {
                MySqlCommand cmd = new MySqlCommand("ins6", new MySqlConnection(mysqlCSB.ConnectionString));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("name1", textBox13.Text));
                cmd.Parameters.Add(new MySqlParameter("description1", textBox14.Text));
                cmd.Parameters.Add(new MySqlParameter("price1", textBox15.Text));
                cmd.Parameters.Add(new MySqlParameter("period_start1", dateTimePicker1.Value));
                cmd.Parameters.Add(new MySqlParameter("period_end1", dateTimePicker2));
                cmd.Connection.Open();
                using (cmd.Connection)
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }

            this.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           if (textBox5.Text != "")
            {
                MySqlConnectionStringBuilder mysqlCSB;
                mysqlCSB = new MySqlConnectionStringBuilder();
                mysqlCSB.Server = "127.0.0.1";
                mysqlCSB.UserID = "root";
                mysqlCSB.Password = "123";
                mysqlCSB.Database = "acs13";
                MySqlConnection con = new MySqlConnection();
                con.ConnectionString = mysqlCSB.ConnectionString;

                MySqlCommand cmd = new MySqlCommand("ins2", new MySqlConnection(mysqlCSB.ConnectionString));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("name", textBox5.Text));
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                this.Refresh();
            }
        }
    }
}