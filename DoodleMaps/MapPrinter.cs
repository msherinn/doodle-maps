﻿using System.Xml.Schema;

namespace Kse.Algorithms.Samples
{
    using System;
    using System.Collections.Generic;

    public class MapPrinter
    {
        public void PrintPath(string[,] maze, List<Point> path)
        {
            Console.WriteLine("path " + path);
            foreach (var t in path)
            {
                Console.WriteLine(t + " " + maze[t.Row, t.Column]);
                if (maze[t.Column, t.Row] != "█")
                {
                    maze[t.Column, t.Row] = "*";
                }
                
            }
            
            Print(maze);
        }
        public void Print(string[,] maze)
        {
            PrintTopLine();
            for (var row = 0; row < maze.GetLength(1); row++)
            {
                Console.Write($"{row}\t");
                for (var column = 0; column < maze.GetLength(0); column++)
                {
                    Console.Write(maze[column, row]);
                }

                Console.WriteLine();
            }

            void PrintTopLine()
            {
                Console.Write($" \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10 == 0? i / 10 : " ");
                }
    
                Console.Write($"\n \t");
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    Console.Write(i % 10);
                }
    
                Console.WriteLine("\n");
            }
        }
    }
}