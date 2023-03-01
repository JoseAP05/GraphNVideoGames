using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiyah
{
    public class Particle
    {
        public int radius, z;
        public Brush b;
        public Point center;
        public Point speed;

        public Particle(int sel,Random rand, Rectangle bounds, Point mouse)
        {
            if (sel == 2)
                Fire(rand, bounds, mouse);
        }

        public void UpdateGen(Rectangle bounds, List<Particle> balls, Random rand, int sel, Point mouse)
        {
            this.center.Offset(this.speed);
            if (this.center.X + this.radius < bounds.Left || this.center.X - this.radius > bounds.Right)
            {
                if (sel == 2)
                    Fire(rand, bounds, mouse);
            }
            if (this.center.Y + this.radius < bounds.Top || this.center.Y - this.radius >= bounds.Bottom)
            {
                if (sel == 2)
                    Fire(rand, bounds, mouse);
            }
            foreach (var other in balls)
            {
                if (other.z == this.z)
                {
                    if (other != this && IsThereCollition(this, other))
                    {
                        OffSetting(this, other);
                    }
                }
            }
        }

        public void Fire(Random rand, Rectangle bounds, Point mouse)
        {
            this.radius = rand.Next(15, 40);
            this.center.X = rand.Next(mouse.X-5, mouse.X+6);
            this.center.Y = rand.Next(mouse.Y-5 , mouse.Y+6);
            this.speed.X = rand.Next(-3, 3);
            this.speed.Y = rand.Next(-5, -3);
            this.z = rand.Next(0, 4);
            b = new SolidBrush(Color.FromArgb(255, 255, 255, 255));

        }

        private static void OffSetting(Particle a, Particle b)
        {
            int dx = b.center.X - a.center.X;
            int dy = b.center.Y - a.center.Y;
            int dist = a.radius / 2 + b.radius / 2;
            int overlap = dist - (int)Math.Sqrt(dx * dx + dy * dy);
            a.center.Offset(-overlap * dx / dist, -overlap * dy / dist);
            b.center.Offset(overlap * dx / dist, overlap * dy / dist);
        }

        public void Positioning(Rectangle bounds, List<Particle> balls)
        {
            this.center.Offset(this.speed);
            if (this.center.X  <= bounds.Left || this.center.X + this.radius >= bounds.Right)
            {
                this.speed.X = -this.speed.X;
            }
            if (this.center.Y  <= bounds.Top || this.center.Y + this.radius >= bounds.Bottom)
            {
                this.speed.Y = -this.speed.Y;
            }
            foreach (var other in balls)
            {
                if (other != this && IsThereCollition(this, other))
                {
                    Collide(this, other);
                }
            }
        }

        private static bool IsThereCollition(Particle a, Particle b)
        {
            int dx = a.center.X - b.center.X;
            int dy = a.center.Y - b.center.Y;
            int dist = a.radius/2 + b.radius/2;
            return (dx * dx + dy * dy) < (dist * dist);
        }

        private static void Collide(Particle a, Particle b)
        {
            int dx = b.center.X - a.center.X;
            int dy = b.center.Y - a.center.Y;
            int dist = a.radius/2 + b.radius/2;
            int overlap = dist - (int)Math.Sqrt(dx * dx + dy * dy);

            a.center.Offset(-overlap * dx / dist, -overlap * dy / dist);
            b.center.Offset(overlap * dx / dist, overlap * dy / dist);

            int totalMass = a.radius/2 + b.radius/2;
            int aSpeed = (a.speed.X * dx + a.speed.Y * dy) / totalMass;
            int bSpeed = (b.speed.X * dx + b.speed.Y * dy) / totalMass;
            a.speed.Offset((bSpeed - aSpeed) * dx / dist, (bSpeed - aSpeed) * dy / dist);
            b.speed.Offset((aSpeed - bSpeed) * dx / dist, (aSpeed - bSpeed) * dy / dist);
        }
    }
}
