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
        static List<PointConsole> _borderPointsList = null;
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
            GameOver();
        }

        static bool ValidAction()
        {
            if (Snake.HeadPosition.X == Eat.Position.X && Snake.HeadPosition.Y == Eat.Position.Y)
            {
                Snake.Rise();
                Eat.GeneratePosEat();
            }
            else if (_borderPointsList.Exists(x => x.X == Snake.HeadPosition.X && x.Y == Snake.HeadPosition.Y))
                return false;
            else if (Snake.BodyPoints.Exists(x => x.X == Snake.HeadPosition.X && x.Y == Snake.HeadPosition.Y && x != Snake.BodyPoints.First()))
                return false;
            return true;
        }

        private static void Init()
        {
            Console.CursorVisible = false;
            CreateBorder();
            Eat.GeneratePosEat();
        }

        private static void CreateBorder()
        {
            Console.Clear();

            Console.WindowHeight = 20;
            Console.WindowWidth = 50;
            Console.BufferHeight = Console.WindowTop + Console.WindowHeight;
            Console.BufferWidth = Console.WindowLeft + Console.WindowWidth;

            var border = new FullBorder(new PointConsole(0, 0),
                            new PointConsole(Console.WindowWidth - 1, 0),
                            new PointConsole(1, Console.WindowHeight - 1),
                            new PointConsole(Console.WindowWidth - 1, Console.WindowHeight - 1));
            _borderPointsList = border.BodrerPoints;
        }

        static void GameOver()
        {
            string finanalMsg = "Game Over";
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.SetCursorPosition(Console.WindowWidth / 2 - finanalMsg.Length/2, Console.WindowHeight / 2 + 1);
            Console.WriteLine(finanalMsg);
            Console.ReadKey();
        }
    }
}
