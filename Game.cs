using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment_2
{
    class Game
    {
        const int NUMBER_OF_PLAYERS = 1;
        public static List<Player> Players;
        public static int NumberOfRounds = 1;
        public int[] diceValues = new int[5];
        public int Setup()
        {
            Console.WriteLine("Press any key to start the game. Press Q to Quit the program.");
            
            string start = string.Empty;
            while (string.IsNullOrEmpty(start))
            {
                start = Console.ReadLine();
            }

            if (start != "q" && start != "Q")
            {
                Start();
            }
          
            return Quit();
        }

        public void Start()
        {
            GetPlayers();
            DisplayPlayers();
            Begin(Players);
            Setup();
            
        }

        public static int Quit()
        {
            return 0;
        }

        public void GetPlayers()
        {
            Players = new List<Player>();
            for (int i = 1; i <= NUMBER_OF_PLAYERS; i++)
            {
                Player player = new Player(i);
                Players.Add(player);
            }
        }

        public void DisplayPlayers()
        {
            Console.WriteLine("Players in the game....");

            foreach(Player p in Players)
            {
                Console.WriteLine(p.PlayerNo + ". "+ p.Name);
            } 
        }

        public void Begin(List<Player> players)
        {
            for (int i = 1; i <= NumberOfRounds; i++)
            {
                foreach(Player p in players)
                {
                    Console.WriteLine("Player " + p.PlayerNo + " " + p.Name + " Turn");
                    Die dieObject = new Die();

                    for (int j = 0; j < diceValues.Length; j++)
                    {
                        int dieValue = dieObject.rollDice();
                        diceValues[j] = dieValue;
                    }
                    CountDuplicates(diceValues);
                }
          
            }

        }

        public void CheckDiceRoll()
        {
            foreach(int i in diceValues)
            {
                Console.WriteLine(i);
            }
         
        }

        public void CheckingForDupRolls(int[] checkDupValues)
        {
            int duplicateCount;
            duplicateCount = checkDupValues.Length - checkDupValues.Distinct().Count();
            Console.Write("Number of dice duplicate ");
            Console.WriteLine(duplicateCount + 1);
        }


        private void CountDuplicates(int[] array)
        {
            var dict = new Dictionary<int, int>();
	
            foreach(var value in array)
            {
                if (dict.ContainsKey(value))
                    dict[value]++;
                else
                    dict[value] = 1;
            }
            foreach(var pair in dict)
            {
			    Console.WriteLine("Value {0} occurred {1} times.", pair.Key, pair.Value);
                if(pair.Value < 2){
                    Console.WriteLine("re-roll dice");
                }
                else if(pair.Value == 3){
                    Console.WriteLine("you scored 3 points");
                }
                else if(pair.Value == 4)
                {
                    Console.WriteLine("you scored 6 points");
                }

            }
        }
 


    }
}
