using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    abstract class LevelElement
    {
        public int PositionX { get; set; }


        public int PositionY { get; set; }
        public char Symbol { get; set; }
        public ConsoleColor Color { get; set; }


        public bool Discovered { get; set; } = false;

        public void Draw()
        {
            Console.SetCursorPosition(PositionX, PositionY + 3);

            Console.ForegroundColor = Color;
            Console.Write(Symbol);
            Console.ResetColor();
        }
    }
}
