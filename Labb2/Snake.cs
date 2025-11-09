using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Snake : Enemy
    {
        private static Random rand = new Random();
        public Snake()
        {

            Symbol = 's';
            Color = ConsoleColor.DarkRed;
            Name = "Snake";
            HP = 25;
            AttackDice = new Dice(3, 4, 2);
            DefenceDice = new Dice(1, 8, 5);

        }
        public override void Update(LevelData level, Player player, ref string combatLog)
        {

            double distance = Math.Sqrt(Math.Pow(player.PositionX - PositionX, 2) + Math.Pow(player.PositionY - PositionY, 2));





            if (distance <= 2)
            {

                int dx = Math.Sign(PositionX - player.PositionX);



                int dy = Math.Sign(PositionY - player.PositionY);

                int newX = PositionX + dx;



                int newY = PositionY + dy;

                int dxPlayer = Math.Abs(player.PositionX - newX);




                int dyPlayer = Math.Abs(player.PositionY - newY);


                if ((dxPlayer == 1 && dyPlayer == 0) || (dxPlayer == 0 && dyPlayer == 1))


                {
                    player.Battle(this, level, ref combatLog);
                }
                else if (!level.Elements.Any(e => e.PositionX == newX && e.PositionY == newY && (e is Wall || e is Enemy)))


                {
                    PositionX = newX;
                    PositionY = newY;
                }


            }
        }
    }
}
