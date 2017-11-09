using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snake.Border;

namespace Snake
{
    abstract class Program
    {
        static void Main(string[] args)
        {
            Console.Title = " = )";
            Console.WindowHeight = 20;
            Console.WindowWidth = 40;
            InitConsole();
        }

        private static void InitConsole()
        {
            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowTop + Console.WindowHeight;
            Console.BufferWidth = Console.WindowLeft + Console.WindowWidth;

            new FullBorder(new PointConsole(0, 0),
                new PointConsole(Console.WindowWidth, 0),
                new PointConsole(Console.WindowHeight, 0),
                new PointConsole(Console.WindowHeight, Console.WindowHeight));
            Console.ReadKey();
            Console.Clear();
            InitConsole();
        }
    }
}
