namespace AdventOfCode2025.Days.Day4;

public class Day4
{
    public static void Run()
    {
        List<string> lines = [];
        var filePath = "Days/Day4/Day4Input.txt";

        if (File.Exists(filePath))
        {
            lines.AddRange(File.ReadLines(filePath));
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }

        var grid = new string[lines.Count, lines[0].Length];

        for (var i = 0; i < lines.Count; i++)
        {
            for (var j = 0; j < lines[i].Length; j++)
            {
                grid[i, j] = lines[i][j].ToString();
            }
        }
        
        PrintGrid(grid);

        var totalRemoved = 0;
        var preRemoved = -1;

        while (totalRemoved != preRemoved)
        {
            preRemoved = totalRemoved;
            var removed = RemoveRolls(grid);
            
            totalRemoved += removed;
            Console.WriteLine($"Removed: {removed}");
        }
        
        Console.WriteLine($"Total removed: {totalRemoved}");
    }

    private static int RemoveRolls(string[,] grid)
    {
        var removed = 0;
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j] == "@")
                {
                    var neighbourCount = 0;
                    for (var vertical = -1; vertical <= 1; vertical++)
                    {
                        for (var horizontal = -1; horizontal <= 1; horizontal++)
                        {
                            try
                            {
                                var neighbour = grid[i + vertical, j + horizontal];
                                if (neighbour == "@" && !(vertical == 0 && horizontal == 0))
                                {
                                    neighbourCount++;
                                }
                            }
                            catch
                            {
                                // Ignore
                            }
                        }
                    }

                    if (neighbourCount < 4)
                    {
                        removed++;
                        grid[i, j] = "x";
                    }
                }
            }
        }
        
        return removed;
    }

    private static void PrintGrid(string[,] grid)
    {
        for (var i = 0; i < grid.GetLength(0); i++)
        {
            for (var j = 0; j < grid.GetLength(1); j++)
            {
                Console.Write(grid[i, j]);
            }
            Console.WriteLine();
        }
    }
}