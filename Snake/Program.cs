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
            InitConsole();
        }

        private static void InitConsole()
        {
            Console.Clear();

            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowTop + Console.WindowHeight;
            Console.BufferWidth = Console.WindowLeft + Console.WindowWidth;

            new FullBorder(new PointConsole(0, 0),
                            new PointConsole(Console.WindowWidth - 1, 0),
                            new PointConsole(0, Console.WindowHeight - 1),
                            new PointConsole(Console.WindowWidth - 1, Console.WindowHeight - 1));
            Console.ReadKey();
            InitConsole();
        }
    }
}
