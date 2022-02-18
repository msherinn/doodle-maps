using System;
using System.Collections.Generic;

namespace Kse.Algorithms.Samples;

public class Dijkstra
{
    public static List<Point> Search(Point start, Point goal, string[,]map)
    {
        var visited = new List<Point>();
        PriorityQueue<Point, int> queue = new PriorityQueue<Point, int>();
        Visit(start);
        queue.Enqueue(start, start.Distance);
        while (!visited.Contains(goal) || queue.Count > 0)
        {
            var next = queue.Dequeue();
            var offsetRow = Math.Abs(next.Row - start.Row);
            var offsetColumn = Math.Abs(next.Column - start.Column);
            var offset = offsetColumn + offsetRow;
            var neighbours = GetNeighbours(next.Row, next.Column, map);
            foreach (var neighbour in neighbours)
            {
                if (!visited.Contains(neighbour))
                {
                    if (neighbour.Column == goal.Column && neighbour.Row == goal.Row)
                    {
                        goal.Parent = visited.Count - 1;
                    }

                    var point = neighbour;
                    point.Parent = visited.Count - 1;
                    Visit(neighbour);
                    queue.Enqueue(point, offset);
                }
            }
        }

        var result = new List<Point>();
        result.Insert(0, goal);
        while (!result.Contains(start))
        {
            result.Insert(0, visited[result[0].Parent]);
        }

        return result;

        void Visit(Point point)
            {
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