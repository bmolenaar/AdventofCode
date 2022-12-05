using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Day1
{
    class Program
    {
        public static string txtFile;
        
        static void Main(string[] args)
        {
            txtFile = @"..\..\input.txt";
            int answer = Calc(Input(txtFile));
            Console.WriteLine(answer);
            Console.ReadLine();
        }


        public static List<string> Input(string file)
        {
            List<string> input = new List<string>();

            input.AddRange(File.ReadAllLines(file));


            return input;
        }

        static int Calc(List<string> input)
        {
            int cnt = 0;
            int max = 0;
            List<int> totals = new List<int>();
            List<int> highest = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                if (!String.IsNullOrEmpty(input[i]))
                {
                    cnt += Int32.Parse(input[i]);
                }
                else
                {
                    totals.Add(cnt);
                    cnt = 0;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                highest.Add(totals.Max());
                totals.Remove(totals.Max());

            }

            return highest.Sum();
        }
    }
}
