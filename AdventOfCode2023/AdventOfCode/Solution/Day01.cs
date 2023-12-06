using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AdventOfCode.Solution
{
    internal class Day01 : Day
    {
        private string[] lines;

        public Day01() : base("Day01.txt")
        {

        }

        protected override void Initialize()
        {
            lines = ReadFile();
            //var numbersAsStrings = ReadFile();

            //numbers = Array.ConvertAll(numbersAsStrings, Convert.ToInt32);
        }

        protected override void SolutionPart1()
        {
            long number = 0;

            //foreach (var line in lines)
            //{
            //    var result = Regex.Matches(line, @"\d+").OfType<Match>().Select(m => m.Value);
            //    number += Int64.Parse(result.First() + result.Last());
            //}
            var firstNumber = "";
            var lastNumber = "";

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    var character = line.Substring(i, 1);

                    if (int.TryParse(character, out int n))
                    {
                        firstNumber = character;
                        break;
                    }
                }

                for (int i = line.Length-1; i >= 0; i--)
                {
                    var character = line.Substring(i, 1);

                    if (int.TryParse(character, out int n))
                    {
                        lastNumber = character;
                        break;
                    }
                }

                number += Int64.Parse(firstNumber + lastNumber);
            }

           
            Console.WriteLine("Result: " + number);
        }

        protected override void SolutionPart2()
        {
            var listOfNumbers = new[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var mapping = new Dictionary<string, string>() {
                { "one", "1"}, { "two", "2" }, { "three", "3"}, { "four", "4"}, { "five", "5"},
                { "six", "6"}, { "seven", "7"}, { "eight", "8"}, { "nine", "9"}
            };

            long number = 0;

            var firstNumber = "";
            var lastNumber = "";

            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    var character = line.Substring(i, 1);

                    if (int.TryParse(character, out int n))
                    {
                        firstNumber = character;
                        break;
                    }

                    //var start = 0;
                    var word = line.Substring(0, i + 1);

                    if(listOfNumbers.Any(num => word.Contains(num))) 
                    {
                        // which number did we find?
                        var res = listOfNumbers.Where(num => word.Contains(num)).First();
                        firstNumber = mapping[res];
                        break;
                    }
                }

                for (int i = line.Length - 1; i >= 0; i--)
                {
                    var character = line.Substring(i, 1);

                    if (int.TryParse(character, out int n))
                    {
                        lastNumber = character;
                        break;
                    }

                    var word = line.Substring(i-1, line.Length - (i-1));

                    if (listOfNumbers.Any(num => word.Contains(num)))
                    {
                        // which number did we find?
                        var res = listOfNumbers.Where(num => word.Contains(num)).First();
                        lastNumber = mapping[res];
                        break;
                    }
                }

                number += Int64.Parse(firstNumber + lastNumber);
            }


            Console.WriteLine("Result: " + number);
        }
    }
}
