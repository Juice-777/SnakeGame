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
        PointConsole _pLeftUp { get; set; }
        PointConsole _pRightUp { get; set; }
        PointConsole _pLeftDown { get; set; }
        PointConsole _pRightDown { get; set; }

        public string Symbol { get ; set ; }
        public Color Color { get; set; }

        public List<PointConsole> pointsList = null;

        public FullBorder(PointConsole pLU, PointConsole pRU, PointConsole pLD, PointConsole pRD)
        {
            _pLeftUp = pLU;
            _pRightUp = pRU;
            _pLeftDown = pLD;
            _pRightDown = pRD;

            DrawBorder();
        }

        private void DrawBorder()
        {
            //drawPoint(_pLeftUp);
            //drawPoint(_pRightUp);
            //drawPoint(_pLeftDown);
            //drawPoint(_pRightDown);

            pointsList = new List<PointConsole>();
            new BorderHorizontal(_pLeftUp, _pRightUp).DrawBorder(ref pointsList);
            new BorderHorizontal(_pLeftDown, _pRightDown).DrawBorder(ref pointsList);

            new BorderVertical(_pLeftUp, _pLeftDown).DrawBorder(ref pointsList);
            new BorderVertical(_pRightUp, _pRightDown).DrawBorder(ref pointsList);
        }

        private void drawPoint(PointConsole p)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.WriteLine("*");
        }

    }
}
