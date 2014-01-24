using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GUI_Part_Voronoi
{
    public class Line 
    {
        public Point start, end;
        public Line(Point _start, Point _end)
        {
            start = _start;
            end = _end;
        }
    }
}
