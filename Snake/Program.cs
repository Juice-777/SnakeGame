using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Snake.Border;
using System.Timers;

namespace Snake
{
    abstract class Program
    {
        public static int aaa = 0;
        private static System.Timers.Timer aTimer;
        static List<PointConsole> _borderPointsList = new List<PointConsole>();
        //InitBorder();
        //Snake.Move();
        //Snake.EditDirection(Console.ReadKey());
        static void Main(string[] args)
        {
           StartTimer();
        }

        public static void StartTimer()
        {
            aTimer = new System.Timers.Timer(500);
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;

            Console.ReadKey();
            aTimer.Stop();
            aTimer.Dispose();
            StartTimer();
        }

        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            InitBorder();
            Snake.Move();
            var a = Console.Read();
            Snake.EditDirection(Convert.ToString(a));
        }

        private static void Start()
        {
            //InitBorder();
            //Snake.Move();

            //Console.ReadKey();
            //Console.Clear();
            //Start();
        }
        private static void InitBorder()
        {
            Console.Clear();

            Console.WindowHeight = 40;
            Console.WindowWidth = 120;
            Console.BufferHeight = Console.WindowTop + Console.WindowHeight;
            Console.BufferWidth = Console.WindowLeft + Console.WindowWidth;

            var border = new FullBorder(new PointConsole(0, 0),
                            new PointConsole(Console.WindowWidth - 1, 0),
                            new PointConsole(0, Console.WindowHeight - 1),
                            new PointConsole(Console.WindowWidth - 1, Console.WindowHeight - 1));
            _borderPointsList = border.BodrerPoints;
        }
    }

}
