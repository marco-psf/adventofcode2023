using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2023
{
    public class AOC2
    {
        public static void Main()
        {
            var input = File.ReadLines("input.txt");
            Dictionary<string, int> dies = new Dictionary<string, int>();
            dies.Add("blue", 14);
            dies.Add("red", 12);
            dies.Add("green", 13);

            int idSum = 0;
            int setPowerSum = 0;

            foreach (var line in input)
            {
                var validGame = true;
                var minDies = new Dictionary<string, int>();

                var split = line.Split(":");
                var id = int.Parse(split[0].Split(" ")[1]);
                var split_2 = split[1];

                var split_3 = split_2.Split(";");

                foreach (var round in split_3)
                {
                    var split_4 = round.Split(",");

                    foreach (var split_5 in split_4)
                    {
                        var color = split_5.Trim().Split(" ")[1];
                        var amount = int.Parse(split_5.Trim().Split(" ")[0]);

                        if (!minDies.ContainsKey(color))
                            minDies[color] = amount;
                        else if (minDies[color] < amount)
                            minDies[color] = amount;

                        if (dies[color] < amount)
                            validGame = false;
                    }
                }

                int setPower = minDies["blue"] * minDies["red"] * minDies["green"];
                setPowerSum += setPower;

                if (validGame)
                    idSum += id;
            }
            Console.WriteLine(idSum);
            Console.WriteLine(setPowerSum);
            Console.ReadLine();
        }
    }
}
