using System;
using System.Collections.Generic;
using System.Linq;
using Kse.Algorithms.Samples;

internal class Program
{


    void PaintBFS(Point point, string[,] map)
    {
        var visited = new List<Point>();
        var queue = new Queue<Point>();
        Visit(point);
        queue.Enqueue(point);
        while (queue.Count > 0)
        {
            var next = queue.Dequeue();
            var neighbours = GetNeighbours(next.Row, next.Column, map);
            foreach (var neighbour in neighbours)
            {
                if (!visited.Contains(neighbour))
                {
                    Visit(neighbour);
                    queue.Enqueue(neighbour);
                }
            }
        }

        void Visit(Point point)
        {
            map[point.Row, point.Column] = "1";
            visited.Add(point);
        }
    }

    List<Point> GetNeighbours(int row, int column, string[,] maze)
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

    static void Main(string[] args)
    {
        var generator = new MapGenerator(new MapGeneratorOptions()
        {
            Height = 35,
            Width = 90,
            Seed = 1
        });

        string[,] map = generator.Generate();
        new MapPrinter().Print(map);

        List<Point> GetShortestPath(string[,] map, Point start, Point goal)
        {
            return null;
        }

        var first = new Point(6, 2);
        var second = new Point(6, 3);
        var points = new List<Point>();
        points.Add(first);
        points.Add(second);
        foreach (var i in points)
        {
            Console.WriteLine(i.Row + ", " + i.Column);
        }
        new MapPrinter().PrintPath(map, points);

    }
    
}
