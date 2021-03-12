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
            public double CRS = 0; //control rods' status
            public double CWS = 0; //circulating waters' speed
            public double PL = 0;  //power load
            public double FPS = 0; //fissions per second
            public double FRD = 0; //fuel rods' depletion
            public double RT = 0;  //reactor temperature
            public double CWT = 0; //circulating waters' temperature
            public double TO = 0;  //temperature output
            public double PO = 0;  //power output
        }
        class fuel
        {
            public double startingFPS = 0;  //the FPS at 99% CRS
            public double FPSincrease = 0;  //the FPS increase per 1 CRS decrease
            public double meltdownTemp = 0; //the temperature meltdown value (after this the fuel rods melt, hence the reactor stops)
            public double maxFPS = 0;       //max FPS that the fuel can emit
            public double depletion = 0;    //depletion factor
        }
        class coolant
        {
            public double startingFPS = 0;  //the FPS at 99% CRS
            public double FPSincrease = 0;  //the FPS increase per 1 CRS decrease so 2 means 1 CRS decrease increases the FPS by a factor of 2
            public double Tempincrease = 0; //the temperature increase per FPS increase so 2 means 1 FPS increase increases the temperature by a factor of 2
            public double meltdownFPS = 0;  //the FPS meltdown value (after this the reactor cannot be cooled enough to stop, hence the game over)
            public double meltdownTemp = 0; //the temperature meltdown value (after this the fuel rods melt, hence the reactor stops)
            public double volume = 0;       //how much coolant do You have
            public double boilingTemp = 0;  //boiling point
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 211;
            progressBar2.Value = 211;
            numericUpDown1.Enabled = false;
            numericUpDown2.Enabled = false;
            numericUpDown3.Enabled = false;
            button2.Enabled = false;
            label49.Visible = false;
            label51.Visible = false;
            label52.Visible = false;
            label54.Visible = false;
            label55.Visible = false;
            label60.Visible = false;
            label56.Visible = false;
            label57.Visible = false;
            label59.Visible = false;
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //preparation
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            checkBox1.Enabled = false;
            checkBox2.Enabled = false;
            button1.Enabled = false;
            checkBox3.Enabled = false;
            checkBox4.Enabled = false;
            radioButton4.Enabled = false;
            radioButton5.Enabled = false;

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

            if (checkBox3.Checked)
            {
                label54.Visible = true;
                label55.Visible = true;
                label60.Visible = true;
            }

            if (checkBox4.Checked)
            {
                label56.Visible = true;
                label57.Visible = true;
                label59.Visible = true;
            }

            coolant f1 = new coolant();
            if (radioButton1.Checked)
            {
                f1.startingFPS = 3;
                f1.FPSincrease = 1.5;
                f1.Tempincrease = 2;
                f1.meltdownFPS = 1085;
                f1.meltdownTemp = 2178;
                f1.maxFPS = 100000;
                f1.depletion = 2;
            }
            else if (radioButton2.Checked)
            {
                f1.startingFPS = 3;
                f1.FPSincrease = 1.5;
                f1.Tempincrease = 2;
                f1.meltdownFPS = 1085;
                f1.meltdownTemp = 2178;
                f1.maxFPS = 100000;
                f1.depletion = 2;
            }
            else if (radioButton3.Checked)
            {
                f1.startingFPS = 3;
                f1.FPSincrease = 1.5;
                f1.Tempincrease = 2;
                f1.meltdownFPS = 1085;
                f1.meltdownTemp = 2178;
                f1.maxFPS = 100000;
                f1.depletion = 2;
            }
            //ACTION
            reactor r1 = new reactor();
            while (!gameover(r1,f1))
            {
                //set data
                label39.Text = Convert.ToString(r1.CRS);
                progressBar2.Value = Convert.ToInt32(label39.Text);
                label42.Text = Convert.ToString(r1.CWS);
                progressBar4.Value = Convert.ToInt32(Math.Round(r1.CWS, 0));
                label45.Text = Convert.ToString(r1.PL);
                label52.Text = Convert.ToString(Math.Round(r1.FPS, 0));
                label40.Text = Convert.ToString(Math.Round(r1.FRD, 3));
                progressBar3.Value = Convert.ToInt32(Math.Round(r1.FRD, 0));
                label38.Text = Convert.ToString(Math.Round(r1.RT, 3));
                progressBar1.Value = Convert.ToInt32(Math.Round(r1.RT, 0));
                label41.Text = Convert.ToString(Math.Round(r1.CWT, 3));
                label43.Text = Convert.ToString(Math.Round(r1.TO, 3));
                label44.Text = Convert.ToString(r1.PO);

                //get data from prev cycle
                r1.CRS = Convert.ToDouble(label39.Text);
                r1.CWS = Convert.ToDouble(label42.Text);
                r1.PL = Convert.ToDouble(label45.Text);
                r1.FPS = Convert.ToDouble(label52.Text);
                r1.FRD = Convert.ToDouble(label40.Text);
                r1.RT = Convert.ToDouble(label38.Text);
                r1.CWT = Convert.ToDouble(label41.Text);
                r1.TO = Convert.ToDouble(label43.Text);
                r1.PO = Convert.ToDouble(label44.Text);

                //action happens here
                r1 = cycle(r1, f1);

                //timer
                double time = Convert.ToDouble(label55.Text);
                time += 0.1;
                label55.Text = Convert.ToString(time);

                //other cool features
                progressBar1.Maximum = Convert.ToInt32(f1.meltdownTemp);

                if (r1.RT > (f1.meltdownTemp / 10)*9)
                {
                    label38.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    label38.ForeColor = System.Drawing.Color.Black;
                }

                if (true)
                {

                }

                if (r1.CWS > 0)
                {
                    Image img = pictureBox1.Image;
                    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    pictureBox1.Image = img;
                }

                //await tenth of a sec
                await Task.Delay(100);
            }
            //game over
            MessageBox.Show("Game over");
        }

        private reactor cycle(reactor r1, fuel f1)
        {
            r1.CRS = Convert.ToDouble(numericUpDown1.Value); //control rods' status

            r1.CWS = Convert.ToDouble(numericUpDown2.Value); //water speed

            r1.FPS = ((211-r1.CRS)*4*1.5)/((r1.FRD + 0.1)/10); //fission per sec
            
            r1.RT = r1.RT + (r1.FPS / 3.2);

            if (r1.FPS == 0 && 2 == 0)
            {
                r1.FRD = 0; //fuel depletion but only if 0/0
            }
            else
            {
                r1.FRD = r1.FRD + (r1.FPS / 2)/1000; //fuel depletion
            }

            double exchangedTemp = 0;
            if (!(r1.RT <= 0 && r1.CWT <= 0))
            {
                exchangedTemp = r1.RT * (0.9 * ((r1.CWS + 1) / 1868)); //exchanged temperature between reactor and coolant
            }

            r1.CWT = r1.CWT + exchangedTemp; //water temperature

            r1.RT = r1.RT - exchangedTemp; //reactor temperature again after exchange

            exchangedTemp = 0;
            if (!(r1.TO <= 0 && r1.CWT <= 0))
            {
                exchangedTemp = r1.CWT * (0.9 * ((r1.CWS + 1) / 1914)); //exchanged temperature again between coolant and output
            }

            r1.TO = r1.TO + exchangedTemp; //output temperature

            r1.CWT = r1.CWT - exchangedTemp; //water temperature after exchange

            if (r1.TO > 100)
            {
                r1.TO = r1.TO - (r1.TO - 100);
            }

            return r1;
        }

        private bool gameover(reactor r1, fuel f1, coolant c1)
        {
            bool gameover = false;
            //fuel rod depletion
            if (r1.FRD >= 100)
            {
                gameover = true;
            }
            //max FPS reached
            if (r1.FPS == f1.maxFPS)
            {
                gameover = true;
            }
            //max temperature (core meltdown) reached
            if (r1.RT >= f1.meltdownTemp)
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
            progressBar9.Minimum = 0;
            progressBar9.Maximum = 211;
            progressBar9.Value = Convert.ToInt32(numericUpDown1.Value);
            label46.Text = Convert.ToString(numericUpDown1.Value);
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            progressBar10.Value = Convert.ToInt32(numericUpDown2.Value);
            label47.Text = Convert.ToString(numericUpDown2.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            progressBar11.Value = Convert.ToInt32(numericUpDown3.Value);
            label48.Text = Convert.ToString(numericUpDown3.Value);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value = 211;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                label1.Text = "Set starting parameters";
                label24.Text = "Type of coolant";

                radioButton1.Text = "Heavy water";
                radioButton2.Text = "TRIGA (low temp)";
                radioButton3.Text = "QUADRISO (unsafe at high depl)";

                label53.Text = "Show timer";
                label25.Text = "Automatic power load";
                label26.Text = "regulation";
                label50.Text = "Show fissions per second";
                label58.Text = "Show power generated";

                label51.Text = "Fission per second:";
                label54.Text = "Timer:";
                label56.Text = "Power generated:";

                button1.Text = "Start Simulation";

                label2.Text = "Reactor core";

                label3.Text = "Reactor core temperature";
                label4.Text = "Control rods' insertion status";
                label33.Text = "rods in";
                label5.Text = "Fuel rods' depletion percent";
                label18.Text = "Change control rods' insertion status";
                label19.Text = "Desired value:";
                label35.Text = "rods in";

                label7.Text = "Cooling system";

                label8.Text = "Circulating coolants' temperature";
                label6.Text = "Circulating coolant' speed";
                label21.Text = "Change circulating coolants' speed";
                label20.Text = "Desired value:";

                label13.Text = "Output";

                label10.Text = "Temperature output";
                label9.Text = "Power output";
                label17.Text = "Power load";
                label23.Text = "Change power load";
                label49.Text = "Automatic power load regulation enabled";
                label22.Text = "Desired value:";
            }
            else
            {
                label1.Text = "Kezdő beállítások";
                label24.Text = "Hűtővíz típusa";

                radioButton1.Text = "RBMK (unsafe at low temp)";
                radioButton2.Text = "TRIGA (low temp)";
                radioButton3.Text = "QUADRISO (unsafe at high depl)";

                label53.Text = "Eltelt idő mutatása";
                label25.Text = "Automatikus áram-";
                label26.Text = "terhelés változtatása";
                label50.Text = "Fúziók/s mutatása";
                label58.Text = "Áramtermelés mutatása";

                label51.Text = "Fúziók/s:";
                label54.Text = "Idő:";
                label56.Text = "Áramtermelés:";

                button1.Text = "Szimuláció indítása";

                label2.Text = "Reaktormag";

                label3.Text = "Reaktormag hőmérséklete";
                label4.Text = "Szabályzórudak helyzete";
                label33.Text = "rúd van bent";
                label5.Text = "Fűtőrudak elhasználtsága";
                label18.Text = "Szabályzórudak helyzetének változtatása";
                label19.Text = "Kért érték:";
                label35.Text = "rúd van bent";

                label7.Text = "Hűtőrendszer";

                label8.Text = "Keringetett hűtővíz hőmérséklete";
                label6.Text = "Keringetett hűtővíz sebessége";
                label21.Text = "Keringetett hűtővíz sebességének változtatása";
                label20.Text = "Kért érték:";

                label13.Text = "Kimenet";

                label10.Text = "Hőkimenet";
                label9.Text = "Áramkimenet";
                label17.Text = "Áramterhelés";
                label23.Text = "Áramterhelés változtatása";
                label49.Text = "Automatikus áramterhelés-változtatás bekapcsolva";
                label22.Text = "Kért érték:";
            }
        }
    }
}
