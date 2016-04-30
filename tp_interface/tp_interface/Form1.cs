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
using System.Web.Script.Serialization;
using Newtonsoft.Json;

namespace tp_interface
{

    public partial class Form1 : Form
    {
        string s1, s2;
        private BindingSource bs = new BindingSource();
        private BindingSource bs2 = new BindingSource();
        private BindingSource bs3 = new BindingSource();
        private BindingSource bs4 = new BindingSource();
        private BindingSource bs5 = new BindingSource();
        private BindingSource bs6 = new BindingSource();
        private BindingSource bs9 = new BindingSource();
        private BindingSource bs7 = new BindingSource();
        private BindingSource bs10 = new BindingSource();
        private BindingSource bs8 = new BindingSource();
        private BindingSource bs11 = new BindingSource();
        DataTable dtable1 = new DataTable();
        JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
        List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
        Dictionary<string, object> childRow;
        string str1;

        public Form1(string st1, string st2)
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
            MySqlCommand command2 = new MySqlCommand();
            MySqlCommand command3 = new MySqlCommand();
            MySqlCommand command4 = new MySqlCommand(); 
            MySqlCommand command5 = new MySqlCommand();
            MySqlCommand command6 = new MySqlCommand();
            MySqlCommand command7 = new MySqlCommand();
            MySqlCommand command8 = new MySqlCommand();
            MySqlCommand command9 = new MySqlCommand();
            MySqlCommand command10 = new MySqlCommand();
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            DataTable dt4 = new DataTable();
            DataTable dt5 = new DataTable();
            DataTable dt6 = new DataTable();
            DataTable dt7 = new DataTable();
            DataTable dt8 = new DataTable();
            DataTable dt9 = new DataTable();
            DataTable dt10 = new DataTable();
            //dtable1.Columns.Add("id", typeof(Int32));
            //dtable1.Columns.Add("surname", typeof(string));
            //dtable1.Columns.Add("name", typeof(string));
            //dtable1.Columns.Add("mname", typeof(string));
            //dtable1.Columns.Add("birthday", typeof(string));
            //dtable1.Columns.Add("department", typeof(string));
            //dtable1.Columns.Add("phone", typeof(string));
            //dtable1.Columns.Add("adress", typeof(string));

            try
            {
                con.Open();
                string reqstr1 = "SELECT * FROM " + "acs13.info";
                command1 = new MySqlCommand(reqstr1, con);
                MySqlDataReader dr = command1.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                }
                bs.DataSource = dt;
                dataGridView1.DataSource = bs;
                bindingNavigator1.BindingSource = bs;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.AutoResizeColumns();
                dtable1 = dt;
                

                string reqstr2 = "SELECT * FROM " + "acs13.dep";
                command2 = new MySqlCommand(reqstr2, con);
                MySqlDataReader dr2 = command2.ExecuteReader();
                if (dr2.HasRows)
                {
                    dt2.Load(dr2);
                }
                bs2.DataSource = dt2;
                dataGridView2.DataSource = bs2;
                bindingNavigator2.BindingSource = bs2;
                dataGridView2.Columns[0].Visible = false;
                dataGridView2.AutoResizeColumns();

                //string reqstr3 = "SELECT * FROM " + "acs13.operations";
                //command3 = new MySqlCommand(reqstr3, con);
                //MySqlDataReader dr3 = command3.ExecuteReader();
                //if (dr3.HasRows)
                //{
                //    dt3.Load(dr3);
                //}
                //bs3.DataSource = dt3;
                //dataGridView3.DataSource = bs3;
                //bindingNavigator3.BindingSource = bs3;
                //dataGridView3.Columns[0].Visible = false;
                //dataGridView3.AutoResizeColumns();

                string reqstr4 = "SELECT * FROM " + "acs13.client";
                command4 = new MySqlCommand(reqstr4, con);
                MySqlDataReader dr4 = command4.ExecuteReader();
                if (dr4.HasRows)
                {
                    dt4.Load(dr4);
                }
                bs4.DataSource = dt4;
                dataGridView4.DataSource = bs4;
                bindingNavigator4.BindingSource = bs4;
                dataGridView4.Columns[0].Visible = false;
                dataGridView4.Rows[0].Selected = true;
                dataGridView4.AutoResizeColumns();

