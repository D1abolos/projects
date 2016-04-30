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
    public partial class Form4 : Form
    {
        string s1, s2,s3;
        private BindingSource bs = new BindingSource();
        DataSet dset = new DataSet();
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataTable dt = new DataTable();
        public Form4(string st1, string st2, string st3)
        {
            InitializeComponent();
            s1 = st1;
            s2 = st2;
            s3 = st3;
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

        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 fr1 = new Form1(s1, s2);
            fr1.Show();
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
            MySqlCommand cmd = new MySqlCommand("edt", new MySqlConnection(mysqlCSB.ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("surname1", textBox1.Text));
            cmd.Parameters.Add(new MySqlParameter("name1", textBox2.Text));
            cmd.Parameters.Add(new MySqlParameter("mname1", textBox3.Text));
            cmd.Parameters.Add(new MySqlParameter("birthday1", textBox4.Text));
            cmd.Parameters.Add(new MySqlParameter("department1", comboBox1.Text));
            cmd.Parameters.Add(new MySqlParameter("phone1", textBox1.Text));
            cmd.Parameters.Add(new MySqlParameter("adress1", textBox6.Text));
            cmd.Parameters.Add(new MySqlParameter("id1", s3));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //adapter.Update(dset);
            MessageBox.Show("База данных обновлена");
        }
    }
}
