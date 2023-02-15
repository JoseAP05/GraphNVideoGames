using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pac_Man_Nightmare
{
    public partial class Form1 : Form
    {
        static Graphics g;
        static int forward;
        int step, score;
        Scene scene;
        Enemies enemies;
        Points points;
        Point active;
        Player p;
        Enemy en;
        bool hold, right, left, down, gameover;
        bool up = false;
        float distance;
        PointF valid, valid2, valid3, trigger, l, l2, l3;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Right)
            {
                right = true;
                left = false;
                up = false;
                down = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);


            }
            else if (e.KeyData == Keys.Left)
            {
                left = true;
                right = false;
                up = false;
                down = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);

            }
            else if (e.KeyData == Keys.Up)
            {
                up = true;
                right = false;
                left = false;
                down = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);

            }
            else if (e.KeyData == Keys.Down)
            {
                down = true;
                right = false;
                left = false;
                up = false;
                hold = false;
                l = new PointF(0, 0);
                l2 = new PointF(0, 0);
                l3 = new PointF(0, 0);
                trigger = new PointF(0, 0);

            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Map_PB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        public Form1()

        {
            InitializeComponent();
            DrawMap(1);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (left == true && hold == false)
            {
                up = false;
                down = false;
                left = true;
                right = false;
                p.LeftRight();
                p.Turn(4);
                if (trigger.X - 10 <= p.middle.X - 5 && p.middle.X - 5 <= trigger.X && trigger.Y < p.middle.Y + 10 && trigger.Y > p.middle.Y - 10)
                {
                    score += 5;
                    label1.Text = score.ToString();
                    points.points.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();

                }
                if ((p.middle.X - 7.5f <= l.X + 1 && l.X != 0 && l.Y != 0) || (p.middle2.X - 7.5f <= l2.X + 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.X - 7.5f <= l3.X + 1 && l3.X != 0 && l3.Y != 0))
                {
                    left = false;
                    gameover = true;
                }
                if ((p.middle.X - 7.5f <= valid.X + 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.X - 7.5f <= valid2.X + 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.X - 7.5f <= valid3.X + 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    left = false;

                }
                else
                {
                    p.Turn(4);
                    forward += step;
                    UpdatePosition();
                }

            }
            else if (right == true && hold == false)
            {
                up = false;
                down = false;
                left = false;
                right = true;

                if (trigger.X + 10 > p.middle.X + 5 && p.middle.X + 5 >= trigger.X && trigger.X != -100 && trigger.Y < p.middle.Y + 10 && trigger.Y > p.middle.Y - 10)
                {
                    score += 5;
                    label1.Text = score.ToString();
                    points.points.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                p.LeftRight();
                p.Turn(2);
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                }
                if ((p.middle.X + 7.5f >= l.X - 1 && l.X != 0 && l.Y != 0) || (p.middle2.X + 7.5f >= l2.X - 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.X + 7.5f >= l3.X - 1 && l3.X != 0 && l3.Y != 0))
                {
                    right = false;
                    gameover = true;
                }
                if ((p.middle.X + 7.5f >= valid.X - 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.X + 7.5f >= valid2.X - 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.X + 7.5f >= valid3.X - 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    right = false;
                }
                else
                {
                    p.Turn(2);
                    forward += step;
                    UpdatePosition();
                }

            }
            else if (up == true && hold == false)
            {
                up = true;
                down = false;
                left = false;
                right = false;
                p.UpDown();
                p.Turn(1);
                if (trigger.Y - 10 < p.middle.Y - 5 && p.middle.Y - 5 <= trigger.Y && trigger.X < p.middle.X + 10 && trigger.X > p.middle.X - 10)
                {
                    score += 5;
                    label1.Text = score.ToString();
                    points.points.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                }
                if ((p.middle.Y - 7.5f <= l.Y + 1 && l.X != 0 && l.Y != 0) || (p.middle2.Y - 7.5f <= l2.Y + 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.Y - 7.5f <= l3.Y + 1 && l3.X != 0 && l3.Y != 0))
                {
                    up = false;
                    gameover = true;
                }

                if ((p.middle.Y - 7.5f <= valid.Y + 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.Y - 7.5f <= valid2.Y + 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.Y - 7.5f <= valid3.Y + 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    up = false;
                }
                else
                {
                    p.Turn(1);
                    forward += step;
                    UpdatePosition();
                }
            }
            else if (down == true && hold == false)
            {

                up = false;
                down = true;
                left = false;
                right = false;
                p.UpDown();
                p.Turn(3);
                if (trigger.Y + 10 > p.middle.Y + 5 && p.middle.Y + 5 >= trigger.Y && trigger.X != -100 && trigger.X < p.middle.X + 10 && trigger.X > p.middle.X - 10)
                {
                    score += 5;
                    label1.Text = score.ToString();
                    points.points.Remove(active);
                    trigger = new PointF(-100, -100);
                }
                if (valid.X == 0 && valid.Y == 0 && valid2.X == 0 && valid2.Y == 0 && valid3.X == 0 && valid3.Y == 0)
                {
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();

                }
                if ((p.middle.Y + 7.5f == l.Y - 1 && l.X != 0 && l.Y != 0) || (p.middle2.Y + 7.5f == l2.Y - 1 && l2.X != 0 && l2.Y != 0) || (p.middle3.Y + 7.5f == l3.Y - 1 && l3.X != 0 && l3.Y != 0))
                {
                    down = false;
                    gameover = true;
                }

                if ((p.middle.Y + 7.5f >= valid.Y - 1 && valid.X != 0 && valid.Y != 0) || (p.middle2.Y + 7.5f >= valid2.Y - 1 && valid2.X != 0 && valid2.Y != 0) || (p.middle3.Y + 7.5f >= valid3.Y - 1 && valid3.X != 0 && valid3.Y != 0))
                {
                    down = false;
                }
                else
                {
                    p.Turn(3);
                    forward += step;
                    UpdatePosition();
                }
            }
            Player_PB.Top = (int)p.getPos().Y + 1;
            Player_PB.Left = (int)p.getPos().X;
            Render();
        }

        public void DrawMap(int nivel)
        {
            Bitmap bmp = new Bitmap(500, 500);
            g = Graphics.FromImage(bmp);
            Map_PB.Image = bmp;
            g.Clear(Color.Black);
            scene = new Scene();
            points = new Points();
            enemies = new Enemies();
            score = 0;
            step = 3;

            for (int x = 0; x < Load_Map.map0.GetLength(0); x++)
            {
                for (int y = 0; y < Load_Map.map0.GetLength(1); y++)
                {
                    if (Load_Map.map0[y, x] == 1)
                    {
                        Figure fig = new Figure();
                        fig.Lines.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                        fig.Lines.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                        scene.Figures.Add(fig);
                    }
                    else if (Load_Map.map0[y, x] == 2)
                    {
                        p = new Player(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                        p.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                        p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                        p.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                        p.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));


                    }
                    else if (Load_Map.map0[y, x] == 3)
                    {
                        Point point = new Point(new PointF(x * 15 + 7.5f, y * 15 + 7.5f));
                        point.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                        point.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                        point.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                        point.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                        points.points.Add(point);
                    }
                    else if (Load_Map.map0[y, x] == 4)
                    {
                        en = new Enemy(new PointF(x * 15, y * 15), new PointF(x * 15 + 7.5f, y * 15 - 15));
                        en.hb.Add(new Line(new PointF(x * 15, y * 15), new PointF(x * 15 + 15, y * 15)));
                        en.hb.Add(new Line(new PointF(x * 15 + 15, y * 15), new PointF(x * 15 + 15, y * 15 + 15)));
                        en.hb.Add(new Line(new PointF(x * 15 + 15, y * 15 + 15), new PointF(x * 15, y * 15 + 15)));
                        en.hb.Add(new Line(new PointF(x * 15, y * 15 + 15), new PointF(x * 15, y * 15)));
                        enemies.enemies.Add(en);

                    }
                }
            }
            Render();
        }

        public void Render()
        {
            g.Clear(Color.MediumSeaGreen);
            for (int f = 0; f < scene.Figures.Count; f++)
            {
                for (int l = 0; l < scene.Figures[f].Lines.Count; l++)
                {
                    g.DrawLine(Pens.Gray, scene.Figures[f].Lines[l].a, scene.Figures[f].Lines[l].b);
                }
            }
            for (int i = 0; i < points.points.Count; i++)
            {
                g.FillEllipse(Brushes.Yellow, points.points[i].location.X, points.points[i].location.Y, 5, 5);
            }

            Verify();
            Verifiy_Player();
            Verify_Enemy();
            DrawEnemy();
            if (gameover)
            {
                g.Clear(Color.Black);
                gameover = false;
                score = 0;
                DrawMap(1);
            }
            label1.Text = score.ToString();
            Map_PB.Invalidate();
        }

        public void DrawEnemy()
        {
            for (int i = 0; i < enemies.enemies.Count; i++)
            {
                g.FillRectangle(Brushes.Blue, enemies.enemies[i].pos.X, enemies.enemies[i].pos.Y, 15, 15);
            }
        }

        public void UpdatePosition()
        {
            float f = (float)forward / 50;
            if (p.pos.X > 605)
            {
                p.middle.X = -50f;
            }
            if (p.pos.X < -20)
            {
                p.middle.X = 650f;
            }
            if (p.pos.Y > 605)
            {
                p.middle.Y = -50f;
            }
            if (p.pos.Y < -20)
            {
                p.middle.Y = 650f;
            }
            p.middle = Util.Instance.NextStep(p.middle, p.lookAt, f);
            p.middle2 = Util.Instance.NextStep(p.middle2, p.lookAt2, f);
            p.middle3 = Util.Instance.NextStep(p.middle3, p.lookAt3, f);
            p.hb[0].a = p.pos;
            p.hb[0].b = new PointF(p.pos.X + 15, p.pos.Y);
            p.hb[1].a = p.hb[0].b;
            p.hb[1].b = new PointF(p.hb[1].a.X, p.hb[1].a.Y + 15);
            p.hb[2].a = p.hb[1].b;
            p.hb[2].b = new PointF(p.hb[2].a.X - 15, p.hb[2].a.Y);
            p.hb[3].a = p.hb[2].b;
            p.hb[3].b = new PointF(p.hb[3].a.X, p.hb[3].a.Y - 15);

            p.pos = new PointF(p.middle.X - 7.5f, p.middle.Y - 7.5f);

            Render();
            forward = 0;
        }

        public void Verify()
        {
            PointF collision, collision2, collision3;
            Figure figure;
            Line line, user, user2, user3;

            PointF tmp;
            float dTemp, dTemp2, dTemp3, d, d2, d3;

            dTemp = float.MaxValue;
            dTemp2 = float.MaxValue;
            dTemp3 = float.MaxValue;

            valid = new PointF();
            valid2 = new PointF();
            valid3 = new PointF();
            user = new Line(p.middle, p.lookAt);
            user2 = new Line(p.middle2, p.lookAt2);
            user3 = new Line(p.middle3, p.lookAt3);

            for (int i = 0; i < scene.Figures.Count; i++)
            {
                figure = scene.Figures[i];
                for (int j = 0; j < figure.Lines.Count; j++)
                {
                    line = figure.Lines[j];
                    if (Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);

                        if (d < dTemp)
                        {
                            dTemp = d;
                            valid = collision;

                        }
                    }
                    if (Util.Instance.Intersect(user2, line))
                    {
                        collision2 = Util.Instance.FindPoint(user2, line);
                        d2 = Util.Instance.Distance(collision2, p.middle2);

                        if (d2 < dTemp2)
                        {
                            dTemp2 = d2;
                            valid2 = collision2;

                        }
                    }
                    if (Util.Instance.Intersect(user3, line))
                    {
                        collision3 = Util.Instance.FindPoint(user3, line);
                        d3 = Util.Instance.Distance(collision3, p.middle3);

                        if (d3 < dTemp3)
                        {
                            dTemp3 = d3;
                            valid3 = collision3;

                        }
                    }
                }
            }
            distance = dTemp;
        }

        public void Verifiy_Player()
        {
            PointF collision;
            Point point;
            Line line, user;

            PointF tmp;
            float dTemp, d;

            dTemp = float.MaxValue;

            valid = new PointF();
            user = new Line(p.middle, p.lookAt);

            for (int i=0; i<points.points.Count; i++)
            {
                point = points.points[i];
                for (int j=0; j<point.hb.Count; j++)
                {
                    line = point.hb[j];
                    if(Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);
                        if (d < dTemp)
                        {
                            dTemp = d;
                            trigger = collision;
                            active = point;
                        }
                    }
                }
            }
            distance = dTemp;
        }

        public void Verify_Enemy()
        {
            PointF collision, collision2, collision3;
            Enemy enemy;
            Line line, user, user2, user3;

            PointF tmp;
            float dTemp, dTemp2, dTemp3, d, d2, d3;

            dTemp = float.MaxValue;
            dTemp2 = float.MaxValue;
            dTemp3 = float.MaxValue;

            l = new PointF();
            l2 = new PointF();
            l3 = new PointF();
            user = new Line(p.middle, p.lookAt);
            user2 = new Line(p.middle2, p.lookAt2);
            user3 = new Line(p.middle3, p.lookAt3);

            for (int i = 0; i <enemies.enemies.Count; i++)
            {
                enemy = enemies.enemies[i];
                for (int j = 0; j <enemy.hb.Count; j++)
                {
                    line = enemy.hb[j];
                    if (Util.Instance.Intersect(user, line))
                    {
                        collision = Util.Instance.FindPoint(user, line);
                        d = Util.Instance.Distance(collision, p.middle);

                        if (d < dTemp)
                        {
                            dTemp = d;
                            l = collision;

                        }
                    }
                    if (Util.Instance.Intersect(user2, line))
                    {
                        collision2 = Util.Instance.FindPoint(user2, line);
                        d2 = Util.Instance.Distance(collision2, p.middle2);

                        if (d2 < dTemp2)
                        {
                            dTemp2 = d2;
                            l2 = collision2;

                        }
                    }
                    if (Util.Instance.Intersect(user3, line))
                    {
                        collision3 = Util.Instance.FindPoint(user3, line);
                        d3 = Util.Instance.Distance(collision3, p.middle3);

                        if (d3 < dTemp3)
                        {
                            dTemp3 = d3;
                            l3 = collision3;

                        }
                    }
                }
            }
            distance = dTemp;
        }


    }
}
