using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace BilliardsUwU
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        List<VPoint> Bballs;
        VSolver solver;
        Point mouse, trigger;
        bool isMouseDown,isRightButton;
        int ballId;
        bool BlueWin = false;
        bool OrangeWin= false;

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
            solver              = new VSolver(Bballs);
            BlueWin = false;
            OrangeWin = false;

            Bballs.Add(new VPoint(550, 153, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(475, 190, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(550, 233, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(550, 273, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(440, 210, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(511, 211, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(511, 293, Bballs.Count, Color.DarkBlue));
            Bballs.Add(new VPoint(511, 252, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(511, 170, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(550, 313, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(475, 270, Bballs.Count, Color.OrangeRed));
            Bballs.Add(new VPoint(550, 193, Bballs.Count, Color.OrangeRed));
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
                    mouse = e.Location;
                    if (ballId >= 0 && ballId < Bballs.Count)
                    {
                        Bballs[15].Pos.X = e.Location.X;
                        Bballs[15].Pos.Y = e.Location.Y;

                        Bballs[15].Old = Bballs[15].Pos;
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
                Bballs[15].Old.X = e.Location.X;
                Bballs[15].Old.Y = e.Location.Y;             
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
                if (Bballs[i].Pos.X <= 50 && Bballs[i].Pos.Y >= 420)
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

            //condicion para que azules ganen
            if ((Bballs[0].C == Color.Transparent) && (Bballs[1].C == Color.Transparent) && (Bballs[2].C == Color.Transparent) && (Bballs[3].C == Color.Transparent) && (Bballs[4].C == Color.Transparent) && (Bballs[5].C == Color.Transparent) && (Bballs[6].C == Color.Transparent) && (Bballs[14].C == Color.Transparent))
            {
                BlueWin = true;
                Init();
                Form4 form4 = new Form4();
                form4.Show();
            }

            //condicion para que naranjas ganen
            if ((Bballs[7].C == Color.Transparent) && (Bballs[8].C == Color.Transparent) && (Bballs[9].C == Color.Transparent) && (Bballs[10].C == Color.Transparent) && (Bballs[11].C == Color.Transparent) && (Bballs[12].C == Color.Transparent) && (Bballs[13].C == Color.Transparent) && (Bballs[14].C == Color.Transparent))
            {
                OrangeWin = true;
                Init();
                Form5 form5 = new Form5();
                form5.Show();
            }
            if ((Bballs[14].C == Color.Transparent) && (BlueWin == false) && (OrangeWin == false))
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
                    canvas.g.DrawLine(Pens.White, Bballs[15].X, Bballs[15].Y, trigger.X, trigger.Y);
                }
            }
            PCT_CANVAS.Invalidate();
        }
    }
}
