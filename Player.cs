using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace OOP_Assessment_2
{
    class Player
    {
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
        
        public string Name { get; set; }
        public int PlayerNo{ get; set; }     
        
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

    }
}


