using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNet_HW_3
{
    public partial class Form1 : Form
    {
        string connection = @"Data Source = SQL5103.site4now.net; Initial Catalog = DB_A7168B_kuvaevsql; User Id = DB_A7168B_kuvaevsql_admin; Password=qwerty009";
        SqlConnection sqlConnection = null;
        SqlDataAdapter sqlDateAdapter = null;
        DataSet dataSet = null;
        SqlCommandBuilder sqlCommanBulder = null;
        public Form1()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(connection);
            btnModifiedValues.Click += BtnModifiedValues_Click; ;
            try
            {
                string query = "select * from Customers";
                dataGridView1.DataSource = null;
                dataSet = new DataSet();
                sqlDateAdapter = new SqlDataAdapter(query, sqlConnection);
                sqlCommanBulder = new SqlCommandBuilder(sqlDateAdapter);
                sqlDateAdapter.Fill(dataSet);
                dataGridView1.DataSource = dataSet.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (sqlConnection != null)
                    sqlConnection.Close();
            }
        }

        private void BtnModifiedValues_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = dataSet.Tables[0].GetChanges(DataRowState.Modified);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        
    }
}
