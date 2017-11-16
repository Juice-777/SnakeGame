using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public class PointConsole
    {
        private int _x { get; set; }
        private int _y { get; set; }

        public int X
        {
            get { return _x; }
            set { _x = value; } 
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public PointConsole(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void DrawPoint(Char ch)
        {
            Console.SetCursorPosition(_x, _y);
            Console.WriteLine(ch);
        }
    }
}
