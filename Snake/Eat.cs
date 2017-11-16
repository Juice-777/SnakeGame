using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public static class Eat
    {
        static char _ViewSymb { get; set; }
        static ConsoleColor _ColorEat { get; set; }
        static PointConsole _Position { get; set; }
        static public PointConsole Position { get {  return _Position;  } }

        static Eat()
        {
            _ViewSymb = '@';
            _ColorEat = ConsoleColor.Red;
        }

        static void Draw()
        {
            Console.SetCursorPosition(_Position.X, _Position.Y);
            Console.ForegroundColor = _ColorEat;
            Console.WriteLine(_ViewSymb);
        }

        public static void GeneratePosEat()
        {
            Random rnd = new Random();
            _Position = new PointConsole(rnd.Next(1, Console.WindowWidth - 2), rnd.Next(1, Console.WindowHeight - 2));

            if (Snake.BodyPoints.Exists(x => x.Y == _Position.Y && x.X == _Position.X))
                GeneratePosEat();
            else
            {
                Console.Beep();
                Draw();
            }
        }
    }
}