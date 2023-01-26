using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Project3UwU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            bmp = new Bitmap(PBUwU.Width, PBUwU.Height);
            g = Graphics.FromImage(bmp);
            PBUwU.Image = bmp;
        }

        Canvas canvas;


        Bitmap bmp;
        Graphics g;
        private Point a, b, c, d;
        private float angle;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            angle = float.Parse(textBox1.Text) / 57.2958f;
        }


        private PointF Rotate(PointF a)
        {
            PointF b = new PointF();

            b.X = (float)((a.X * Math.Cos(angle)) - (a.Y * Math.Sin(angle)));
            b.Y = (float)((a.X * Math.Sin(angle)) + (a.Y * Math.Cos(angle)));
            return b;
        }

        private PointF TranslateToCenter(PointF a)
        {
            int Sx = (bmp.Width / 2); // origen central en x
            int Sy = (bmp.Height / 2); // origen central en y
            return new PointF(Sx + a.X, Sy - a.Y);
        }

        private PointF Translate(PointF a, PointF b)
        {
            return new PointF(a.X + b.X, a.Y + b.Y);
        }

        private void RenderLine(PointF a, PointF b)
        {
            a = Translate(a, new PointF(-50, -50)); // centroide
            b = Translate(b, new PointF(-50, -50)); // centroide
            PointF c = Rotate(a);
            PointF d = Rotate(b);//*/
            c = TranslateToCenter(c);
            d = TranslateToCenter(d);
            c = Translate(c, new PointF(50, -50));
            d = Translate(d, new PointF(50, -50));
            g.DrawLine(Pens.Gray, c, d);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RenderLine(a, b);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Rotate(a);
            Rotate(b);
            Rotate(c);
            Rotate(d);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TranslateToCenter(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Translate(a, b);
        }

        private void Render()
        {
            g.Clear(Color.Transparent);
            g.DrawLine(Pens.Yellow, bmp.Width / 2, 0, bmp.Width / 2, bmp.Height);
            g.DrawLine(Pens.Yellow, 0, bmp.Height / 2, bmp.Width, bmp.Height / 2);
            a = new Point(0, 0);
            b = new Point(0, 100);
            c = new Point(100, 100);
            d = new Point(100, 0);
            RenderLine(a, b);
            RenderLine(b, c);
            RenderLine(c, d);
            RenderLine(d, a);
            PBUwU.Invalidate();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Render();
        }
    }
}
