using System;
using System.Collections.Generic;

namespace Kse.Algorithms.Samples;

public class BFS
{
    private static int step = 0;
    static List<Point> visited = new List<Point>();
    public static List<Point> BFSearch(List<Point> branch, Point start, Point goal, string[,] map)
    {
        step += 1;
        //Console.WriteLine("step: " + step);
        Visit(start);
        var neighbours = GetNeighbours(start.Row, start.Column, map);
            int i = 0;
            foreach (var neighbour in neighbours)
            {
                var path = new List<Point>(branch);
                if (!visited.Contains(neighbour))
                { 
                   i += 1;
                   Visit(neighbour);
                   //Console.WriteLine(i + ": " + neighbour.Column + ", " + neighbour.Row);
                   path.Add(neighbour);
                   if (neighbour.Row == goal.Row && neighbour.Column == goal.Column)
                   {
                       return path;
                   }
                   
                   /*Console.WriteLine("PATH Count - " + path.Count);
                   foreach (var point in path)
                   {
                       Console.Write(point.Column + ":" + point.Row + ", ");
                   }*/
                   
                   var result = (BFSearch(path, neighbour, goal, map));
                   if (result[result.Count - 1].Row == goal.Row && result[result.Count - 1].Column == goal.Column)
                   {
                       /*Console.WriteLine("RESULT Count - " + result.Count);
                       foreach (var point in result)
                       {
                           Console.Write(point.Column + ":" + point.Row + ", ");
                       }*/
                       return result;
                   }
                }
                
            }
            
            /*Console.WriteLine("Count - " + branch.Count);
            foreach (var point in branch)
            {
                Console.Write(point.Column + ":" + point.Row + ", ");
            }*/
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
            //map[point.Row, point.Column] = ".";
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