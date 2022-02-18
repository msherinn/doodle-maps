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
            Seed = 1,
            Noise = 0.9f
        });

        string[,] map = generator.Generate();

        new MapPrinter().Print(map);
        Console.Write("Enter start point: ");
        string startInput = Console.ReadLine();
        Console.Write("Enter goal point: ");
        string goalInput = Console.ReadLine();
        var stringStartInput = startInput.Split(',').ToList();
        var stringGoalInput = goalInput.Split(',').ToList();
        var start = new Point(Int32.Parse(stringStartInput[0]), Int32.Parse(stringStartInput[1]));
        var goal = new Point(Int32.Parse(stringGoalInput[0]), Int32.Parse(stringGoalInput[1]));

        /*var start = new Point(6, 2);
        var goal = new Point(20, 80);
        var pointList = new List<Point>();
        pointList.Add(start);
        var result = BFS.BFSearch(pointList, start, goal, map);*/

        var result = Dijkstra.Search(start, goal, map);
        foreach (var point in result)
        {
            //Console.WriteLine("path: " + point.Column + ", " + point.Row);
            map[point.Row, point.Column] = ".";
        }
        new MapPrinter().Print(map);
    }
    
}
