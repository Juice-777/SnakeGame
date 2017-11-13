using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake.Border
{
    public static class FullBorder
    {
        static PointConsole _pLeftUp { get; set; }
        static PointConsole _pRightUp { get; set; }
        static PointConsole _pLeftDown { get; set; }
        static PointConsole _pRightDown { get; set; }

        public static string Symbol { get ; set ; }
        public static Color Color { get; set; }

        private static List<PointConsole> _pointsList = null;
        public static List<PointConsole> BodrerPoints
        {
            get
            {
                if (_pointsList != null)
                    return _pointsList;
                return new List<PointConsole>();
            }
        }

        public static void CreateBorder(PointConsole pLU, PointConsole pRU, PointConsole pLD, PointConsole pRD)
        {
            _pLeftUp = pLU;
            _pRightUp = pRU;
            _pLeftDown = pLD;
            _pRightDown = pRD;

            DrawBorder();
        }

        private static void DrawBorder()
        {
            _pointsList = new List<PointConsole>();
            new BorderHorizontal(_pLeftUp, _pRightUp).DrawBorder(ref _pointsList);
            new BorderHorizontal(_pLeftDown, _pRightDown).DrawBorder(ref _pointsList);

            new BorderVertical(_pLeftUp, _pLeftDown).DrawBorder(ref _pointsList);
            new BorderVertical(_pRightUp, _pRightDown).DrawBorder(ref _pointsList);
        }

        //private static void drawPoint(PointConsole p)
        //{
        //    Console.SetCursorPosition(p.X, p.Y);
        //    Console.WriteLine("*");
        //}
    }
}
