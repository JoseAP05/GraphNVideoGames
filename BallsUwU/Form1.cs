using System;
using System.Runtime.CompilerServices;

namespace BallsUwU
{
    public partial class Form1 : Form
    {
        Ball b;
        Graphics g;
        Bitmap bmp;
        List<Ball> ball_list;

        public Form1()
        {
            InitializeComponent();
            ball_list = new List<Ball>();


            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            cent = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2);
            limits = new Rectangle(new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height));
            g = Graphics.FromImage(bmp);
            pictureBox1.Image = bmp;


            for (int x = 0; x <= 25; x++)
            {
                generate();
            }


        }

        private void generate()
        {
            var random = new Random();
            b = new Ball(random);
            ball_list.Add(b);
        }

        Rectangle limits;
        int radius = 15;
        int speedX = 5;
        int speedY = 5;
        Point cent, speed;

        public void Render()
        {
            g.Clear(Color.Black);
            for (int i = 0; i < ball_list.Count; i++)
            {
                g.FillEllipse(Brushes.White, ball_list[i].cent.X, ball_list[i].cent.Y, ball_list[i].radio, ball_list[i].radio);
            }

            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < ball_list.Count; i++)
                ball_list[i].PositionTick(limits, ball_list);
            Render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            generate();
        }
    }
}