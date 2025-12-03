namespace AdventOfCode2025.Days.Day3;

public class Day3
{
    public static void Run()
    {
        List<string> lines = [];
        var filePath = "Days/Day3/Day3Input.txt";
            
        if (File.Exists(filePath))
        {
            lines.AddRange(File.ReadLines(filePath));
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }
        
        double total = 0;
        foreach (var line in lines)
        {
            total += LargeMaxJoltage(line);
        }
        
        Console.WriteLine($"Total Joltage: {total}");
    }

    private static int MaxJoltage(string batteryBank)
    {
        var batteryBankArray = batteryBank.ToCharArray();
        var char1 = batteryBankArray[0];
        var char2 = batteryBankArray[1];

        for (var i = 2; i < batteryBankArray.Length; i++)
        {
            if (char2 > char1)
            {
                char1 = char2;
                char2 = batteryBankArray[i];
                continue;
            }

            if (batteryBankArray[i] > char2)
            {
                char2 = batteryBankArray[i];
                continue;
            }
        }
        
        Console.WriteLine($"Max Joltage: {char1 + "" + char2}");
        return Convert.ToInt32(char1 + "" + char2);
    }

    private static double LargeMaxJoltage(string batteryBank)
    {
        Console.WriteLine($"Battery Bank: {batteryBank}");
        var batteryBankArray = batteryBank.ToCharArray();
        var bestBatteryArray = batteryBankArray[..12];

        for (var i = 12; i < batteryBankArray.Length; i++)
        {
            var shifted = false;
            for (var j = 1; j < bestBatteryArray.Length; j++)
            {
                if (bestBatteryArray[j] > bestBatteryArray[j - 1])
                {
                    for (var k = j; k < bestBatteryArray.Length; k++)
                    {
                        bestBatteryArray[k-1] = bestBatteryArray[k];
                    }
                    bestBatteryArray[11] = batteryBankArray[i];

                    shifted = true;
                }

                if (shifted)
                {
                    break;
                }
            }

            if (batteryBankArray[i] > bestBatteryArray[11])
            {
                bestBatteryArray[11] = batteryBankArray[i];
                continue;
            }
        }


        double maxJoltage = 0;
        for (var i = bestBatteryArray.Length - 1; i >= 0; i--)
        {
            maxJoltage += Convert.ToInt32(bestBatteryArray[i].ToString()) * Math.Pow(10, bestBatteryArray.Length - 1 - i);
        }
        
        Console.WriteLine($"Max Joltage: {maxJoltage}");
        return maxJoltage;
    }
    
}