using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Efron_Experimental
{
    class Program
    {
        static void Main(string[] args)
        {
            string @continue = "y";
            do
            {
                Random rnd = new Random();
                Console.Write("Select a die for player 1 to throw: ");
                string player1Die = Console.ReadLine();
                //finish the support code
                Console.Write("Select a die for player 2 to throw: ");
                string player2Die = Console.ReadLine();
                Console.Write("Enter number of trials: ");
                try
                {
                    int trials = Int32.Parse(Console.ReadLine());
                    EfronTrials(player1Die, player2Die, trials,rnd);
                }
                catch(FormatException)
                {
                    Console.WriteLine("Enter numeric values only");
                }
                Console.Write("Again? ");
                @continue = Console.ReadLine();
            }
            while (@continue.Equals("y"));

        }
        static int EfronThrow(string die, Random r)
        {
            int seed = r.Next(6);
            //Console.WriteLine(seed);
            int retVal = 0;
            switch(die)
            {
                case "a":
                case "A":
                    {
                        if (seed < 2) 
                        {
                            return 0;
                        }
                        else 
                        {
                            return 4;
                        }
                    }
                case "b":
                case "B": 
                    {
                        return 3;
                    }
                case "c":
                case "C":
                    {
                        if (seed < 2)
                        {
                            return 6;
                        }
                        else
                        {
                            return 2;
                        }
                    }
                case "d":
                case "D":
                    {
                        if (seed < 3)
                        {
                            return 1;
                        }
                        else
                        {
                            return 5;
                        }
                    }
                default:
                    return retVal;
            }
        }
        static void EfronTrials(string p1, string p2, int trials,Random rnd) 
        {
            int p1Result;
            int p1Wins = 0;
            int p2Result;
            int p2Wins = 0;
            int ties = 0;
            for (int i = 0; i < trials; i++)
            {
                p1Result = EfronThrow(p1, rnd);
                p2Result = EfronThrow(p2, rnd);
                if (p1Result > p2Result)
                {
                    p1Wins++;
                }
                else if (p2Result > p1Result)
                {
                    p2Wins++;
                }
                else ties++;
            }
            Console.WriteLine("Player 1 wins: " + p1Wins);
            Console.WriteLine("Player 2 wins: " + p2Wins);
            Console.WriteLine("Ties: " + ties);
        }
    }
}
