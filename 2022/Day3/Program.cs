using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string txtFile;
            txtFile = @"..\..\input.txt";

            string exampleFile;
            exampleFile = @"..\..\example.txt";

            Console.WriteLine("Part 1: " + PartOne(Input(txtFile)));
            Console.WriteLine("Part 2: " + PartTwo(Input(txtFile)));
            Console.ReadLine();
        }

        public static List<string> Input(string file)
        {
            List<string> input = new List<string>();

            input.AddRange(File.ReadAllLines(file));

            return input;
        }

        public static int PartOne(List<string> input)
        {

            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = lowercase.ToUpper();
            string totalChars = lowercase + uppercase;

            int total = 0;

            for (int i = 0; i < input.Count; i++)
            {
                List<char> firstHalf = new List<char>();
                List<char> backHalf = new List<char>();
                int found = 0;

                for (int j = 0; j < input[i].Length; j++)
                {
                    if (j < input[i].Length / 2)
                    {
                        firstHalf.Add(input[i][j]);
                    }
                    else
                    {
                        backHalf.Add(input[i][j]);
                    }
                }

                for (int k = 0; k < firstHalf.Count; k++)
                {
                    if (backHalf.Contains(firstHalf[k]))
                    {
                        found += 1;
                        if (found < 2)
                        {
                            int sum = totalChars.IndexOf(firstHalf[k]) + 1;
                            total += sum;
                        }
                    }
                }

            }

            return total;
            
        }

        public static int PartTwo(List<string> input)
        {
            string lowercase = "abcdefghijklmnopqrstuvwxyz";
            string uppercase = lowercase.ToUpper();
            string totalChars = lowercase + uppercase;

            int total = 0;
            int cnt = 0;

            List<string> group = new List<string>();

            for (int i = 0; i < input.Count; i++)
            {

                if (group.Count == 3)
                {
                    for (int j = 0; j < group[0].Length; j++)
                    {
                        if (group[1].Contains(group[0][cnt]) && group[2].Contains(group[0][cnt]))
                        {
                            int sum = totalChars.IndexOf(group[0][cnt]) + 1;
                            total += sum;
                            cnt = 0;
                            break;
                        }
                        cnt++;
                    }

                    group.Clear();
                    group.Add(input[i]);
                }
                else
                {
                    group.Add(input[i]);
                }

            }

            if (group.Count == 3)
            {
                for (int j = 0; j < group[0].Length; j++)
                {
                    if (group[1].Contains(group[0][cnt]) && group[2].Contains(group[0][cnt]))
                    {
                        int sum = totalChars.IndexOf(group[0][cnt]) + 1;
                        total += sum;
                        cnt = 0;
                        break;
                    }
                    cnt++;
                }
            }

            return total;
        }
    }
}
