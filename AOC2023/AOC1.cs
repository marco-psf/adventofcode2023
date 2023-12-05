using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023
{
    public class AOC1
    {
        public static void Main()
        {
            List<string> input = File.ReadLines("input.txt").ToList();
            var digitDict = new Dictionary<string, string>();
            digitDict.Add("one", "1");
            digitDict.Add("two", "2");
            digitDict.Add("three", "3");
            digitDict.Add("four", "4");
            digitDict.Add("five", "5");
            digitDict.Add("six", "6");
            digitDict.Add("seven", "7");
            digitDict.Add("eight", "8");
            digitDict.Add("nine", "9");

            var sum = 0;
            foreach (var line in input)
            {
                //cqjsfxvcfdseightfour9g857
                if (line.Contains("cfdseightfour9g857"))
                {
                    var debug = true;
                }

                var leftDigit = string.Empty;
                var rightDigit = string.Empty;

                var temp = string.Empty;

                //traverse from left
                for (int i = 0; i < line.Length; i++)
                {
                    var c = line[i].ToString();

                    temp += c;
                    if (digitDict.ContainsKey(temp))
                    {
                        leftDigit = digitDict[temp];
                        temp = string.Empty;
                        break;
                    }
                    if (digitDict.Keys.Any(k => k.StartsWith(temp)))
                    {
                        continue;
                    }
                    else if (temp.Length > 1)
                    {
                        i -= temp.Length - 1;
                        temp = string.Empty;
                    }
                    else
                    {
                        temp = string.Empty;
                    }

                    if (int.TryParse(c, out var throwaway))
                    {
                        leftDigit = c;
                        break;
                    }
                }

                //traverse from right
                for (int i = line.Length - 1; i >= 0; i--)
                {
                    var c = line[i].ToString();

                    temp = c += temp;
                    if (digitDict.ContainsKey(temp))
                    {
                        rightDigit = digitDict[temp];
                        temp = string.Empty;
                        break;
                    }
                    else if (digitDict.Keys.Any(k => k.EndsWith(temp)))
                    {
                        continue;
                    }
                    else if (temp.Length > 1)
                    {
                        i += temp.Length - 1;
                        temp = string.Empty;
                    }
                    else
                    {
                        temp = string.Empty;
                    }


                    if (int.TryParse(c, out var throwaway))
                    {
                        rightDigit = c;
                        break;
                    }
                }

                var linesum = int.Parse(leftDigit + rightDigit);
                Console.WriteLine(linesum + " " + line);
                sum += linesum;
            }
            Console.WriteLine(sum);
            Console.ReadLine();
        }
    }
}
