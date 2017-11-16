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
        static public Direction Direct { get; set; }
        public static PointConsole HeadPosition { get; set; }

        static Snake()
        {
            ColorSnake = ConsoleColor.Green;
            HeadSymb = '#';
            BodySymb = 'X';
            Direct = Direction.up;

            BornBody();
        }

        public static void Move()
        {
            PointConsole tempPoint = BodyPoints.First();
            if (Direct == Direction.up)
                tempPoint = new PointConsole(tempPoint.X, tempPoint.Y - 1);
            if (Direct == Direction.down)
                tempPoint = new PointConsole(tempPoint.X, tempPoint.Y + 1);
            if (Direct == Direction.left)
                tempPoint = new PointConsole(tempPoint.X-1, tempPoint.Y);
            if (Direct == Direction.right)
                tempPoint = new PointConsole(tempPoint.X + 1, tempPoint.Y);

            BodyPoints.Insert(0, tempPoint);
            BodyPoints.Remove(BodyPoints.Last());

            DrawSnake();
        }

        static void DrawSnake()
        {
            Console.ForegroundColor = ColorSnake;
            foreach (var p in BodyPoints)
            {
                char ch;
                if (BodyPoints.First() == p)
                    ch = HeadSymb;
                else
                    ch = BodySymb;

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
                    Direct = Direction.up;
                    break;
                case ConsoleKey.DownArrow:
                    Direct = Direction.down;
                    break;
                case ConsoleKey.LeftArrow:
                    Direct = Direction.left;
                    break;
                case ConsoleKey.RightArrow:
                    Direct = Direction.right;
                    break;
            }
        }
        public static void EditDirection(string key)
        {

            switch (key)
            {
                case "4":
                    Direct = Direction.up;
                    break;
                case "97":
                    Direct = Direction.down;
                    break;
                case "a":
                    Direct = Direction.left;
                    break;
                case "d":
                    Direct = Direction.right;
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
            up,
            down,
            left,
            right
        }
    }
}
