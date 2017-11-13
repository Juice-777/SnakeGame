using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    class BorderVertical : IBorder
    {
        public PointConsole PositionA { get; set; }
        public PointConsole PositionB { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set ; }

        public BorderVertical()
        {
            InitParams();
        }

        public BorderVertical(PointConsole pA, PointConsole pB)
        {
            InitParams();
            PositionA = pA;
            PositionB = pB;
        }

        private void InitParams()
        {
            Symbol = "|";
            this.Color = ConsoleColor.Cyan;
        }

        public void DrawBorder()
        {
            if (PositionA != null && PositionB != null)
            {
                int delta = PositionB.Y - PositionA.Y;
                Console.ForegroundColor = Color;
                for (int i = 0; i < delta; i++)
                {
                    PointConsole point = new PointConsole(PositionA.X, i);
                    Console.SetCursorPosition(point.X, point.Y);
                    Console.Write(Symbol);
                }
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
        }

        public void DrawBorder(ref List<PointConsole> list)
        {
            int delta = PositionB.Y - PositionA.Y;
            Console.ForegroundColor = Color;
            for (int i = 0; i < delta; i++)
            {
                PointConsole point = new PointConsole(PositionA.X, i);
                Console.SetCursorPosition(point.X, point.Y);
                Console.Write(Symbol);
                list.Add(point);
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;

        }
    }
}
