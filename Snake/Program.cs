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
            //Console.WriteLine(Console.BufferHeight + "x" + Console.BufferWidth);
            Console.ReadKey();
            Console.Clear();

            new BorderHorizontal(new PointConsole(0, 0), new PointConsole(Console.WindowWidth, 0)).DrawBorder();
            new BorderHorizontal(new PointConsole(0, Console.WindowHeight), new PointConsole(Console.WindowWidth, Console.WindowHeight)).DrawBorder();


            InitConsole();
        }
    }
}
