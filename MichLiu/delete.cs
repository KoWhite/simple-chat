using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace MichLiu
{
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }
        DataView mydv = new DataView();
        DataSet myds = new DataSet();
        OleDbDataAdapter myadp = new OleDbDataAdapter();
        OleDbConnection myconn = new OleDbConnection();
        private void delete_Load(object sender, EventArgs e)
        {

            string connstr = @"Provider = Microsoft.Jet.OLEDB.4.0;
                            Data Source = school.mdb";
            myconn.ConnectionString = connstr;
            myconn.Open();

            string sqlstr = "SELECT * FROM communication";
            OleDbCommand mycmd = new OleDbCommand();
            mycmd.CommandText = sqlstr;
            mycmd.Connection = myconn;
            myadp.SelectCommand = mycmd;
            DataSet myds1 = new DataSet();
            DataSet myds2 = new DataSet();
            DataSet myds3 = new DataSet();
            myadp.Fill(myds, "communication");
            mydv = myds.Tables["communication"].DefaultView;

            dataGridView1.DataSource = mydv;
            dataGridView1.GridColor = Color.RoyalBlue;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.CellBorderStyle =
                DataGridViewCellBorderStyle.Single;
            dataGridView1.Columns[9].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[0].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode =
                DataGridViewAutoSizeColumnMode.AllCells;
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("您确认要删除该条信息吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {

                    OleDbCommand mycmd = new OleDbCommand();
                    string sqrt = "delete from communication where 姓名='" + this.dataGridView1.CurrentRow.Cells[0].Value.ToString() + "'";
                    mycmd.CommandText = sqrt;
                    mycmd.Connection = myconn;
                    mycmd.ExecuteNonQuery();
                    DataRowView drv = dataGridView1.SelectedRows[0].DataBoundItem as DataRowView;
                    drv.Delete();
                    MessageBox.Show("删除信息成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("未查找到数据记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }

        private void delete_FormClosing(object sender, FormClosingEventArgs e)
        {
            myconn.Close();
        }
    }
}