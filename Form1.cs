using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace robot
{
    public partial class Form1 : Form
    {
        public class portaccess
        {
            [DllImport("inpout32.dll", EntryPoint = "Out32")]
            public static extern void Output(int adress, int value);
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.SetRange(1,5);
            trackBar1.Value = 3;
            trackBar2.Value = 2;
            trackBar3.Value = 2;
            timer1.Interval = 1;
            timer1.Enabled = true;
            radioButton4.Checked = true;
        }

        private void direction()
        {
            if (radioButton4.Checked)
                switch (trackBar1.Value)
                {
//***********************************************************
                    case 1:
                        if (!(radioButton1.Checked) && !(radioButton2.Checked))
                        {
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\stop.png", true);
                            label1.Text = "Choose Forward or Backward";
                            label2.Text = "The motors are set to off now";
                            motor(0,0);                                                       
                            break;
                        }                                                
                        radioButton1.Checked = true;
                        label1.Text = "The robot is turning left(fast!)";
                        label2.Text = " ";
                        pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\l.f.png", true);
                        motor(-1,1);
                        break;
//***********************************************************
                    case 2:
                        if (!(radioButton1.Checked) && !(radioButton2.Checked))
                        {
                            label1.Text = "Choose Forward or Backward";
                            label2.Text = "The motors are set to off now";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\stop.png", true);
                            motor(0,0);
                            break;
                        }
                        label1.Text = "The robot is turning left";
                        if (radioButton1.Checked)
                        {
                            label2.Text = "And going forwrad";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\f.l.png", true);
                            motor(0,1);
                        }
                        if (radioButton2.Checked)
                        {
                            label2.Text = "And going backward";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\b.l.png", true);
                            motor(-1, 0);
                        }
                        break;
//***********************************************************
                    case 3:
                        if (!(radioButton1.Checked) && !(radioButton2.Checked))
                        {
                            label1.Text = "Choose Forward or Backward";
                            label2.Text = "The motors are set to off now";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\stop.png", true);
                            motor(0, 0);
                            break;
                        }
                        label1.Text = "Straight";
                        if (radioButton1.Checked)
                        {
                            label2.Text = "And going forwrad";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\s.f.png", true);
                            motor(1,1);
                        }
                        if (radioButton2.Checked)
                        {
                            label2.Text = "And going backward";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\s.b.png", true);
                            motor(-1,-1);
                        }
                        break;
//***********************************************************
                    case 4:
                        if (!(radioButton1.Checked) && !(radioButton2.Checked))
                        {
                            label1.Text = "Choose Forward or Backward";
                            label2.Text = "The motors are set to off now";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\stop.png", true);
                            motor(0, 0);
                            break;
                        }
                        label1.Text = "The robot is turning right";
                        if (radioButton1.Checked)
                        {
                            label2.Text = "And going forwrad";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\f.r.png", true);
                            motor(1,0);
                        }
                        if (radioButton2.Checked)
                        {
                            label2.Text = "And going backward";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\b.r.png", true);
                            motor(0,-1);
                        }
                        break;
//************************************************************
                    case 5:
                        if (!(radioButton1.Checked) && !(radioButton2.Checked))
                        {
                            label1.Text = "Choose Forward or Backward";
                            label2.Text = "The motors are set to off now";
                            pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\stop.png", true);
                            motor(0, 0);
                            break;
                        }
                        label2.Text = "";
                        radioButton1.Checked = true;
                        label1.Text = "The robot is turning right(fast!)";
                        pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\r.f.png", true);
                        motor(1,-1);
                        break;
//************************************************************
                }
            else
            {
                label1.Text = "You are controling the robot's motors manually.";
                label2.Text = " ";
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {    
             direction();
             motocon();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = System.Drawing.Bitmap.FromFile("D:\\programming\\Robotic\\my new robot\\img\\CU\\stop.png", true);
            trackBar1.Value = 3;
            trackBar2.Value = 2;
            trackBar3.Value = 2;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }
        private void motocon()
        {
            if (radioButton3.Checked)
            {
                if ((trackBar2.Value == 2) && (trackBar3.Value == 2))
                {
                    label11.Text = "Choose how the motors move";
                    label12.Text = "The motors are set to off now";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\stop.png", true);
                    motor(0,0);
                }
                if ((trackBar2.Value == 3) && (trackBar3.Value == 3))
                {
                    label11.Text = "Straight";
                    label12.Text = "And going forwrad";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\s.f.png", true);
                    motor(1,1);
                }
                if ((trackBar2.Value == 1) && (trackBar3.Value == 1))
                {
                    label11.Text = "Straight";
                    label12.Text = "And going backward";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\s.b.png", true);
                    motor(-1,-1);
                }
                if((trackBar2.Value==1)&&(trackBar3.Value==3))
                {
                    label11.Text = "The robot is turning left(fast!)";
                    label12.Text = " ";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\l.f.png", true);
                    motor(-1,1);
                }
                if ((trackBar2.Value == 3) && (trackBar3.Value == 1))
                {
                    label12.Text = "";                    
                    label11.Text = "The robot is turning right(fast!)";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\r.f.png", true);
                    motor(1,-1);
                }
                if((trackBar2.Value==3)&&(trackBar3.Value==2))
                {
                    label11.Text = "The robot is turning right";
                    label12.Text = "And going forwrad";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\f.r.png", true);
                    motor(1,0);
                }
                if ((trackBar2.Value == 1) && (trackBar3.Value == 2))
                {
                    label11.Text = "The robot is turning right";
                    label12.Text = "And going backward";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\b.r.png", true);
                    motor(0,-1);
                }
                if ((trackBar2.Value == 2) && (trackBar3.Value == 3))
                {
                    label11.Text = "The robot is turning left";
                    label12.Text = "And going forwrad";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\f.l.png", true);
                    motor(0,1);
                }
                if ((trackBar2.Value == 2) && (trackBar3.Value == 1))
                {
                    label11.Text = "The robot is turning left";
                    label12.Text = "And going backward";
                    pictureBox1.Image = System.Drawing.Bitmap.FromFile("img\\CU\\b.l.png", true);
                    motor(-1,0);
                }
            }
            else
            {
                label11.Text = "You're controling the direction via this software";
                label12.Text = "";
            }
        }
        private void motor(int lm, int rm)
        {
            /*
             *parallel port pin2 --> rf transmitor +5VCC ==> portv += 0;
             *parallel port pin3 --> rf transmitor right motor forward ==> portv -= 2;
             *parallel port pin4 --> rf transmitor right motor backward ==> portv -= 4;
             *parallel port pin5 --> rf transmitor left motor forward ==> portv -= 8;
             *parallel port pin6 --> rf transmitor left motor backward ==> portv -= 16;
            */
            int portv = 255;
            switch(lm)
            {
                case 0:
                    break;
                case 1:
                    portv -= 8;
                    break;
                case -1:
                    portv -= 16;
                    break;
            }
            switch (rm)
            {
                case 0:
                    break;
                case 1:
                    portv -= 2;
                    break;
                case -1:
                    portv -= 4;
                    break;
            }
            portaccess.Output(888,portv);
            portvl.Text=System.Convert.ToString(portv);
            portaccess.Output(888, portv);
            const int max = 32;
            int[] a = new int[max];
            int i = 0;
            while (portv > 0)
            {
                a[i] = portv % 2;
                portv /= 2;    
                i++;
            }
            bportvl.ResetText();
            for (int j = i - 1; j >= 0; j--)
                bportvl.Text = bportvl.Text + a[j].ToString();            
        }
    }
}