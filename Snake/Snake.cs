using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public static class Snake
    {
        static Direction _Direct;
        static List<PointConsole> _BodyPoints { get; set; }
        static ConsoleColor _ColorSnake { get; set; }
        static char _HeadSymb { get; set; }
        static char _BodySymb { get; set; }
        public static Direction Direct {
            get
            {
                return _Direct;
            }
            set
            {
                if (Direct != value)
                    _Direct = value;
            }
        }

        public static List<PointConsole> BodyPoints
        {
            get
            {
                return _BodyPoints;
            }
        }

        static Snake()
        {
            _ColorSnake = ConsoleColor.Green;
            _HeadSymb = '#';
            _BodySymb = 'X';
            _Direct = Direction.Up;

            BornBody();
        }

        public static void Move()
        {
            PointConsole tempPoint = _BodyPoints.First();
            if (Direct == Direction.Up)
                tempPoint = new PointConsole(tempPoint.X, tempPoint.Y - 1);
            if (Direct == Direction.Down)
                tempPoint = new PointConsole(tempPoint.X, tempPoint.Y + 1);
            if (Direct == Direction.Left)
                tempPoint = new PointConsole(tempPoint.X-1, tempPoint.Y);
            if (Direct == Direction.Right)
                tempPoint = new PointConsole(tempPoint.X + 1, tempPoint.Y);

            SetConsoleSymbol(_BodyPoints.Last(), " ");
            _BodyPoints.Remove(_BodyPoints.Last());
            _BodyPoints.Insert(0, tempPoint);

            DrawSnake();
        }

        public static void SetConsoleSymbol(PointConsole coord, string symbol)
        {
            Console.SetCursorPosition(coord.X, coord.Y);
            Console.Write(symbol);
        }

        static void DrawSnake()
        {
            Console.ForegroundColor = _ColorSnake;
            foreach (var p in _BodyPoints)
            {
                char ch;
                if (_BodyPoints.First() == p)
                    ch = _HeadSymb;
                else
                    ch = _BodySymb;

                Console.SetCursorPosition(p.X, p.Y);
                Console.Write(ch);
            }
            Console.ForegroundColor = ConsoleColor.Black;
        }

        public static void EditDirection(ConsoleKeyInfo key )
        {
            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    Direct = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                    Direct = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                    Direct = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                    Direct = Direction.Right;
                    break;
            }
        }

        static  void BornBody()
        {
            _BodyPoints = new List<PointConsole>();
            for (int i = 0; i < 5; i++)
                _BodyPoints.Add(new PointConsole(Console.WindowWidth / 2, Console.WindowHeight / 2 +1));
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        public static PointConsole GetHeadCoord()
        {
            return _BodyPoints.First();
        }

        public static void Rise()
        {
            _BodyPoints.Add(_BodyPoints.Last());
        }
    }
}
