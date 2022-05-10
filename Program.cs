using System;

namespace OOP_Assessment_2
{
    class Program
    {
        static void Main()
        {
            Game gameObject = new Game();
            Die dieObject = new Die();

            int[] diceValues = new int[5];

            for (int i = 0; i < diceValues.Length; i++)
            {
                int dieValue = dieObject.rollDice();
                Console.WriteLine(dieValue);
                diceValues[i] = dieValue;
            }

            Console.WriteLine("\n");
            foreach(int i in diceValues){
                Console.WriteLine(i);
            }
            
          
        }
    }
}
