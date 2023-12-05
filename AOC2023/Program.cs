// See https://aka.ms/new-console-template for more information

//AOC2.Main();
AOC3.Main();

public class AOC3
{
    public static void Main()
    {
        var input = File.ReadLines("input3.txt").ToList();
        var x = input.First().Length;
        var y = input.Count();

        string[,] schematic = new string[x, y];

        for (var i = 0; i < input.Count(); i++)
        {
            var line = input[i];
            for (var j = 0; j < line.Length; j++)
            {
                schematic[i, j] = line[j].ToString();
            }
        }

        Dictionary<string, string> partNumbers = new Dictionary<string, string>();

        Console.ReadLine();
    }

    public static void ProcessPoint(int x, int y)
    {
        //process neighbours of point
        //if number, get full number
        //put any number in dictionary with xy as key
    }

    public static string GetFullNumber(int x, int y)
    {
        return "";
    }

    public static bool IsNumber(string input)
    {
        return false;
    }
}

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