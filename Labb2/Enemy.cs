using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    abstract class Enemy : LevelElement
    {
        public string Name { get; set; }


        public int HP { get; set; }
        public Dice AttackDice { get; set; }


        public Dice DefenceDice { get; set; }

        public abstract void Update(LevelData level, Player player, ref string combatLog);
    }
}
