using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
namespace GUI_Part_Voronoi
{
    class Dijkstra
    {
        Dictionary<Point, List<Point>> adjList;
        Dictionary<Point, int> dist;
        Dictionary<Point, bool> visited;
        Dictionary<Point, Point> prev;
        Point start, dest;
        public Dijkstra(List<Line> edges, Point _start,Point _dest)
        {
            start= _start;
            dest= _dest;
            DijkstraUtil.resetData();
            adjList = DijkstraUtil.adjList;
            dist = DijkstraUtil.dist;
            visited = DijkstraUtil.visited;
            prev = DijkstraUtil.prev;
            for (int i = 0; i < edges.Count; ++i)
            {
                if (adjList.ContainsKey(edges[i].start))
                    adjList[edges[i].start].Add(edges[i].end);
                else
                    adjList.Add(edges[i].start, new List<Point>());
             
                if (adjList.ContainsKey(edges[i].end))
                    adjList[edges[i].end].Add(edges[i].start);
                else
                    adjList.Add(edges[i].end, new List<Point>());
            }
        }
        public List<Point> runDijstra()
        {
            foreach (KeyValuePair<Point, List<Point>> pair in adjList)
            {
                dist[pair.Key] = 10000000;
                visited[pair.Key] = false;
                prev[pair.Key] = new Point(-1,-1);
            }
            dist[start] = 0;
            PriorityQueue<dijkstraPoint> queue = new PriorityQueue<dijkstraPoint>();
            queue.Add(new dijkstraPoint(start));
            while (queue.Count>0)
            {
                dijkstraPoint u = queue.Dequeue();
                visited[u.point] = true;

                foreach (Point v in adjList[u.point])
                { 
                    int alt = dist[u.point] + (int)Utilities.distance(u.point, v);          
                    if (alt < dist[v])
                    {
                        dist[v] = alt;
                        prev[v] = u.point;
                        if (!visited[v])
                            queue.Enqueue(new dijkstraPoint(v));
                    }
                }
            }
            if (dist[dest] == 10000000)
                return null;
            List<Point> path = new List<Point>();
            Point curr = dest;
            while (curr != new Point(-1, -1))
            {
                path.Add(curr);
                curr = prev[curr];
            }
            path.Reverse();
            return path;
        }
    }
}