                string reqstr5 = "SELECT * FROM " + "acs13.info2";
                command5 = new MySqlCommand(reqstr5, con);
                MySqlDataReader dr5 = command5.ExecuteReader();
                if (dr5.HasRows)
                {
                    dt5.Load(dr5);
                }
                bs5.DataSource = dt5;
                dataGridView5.DataSource = bs5;
                bindingNavigator5.BindingSource = bs5;
                dataGridView5.Columns[0].Visible = false;
                dataGridView5.AutoResizeColumns();
                dataGridView5.Columns[1].HeaderText = "client identifier";
                dataGridView5.Columns[3].HeaderText = "start of period";
                dataGridView5.Columns[4].HeaderText = "end of period";

                string reqstr6 = "SELECT * FROM " + "acs13.accesspoint";
                command6 = new MySqlCommand(reqstr6, con);
                MySqlDataReader dr6 = command6.ExecuteReader();
                if (dr6.HasRows)
                {
                    dt6.Load(dr6);
                }
                bs6.DataSource = dt6;
                dataGridView6.DataSource = bs6;
                bindingNavigator6.BindingSource = bs6;
                dataGridView6.Columns[0].Visible = false;
                dataGridView6.AutoResizeColumns();
                dataGridView6.Columns[1].HeaderText = "contract number";

                string reqstr7 = "SELECT * FROM " + "acs13.internettariff where id>1";
                command7 = new MySqlCommand(reqstr7, con);
                MySqlDataReader dr7 = command7.ExecuteReader();
                if (dr7.HasRows)
                {
                    dt7.Load(dr7);
                }
                bs7.DataSource = dt7;
                dataGridView7.DataSource = bs7;
                bindingNavigator7.BindingSource = bs7;
                dataGridView7.Columns[0].Visible = false;
                dataGridView7.AutoResizeColumns();
                dataGridView7.Columns[4].HeaderText = "start of period";
                dataGridView7.Columns[5].HeaderText = "end of period";

                string reqstr8= "SELECT * FROM " + "acs13.internetservice where id>1";
                command8 = new MySqlCommand(reqstr8, con);
                MySqlDataReader dr8 = command8.ExecuteReader();
                if (dr8.HasRows)
                {
                    dt8.Load(dr8);
                }
                bs8.DataSource = dt8;
                dataGridView8.DataSource = bs8;
                bindingNavigator8.BindingSource = bs8;
                dataGridView8.Columns[0].Visible = false;
                dataGridView8.AutoResizeColumns();
                dataGridView8.Columns[4].HeaderText = "start of period";
                dataGridView8.Columns[5].HeaderText = "end of period";

                string reqstr9 = "SELECT * FROM " + "acs13.tvtariff where id>1";
                command9 = new MySqlCommand(reqstr9, con);
                MySqlDataReader dr9 = command9.ExecuteReader();
                if (dr9.HasRows)
                {
                    dt9.Load(dr9);
                }
                bs9.DataSource = dt9;
                dataGridView9.DataSource = bs9;
                bindingNavigator9.BindingSource = bs9;
                dataGridView9.Columns[0].Visible = false;
                dataGridView9.AutoResizeColumns();
                dataGridView9.Columns[4].HeaderText = "start of period";
                dataGridView9.Columns[5].HeaderText = "end of period";

