using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace LYB
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        List<VPoint> Bballs;
        VRope rope;
        List<VBox> boxes;
        VSolver solver;
        Point mouse, trigger;
        bool isMouseDown,isRightButton;
        int ballId;

        public Form1()
        {
            InitializeComponent();
        }

        private void Init()
        {
            Random rand = new Random();
            canvas              = new Canvas(PCT_CANVAS.Size);
            PCT_CANVAS.Image    = canvas.bmp;
            Bballs              = new List<VPoint>();
            boxes               = new List<VBox>();
            solver              = new VSolver(Bballs);

            Bballs.Add(new VPoint(550, 153, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(550, 193, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(550, 233, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(550, 273, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(550, 313, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(511, 293, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(511, 252, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(511, 211, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(511, 170, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(475, 190, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(475, 270, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(440, 210, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(440, 250, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(405, 228, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(475, 230, Bballs.Count, Color.Black));
            Bballs.Add(new VPoint(145, 228, Bballs.Count, Color.White));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Init();
        }

        private void BTN_EXE_Click(object sender, EventArgs e)
        {
            Init();
        }

        private void PCT_CANVAS_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void PCT_CANVAS_MouseDown(object sender, MouseEventArgs e)
        {
                isMouseDown = true;

                isRightButton = (e.Button == MouseButtons.Right);
                if (isRightButton)
                    trigger = e.Location;

                mouse = e.Location;
            
        }

        private void PCT_CANVAS_MouseMove(object sender, MouseEventArgs e)
        {         
            if (isMouseDown)
            {
                if (e.Button == MouseButtons.Left)//MOVE BALL TO POINTER
                {
                    LBL_STATUS.Text = "Ahh !!" + e.Location.ToString();
                    mouse = e.Location;
                    if (ballId >= 0 && ballId < Bballs.Count)
                    {
                        Bballs[ballId].Pos.X = e.Location.X;
                        Bballs[ballId].Pos.Y = e.Location.Y;

                        Bballs[ballId].Old = Bballs[ballId].Pos;
                    }
                }
                else
                    trigger = e.Location;
            }
        }

        private void CHK_GENERATE_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void PCT_CANVAS_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
            if (e.Button == MouseButtons.Right && ballId != -1)
            {
                Bballs[ballId].Old.X = e.Location.X;
                Bballs[ballId].Old.Y = e.Location.Y;
                LBL_STATUS.Text = "FIRE !!!";               
            }

            ballId = -1;
        }
        private void TIMER_Tick(object sender, EventArgs e)
        {
            canvas.LessFast();
            for(int i = 0; i < Bballs.Count; i++)
            {
                if (Bballs[i].Pos.X <= 60 && Bballs[i].Pos.Y <= 60)
                {
                    Bballs[i].C = Color.Transparent;
                    Bballs[i].Pos.X = -30;
                    Bballs[i].Pos.Y = -30;
                }
                if (Bballs[i].Pos.X >= 700 && Bballs[i].Pos.Y <= 60)
                {
                    Bballs[i].C = Color.Transparent;
                    Bballs[i].Pos.X = 850;
                    Bballs[i].Pos.Y = -60;
                }
                if (Bballs[i].Pos.X >= 715 && Bballs[i].Pos.Y >= 425)
                {
                    Bballs[i].C = Color.Transparent;
                    Bballs[i].Pos.X = 850;
                    Bballs[i].Pos.Y = 500;
                }
                if (Bballs[i].Pos.X <= 45 && Bballs[i].Pos.Y >= 420)
                {
                    Bballs[i].C = Color.Transparent;
                    Bballs[i].Pos.X = -30;
                    Bballs[i].Pos.Y = -500;
                }
            }

            if(Bballs[15].Pos.X < 0 || Bballs[15].Pos.X > 800)
            {
                Bballs[15].Init(145, 228, 0, 0, Color.White);
                Form2 form2 = new Form2();
                form2.Show();
            }

            if (Bballs[14].Pos.X < 0 || Bballs[14].Pos.X > 800)
            {
                Init();
                Form3 form3 = new Form3();
                form3.Show();
            }


            ballId = solver.Update(canvas.g, canvas.Width, canvas.Height, mouse, isMouseDown);

            if (isMouseDown && isRightButton && ballId != -1)
            {
                if (ballId >= 0 && ballId < Bballs.Count)
                {
                    canvas.g.DrawLine(Pens.White, Bballs[ballId].X, Bballs[ballId].Y, trigger.X, trigger.Y);
                }
            }
                
            
            PCT_CANVAS.Invalidate();
        }
    }
}
