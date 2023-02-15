using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man_Nightmare
{
    public class Player
    {
        public List<Line> hb;
        public Line looks;
        public PointF pos, lookAt, lookAt2, lookAt3, middle, middle2, middle3;

        public Player(PointF pos, PointF looksAt)
        {
            this.pos = pos;
            this.lookAt = looksAt;
            hb = new List<Line>();
            middle = new PointF(pos.X + 7.5f, pos.Y + 7.5f);

            looks = new Line(middle, looksAt);

        }
        public PointF getPos()
        {
            return this.pos;
        }

        public void Turn(int i)
        {
            switch (i)
            {
                case 1:
                    {
                        lookAt.X = middle.X;
                        lookAt.Y = middle.Y - 22.5f;
                        lookAt2.X = middle2.X;
                        lookAt2.Y = middle2.Y - 22.5f;
                        lookAt3.X = middle3.X;
                        lookAt3.Y = middle3.Y - 22.5f;
                        break;
                    }

                case 2:
                    {

                        lookAt.X = middle.X + 22.5f;
                        lookAt.Y = middle.Y;
                        lookAt2.X = middle2.X + 22.5f;
                        lookAt2.Y = middle2.Y;
                        lookAt3.X = middle3.X + 22.5f;
                        lookAt3.Y = middle3.Y;
                        break;
                    }

                case 3:
                    {
                        lookAt.X = middle.X;
                        lookAt.Y = middle.Y + 22.5f;
                        lookAt2.X = middle2.X;
                        lookAt2.Y = middle2.Y + 22.5f;
                        lookAt3.X = middle3.X;
                        lookAt3.Y = middle3.Y + 22.5f;
                        break;
                    }
                case 4:
                    {
                        lookAt.X = middle.X - 22.5f;
                        lookAt.Y = middle.Y;
                        lookAt2.X = middle2.X - 22.5f;
                        lookAt2.Y = middle2.Y;
                        lookAt3.X = middle3.X - 22.5f;
                        lookAt3.Y = middle3.Y;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public void UpDown()
        {
            middle2 = new PointF(pos.X + 1, pos.Y + 7.5f);
            middle3 = new PointF(pos.X + 14, pos.Y + 7.5f);
        }
        public void LeftRight()
        {
            middle2 = new PointF(pos.X + 7.5f, pos.Y + 1);
            middle3 = new PointF(pos.X + 7.5f, pos.Y + 14);
        }
    }
}
