using System.Runtime.CompilerServices;
using static System.Formats.Asn1.AsnWriter;

namespace Fiyah
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        
        Graphics g;
        Bitmap bmp;
        Random random;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            posCursor = new Point(0, 0);
            canvas = new Canvas(pictureBox1.Width, pictureBox1.Height);
            partics = new List<Particle>();
            bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            limits = new Rectangle(new Point(0, 0), new Size(pictureBox1.Width, pictureBox1.Height));
            pictureBox1.Image = bmp;
            g = Graphics.FromImage(bmp);
            counter = 0;

        }

        int counter, sel;
        Brush brush;
        List<Particle> partics;
        Particle b;
        Point posCursor;
        Rectangle limits;
        public bool fire = false;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            posCursor = e.Location;
        }

        public void Render()
        {
            g.Clear(Color.Black);

            if (fire)
            {
                for (int i = 0; i < partics.Count; i++)
                {
                    if (partics[i].z < 1)
                        g.DrawImage(Resource1.flame_RED, partics[i].center.X, partics[i].center.Y, partics[i].radius, partics[i].radius);
                    else if (partics[i].z < 2)
                        g.DrawImage(Resource1.flame2_RED, partics[i].center.X, partics[i].center.Y, partics[i].radius, partics[i].radius);
                    else if (partics[i].z < 3)
                        g.DrawImage(Resource1.flame_RED, partics[i].center.X, partics[i].center.Y, partics[i].radius, partics[i].radius);
                    else if (partics[i].z < 4)
                        g.DrawImage(Resource1.flame2_RED, partics[i].center.X, partics[i].center.Y, partics[i].radius, partics[i].radius);
                    else
                        g.DrawImage(Resource1.flame_RED, partics[i].center.X, partics[i].center.Y, partics[i].radius, partics[i].radius);
                }
            }
            pictureBox1.Invalidate();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            canvas.FastClear();
            if (fire)
            {
                for (int i = 0; i < partics.Count; i++)
                    partics[i].UpdateGen(limits, partics, random, sel, posCursor);
            }
            Render();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sel = 2;
            partics.Clear();
            fire = true;
            for (int i = 0; i < 250; i++)
            {
                b = new Particle(sel, random, limits, posCursor);
                partics.Add(b);
            }
        }
    }
}