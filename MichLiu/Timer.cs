using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MichLiu
{
    public partial class Timer : Form
    {
        public Timer()
        {
            InitializeComponent();
        }
        System.DateTime TimeP = new System.DateTime(0);
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            timer1.Interval = 1000;
            DateTime dt = DateTime.Now;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeP = TimeP.AddSeconds(+1);
            label1.Text = TimeP.ToString("HH");
            label2.Text = TimeP.ToString("mm");
            label3.Text = TimeP.ToString("ss");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            TimeP = new System.DateTime(0);
            label1.Text = TimeP.ToString("HH");
            label2.Text = TimeP.ToString("mm");
            label3.Text = TimeP.ToString("ss");
            button2.BackgroundImage = Properties.Resources.T3;
            button3.BackgroundImage = Properties.Resources.T6;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.T3;
            button3.BackgroundImage = Properties.Resources.T5;
            timer1.Stop();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.BackgroundImage = Properties.Resources.T4;
            button3.BackgroundImage = Properties.Resources.T6;
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            timer2.Interval = 100;
            timer2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        Point downPoint; 
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            downPoint = new Point(e.X, e.Y);  
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
           if (e.Button == MouseButtons.Left)  
            {  
               this.Location = new Point(this.Location.X + e.X - downPoint.X,  
               this.Location.Y + e.Y - downPoint.Y);  
            }  

        }
    }
}
