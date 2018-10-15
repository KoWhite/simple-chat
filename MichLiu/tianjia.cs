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
    public partial class tianjia : Form
    {
        OleDbCommand mycmd = new OleDbCommand();
        OleDbConnection myconn = new OleDbConnection();
       
        public tianjia()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                this.Location.Y + e.Y - downPoint.Y);
            }  
        }
        Point downPoint; 
        private void button2_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y); 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f4 = new Form2();
            f4.Show();
            this.Hide();
            this.Close();
        }

        private void tianjia_Load(object sender, EventArgs e)
        {
            string connstr = @"Provider = Microsoft.Jet.OLEDB.4.0;
                            Data Source = school.mdb";
            myconn.ConnectionString = connstr;
            myconn.Open();
            if (myconn.State == ConnectionState.Open)
                Console.WriteLine("成功连接到Access数据库");
            else
                Console.WriteLine("连接失败");
        }

        private void tianjia_FormClosing(object sender, FormClosingEventArgs e)
        {
            myconn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""||textBox2.Text==""||textBox3.Text==""||textBox4.Text==""||textBox5.Text==""||textBox6.Text==""||textBox7.Text==""||textBox8.Text=="")
            {
                MessageBox.Show("请输入完整信息！");
            }
            if (checkBox1.Checked)
            {
                string sign = "insert into communication ([姓名],[性别],[年龄],[省1],[市1],[县1],[省2],[市2],[县2])values('" + textBox1.Text +"','"+"男"+ "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text+"','" + textBox7.Text + "','" + textBox8.Text + "')";
                mycmd.CommandText = sign;
                mycmd.Connection = myconn;
                mycmd.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
            }
            else if(checkBox2.Checked)
            {
                string sign = "insert into communication ([姓名],[性别],[年龄],[省1],[市1],[县1],[省2],[市2],[县2])values('" + textBox1.Text + "','"+"女" + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text +"','"+ textBox7.Text + "','" + textBox8.Text + "')";
                mycmd.CommandText = sign;
                mycmd.Connection = myconn;
                mycmd.ExecuteNonQuery();
                MessageBox.Show("添加成功！");
            }
            else
            {
                MessageBox.Show("添加失败，请重新输入。");
            }
        }
    }
}
