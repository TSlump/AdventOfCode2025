using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2025.Days.Day6;

public class Day6
{
    public static void RunPartOne()
    {
        List<int[]> numbersList = [];
        List<string> operations = [];
        var filePath = "Days/Day6/Day6Input.txt";

        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (line[0] is '*' or '+')
                {
                    operations = line.Where(o => o is '+' or '*').Select(o => o.ToString()).ToList();
                }
                else
                {
                    numbersList.Add(Regex.Matches(line, @"\d+").Select(m => Convert.ToInt32(m.Value)).ToArray());
                }
            }
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }
        
        Console.WriteLine($"Operations count: {operations.Count}");
        Console.WriteLine($"Width lenght is: {numbersList[0].Length}");

        long total = 0;
        for (var i = 0; i < operations.Count; i++)
        {
            long output = numbersList[0][i];
            for (var j = 1; j < numbersList.Count; j++)
            {
                switch (operations[i])
                {
                    case "*":
                        output *= numbersList[j][i];
                        break;
                    case "+":
                        output += numbersList[j][i];
                        break;
                }
            }
            
            total += output;
        }
        
        Console.WriteLine("Part One:");
        Console.WriteLine($"Total: {total}");
    }

    public static void RunPartTwo()
    {
        string[] lines = [];
        var filePath = "Days/Day6/Day6Input.txt";
        
        if (File.Exists(filePath))
        {
            lines = File.ReadAllLines(filePath);
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }

        List<int> numbers = [];
        BigInteger total = 0;
        for (var i = lines[0].Length - 1; i >= 0; i--)
        {
            var number = "";
            //Console.WriteLine($"Line: {string.Join("",lines.Select(c => c[i]).ToList())}");
            //Console.WriteLine($"Numbers: {string.Join(" ", numbers)}");
            foreach (var line in lines)
            {
                switch (line[i])
                {
                    case ' ':
                        continue;
                    case '+' or '*':
                    {
                        numbers.Add(Convert.ToInt32(number));
                        var output = CalculateOutput(line[i], numbers);
                        total += output;
                        numbers.Clear();
                        number = "";
                    
                        Console.WriteLine($"output: {output}");
                        break;
                    }
                    default:
                        number += line[i];
                        break;
                }
            }

            if (number != "")
            {
                numbers.Add(Convert.ToInt32(number));
            }
        }
        
        Console.WriteLine("Part Two:");
        Console.WriteLine($"Total: {total}");
    }

    private static BigInteger CalculateOutput(char operation, List<int> numbers)
    {
        Console.WriteLine(string.Join($"{operation}", numbers));
        
        return operation switch
        {
            '+' => numbers.Sum(),
            '*' => numbers.Aggregate(1L, (current, number) => current * number),
            _ => 0
        };
    }
}