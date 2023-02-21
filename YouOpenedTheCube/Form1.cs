using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YouOpenedTheBox
{
    public partial class Form1 : Form
    {
        public Graphics g;
        Bitmap bmp;
        public Scene scene;
        public Form1()
        {
            InitializeComponent();
            Init();
            scene = new Scene(new Figures(points, sides));
            DrawFig();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void DrawFig()
        {
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;
            scene.Draw(g, pictureBox1.Width, pictureBox1.Height, RX, RY, RZ);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
            DrawFig();
            angle += 2;
        }





        private void RX_BUTT_Click(object sender, EventArgs e)
        {
            label2.Text = "RX Active";
            RX = true;
        }
        private void RY_BUTT_Click(object sender, EventArgs e)
        {
            label3.Text = "RY Active";
            RY = true;
        }
        private void RZ_BUTT_Click(object sender, EventArgs e)
        {
            label4.Text = "RZ Active";
            RZ = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "RZ Unactive";
            RZ = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = "RX Unactive";
            RX = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "RY Unactive";
            RY = false;
        }

        public Vertex[] points;
        public int[,] sides;
        public int angle;
        public bool RX, RY, RZ;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Init()
        {
            points = new Vertex[]
            {
                new Vertex(-1, 1, -1),
                new Vertex(1, 1, -1),
                new Vertex(1, -1, -1),
                new Vertex(-1, -1, -1),
                new Vertex(-1, 1, 1),
                new Vertex(1, 1, 1),
                new Vertex(1, -1, 1),
                new Vertex(-1, -1, 1)
            };

            sides = new int[,]
            {
                {
                    0, 1, 2, 3
                },
                {
                    1, 5, 6, 2
                },
                {
                    5, 4, 7, 6
                },
                {
                    4, 0, 3, 7
                },
                {
                    0, 4, 5, 1
                },
                {
                    3, 2, 6, 7
                }
            };
        }
    }
}
