using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace budilnik
{
    public partial class Form1 : Form
    {
        Timer timer01 = new Timer();
        bool b = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            timer01.Interval = 1000;
            timer01.Tick += new EventHandler(timer1_Tick);
            timer01.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
            
        }
      

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (b == false)
            {
                label2.Text = maskedTextBox1.Text;
                timer2.Start();
                maskedTextBox1.Visible = false;
                button1.Text = "Убрать будильник";
                b=true;
            }
            else if(b==true)
            {
                label2.Text = "00:00";
                timer2.Stop();
                maskedTextBox1.Visible = true;
                button1.Text = "Завести будильник";
                b = false;
            }           
            
        }
       
      private void timer2_Tick(object sender, EventArgs e)
        {
            if (label1.Text == label2.Text + ":00")
            {
                button2.Enabled = true;
            }
       
        }

      private void button2_Click(object sender, EventArgs e)
      {
          button2.Enabled = false;
          maskedTextBox1.Visible = true;
          button1.Text = "Завести будильник";
          b = false;
      }
   

    }
}
