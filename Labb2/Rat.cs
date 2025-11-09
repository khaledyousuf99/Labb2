using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Rat : Enemy
    {
        private static Random rand = new Random();


        public Rat()
        {
            Symbol = 'r';
            Color = ConsoleColor.DarkRed;
            Name = "Rat";
            HP = 10;
            AttackDice = new Dice(1, 6, 3);
            DefenceDice = new Dice(1, 6, 1);


        }

        public override void Update(LevelData level, Player player, ref string combatLog)
        {

            int dx = Math.Abs(player.PositionX - PositionX);


            int dy = Math.Abs(player.PositionY - PositionY);

            if ((dx == 1 && dy == 0) || (dx == 0 && dy == 1))


            {
                player.Battle(this, level, ref combatLog);
                return;
            }


            int direction = rand.Next(4);


            int newX = PositionX;
            int newY = PositionY;

            switch (direction)
            {
                case 0:
                    newY -= 1;
                    break;

                case 1:
                    newY += 1;
                    break;

                case 2:
                    newX -= 1;
                    break;

                case 3:
                    newX += 1;
                    break;
            }

            if (!level.Elements.Any(e => e.PositionX == newX && e.PositionY == newY && (e is Wall || e is Enemy)))


            {
                PositionX = newX;
                PositionY = newY;
            }
        }
    }
}
