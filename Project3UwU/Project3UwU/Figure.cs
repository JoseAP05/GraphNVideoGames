using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3UwU
{
    public class Figure
    {
        public PointF centroid;
        public List<PointF> pts;
        public Figure(List<PointF> pts)
        {
            centroid = new PointF();
            for (int p = 0; p < pts.Count; p++)
            {
                centroid.X += pts[p].X;
                centroid.Y += pts[p].Y;
            }
            centroid.X /= pts.Count;
            centroid.Y /= pts.Count;
        }

    }
}
