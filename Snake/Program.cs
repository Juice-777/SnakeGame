using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Snake.Border;

namespace Snake
{
    abstract class Program
    {
        private static int speedSnake = 100;
        static List<PointConsole> _borderPointsList = new List<PointConsole>();
        //InitBorder();
        //Snake.Move();
        //Snake.EditDirection(Console.ReadKey());
        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            Init();

            Console.ReadKey();
            bool GemeOn = true;
            while (GemeOn)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Snake.EditDirection(keyInfo);
                }
                Snake.Move();
                GemeOn = ValidAction();
                Thread.Sleep(speedSnake);
            }
        }

        private static void Init()
        {
            Console.CursorVisible = false;
            CreateBorder();
            _borderPointsList = FullBorder.BodrerPoints;
            Eat.GeneratePosEat();
        }

        private static void CreateBorder()
        {
            //InitBorder();
            //Snake.Move();

            //Console.ReadKey();
            //Console.Clear();
            //Start();
        }
        private static void InitBorder()
        {
            Console.Clear();

            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowTop + Console.WindowHeight;
            Console.BufferWidth = Console.WindowLeft + Console.WindowWidth;

            var border = new FullBorder(new PointConsole(0, 0),
                            new PointConsole(Console.WindowWidth - 1, 0),
                            new PointConsole(0, Console.WindowHeight - 1),
                            new PointConsole(Console.WindowWidth - 1, Console.WindowHeight - 1));
            _borderPointsList = border.BodrerPoints;
        }
    }

        static void GameOver()
        {
            string finanalMsg = "Game Over";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - finanalMsg.Length/2, Console.WindowHeight / 2 + 1);
            Console.WriteLine(finanalMsg);
            Console.ReadKey();
            Start();
        }
    }
}
