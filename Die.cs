using System.Collections.Generic;
using System.Linq;
using System;


namespace OOP_Assessment_2
{
    class Die
    {
        const int MIN = 1;
        const int MAX = 7;
        public int dieRolledValue; // die roll value
        public int dieReroll; // re roll die roll value
        private Random die = new Random(); // random die roll
        // dice roll function, which returns a value between 1-6;
        public int rollDice()
        {
            Console.WriteLine("Press any key to roll the dice.");
            Console.ReadKey();
            // try and catch error handling, checks if the dice goes above 6. or less than 0
            try
            {
                dieRolledValue = die.Next(MIN, MAX);
                Console.WriteLine("You rolled a " + dieRolledValue);
                if(dieRolledValue <= 0 || dieRolledValue >= 7)
                {
                    throw new SystemException();
                }
                Console.ReadKey(); 
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message, "Error. Roll Again");
            }

            return dieRolledValue;
        }

        // dice re-roll function, but every reroll it will decremeant by one.
        public int ReRollDice(int numberOfRolls)
        {
            Console.WriteLine("You have remaining of " + numberOfRolls + " rolls left.");
            numberOfRolls--;
            Console.ReadKey();
            // try and catch error to see if the die value goes above 6 or less than 1.
            try
            {       
                dieReroll = die.Next(MIN,MAX);
                Console.WriteLine("You rolled a " + dieReroll);
                if(dieReroll <= 0 || dieReroll >=7)
                {
                    throw new SystemException();
                }
            }
            catch(FormatException ex)
            {
                Console.WriteLine(ex.Message, "Value is Out of Bounds!");
            }

            return dieReroll;

            
        }
    }
}


