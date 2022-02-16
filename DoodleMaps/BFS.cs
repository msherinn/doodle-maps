using System;
using System.Collections.Generic;

namespace Kse.Algorithms.Samples;

public class BFS
{
    static List<Point> visited = new List<Point>();
    public static List<Point> PaintBFS(List<Point> branch, Point start, Point goal, string[,] map)
    {
        var path = branch;
        var paths = new List<List<Point>>();
        Visit(start);
        var neighbours = GetNeighbours(start.Row, start.Column, map);
            int i = 0;
            foreach (var neighbour in neighbours)
            {
                if (!visited.Contains(neighbour))
                { 
                    i += 1;
                   Visit(neighbour);
                   Console.WriteLine(neighbour.Column + ", " + neighbour.Row);
                   path.Add(neighbour);
                   if (neighbour.Row == goal.Row && neighbour.Column == goal.Column)
                   {
                       return path;
                   }

                   var result = (PaintBFS(path, neighbour, goal, map));
                   if (result[result.Count - 1].Row == goal.Row && result[result.Count - 1].Column == goal.Column)
                   {
                       return result;
                   }
                }
                
            }

            return branch;
            
            /*if (paths.Count == 0)
            {
                return path;
            }

            var finalResult = paths[0];
            for (var j = 1; j < paths.Count; j++)
            {
                
            }

            return path;*/

            void Visit(Point point)
        {
            map[point.Row, point.Column] = ".";
            visited.Add(point);
        }
    
    }

    static List<Point> GetNeighbours(int row, int column, string[,] maze)
    {
        var result = new List<Point>();
        TryAddWithOffset(1, 0);
        TryAddWithOffset(-1, 0);
        TryAddWithOffset(0, 1);
        TryAddWithOffset(0, -1);
        return result;

        void TryAddWithOffset(int offsetRow, int offsetColumn)
        {
            var newX = row + offsetRow;
            var newY = column + offsetColumn;
            if (newX >= 0 && newY >= 0 && newX < maze.GetLength(0) && newY < maze.GetLength(1) &&
                maze[newX, newY] != "█")
            {
                result.Add(new Point(newY, newX));
            }
        }
    }
}