using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man_Nightmare
{
    public class Point
    {
        public List<Line> hb;
        public PointF location;


        public Point(PointF location)
        {
            this.location = location;
            this.hb = new List<Line>();
        }
    }
}
