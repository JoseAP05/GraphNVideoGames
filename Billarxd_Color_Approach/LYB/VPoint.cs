using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace LYB
{
    public class VPoint
    {
        bool isPinned = false;
        bool fromBody = false;       
        Vec2 pos, old, vel, gravity;
        int id;
        public float Mass;
        float radius, bounce, diameter, m, frict = 0.97f;
        float groundFriction = 0.7f;
        Color c;
        SolidBrush brush;

        public bool FromBody
        {
            get { return fromBody; }
            set { fromBody = value; }
        }
        public Color C
        {
            get { return c; }
            set { c = value; }
        }
        public float Diameter
        {
            get { return diameter; }
            set { diameter = value; }
        }
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public bool IsPinned
        {
            get { return isPinned; }
            set { isPinned = value; }
        }
        public float X
        {
            get { return pos.X; }
            set { pos.X = value; }
        }
        public float Y
        {
            get { return pos.Y; }
            set { pos.Y = value; }
        }
        public Vec2 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
        public Vec2 Old
        {
            get { return old; }
            set { old = value; }
        }
        public float Radius
        {
            get { return radius; }
            set { radius = value; diameter = radius + radius; }
        }

        public VPoint(int x, int y, Color color)
        {
            this.id = -1;
            Init(x, y, 0, 0, color);
        }
        public VPoint(int x, int y, int id, bool Pinned, Color color)
        {
            this.id = id;
            isPinned = Pinned;
            Init(x, y, 0, 0, color);
        }
        public VPoint(int x, int y, int id, Color color)
        {
            this.id = id;
            Init(x, y, 0, 0, color);
        }
        public VPoint(int x, int y, float vx, float vy, int id, bool Pinned, Color color)
        {
            this.id = id;
            isPinned = Pinned;
            Init(x, y, vx, vy, color);
        }

        public VPoint(int x, int y, float vx, float vy, int id, Color color)
        {
            this.id = id;
            Init(x, y, vx, vy, color);
        }

        public void Init(int x, int y, float vx, float vy, Color color)
        {
            pos = new Vec2(x, y);
            old = new Vec2(x, y);
            gravity = new Vec2(0, 0);
            vel = new Vec2(vx, vy);
            radius = 19;
            diameter = radius + radius;
            Mass = 5f;
            bounce = 1f;
            c = color;
            brush = new SolidBrush(c);
            if (IsPinned)
            {
                Pin();
            }
        }

        public void Pin()
        {
            brush = new SolidBrush(Color.Gray);
            radius = 10;
            diameter = radius + radius;
            isPinned = true;
        }

        public void Update(int width, int height)
        {
            
            if (isPinned)
                return;//*/

            vel = (pos - old) *  frict;
            /*
            if (pos.Y >= height - radius && vel.MagSqr() > 0.000001)//en el piso
            {
                m   = vel.Length();
                vel /= m;
                vel *= (m * groundFriction);
            }//*/
            
            old = pos;
            pos += vel + gravity;
        }

        public void Constraints(int width, int height)
        {
            if (pos.X > width - radius)     { pos.X = width - radius;   old.X = (pos.X + vel.X); }
            if (pos.X < radius)             { pos.X = radius;           old.X = (pos.X + vel.X) ; }
            if (pos.Y > height - radius)    { pos.Y = height - radius;  old.Y = (pos.Y + vel.Y) ; }
            if (pos.Y < radius)             { pos.Y = radius;           old.Y = (pos.Y + vel.Y) ; }
        }

        public void Render(Graphics g, int width, int height)
        {
            if (fromBody)
                return;

            Update(width, height);
            Constraints(width, height);

            g.FillEllipse(brush, pos.X - radius, pos.Y - radius, diameter, diameter);
        }


        public override string ToString()
        {
            return "ID: "+id+" : "+pos.ToString();
        }

    }
}