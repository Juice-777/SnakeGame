using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    class BorderHorizontal : IBorder
    {
        public PointConsole PositionA { get; set; }
        public PointConsole PositionB { get; set; }
        public string Symbol { get; set; }
        public ConsoleColor Color { get; set ; }

        public BorderHorizontal(PointConsole pA, PointConsole pB)
        {
            Symbol = "-";
            Color = ConsoleColor.Cyan;
            PositionA = pA;
            PositionB = pB;
        }

        public void DrawBorder()
        {
            throw new NotImplementedException();
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