                string reqstr10 = "SELECT * FROM " + "acs13.package where id>1";
                command10 = new MySqlCommand(reqstr10, con);
                MySqlDataReader dr10 = command10.ExecuteReader();
                if (dr10.HasRows)
                {
                    dt10.Load(dr10);
                }
                bs10.DataSource = dt10;
                dataGridView10.DataSource = bs10;
                bindingNavigator10.BindingSource = bs10;
                dataGridView10.Columns[0].Visible = false;
                dataGridView10.Columns[4].Visible = false;
                dataGridView10.Columns[2].Visible = false;
                dataGridView10.Columns[3].Visible = false;
                dataGridView10.AutoResizeColumns();
                dataGridView10.Columns[6].HeaderText = "start of period";
                dataGridView10.Columns[7].HeaderText = "end of period";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //adapter.Update(dset);
            MessageBox.Show("База данных обновлена");
        }

         
        private void bindingNavigatorAddNewItem_Click_1(object sender, EventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
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
                string reqstr1 = "delete FROM " + "acs13.dep where id=" + dataGridView2.CurrentRow.Cells[0].Value.ToString();
                command1 = new MySqlCommand(reqstr1, con);
                MySqlDataReader dr = command1.ExecuteReader();
                dataGridView2.Rows.RemoveAt(dataGridView2.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form4 fr4 = new Form4(s1, s2, dataGridView1.CurrentRow.Cells[0].Value.ToString());
            fr4.Show();
            this.Hide();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(s1,s2);
            fr2.Show();
            this.Hide();
        }

        private void bindingNavigatorDeleteItem_Click_1(object sender, EventArgs e)
        {
            
           
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
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                con.Open();
                            
                    string reqstr2 = "delete FROM acs13.emp where id=" + dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    command1 = new MySqlCommand(reqstr2, con);
                    MySqlDataReader dr = command1.ExecuteReader();
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            MySqlCommand command1 = new MySqlCommand();
            try
            {
                con.Open();
                string reqstr2 = "delete FROM acs13.client where id=" + dataGridView4.CurrentRow.Cells[0].Value.ToString();
                command1 = new MySqlCommand(reqstr2, con);
                MySqlDataReader dr = command1.ExecuteReader();
                dataGridView4.Rows.RemoveAt(dataGridView4.CurrentRow.Index);               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
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
                string reqstr2 = "delete FROM acs13.compact where id=" + dataGridView5.CurrentRow.Cells[0].Value.ToString();
                command1 = new MySqlCommand(reqstr2, con);
                MySqlDataReader dr = command1.ExecuteReader();
                dataGridView5.Rows.RemoveAt(dataGridView5.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand("edtclient", new MySqlConnection(mysqlCSB.ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("surname1", dataGridView4.CurrentRow.Cells[1].Value.ToString()));
            cmd.Parameters.Add(new MySqlParameter("name1", dataGridView4.CurrentRow.Cells[2].Value.ToString()));
            cmd.Parameters.Add(new MySqlParameter("mname1", dataGridView4.CurrentRow.Cells[3].Value.ToString()));
            cmd.Parameters.Add(new MySqlParameter("adress1", dataGridView4.CurrentRow.Cells[4].Value.ToString()));
            cmd.Parameters.Add(new MySqlParameter("keypassword1", dataGridView4.CurrentRow.Cells[5].Value.ToString()));
            cmd.Parameters.Add(new MySqlParameter("id1", dataGridView4.CurrentRow.Cells[0].Value.ToString()));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //adapter.Update(dset);
            MessageBox.Show("База данных обновлена");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand command4 = new MySqlCommand();
            DataTable dt4 = new DataTable();
            con.Open();
            using (con)
            {
                string reqstr4 = "SELECT * FROM " + "acs13.accesspoint where id_compact=" + dataGridView5.CurrentRow.Cells[0].Value.ToString(); ;
                command4 = new MySqlCommand(reqstr4, con);
                MySqlDataReader dr4 = command4.ExecuteReader();
                if (dr4.HasRows)
                {
                    dt4.Load(dr4);
                }
                bs4.DataSource = dt4;
                dataGridView6.DataSource = bs4;
                bindingNavigator6.BindingSource = bs4;
                dataGridView6.Columns[0].Visible = false;
                dataGridView6.AutoResizeColumns();
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage6"];
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand command4 = new MySqlCommand();
            DataTable dt4 = new DataTable();
            con.Open();
            using (con)
            {
                string reqstr4 = "SELECT * FROM " + "acs13.compact where id_client=" + dataGridView4.CurrentRow.Cells[0].Value.ToString(); 
                command4 = new MySqlCommand(reqstr4, con);
                MySqlDataReader dr4 = command4.ExecuteReader();
                if (dr4.HasRows)
                {
                    dt4.Load(dr4);
                }
                bs4.DataSource = dt4;
                dataGridView5.DataSource = bs4;
                bindingNavigator5.BindingSource = bs4;
                dataGridView5.Columns[0].Visible = false;
                dataGridView5.AutoResizeColumns();
                tabControl1.SelectedTab = tabControl1.TabPages["tabPage5"];
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand command5 = new MySqlCommand();
            DataTable dt5 = new DataTable();
            con.Open();
            using (con)
            {
                string reqstr5 = "SELECT * FROM " + "acs13.compact";
                command5 = new MySqlCommand(reqstr5, con);
                MySqlDataReader dr5 = command5.ExecuteReader();
                if (dr5.HasRows)
                {
                    dt5.Load(dr5);
                }
                bs5.DataSource = dt5;
                dataGridView5.DataSource = bs5;
                bindingNavigator5.BindingSource = bs5;
                dataGridView5.Columns[0].Visible = false;
                dataGridView5.AutoResizeColumns();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form5 fr5 = new Form5(s1, s2, dataGridView5.CurrentRow.Cells[0].Value.ToString());
            fr5.Show();
            this.Hide();
        }

        private void bindingNavigatorAddNewItem2_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(s1, s2);
            fr2.Show();
            this.Hide();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            
                Form7 fr7 = new Form7(s1, s2, dataGridView4.CurrentRow.Cells[0].Value.ToString());
                fr7.Show();
                this.Hide();
           
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Form6 fr6 = new Form6(s1, s2, dataGridView5.CurrentRow.Cells[0].Value.ToString());
            fr6.Show();
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
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
                string reqstr2 = "delete FROM acs13.accesspoints where id=" + dataGridView6.CurrentRow.Cells[0].Value.ToString();
                command1 = new MySqlCommand(reqstr2, con);
                MySqlDataReader dr = command1.ExecuteReader();
                dataGridView6.Rows.RemoveAt(dataGridView6.CurrentRow.Index);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MySqlConnectionStringBuilder mysqlCSB;
            mysqlCSB = new MySqlConnectionStringBuilder();
            mysqlCSB.Server = "127.0.0.1";
            mysqlCSB.UserID = "root";
            mysqlCSB.Password = "123";
            mysqlCSB.Database = "acs13";
            MySqlConnection con = new MySqlConnection();
            con.ConnectionString = mysqlCSB.ConnectionString;
            MySqlCommand cmd = new MySqlCommand("edtaccesspoint", new MySqlConnection(mysqlCSB.ConnectionString));
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new MySqlParameter("info1", dataGridView6.CurrentRow.Cells[2].Value.ToString()));
            cmd.Parameters.Add(new MySqlParameter("mac1", dataGridView6.CurrentRow.Cells[3].Value.ToString()));            
            cmd.Parameters.Add(new MySqlParameter("id1", dataGridView6.CurrentRow.Cells[0].Value.ToString()));
            cmd.Connection.Open();
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            //adapter.Update(dset);
            MessageBox.Show("База данных обновлена");
        }

        private void bindingNavigatorAddNewItem5_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(s1, s2);
            fr2.Show();
            this.Hide();
        }

        private void bindingNavigatorAddNewItem6_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(s1, s2);
            fr2.Show();
            this.Hide();
        }

        private void bindingNavigatorAddNewItem7_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(s1, s2);
            fr2.Show();
            this.Hide();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            
            foreach (DataRow row in dtable1.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in dtable1.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            str1=jsSerializer.Serialize(parentRow);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            DataTable dt11 = (DataTable)JsonConvert.DeserializeObject(str1, (typeof(DataTable)));
            bs11.DataSource = dt11;
            dataGridView11.DataSource = bs11;            
            dataGridView11.Columns[0].Visible = false;
            dataGridView11.AutoResizeColumns();
        }

        private void bindingNavigatorAddNewItem1_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2(s1,s2);
            fr2.Show();
            this.Hide();
        }
    }
}
