using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {

            string txtFile;
            txtFile = @"..\..\input.txt";
            string exampleFile;
            exampleFile = @"..\..\example.txt";
            string answer = PartOne(Input(txtFile));
            string answer2 = PartTwo(Input(txtFile));
            Console.WriteLine("Part One: " + answer);
            Console.WriteLine("Part Two: " + answer2);

            Console.ReadLine();
        }

        public static List<string> Input(string file)
        {
            List<string> input = new List<string>();

            input.AddRange(File.ReadAllLines(file));


            return input;
        }

        public static string PartOne(List<string> input)
        {
            List<List<string>> startingStack = new List<List<string>>();
            List<string> instructions = new List<string>();

            for (int k = 0; k < 9; k++)
            {
                startingStack.Add(new List<string>());
            }

            for (int i = 0; i < input.Count; i++)
            {

                if (String.IsNullOrWhiteSpace(input[i]) || input[i][1] == '1')
                {
                    continue;
                }
                else if(input[i][0] == 'm')
                {
                    instructions.Add(input[i]);
                }
                else
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (Char.IsLetter(input[i][j]))
                        {

                            switch (j)
                            {
                                case 1:
                                    startingStack[0].Add(input[i][j].ToString());
                                    break;
                                case 5:
                                    startingStack[1].Add(input[i][j].ToString());
                                    break;
                                case 9:
                                    startingStack[2].Add(input[i][j].ToString());
                                    break;
                                case 13:
                                    startingStack[3].Add(input[i][j].ToString());
                                    break;
                                case 17:
                                    startingStack[4].Add(input[i][j].ToString());
                                    break;
                                case 21:
                                    startingStack[5].Add(input[i][j].ToString());
                                    break;
                                case 25:
                                    startingStack[6].Add(input[i][j].ToString());
                                    break;
                                case 29:
                                    startingStack[7].Add(input[i][j].ToString());
                                    break;
                                case 33:
                                    startingStack[8].Add(input[i][j].ToString());
                                    break;
                            }

                            continue;
                        }
                    }
                }
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                string[] values = Regex.Split(instructions[i], @"\D+");
                values[0] = values[1];
                values[1] = values[2];
                values[2] = values[3];
     
                for (int j = 0; j < Int16.Parse(values[0]); j++)
                {
                    startingStack[Int16.Parse(values[2]) - 1].Insert(0, startingStack[Int16.Parse(values[1]) - 1][0]);
                    
                    startingStack[Int16.Parse(values[1]) - 1].Remove(startingStack[Int16.Parse(values[1]) - 1][0]);
                }

            }

            string answer = "";

            for (int i = 0; i < startingStack.Count; i++)
            {
                if (startingStack[i].Any())
                {
                    answer += startingStack[i].First();
                }
                
            }

            return answer;
        }

        public static string PartTwo(List<string> input)
        {
            List<List<string>> startingStack = new List<List<string>>();
            List<string> instructions = new List<string>();

            for (int k = 0; k < 9; k++)
            {
                startingStack.Add(new List<string>());
            }

            for (int i = 0; i < input.Count; i++)
            {

                if (String.IsNullOrWhiteSpace(input[i]) || input[i][1] == '1')
                {
                    continue;
                }
                else if (input[i][0] == 'm')
                {
                    instructions.Add(input[i]);
                }
                else
                {
                    for (int j = 0; j < input[i].Length; j++)
                    {
                        if (Char.IsLetter(input[i][j]))
                        {

                            switch (j)
                            {
                                case 1:
                                    startingStack[0].Add(input[i][j].ToString());
                                    break;
                                case 5:
                                    startingStack[1].Add(input[i][j].ToString());
                                    break;
                                case 9:
                                    startingStack[2].Add(input[i][j].ToString());
                                    break;
                                case 13:
                                    startingStack[3].Add(input[i][j].ToString());
                                    break;
                                case 17:
                                    startingStack[4].Add(input[i][j].ToString());
                                    break;
                                case 21:
                                    startingStack[5].Add(input[i][j].ToString());
                                    break;
                                case 25:
                                    startingStack[6].Add(input[i][j].ToString());
                                    break;
                                case 29:
                                    startingStack[7].Add(input[i][j].ToString());
                                    break;
                                case 33:
                                    startingStack[8].Add(input[i][j].ToString());
                                    break;
                            }

                            continue;
                        }
                    }
                }
            }

            for (int i = 0; i < instructions.Count; i++)
            {
                string[] values = Regex.Split(instructions[i], @"\D+");
                values[0] = values[1];
                values[1] = values[2];
                values[2] = values[3];

                List<string> newVals = new List<string>();

                for (int k = 0; k < Int16.Parse(values[0]); k++)
                {
                    newVals.Add(startingStack[Int16.Parse(values[1])-1][k]);
                }

                startingStack[Int16.Parse(values[2]) - 1].InsertRange(0, newVals);
                
                startingStack[Int16.Parse(values[1]) -1].RemoveRange(0, Int16.Parse(values[0]));


            }

            string answer = "";

            for (int i = 0; i < startingStack.Count; i++)
            {
                if (startingStack[i].Any())
                {
                    answer += startingStack[i].First();
                }

            }

            return answer;
        }
    }
}
