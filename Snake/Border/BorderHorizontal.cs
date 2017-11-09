using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    class BorderHorizontal : Border
    {
        public PointConsole PositionA { get; set; }
        public PointConsole PositionB { get; set; }
        public string Symbol { get; set; }
        public Color Color { get; set ; }

        public BorderHorizontal(PointConsole pA, PointConsole pB)
        {
            PositionA = pA;
            PositionB = pB;
        }

        public void DrawBorder()
        {
            int delta = PositionB.X - PositionA.X;
            for (int i = 0; i < delta-1; i++)
            {
                Console.SetCursorPosition(i, PositionA.Y);
                Console.Write("*");
            }
        }
    }
}
