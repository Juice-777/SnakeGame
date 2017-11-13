using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Border;
using System.Timers;

namespace Snake
{
    abstract class Program
    {
        static System.Timers.Timer _gameTimer;
        private static int speedSnake = 100;
        static List<PointConsole> _borderPointsList = new List<PointConsole>();
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            CreateBorder();
            _borderPointsList = FullBorder.BodrerPoints;
            Eat.GeneratePosEat();
            StartTimer();
        }

        private static void StartTimer()
        {
            _gameTimer = new System.Timers.Timer(speedSnake);
            _gameTimer.Elapsed += GameAction;
            _gameTimer.AutoReset = true;
            _gameTimer.Enabled = true;
            Snake.EditDirection(Console.ReadKey());
            if (ValidAction())
            {
                _gameTimer.Stop();
                _gameTimer.Dispose();
                StartTimer();
            }
        }

        private static void GameAction(Object source, ElapsedEventArgs e)
        {
            Snake.Move();
            if (ValidAction())
                Snake.EditDirection(Console.ReadKey());
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
            _gameTimer.Stop();
            _gameTimer.Dispose();
            Console.Clear();
        }
    }
}
