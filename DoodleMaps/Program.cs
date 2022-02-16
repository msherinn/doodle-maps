using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using Kse.Algorithms.Samples;

internal class Program
{
    static void Main(string[] args)
    {
        var generator = new MapGenerator(new MapGeneratorOptions()
        {
            Height = 35,
            Width = 90,
            Seed = 1
        });

        string[,] map = generator.Generate();

        List<Point> GetShortestPath(string[,] map, Point start, Point goal)
        {
            return null;
        }
        
        new MapPrinter().Print(map);
        Point start = new Point(6, 2);
        Point goal = new Point(24, 14);
        var pointList = new List<Point>();
        var path = BFS.PaintBFS(pointList, start, goal, map);
        foreach (var point in path)
        {
            Console.WriteLine("path: " + point.Column + ", " + point.Row);
            map[point.Row, point.Column] = "*";
        }
        new MapPrinter().Print(map);
    }
    
}
