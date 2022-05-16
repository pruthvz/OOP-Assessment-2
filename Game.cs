using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_Assessment_2
{
    class Game
    {
        public static List<Player> Players; // player lists
        public int[] diceValues = new int[5]; // this list will contain all the 5 dice values the player rolled.
        public static int RoundScore { get; set; }
        public bool reRoll = false;
        public int amountOfRerolls = 0; // if there are dupes in the rolls then the amount of rolls will be assigned to a number.

        public List<int> CompareScores = new List<int>() {}; // saves the players scores. 2 is more preferable.
        public List<int> TotalWins = new List<int>() {0,0}; // saves all the wins. 

        // a setup function which will start up the entire game. it will ask the user for an input to get the game started.
        public int Setup()
        {
            GameSettings settingObj = new GameSettings();
            settingObj.GameRules(); // applies all the game rules;
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

        // start function will get all the players and begin the dice game.
        public void Start()
        {
            // if the number of players is = 1 then the game cannot start, since the game is meant for 2 players.
            if(GameSettings.NumberOfPlayers <= 1)
            {
                Console.WriteLine("Please change the Number of Players == 2, No more than 2.");
            }
            else
            {
                GetPlayers();
                DisplayPlayers();
                Begin(Players);
                Setup();
            }
        }
        // Quit function simply terminates the program by returning a 0
        public static int Quit()
        {
            return 0;
        }

        // the get player function will return all the players in the player list.
        public void GetPlayers()
        {
            Players = new List<Player>();
            for (int i = 1; i <= GameSettings.NumberOfPlayers ; i++)
            {
                Player player = new Player(i);
                Players.Add(player);
            }
        }

        // the display player function will use the player list to loop through all the users and display all the players.
        public void DisplayPlayers()
        {
            Console.WriteLine("Players in the game....");

            foreach(Player p in Players)
            {
                Console.WriteLine(p.PlayerNo + ". "+ p.Name);
            } 
        }

        // the begin function takes in a player as a list, because when the dice rolling function is called the score is saved to a particlar player.
        public void Begin(List<Player> players)
        {
            // checks for how many rounds the game will have by using the variable in GameSettings.cs
            for (int i = 1; i <= GameSettings.TotalRounds; i++)
            {
                // the program will loop through the dice roll depending on how many players are in the list.
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
                    p.RollingDice(); // rolls the dice.
                    CompareScores.Add(RoundScore); // saves the players final score to a list.
                    DisplayScore(); // displays to the user what the player rolled.
                }
                DisplayWinner(); // displays the round winner.     
            }
            DisplayWins(TotalWins[0], TotalWins[1]); // << passes the two indexs in the list to assign the new user score.

        }

        // displays all the dice values.
        public void CheckDiceRoll()
        {
            foreach(int i in diceValues)
            {
                Console.WriteLine(i);
            }
         
        }

        // CheckingForDupRolls checks if there are any duplicate values in the rolls. If there are then it will allow the user to reroll again the remaining ones that aren't dupes.
        public void CheckingForDupRolls(int[] checkDupValues)
        {
            int duplicateCount;
            duplicateCount = checkDupValues.Length - checkDupValues.Distinct().Count();
            Console.Write("Number of dice duplicate ");
            Console.WriteLine(duplicateCount + 1);
        }

        // This function will also count all the dupes and display to the user which values occured more than ones. And allow the user to re-roll the remaining dice.
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
                    amountOfRerolls++; // incremeants depending on how many weren't dupes.
                }
            }
            // this for loop will go through the diceValues that the user rolled first, and then have the ones that weren't dupes removed from the list and add the new re-rolled values to the list.
            for(int reRoll = 0; reRoll < amountOfRerolls; reRoll++)
            {
                int rerollValue = dieObj.ReRollDice(amountOfRerolls);
                array = array.Concat(new int[] {rerollValue}).ToArray();
            }
            // displays the new list with the re-rolled values.
            foreach(int i in array)
            {
                Console.WriteLine(i);
            }

            AssignScore(array); // AssigningScore will check if there are 3-of-a-kind and assign score depending on the if statement.
            // DisplayScore();
            ResetGameForNextPlayer(array); 

        }

        // assign score to the user depending on what the if statements say. If there are 3-of-a-kind then the player will score 3 points. 
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
        
        // the program will display to the user what they scored in total during the round.
        public void DisplayScore()
        {
            Console.WriteLine("> Your Total Round Score was :" + RoundScore);
            RoundScore = 0; //reset value
        }
        // for debuging, to see if the scores were being added to the array.
        private void ViewScores()
        {
            foreach(int i in CompareScores)
            {
                Console.WriteLine(i);
            }
        }
        // Here depending on what user won the round, the array TotalWins will incremeant its index. 
        private void DisplayWinner()
        {
            List<Player> winners = new List<Player>();
            int PLAYER1_SCORE = CompareScores[0];
            int PLAYER2_SCORE = CompareScores[1];


            if (PLAYER1_SCORE > PLAYER2_SCORE)
            {
                Console.WriteLine("→ Player 1 won this round.");
                TotalWins[0]++;
                
            }
            else if (PLAYER1_SCORE < PLAYER2_SCORE)
            {
                Console.WriteLine("→ Player 2 won this round.");
                TotalWins[1]++;
            }
            else
            {
                Console.WriteLine("→ Tie!!");
            }

            CompareScores.Clear(); // reset the values so the next player doesn't get unfair rolls/score.
            Console.WriteLine(">> PLAYER STATS → PLAYER1 WINS " + TotalWins[0] + " PLAYER 2 WINS "  + TotalWins[1]); // tally up the total wins.
        }

        // depending on the total wins after certain rounds. the winner of the game will be annonced here.
        public void DisplayWins(int player1Wins, int player2Wins)
        {
            if(player1Wins > player2Wins)
            {
                Console.WriteLine(">> Congrats PLAYER 1 you have won the game!");
            }
            else if(player1Wins < player2Wins)
            {
                Console.WriteLine(">> Congrats PLAYER 2 you have won the game!");
            }
            else
            {
                Console.WriteLine(">> It was a tie!!");
            }
            // Console.WriteLine(TotalWins[0] + " " +  TotalWins[1]);
            // a try and catch statement to check if another index is added for example. TotalWins[3]; which will cause the program to crash.
            try 
            {
                // reset the total wins after the game is finished.
                TotalWins[0] = 0;
                TotalWins[1] = 0; 
            }
           catch(IndexOutOfRangeException)
            {
                Console.WriteLine("An index was out of range!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("Some sort of error occured: " + ex.Message);
            }

            Console.WriteLine("\n");
        }

        // this function will reset all the amount of re rolls, the diceValues etc when the game is finished.
        private void ResetGameForNextPlayer(int[] array){
            array  = new int[0];
            amountOfRerolls = 0;
        }
    }
}
