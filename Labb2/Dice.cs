using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2
{
    class Dice
    {
        private int numberOfDice;


        private int sidesPerDice;


        private int modifier;

        private Random rand = new Random();

        public Dice(int numberOfDice, int sidesPerDice, int modifier)
        {
            this.numberOfDice = numberOfDice;

            this.sidesPerDice = sidesPerDice;
            this.modifier = modifier;

        }

        public int Throw()
        {
            int total = 0;

            for (int i = 0; i < numberOfDice; i++)
            {
                total += rand.Next(1, sidesPerDice + 1);

            }
            total += modifier;
            return total;


        }

        public override string ToString()
        {
            return $"{numberOfDice}d{sidesPerDice}+{modifier}";

        }
    }
}
