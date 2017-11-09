using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    class FullBorder
    {
        public PointConsole pLeftUp { get; set; }
        public PointConsole pRightUp { get; set; }
        public PointConsole pLeftDown { get; set; }
        public PointConsole pRightDown { get; set; }

        public string Symbol { get ; set ; }
        public Color Color { get; set; }

        public FullBorder(PointConsole pLU, PointConsole pRU, PointConsole pLD, PointConsole pRD)
        {
            pLeftUp = pLU;
            pRightUp = pRU;
            pLeftDown = pLD;
            pRightDown = pRD;

            DrawBorder();
        }

        private void DrawBorder()
        {
            //new BorderHorizontal(pLeftUp, pRightUp).DrawBorder();
            new BorderHorizontal(pLeftDown, pRightDown).DrawBorder();

        }

    }
}
