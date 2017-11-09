using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    interface Border
    {
        PointConsole PositionA { get; set; }
        PointConsole PositionB { get; set; }
        string Symbol { get; set; }
        Color Color { get; set; }

        void DrawBorder();
    }
}
