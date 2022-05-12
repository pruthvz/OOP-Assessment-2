using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment_2
{
    class Game
    {
        const int NUMBER_OF_PLAYERS = 2;
        public static List<Player> Players;
        public static int NumberOfRounds = 1;
        public int[] diceValues = new int[5];
        public static int RoundScore { get; set; }
        public bool reRoll = false;
        public int amountOfRerolls = 0; 

        public List<int> CompareScores = new List<int>() {}; // saves the players scores. 2 is more preferable.

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

                    // for (int j = 0; j < diceValues.Length; j++)
                    // {
                    //     int dieValue = dieObject.rollDice();
                    //     diceValues[j] = dieValue;
                    // }
                    // CountDuplicates(diceValues);
                    p.RollingDice();
                    CompareScores.Add(RoundScore);
                    DisplayScore();
                }
                GetRoundWinner(players);
          
            }
            DisplayWinner();      

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


        public void CountDuplicates(int[] array)
        {
            var dict = new Dictionary<int, int>();
            Die dieObj = new Die();
	
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
                if(pair.Value <= 1){
                    // var numIndex = array.Where(x=>x ==pair.Value);
                    array = Array.FindAll(array, i => i != pair.Key).ToArray();
                    amountOfRerolls++;
                }
            }
            for(int reRoll = 0; reRoll < amountOfRerolls; reRoll++)
            {
                int rerollValue = dieObj.ReRollDice(amountOfRerolls);
                array = array.Concat(new int[] {rerollValue}).ToArray();
            }

            foreach(int i in array)
            {
                Console.WriteLine(i);
            }

            AssignScore(array);
            // DisplayScore();
            ResetGameForNextPlayer(array); 

        }
        
        private void AssignScore(int[] arr)
        {
            var dict = new Dictionary<int, int>();
            foreach(var value in arr)
            {
                if(dict.ContainsKey(value))
                {
                    dict[value]++;
                }
                else
                {
                    dict[value] = 1;
                }

                foreach(var pair in dict)
                {
                    if(pair.Value == 3)
                    {
                        Console.WriteLine(">> You Scored 3 points");
                        RoundScore = 3;
                    }
                    else if (pair.Value == 4)
                    {
                        Console.WriteLine(">> You Scored 6 points");
                        RoundScore = 6;
                    }
                    else if (pair.Value == 5)
                    {
                        Console.WriteLine(">> You Scored 12 points");
                        RoundScore = 12;
                    }
                }
            }
        }
 
        public void DisplayScore()
        {
            Console.WriteLine("> Your Total Round Score was :" + RoundScore);
            RoundScore = 0; //reset value
        }

        private static void GetRoundWinner(List<Player> players)
        {
            int maxScore = 6;
            List<Player> winners = new List<Player>();

            foreach(Player p in players)
            {
                if(p.RoundScore >= maxScore)
                {
                    p.IncrementPlayerWins();
                }
            }
        }

        private void ViewScores()
        {
            foreach(int i in CompareScores)
            {
                Console.WriteLine(i);
            }
        }
        private void DisplayWinner()
        {
            List<Player> winners = new List<Player>();
            int PLAYER1_SCORE = CompareScores[0];
            int PLAYER2_SCORE = CompareScores[1];

            if (PLAYER1_SCORE > PLAYER2_SCORE)
            {
                Console.WriteLine("Player 1 Won!!");
            }
            else if (PLAYER1_SCORE < PLAYER2_SCORE)
            {
                Console.WriteLine("Player 2 Won!!");
            }
            else
            {
                Console.WriteLine("Tie!!");
            }

        }

        private void ResetGameForNextPlayer(int[] array){
            array  = new int[0];
            amountOfRerolls = 0;
        }
    }
}
