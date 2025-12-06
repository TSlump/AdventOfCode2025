using AdventOfCode2025.Days.Day1;
using AdventOfCode2025.Days.Day2;
using AdventOfCode2025.Days.Day3;
using AdventOfCode2025.Days.Day4;
using AdventOfCode2025.Days.Day5;
using AdventOfCode2025.Days.Day6;

Console.WriteLine("Advent of Code-2025 \n");

var day = 6;

switch (day)
{
    case 1:
        Console.WriteLine("Day 1");
        Day1.Run();
        break;
    
    case 2:
        Console.WriteLine("Day 2");
        Day2.Run();
        break;
    
    case 3:
        Console.WriteLine("Day 3");
        Day3.Run();
        break;
    
    case 4:
        Console.WriteLine("Day 4");
        Day4.Run();
        break;
    
    case 5:
        Console.WriteLine("Day 5");
        Day5.Run();
        break;
    
    case 6:
        Console.WriteLine("Day 6");
        Day6.RunPartOne();
        Day6.RunPartTwo();
        break;
}