using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;

namespace GUI_Part_Voronoi
{
    public class Utilities
    {
        public static Point toVector(Point A, Point B)
        {
            return new Point(B.X - A.X, B.Y - A.Y);
        }
        public static double angleTwoLines(Point A, Point B)
        {
            double angle = Math.Round((dotProduct(A, B)/(magn(A)*magn(B))),5);

            return Math.Acos(angle) * (180 / Math.PI);
        }
        public static bool isRight(Point A, Point B, Point C)
        {
            return ((B.X - A.X) * (C.Y - A.Y) - (B.Y - A.Y) * (C.X - A.X)) > 0;
        }
        public static double magn(Point A)
        { 
            return Math.Sqrt(A.X*A.X + A.Y*A.Y);
        }
        public static double dotProduct(Point A, Point B)
        {
            return A.X * B.X + A.Y * B.Y;
        }
        public static Point nearestPoint(Point A, List<Line> L)
        {
            Point res = L[0].start;
            double minDist = distance(L[0].start, A);
            for (int i = 0; i < L.Count; ++i)
            {
                if (distance(L[i].start, A) < minDist)
                {
                    res = L[i].start;
                    minDist = distance(L[i].start, A);
                }
                if (distance(L[i].end, A) < minDist)
                {
                    res = L[i].end;
                    minDist = distance(L[i].end, A);
                }
            }
            return res;
        }
        public static double dot(Point A, Point B, Point C)
        {
            Point AB = new Point(B.X - A.X, B.Y - A.Y);
            Point BC = new Point(C.X - B.X, C.Y - B.Y);
            double dot = AB.X * BC.X + AB.Y * BC.Y;
            return dot;
        }
        public static double cross(Point A, Point B, Point C)
        {
            Point AB = new Point(B.X - A.X, B.Y - A.Y);
            Point AC = new Point(C.X - A.X, C.Y - A.Y);
            double cross = AB.X * AC.Y - AB.Y * AC.X;
            return cross;
        }
        public static double distance(Point A, Point B)
        {
            int d1 = A.X - B.X;
            int d2 = A.Y - B.Y;
            return Math.Sqrt(d1 * d1 + d2 * d2);
        }
        public static double linePointDist(Line seg, Point C)
        {
            double dist = cross(seg.start, seg.end, C) / distance(seg.start, seg.end);
            double dot1 = dot(seg.start, seg.end, C);
            if (dot1 > 0) return distance(seg.end, C);
            double dot2 = dot(seg.end, seg.start, C);
            if (dot2 > 0) return distance(seg.start, C);
            return Math.Abs(dist);
        }
        public static Bitmap ResizeBitmap(Bitmap sourceBMP, int Start, int End, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawImage(sourceBMP, Start, End, width, height);
            }
            return result;
        }

    }
    public class DijkstraUtil : Utilities
    {
        public static void resetData()
        {
            adjList = new Dictionary<Point, List<Point>>();
            dist = new Dictionary<Point, int>();
            visited = new Dictionary<Point, bool>();
            prev = new Dictionary<Point, Point>();
        }
        public static Dictionary<Point, List<Point>> adjList;
        public static Dictionary<Point, int> dist;
        public static Dictionary<Point, bool> visited;
        public static Dictionary<Point, Point> prev;
    }
    public class FileUtil : Utilities
    {
        public static List<Point> readPoints(string fileName)
        {
            Dictionary<Point, bool> visited = new Dictionary<Point, bool>();
            List<Point> res = new List<Point>();
            FileStream file = new FileStream(fileName,
                FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(file);
            string[] st = sr.ReadLine().Split(' ');
            for (int i = 0, j = 0; j < st.Length / 2; j++)
            {
                int x = (int)double.Parse(st[i++]);
                int y = (int)double.Parse(st[i++]);
                if(!visited.ContainsKey(new Point(x,y)))
                    res.Add(new Point(x, y));
            }
            sr.Close(); file.Close();
            return res;
        }
        public static List<Line> readLinesFromFile(int w,int h)
        {
            FileStream file = new FileStream("c++Out.txt",
                FileMode.OpenOrCreate);
            StreamReader sr = new StreamReader(file);
            string[] st = sr.ReadLine().Split(' ');
            List<Line> VoronoiSegs = new List<Line>();
            for (int i = 0, j = 0; j < st.Length / 4; j++)
            {
                int x1 = (int)double.Parse(st[i++]);
                int y1 = (int)double.Parse(st[i++]);
                int x2 = (int)double.Parse(st[i++]);
                int y2 = (int)double.Parse(st[i++]);
                x1 = x1 < w ? x1 : w - 1; x1 = x1 >= 0 ? x1 : 0;
                y1 = y1 < h ? y1 : h - 1; y1 = y1 >= 0 ? y1 : 0;
                x2 = x2 < w ? x2 : w - 1; x2 = x2 >= 0 ? x2 : 0;
                y2 = y2 < h ? y2 : h - 1; y2 = y2 >= 0 ? y2 : 0;
                VoronoiSegs.Add(new Line(new Point(x1, y1), new Point(x2, y2)));
            }
            sr.Close(); file.Close();

            return VoronoiSegs;
        }
        public static int savePointsToFile(int w, int h, List<Point> obstaclePoints)
        {
            FileStream file = new FileStream("c++In.txt", FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(file);
            sw.WriteLine(w + " " + h);

            for (int i = 0; i < obstaclePoints.Count - 1; ++i)
            {
                if (obstaclePoints[i].X < 0 || obstaclePoints[i].Y < 0 || obstaclePoints[i].X >= w || obstaclePoints[i].Y >= h)
                    return -1;
                sw.WriteLine(obstaclePoints[i].X.ToString() + " " + obstaclePoints[i].Y.ToString());
            }
            sw.Write(obstaclePoints[obstaclePoints.Count - 1].X.ToString() + " " + obstaclePoints[obstaclePoints.Count - 1].Y.ToString());
            sw.Close(); file.Close();
            return 0;
        }
        
    }
    
}
