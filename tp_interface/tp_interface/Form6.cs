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
    public partial class Form6 : Form
    {
        string s1, s2, s3;
        private BindingSource bs = new BindingSource();
        DataSet dset = new DataSet();
        MySqlDataAdapter adapter = new MySqlDataAdapter();

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
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                MySqlCommand cmd = new MySqlCommand("ins5", new MySqlConnection(mysqlCSB.ConnectionString));
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new MySqlParameter("id_compact1", s3));
                cmd.Parameters.Add(new MySqlParameter("info1", textBox1.Text));
                cmd.Parameters.Add(new MySqlParameter("mac1", textBox2.Text));          
                cmd.Connection.Open();
                using (cmd.Connection)
                {
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }

            this.Refresh();
        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 fr1 = new Form1(s1, s2);
            fr1.Show();
        }

        DataTable dt = new DataTable();
        public Form6(string st1, string st2, string st3)
        {
            InitializeComponent();
            s1 = st1;
            s2 = st2;
            s3 = st3;
        }
    }
}
