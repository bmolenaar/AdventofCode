using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day2
{
    class Program
    {
        public static string txtFile;

        static void Main(string[] args)
        {
            int total;
            txtFile = @"..\..\input.txt";
            total = CalcScore(Input(txtFile));
            Console.WriteLine("Day 1: " + total);
            Console.WriteLine("Day 2: " + PartTwo(Input(txtFile)));
            Console.ReadLine();
        }

        public static List<string> Input(string file)
        {
            List<string> input = new List<string>();

            input.AddRange(File.ReadAllLines(file));


            return input;
        }

        public static int CalcScore(List<string> input)
        {
            int totalScore = 0;

            int win = 6;
            int lose = 0;
            int draw = 3;

            int rock = 1;
            int paper = 2;
            int scissors = 3;

            //A = Rock, B = Paper, C = Scissors
            //X = Rock, Y = Paper, Z = Scissors
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i][2] == Char.Parse("X"))
                {
                    switch (input[i][0])
                    {
                        case 'A':
                            totalScore += (rock + draw);
                            break;
                        case 'B':
                            totalScore += (rock + lose);
                            break;
                        case 'C':
                            totalScore += (rock + win);
                            break;
                    }
                }
                else if (input[i][2] == Char.Parse("Y"))
                {
                    switch (input[i][0])
                    {
                        case 'A':
                            totalScore += (paper + win);
                            break;
                        case 'B':
                            totalScore += (paper + draw);
                            break;
                        case 'C':
                            totalScore += (paper + lose);
                            break;
                    }
                }
                else
                {
                    switch (input[i][0])
                    {
                        case 'A':
                            totalScore += (scissors + lose);
                            break;
                        case 'B':
                            totalScore += (scissors + win);
                            break;
                        case 'C':
                            totalScore += (scissors + draw);
                            break;
                    }
                }
            }

            return totalScore;
        }

        public static int PartTwo(List<string> input)
        {
            int totalScore = 0;

            int win = 6;
            int lose = 0;
            int draw = 3;

            int rock = 1;
            int paper = 2;
            int scissors = 3;

            //A = Rock, B = Paper, C = Scissors
            //X = Lose, Y = Draw, Z = Win
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i][0] == Char.Parse("A"))
                {
                    switch (input[i][2])
                    {
                        case 'X':
                            totalScore += (scissors + lose);
                            break;
                        case 'Y':
                            totalScore += (rock + draw);
                            break;
                        case 'Z':
                            totalScore += (paper + win);
                            break;
                    }
                }
                else if (input[i][0] == Char.Parse("B"))
                {
                    switch (input[i][2])
                    {
                        case 'X':
                            totalScore += (rock + lose);
                            break;
                        case 'Y':
                            totalScore += (paper + draw);
                            break;
                        case 'Z':
                            totalScore += (scissors + win);
                            break;
                    }
                }
                else
                {
                    switch (input[i][2])
                    {
                        case 'X':
                            totalScore += (paper + lose);
                            break;
                        case 'Y':
                            totalScore += (scissors + draw);
                            break;
                        case 'Z':
                            totalScore += (rock + win);
                            break;
                    }
                }
            }

            return totalScore;
        }
    }
}
