using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsUwU
{
    public class Ball
    {
        public int radio;
        public Point cent;
        public Point vel;

        public Ball(Random rand)
        {
            this.radio = rand.Next(15,30);
            this.cent.X = rand.Next(35,540);
            this.cent.Y = rand.Next(35, 320);
            this.vel.X = rand.Next(-5, 15);
            this.vel.Y = rand.Next(-5, 15);

        }



        private static bool IsThereCollision(Ball a, Ball b)
        {
            int dx = a.cent.X - b.cent.X;
            int dy = a.cent.Y - b.cent.Y;
            int dist = a.radio / 2 + b.radio / 2;
            return (dx * dx + dy * dy) < (dist * dist);
        }





        public void PositionTick(Rectangle bounds, List<Ball> balls)
        {
            this.cent.Offset(this.vel);

         
            if (this.cent.X  <= bounds.Left || this.cent.X + this.radio >= bounds.Right)
            {
                this.vel.X = -this.vel.X;
            }
            if (this.cent.Y  <= bounds.Top || this.cent.Y + this.radio >= bounds.Bottom)
            {
                this.vel.Y = -this.vel.Y;
            }

           

            foreach (var other in balls)
            {
                if (other != this && IsThereCollision(this, other))
                {
                    Collide(this, other);
                }
            }
        }

        

        private static void Collide(Ball a, Ball b)
        {
            int dx = b.cent.X - a.cent.X;
            int dy = b.cent.Y - a.cent.Y;
            int dist = a.radio/2 + b.radio/2;
            int overlap = dist - (int)Math.Sqrt(dx * dx + dy * dy);

           

            a.cent.Offset(-overlap * dx / dist, -overlap * dy / dist);
            b.cent.Offset(overlap * dx / dist, overlap * dy / dist);


            int totalMass = a.radio/2 + b.radio/2;
            int aSpeed = (a.vel.X * dx + a.vel.Y * dy) / totalMass;
            int bSpeed = (b.vel.X * dx + b.vel.Y * dy) / totalMass;
            a.vel.Offset((bSpeed - aSpeed) * dx / dist, (bSpeed - aSpeed) * dy / dist);
            b.vel.Offset((aSpeed - bSpeed) * dx / dist, (aSpeed - bSpeed) * dy / dist);
        }
    }
}
