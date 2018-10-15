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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
            label4.Text = "";
            
        }

        private void textBox2_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.Text = "";
            label5.Text = "";
        }

        private void textBox3_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
            label6.Text = "";
        }


        OleDbCommand mycmd = new OleDbCommand();
        OleDbConnection myconn = new OleDbConnection();
        OleDbCommand mysmd = new OleDbCommand();

        private void Form1_Load(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand checkcmd = myconn.CreateCommand();
           

            string s = "Select * from login where account ='" + textBox4.Text + "'and email='" + textBox5.Text + "'and password='" + textBox6.Text + "'";
            
            checkcmd.CommandText = s;
            OleDbDataAdapter check = new OleDbDataAdapter();
            check.SelectCommand = checkcmd;
            DataSet checkData = new DataSet();
            int n = check.Fill(checkData, "register");
            if (n != 0)
            {
                label3.Text = "用户名存在";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();

            }
          
                string sign = "insert into login ([account],[email],[password])values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "')";
                mysmd.CommandText = sign;
                mysmd.Connection = myconn;
                mysmd.ExecuteNonQuery();
                if (textBox4.Text == "" || textBox6.TextLength <= 6 || textBox5.Text == "" || textBox6.Text == "")
                {
                    label3.Text = "请将信息填写完整";

                }
                else
                {
                    label3.Text = "注册成功!";
                }
                mysmd = null;
        }
       
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            myconn.Close();
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            button1.Visible = true;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button2.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            string _x1 = textBox1.Text;
            string Email = textBox2.Text.Trim();
            string pw = textBox3.Text.Trim();
            string stary = "Select * from login where account ='" + textBox1.Text + "'and email='" + textBox2.Text + "'and password='" + textBox3.Text + "'";
            mycmd.CommandText = stary;
            mycmd.Connection = myconn;
            OleDbDataReader sdr;
            sdr = mycmd.ExecuteReader();
            if (sdr.Read())
            {
                label3.Text = "登录成功！";
                Form2 f2 = new Form2();
                this.Hide();
                f2.Show();
            }
            else
            {
                label3.Text = "登录失败，账号或者密码输错了！";
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox1.Focus();
                return;
            }
            mycmd = null;
           
        }

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
            textBox1.Visible = false;
            textBox2.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            label2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            button1.Visible = false;
            label7.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
            label10.Visible = true;
            label11.Visible = true;
            textBox4.Visible = true;
            textBox5.Visible = true;
            textBox6.Visible = true;
            button2.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            button1.Visible = true;
            label2.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            button1.Visible = true;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            textBox4.Visible = false;
            textBox5.Visible = false;
            textBox6.Visible = false;
            button2.Visible = false;

        }

        private void textBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox4.Text = "";
            label9.Text = "";
        }

        private void textBox5_MouseDown(object sender, MouseEventArgs e)
        {
            textBox5.Text = "";
            label10.Text = "";
        }

        private void textBox6_MouseDown(object sender, MouseEventArgs e)
        {
            textBox6.Text = "";
            label11.Text = "";
        }

      
    }
}
