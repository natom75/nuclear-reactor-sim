using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace nuclear_reactor_sim
{
    public partial class Form1 : Form
    {
        class reactor
        {
            public int CRS = 0; //control rods' status
            public int CWS = 0; //circulating waters' speed
            public int PL = 0;  //power load
            public int FPS = 0; //fissions per second
            public int FRD = 0; //fuel rods' depletion
            public int RT = 0;  //reactor temperature
            public int CWT = 0; //circulating waters' temperature
            public int TO = 0;  //temperature output
            public int PO = 0;  //power output
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 100;
            progressBar2.Value = 100;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            button2.Enabled = false;
            label49.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //preparation
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            button1.Enabled = false;

            numericUpDown1.Enabled = true;
            numericUpDown2.Enabled = true;
            button2.Enabled = true;

            if (checkBox1.Checked)
            {
                label49.Visible = true;
                numericUpDown3.Value = 100;
            }
            else
            {
                numericUpDown3.Enabled = true;
            }

            if (checkBox2.Checked)
            {
                label51.Visible = true;
                label52.Visible = true;
            }
            //ACTION
            reactor r1 = new reactor();
            while (!gameover(r1))
            {
                r1.CRS = Convert.ToInt32(label39.Text);
                r1.CWS = Convert.ToInt32(label42.Text);
                r1.PL = Convert.ToInt32(label45.Text);
                r1.FPS = Convert.ToInt32(label52.Text);
                r1.FRD = Convert.ToInt32(label40.Text);
                r1.RT = Convert.ToInt32(label38.Text);
                r1.CWT = Convert.ToInt32(label41.Text);
                r1.TO = Convert.ToInt32(label43.Text);
                r1.PO = Convert.ToInt32(label44.Text);

                r1 = cycle(r1); //action happens here

                label39.Text = Convert.ToString(r1.CRS);
                label42.Text = Convert.ToString(r1.CWS);
                label45.Text = Convert.ToString(r1.PL);
                label52.Text = Convert.ToString(r1.FPS);
                label40.Text = Convert.ToString(r1.FRD);
                label38.Text = Convert.ToString(r1.RT);
                label41.Text = Convert.ToString(r1.CWT);
                label43.Text = Convert.ToString(r1.TO);
                label44.Text = Convert.ToString(r1.PO);

                WaitASecond();
            }
        }

        private reactor cycle(reactor r1)
        {
            reactor r2 = r1;
            return r2;
        }

        private bool gameover(reactor r1)
        {
            bool gameover = false;
            //fuel rod depletion
            if (r1.FRD == 0)
            {
                gameover = true;
            }

            //just booted up
            if (r1.CRS == 0 && r1.CWS == 0 && r1.PL == 0 && r1.FPS == 0 && r1.FRD == 0 && r1.RT == 0 && r1.CWT == 0 && r1.TO == 0 && r1.PO == 0)
            {
                gameover = false;
            }

            return gameover;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            progressBar9.Value = Convert.ToInt32(numericUpDown1.Value);
            label46.Text = Convert.ToString(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            progressBar10.Value = Convert.ToInt32(numericUpDown2.Value) / 1000;
            label47.Text = Convert.ToString(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            progressBar11.Value = Convert.ToInt32(numericUpDown3.Value) / 100;
            label48.Text = Convert.ToString(numericUpDown3.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 100;
        }
        public async void WaitASecond()
        {
            await Task.Delay(1000);
            this.Enabled = true;
            this.Cursor = Cursors.Default;
        }
    }
}
