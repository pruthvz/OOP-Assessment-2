using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace OOP_Assessment_2
{
    class Player
    {
        // player objects.
        public string Name { get; set; }
        public int PlayerNo{ get; set; }     
        public int RoundScore { get; set; }
        public Player(int playerNumber, bool anyAI = false)
        {
            PlayerNo = playerNumber;
            if(anyAI)
            {
                anyAI = true;
                // AI game;
            }
            else
            {
                AskPlayerName();
            }
        }
        // AskPlayerName will simply take the players name.
        private void AskPlayerName()
        {
            // a try and catch statement will check whether a string is given or not.
            try
            {
                
                Console.WriteLine("What is the " + PlayerNo + " player's name?");
                Name = Console.ReadLine();

                while(string.IsNullOrEmpty(Name))
                {
                    Console.WriteLine("What is the " + PlayerNo + " player's name?");
                    Name = Console.ReadLine();
                    // Name = Console.ReadLine();
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // player roll dice. simply rolls the dice for the player 5 times
        public int RollingDice()
        {
            Game gameObj = new Game();
            Die dieObj = new Die();
            int rollValue = 0;
            for (int j = 0; j < gameObj.diceValues.Length; j++)
            {
                int dieValue = dieObj.rollDice();
                gameObj.diceValues[j] = dieValue;
                // a try catch error to see if the die value is above 6 or less than 1.
                try
                {
                    if(dieValue <= 0 || dieValue >= 7)
                    {
                        throw new SystemException();
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("Dice Values have to be in between 1-6");
                }
                
            }
            gameObj.CountDuplicates(gameObj.diceValues);
            return rollValue; // returns the die Value to the main function.
        }
    }
}


