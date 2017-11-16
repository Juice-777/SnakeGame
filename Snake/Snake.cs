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
        public static List<PointConsole> BodyPoints { get; set; }
        static ConsoleColor ColorSnake { get; set; }
        static char HeadSymb { get; set; }
        static char BodySymb { get; set; }
        static Direction Direct { get; set; }
        public static PointConsole HeadPosition { get { return BodyPoints.First(); } }

        static Snake()
        {
            ColorSnake = ConsoleColor.Green;
            HeadSymb = '#';
            BodySymb = 'X';
            Direct = Direction.Up;

            BornBody();
        }

        public static void Move()
        {
            PointConsole tempPoint = BodyPoints.First();
            if (Direct == Direction.Up)
                tempPoint = new PointConsole(tempPoint.X, tempPoint.Y - 1);
            if (Direct == Direction.Down)
                tempPoint = new PointConsole(tempPoint.X, tempPoint.Y + 1);
            if (Direct == Direction.Left)
                tempPoint = new PointConsole(tempPoint.X-1, tempPoint.Y);
            if (Direct == Direction.Right)
                tempPoint = new PointConsole(tempPoint.X + 1, tempPoint.Y);

            BodyPoints.Insert(0, tempPoint);
            new PointConsole(BodyPoints.Last().X, BodyPoints.Last().Y).DrawPoint(' ');
            BodyPoints.Remove(BodyPoints.Last());
            DrawSnake();
        }

        static void DrawSnake()
        {
            Console.ForegroundColor = ColorSnake;
            foreach (var p in BodyPoints)
            {
                Console.SetCursorPosition(p.X, p.Y);
                if (BodyPoints.First() == p)
                    Console.Write(HeadSymb);
                else
                    Console.Write(BodySymb);
            }
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

        static void BornBody()
        {
            BodyPoints = new List<PointConsole>();
            PointConsole centr = new PointConsole(Console.WindowWidth / 2, Console.WindowHeight /2);
            for (int i = 0; i < 5; i++)
                BodyPoints.Add(new PointConsole(centr.X, centr.Y + i));
        }

        public static void Rise()
        {
            BodyPoints.Add(BodyPoints.Last());
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}
