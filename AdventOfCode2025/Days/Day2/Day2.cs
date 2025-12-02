namespace AdventOfCode2025.Days.Day2;

public class Day2
{
    public static void Run()
    {
        string[] lines = [];
        var filePath = "Days/Day2/Day2Input.txt";
            
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                lines = line.Split(",");
            }
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }
        
        long total = 0;
        foreach (var line in lines)
        {
            Console.WriteLine(line);
            
            var ranges = line.Split("-");
            for (var i = Convert.ToInt64(ranges[0]); i <= Convert.ToInt64(ranges[1]); i++)
            {
                if (IsInvalid(i.ToString()))
                {
                    total += i;
                }
            }
        }
        
        Console.WriteLine(total);
    }

    private static bool IsInvalid(string x)
    {
        var patternLength = 1;
        while (patternLength <= x.Length / 2)
        {
            var pattern = x[..patternLength];

            if (x.Length % patternLength != 0)
            {
                patternLength++;
                continue;
            }
            var patternRepCount = x.Length / patternLength;

            if (string.Concat(Enumerable.Repeat(pattern, patternRepCount)) == x)
            {
                Console.WriteLine($"Invalid Id: {x}");
                return true;
            }

            patternLength++;
        }

        return false;
    }
}