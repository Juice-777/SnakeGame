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
        private static int speedSnake = 500;
        static List<PointConsole> _borderPointsList = new List<PointConsole>();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            CreateBorder();
            _borderPointsList = FullBorder.BodrerPoints;
            Eat.GeneratePosEat();
            Start();
        }

        private static void Start()
        {

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    Snake.EditDirection(keyInfo);
                }
                Snake.Move();
                Thread.Sleep(speedSnake);
            }
        }
        
        private static void CreateBorder()
        {
            Console.WindowHeight = 20;
            Console.WindowWidth = 60;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            FullBorder.CreateBorder(new PointConsole(0, 0),
                                    new PointConsole(Console.WindowWidth - 1, 0),
                                    new PointConsole(0, Console.WindowHeight - 1),
                                    new PointConsole(Console.WindowWidth - 1, Console.WindowHeight - 1));
        }

        static bool ValidAction()
        {
            PointConsole headCoord = Snake.GetHeadCoord();
            PointConsole eatPosition = Eat.Position;

            if (eatPosition.X == headCoord.X && eatPosition.Y == headCoord.Y)
            {
                Eat.GeneratePosEat();
                Snake.Rise();
            }

            if (_borderPointsList.Exists(x => x.Y == headCoord.Y && x.X == headCoord.X))           
            {
                GameOver();
                return false;
            }

            if (Snake.BodyPoints != null)
            {
                if (Snake.BodyPoints.Exists(x => x.Y == headCoord.Y && x.X == headCoord.X && x != Snake.BodyPoints.First()))
                {
                    GameOver();
                    return false;
                }
            }
            return true;
        }

        static void GameOver()
        {
            Console.Clear();
        }
    }
}
