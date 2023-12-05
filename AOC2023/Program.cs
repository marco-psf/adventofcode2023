// See https://aka.ms/new-console-template for more information

using AOC2023;

//AOC2.Main();
AOC3.Main();

public class AOC3
{
    static char[,] schematic;
    static Dictionary<string, int> numbers = new Dictionary<string, int>();

    public static void Main()
    {
        var input = File.ReadLines("input3.txt").ToList();
        var x = input.First().Length;
        var y = input.Count();

        schematic = new char[x, y];

        for (var i = 0; i < input.Count(); i++)
        {
            var line = input[i];
            for (var j = 0; j < line.Length; j++)
            {
                schematic[i, j] = line[j];
            }
        }

        for (var i = 0; i < schematic.GetLength(0); i++)
        {
            for (var j = 0; j < schematic.GetLength(1); j++)
            {
                ExtractNumbers(i, j);
            }
        }

        foreach(var number in numbers.Values)
        {
            Console.WriteLine(number);
        }
        var sum = numbers.Values.Sum();
        Console.Write(sum);
        Console.ReadLine();
    }

    public static void ExtractNumbers(int x, int y)
    {
        List<(int x, int y)> neighbours = new List<(int x, int y)>();
        neighbours.Add((x - 1, y - 1));
        neighbours.Add((x - 1, y));
        neighbours.Add((x - 1, y + 1));
        neighbours.Add((x, y + 1));
        neighbours.Add((x + 1, y + 1));
        neighbours.Add((x + 1, y));
        neighbours.Add((x + 1, y - 1));
        neighbours.Add((x, y - 1));

        var indexValue = GetValueAtIndex(x, y);

        if ('.'.Equals(indexValue))
            return;
        else if (indexValue.HasValue && char.IsDigit(indexValue.Value))
            return;

        foreach (var (neighbourX, neighbourY) in neighbours)
        {
            //process neighbours of point
            var neighbourValue = GetValueAtIndex(neighbourX, neighbourY);

            if (neighbourValue.HasValue)
            {
                //if number, get full number
                if (char.IsDigit(neighbourValue.Value))
                {
                    //put any number in dictionary with xy as key
                    var fullNumberResult = GetFullNumber(neighbourX, neighbourY);
                    var index = "" + fullNumberResult.Item1 + fullNumberResult.Item2;
                    numbers[index] = int.Parse(fullNumberResult.Item3);
                }
            }
        }
    }

    public static char? GetValueAtIndex(int x, int y)
    {
        if (x < 0 || x >= schematic.GetLength(0) || y < 0 || y >= schematic.GetLength(1))
            return null;

        return schematic[x, y];
    }

    public static (int, int, string) GetFullNumber(int x, int y)
    {
        var fullNumber = schematic[x, y].ToString();

        var leftY = y - 1;
        var rightY = y + 1;

        //go left
        bool searchLeft = true;
        while (searchLeft)
        {
            var leftValue = GetValueAtIndex(x, leftY);

            if (leftValue.HasValue)
            {
                if (char.IsDigit(leftValue.Value))
                {
                    fullNumber = leftValue.Value.ToString() + fullNumber.ToString();
                    leftY--;
                }
                else
                    searchLeft = false;
            }
            else
                searchLeft = false;

        }

        //go right
        bool searchRight = true;
        while (searchRight)
        {
            var rightValue = GetValueAtIndex(x, rightY);

            if (rightValue.HasValue)
            {
                if (char.IsDigit(rightValue.Value))
                {
                    fullNumber = fullNumber.ToString() + rightValue.Value.ToString();
                    rightY++;
                }
                else
                    searchRight = false;
            }
            else
                searchRight = false;
        }

        return (x, leftY, fullNumber);
    }
}