using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man_Nightmare
{
    public class Points
    {
        public List<Point> points;

        public Points()
        {
            this.points = new List<Point>();
        }

        public Points(List<Point> points)
        {
            this.points = points;
        }
    }
}
