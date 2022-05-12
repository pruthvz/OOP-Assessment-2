using System.Collections.Generic;
using System.Linq;
using System;


namespace OOP_Assessment_2
{
    class Die
    {
        const int MIN = 1;
        const int MAX = 7;
        public int dieRolledValue;
        public int dieReroll;
        private Random die = new Random();
        public int rollDice()
        {
            Console.WriteLine("Press any key to roll the dice.");
            Console.ReadKey();
        
            dieRolledValue = die.Next(MIN, MAX);
            Console.WriteLine("You rolled a " + dieRolledValue);
            Console.ReadKey(); 

            return dieRolledValue;
        }


        public int ReRollDice(int numberOfRolls)
        {
            Console.WriteLine("You have remaining of " + numberOfRolls + " left");
            Console.ReadKey();
            numberOfRolls--;

            dieReroll = die.Next(MIN,MAX);
            Console.WriteLine("You rolled a " + dieReroll);

            return dieReroll;

            
        }
    }
}


