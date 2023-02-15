using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pac_Man_Nightmare
{
    internal class Figure
    {
        public List<Line> Lines;

        public Figure()
        {
            Lines = new List<Line>();
        }

        public Figure(List<Line> lines)
        {
            this.Lines = lines;
        }
    }
}
