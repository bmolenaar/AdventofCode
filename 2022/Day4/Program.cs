using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string txtFile;
            txtFile = @"..\..\input.txt";

            string exampleFile;
            exampleFile = @"..\..\example.txt";

            Console.WriteLine("Part One:" + PartOne(Input(txtFile)));
            Console.WriteLine("Part Two: " + PartTwo(Input(txtFile)));
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
            int total = 0;

            for (int i = 0; i < input.Count; i++)
            {
                string[] splitter = input[i].Split('-', ',');
                int firstMin = Int16.Parse(splitter[0]);
                int firstMax = Int16.Parse(splitter[1]);
                int sndMin = Int16.Parse(splitter[2]);
                int sndMax = Int16.Parse(splitter[3]);

                if (firstMin <= sndMin && sndMax <= firstMax)
                {
                    total++;
                }
                else if(sndMin <= firstMin && firstMax <= sndMax)
                {
                    total++;
                }

            }

            return total;
        }

        public static int PartTwo(List<string> input)
        {
            int total = 0;

            for (int i = 0; i < input.Count; i++)
            {
                string[] splitter = input[i].Split('-', ',');
                int firstMin = Int16.Parse(splitter[0]);
                int firstMax = Int16.Parse(splitter[1]);
                int sndMin = Int16.Parse(splitter[2]);
                int sndMax = Int16.Parse(splitter[3]);

                if (firstMin <= sndMax && firstMax >= sndMin)
                {
                    total++;
                }

            }

            return total;
        }
    }

    
}
