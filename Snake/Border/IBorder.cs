using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    interface IBorder
    {
        PointConsole PositionA { get; set; }
        PointConsole PositionB { get; set; }
        string Symbol { get; set; }
        ConsoleColor Color { get; set; }

        void DrawBorder();
    }
}
