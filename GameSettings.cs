using System.Collections.Generic;
using System.Linq;
using System;


namespace OOP_Assessment_2
{
    class GameSettings
    {
        // these public variables are hard coded right now. But it can be assigned using user input.
        public static int TotalRounds { get; set; } = 2;
        public static int NumberOfPlayers  {get; set;} = 2;

        // a basic game rule display for the game.
        public void GameRules()
        {
            Console.WriteLine("The score will be determined by amount of same rolls you get.");
            Console.WriteLine("If the player scores 2-of-a-kind they will roll the remaining dice.");
            Console.WriteLine("3-of-a-kind : 3 Points");
            Console.WriteLine("4-of-a-kind : 6 Points");
            Console.WriteLine("5-of-a-kind : 12 Points");
        }
    }
}