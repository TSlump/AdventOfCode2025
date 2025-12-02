namespace AdventOfCode2025.Days.Day1;

public class Day1
{
    public static void Run()
    {
        List<string> lines = [];
        var filePath = "Days/Day1/Day1Input.txt";
            
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                lines.Add(line);
            }
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }

        var pointer = 50;
        var lastPointerWasZero = false;
        var zeroCount = 0;
        foreach (var line in lines)
        {
            Console.WriteLine($"{pointer}: {line}");
            
            var direction = line[..1];
            var distance = int.Parse(line[1..]);

            if (direction == "L")
            {
                pointer -= distance % 100;
            }
            else if (direction == "R")
            {
                pointer += distance % 100;
            }
            
            if (pointer is > 100 or < 0 && lastPointerWasZero == false)
            {
                zeroCount++;
            }
            
            zeroCount += distance / 100;
            
            pointer = (pointer % 100 + 100) % 100;
            
            if (pointer == 0)
            {
                zeroCount++;
                lastPointerWasZero = true;
            }
            else
            {
                lastPointerWasZero = false;
            }
            
            Console.WriteLine($"{pointer}: {line}");
            Console.WriteLine($"Zero count: {zeroCount}");
            Console.WriteLine();
        }
        
        Console.WriteLine($"Zero count: {zeroCount}");
    }
}