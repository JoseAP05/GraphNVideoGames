using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouOpenedTheBox
{
    public  class Figures
    {
        public Figures(Vertex[] points, int[,] sides)
        {
            Points = points;
            Sides = sides;
        }

        public Vertex[] Points { get; set; }

        public int[,] Sides { get; set; }
    }
}
