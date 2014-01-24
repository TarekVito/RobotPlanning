using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GUI_Part_Voronoi
{
    class dijkstraPoint : IComparable<dijkstraPoint>,IEquatable<dijkstraPoint>
    {
        public Point point;

        public dijkstraPoint(Point _point)
        {
            point = _point;
        }
      
        public override int GetHashCode()
        {
            return point.X * point.Y + point.Y;
        }
	
        public int CompareTo(dijkstraPoint other)
        {
            if (DijkstraUtil.dist[point] < DijkstraUtil.dist[other.point])
                return -1;
            if (DijkstraUtil.dist[point] > DijkstraUtil.dist[other.point])
                return 1;
            else
                return 0;
        }

        public bool Equals(dijkstraPoint other)
        {
            if (other == null)
                return false;
            if (point == null)
                return false;
            else
                return Equals(other); 
        }
    }
}
