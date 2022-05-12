using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace OOP_Assessment_2
{
    class Player
    {
        public string Name { get; set; }
        public int PlayerNo{ get; set; }     
        public int Wins { get; set; }
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
        private void AskPlayerName()
        {
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

        public void IncrementPlayerWins()
        {
            Wins++;
        }

        public int RollingDice()
        {
            Game gameObj = new Game();
            Die dieObj = new Die();
            int rollValue = 0;
            for (int j = 0; j < gameObj.diceValues.Length; j++)
            {
                int dieValue = dieObj.rollDice();
                gameObj.diceValues[j] = dieValue;
            }
            gameObj.CountDuplicates(gameObj.diceValues);
            return rollValue;
        }
    }
}


