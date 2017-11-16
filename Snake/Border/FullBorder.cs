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

        private List<PointConsole> _pointsList = null;
        public List<PointConsole> BodrerPoints
        {
            get
            {
                if (_pointsList != null)
                    return _pointsList;
                else
                    return new List<PointConsole>();
            }
        }

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
            _pointsList = new List<PointConsole>();
            new BorderHorizontal(_pLeftUp, _pRightUp).DrawBorder(ref _pointsList);
            new BorderHorizontal(_pLeftDown, _pRightDown).DrawBorder(ref _pointsList);

            new BorderVertical(_pLeftUp, _pLeftDown).DrawBorder(ref _pointsList);
            new BorderVertical(_pRightUp, _pRightDown).DrawBorder(ref _pointsList);

        }

        private void drawPoint(PointConsole p)
        {
            Console.SetCursorPosition(p.X, p.Y);
            Console.WriteLine("*");
        }

    }
}
