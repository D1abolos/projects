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
    public partial class Form7 : Form
    {
        string s1, s2, s3;
        private BindingSource bs = new BindingSource();
        DataSet dset = new DataSet();


        private void button1_Click_1(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand("ins4", new MySqlConnection(mysqlCSB.ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("name1", comboBox2.Text));
            cmd.Parameters.Add(new MySqlParameter("period_start1", dateTimePicker1.Value));
            cmd.Parameters.Add(new MySqlParameter("period_end1", dateTimePicker2.Value));
            cmd.Parameters.Add(new MySqlParameter("id_client1", s3));
            cmd.Connection.Open();
            using (cmd.Connection)
            {
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
            }
            //adapter.Update(dset);
            MessageBox.Show("База данных обновлена");
        }

        private void Form7_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 fr1 = new Form1(s1, s2);
            fr1.Show();
        }

        MySqlDataAdapter adapter = new MySqlDataAdapter();

        public Form7(string st1, string st2, string st3)
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
            con.Open();
            string reqstr1 = "SELECT name FROM acs13.package";
            command1 = new MySqlCommand(reqstr1, con);
            MySqlDataAdapter ad = new MySqlDataAdapter(command1);
            adapter = ad;
            adapter.Fill(dset);
            bs.DataSource = dset.Tables[0];
            comboBox2.DataSource = bs;
            comboBox2.DisplayMember = "name";
        }

        
    }
}
