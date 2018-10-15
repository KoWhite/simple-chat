using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Data.OleDb;

namespace MichLiu
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();
            flowLayoutPanel1.Dock = DockStyle.Fill;
            
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            Timer f2 = new Timer();
            f2.Show(); 
        }

        private void button5_Click(object sender, EventArgs e)
        {
            InitializeComponent();
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(pictureBox1.ClientRectangle);
            Region region = new Region(gp);
            pictureBox1.Region = region;
            gp.Dispose();
            region.Dispose();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public string[] FontSizeName =
             {
                 "8","9","10","12","14","16","18","20","22","24","26","28","36","48","72"
             };
        //定义字号数组
        public float[] FontSize =
             {
                 8,9,10,12,14,16,18,20,22,24,26,28,36,48,72
             };
        private string fontName;
        private int fontSize;

        private void Form2_Load(object sender, EventArgs e)
        {
            foreach (FontFamily font in FontFamily.Families)
                this.fontCB.Items.Add(font.Name);//设置fontCB下拉菜单内容
            this.fontCB.SelectedItem = "宋体";//设置fontCB显示内容
            foreach (string name in FontSizeName)
                this.sizeCB.Items.Add(name);//设置sizeCB下拉菜单内容
            this.sizeCB.SelectedItem = "10";//设置sizeCb显示内容
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
            recipient.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.Close();
        }
        Point downPoint; 
        private void button5_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y); 
        }

        private void button5_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - downPoint.X,
                this.Location.Y + e.Y - downPoint.Y);
            }  
        }

        private void cd_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
           openFileDialog1.Filter = "bmp文件（*.bmp）|*.bmp|jpg 文件（*.jpg）|*.jpg|ico 文件（*.ico）|*.ico";
            openFileDialog1.Title = "打开图片";
            openFileDialog1.FilterIndex = 2;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(openFileDialog1.FileName);//获得图片
                Clipboard.SetDataObject(bmp, false);//将图片放在剪贴板中

                if (rtb.CanPaste(DataFormats.GetFormat(DataFormats.Bitmap)))
                    rtb.Paste();//粘贴数据
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox1.Text +=DateTime.Now.ToString("HH:mm:ss") + "\n" + rtb.Text+"\n";
            rtb.Text = "";
        }

        private void fontCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.rtb.SelectionFont = new Font(this.fontCB.Text, this.rtb.SelectionFont.Size, this.rtb.SelectionFont.Style);
            }
            catch (Exception ex)//捕获并显示异常内容
            {
                MessageBox.Show("出现异常：" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sizeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.rtb.SelectionFont = new Font(this.rtb.SelectionFont.FontFamily, FontSize[this.sizeCB.SelectedIndex], this.rtb.SelectionFont.Style);
            }
            catch (Exception ex)
            {
                MessageBox.Show("出现异常：" + ex, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void sender_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            tianjia f3 = new tianjia();
            f3.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection myconn = new OleDbConnection();
            string connstr = @"Provider = Microsoft.Jet.OLEDB.4.0;
                            Data Source = school.mdb";
            myconn.ConnectionString = connstr;
            myconn.Open();

            OleDbCommand mycmd = new OleDbCommand();
            string sqlstr = "SELECT * FROM communication";
            mycmd.CommandText = sqlstr;
            mycmd.Connection = myconn;
            OleDbDataReader myreader = mycmd.ExecuteReader();
            friendlistbox.Items.Add("姓名\t性别\t年龄");
            friendlistbox.Items.Add("=====================================");
            while (myreader.Read())
            {
                friendlistbox.Items.Add(String.Format("{0}\t{1}\t{2}",
                    myreader[0].ToString(), myreader[1].ToString(),
                    myreader[2].ToString()));
            }
            myconn.Close();
            myreader.Close();
        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.TextLength;
            richTextBox1.ScrollToCaret();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            delete f4 = new delete();
            f4.Show();
        }
    }
}
