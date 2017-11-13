using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    public class BorderHorizontal : IBorder
    {
        public PointConsole PositionA { get; set; }
        public PointConsole PositionB { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set ; }

        public BorderHorizontal()
        {
            InitParams();
        }

        public BorderHorizontal(PointConsole pA, PointConsole pB)
        {
            InitParams();
            PositionA = pA;
            PositionB = pB;
        }

        private void InitParams()
        {
            Symbol = "-";
            Color = ConsoleColor.Cyan;
        }

        public void DrawBorder()
        {
            if (PositionA != null && PositionB != null)
            {
                Console.ForegroundColor = Color;
                int delta = PositionB.X - PositionA.X;
                for (int i = 0; i < delta; i++)
                {
                    PointConsole point = new PointConsole(i, PositionB.Y);
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(Symbol);
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        public void DrawBorder(ref List<PointConsole> list)
        {
            Console.ForegroundColor = Color;

            int delta = PositionB.X - PositionA.X;
            for (int i = 0; i < delta; i++)
            {
                PointConsole point = new PointConsole(i, PositionB.Y);
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(Symbol);
                list.Add(point);
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
        }
    }
}
