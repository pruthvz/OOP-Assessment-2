using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment_2
{
    class Game
    {

        public static List<Player> Players;
        public static int NumberOfRounds = 2;
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
            for (int i = 1; i <= 2; i++)
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
                    int[] diceValues = new int[5];

                    for (int j = 0; j < diceValues.Length; j++)
                    {
                        int dieValue = dieObject.rollDice();
                        Console.WriteLine(dieValue);
                        diceValues[j] = dieValue;
                    }
                }
          
            }

        }
 


    }
}
