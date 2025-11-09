using System;
using System.Linq;

namespace Labb2
{
    class Player : LevelElement
    {
        public string Name { get; set; }


        public int HP { get; set; }
        public Dice Attack { get; set; }


        public Dice Defence { get; set; }

        public Player()
        {
            Symbol = '@';
            Color = ConsoleColor.Green;
            HP = 100;

            Attack = new Dice(2, 6, 2);
            Defence = new Dice(2, 6, 0);
        }

        public void Move(ConsoleKey input, LevelData map, ref string log)
        {
            log = "";

            int nextX = PositionX;
            int nextY = PositionY;

            if (input == ConsoleKey.UpArrow) nextY--;


            else if (input == ConsoleKey.DownArrow) nextY++;



            else if (input == ConsoleKey.LeftArrow) nextX--;



            else if (input == ConsoleKey.RightArrow) nextX++;
            else return;

            var target = map.Elements.FirstOrDefault(e => e.PositionX == nextX && e.PositionY == nextY);

            if (target == null || !(target is Wall) && !(target is Enemy))


            {
                Console.SetCursorPosition(PositionX, PositionY);


                Console.Write(' ');

                PositionX = nextX;
                PositionY = nextY;
            }
            else if (target is Enemy foe)


            {
                
                Battle(foe, map, ref log);
            }
        }

       
        public void Battle(Enemy foe, LevelData map, ref string log)
        {
            
            int dx = Math.Abs(PositionX - foe.PositionX);


            int dy = Math.Abs(PositionY - foe.PositionY);
            if (!((dx == 1 && dy == 0) || (dx == 0 && dy == 1)))
                return;

            log = "";

            
            int playerRoll = Attack.Throw();

            int foeDefRoll = foe.DefenceDice.Throw();
            int damageToFoe = playerRoll - foeDefRoll;

            if (damageToFoe > 0)
            {
                foe.HP -= damageToFoe;


                if (foe.HP <= 0)
                {
                    log += $"You (ATK: {Attack} => {playerRoll}) struck the {foe.Name} (DEF: {foe.DefenceDice} => {foeDefRoll}) and killed it.\n";
                    map.Elements.Remove(foe);


                }
                else
                {
                    log += $"You (ATK: {Attack} => {playerRoll}) wounded the {foe.Name} (DEF: {foe.DefenceDice} => {foeDefRoll}) for {damageToFoe}.\n";
                }
            }
            else
            {
                log += $"You (ATK: {Attack} => {playerRoll}) attacked {foe.Name} (DEF: {foe.DefenceDice} => {foeDefRoll}) but caused no damage.\n";
            }

            
            if (foe.HP > 0)
            {
                int foeAtkRoll = foe.AttackDice.Throw();


                int playerDefRoll = Defence.Throw();


                int damageToPlayer = foeAtkRoll - playerDefRoll;

                if (damageToPlayer > 0)
                {
                    HP -= damageToPlayer;
                    if (HP <= 0)
                    {
                        log += $"The {foe.Name} (ATK: {foe.AttackDice} => {foeAtkRoll}) hit you (DEF: {Defence} => {playerDefRoll}) — you died (GAME OVER).\n";
                    }
                    else
                    {
                        log += $"The {foe.Name} (ATK: {foe.AttackDice} => {foeAtkRoll}) hit you (DEF: {Defence} => {playerDefRoll}) for {damageToPlayer}.\n";


                    }
                }
                else
                {
                    log += $"The {foe.Name} (ATK: {foe.AttackDice} => {foeAtkRoll}) attacked you (DEF: {Defence} => {playerDefRoll}) but did no damage.\n";
                }
            }
        }
    }
}
