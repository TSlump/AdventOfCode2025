
namespace AdventOfCode2025.Days.Day5;

public class Day5
{
    public static void Run()
    {
        List<(long, long)> ranges = [];
        List<long> ids = [];
        var filePath = "Days/Day5/Day5Input.txt";

        var rangeSection = true;
        if (File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                if (line == "")
                {
                    rangeSection = false;
                    continue;
                }

                if (rangeSection)
                {
                    var split = line.Split('-');
                    ranges.Add((Convert.ToInt64(split[0]), Convert.ToInt64(split[1])));
                    
                    if (Convert.ToInt64(split[1]) < Convert.ToInt64(split[0]))
                    {
                        Console.WriteLine("Bad range !!!!!");
                        throw new Exception();
                    }
                }
                else
                {
                    ids.Add(Convert.ToInt64(line));
                }
            }
        }
        else
        {
            Console.WriteLine("File not found: " + filePath);
        }

        var totalFresh = 0;
        foreach (var id in ids)
        {
            foreach (var range in ranges)
            {
                if (id >= range.Item1 && id <= range.Item2)
                {
                    totalFresh++;
                    break;
                }
            }
        }
        
        Console.WriteLine("Part 1:");
        Console.WriteLine($"Total fresh: {totalFresh}");

        var compressedRanges = CompressRanges(ranges);

        long totalIds = 0;
        foreach (var compressedRange in compressedRanges)
        {
            Console.WriteLine(compressedRange.Item1 + " " + compressedRange.Item2);
            totalIds += compressedRange.Item2 - compressedRange.Item1 + 1;
        }
        
        Console.WriteLine($"Total ids: {totalIds}");
    }

    private static List<(long, long)> CompressRanges(List<(long, long)> ranges)
    {
        var compressedRanges = new List<(long, long)> { ranges[0] };
        var debug = true;
        
        Console.WriteLine($"Range length: {ranges.Count}");

        for (var i = 1; i < ranges.Count; i++)
        {
            Console.WriteLine($"Compressed range length: {compressedRanges.Count}");
            
            if (debug)
                Console.WriteLine($"Range: {ranges[i].Item1} - {ranges[i].Item2}");
            foreach (var compressedRange in compressedRanges)
            {
                if (debug)
                    Console.WriteLine(compressedRange.Item1 + "-" + compressedRange.Item2);
            }
            
            //Insert at start
            if (ranges[i].Item2 < compressedRanges[0].Item1)
            {
                if (debug)
                    Console.WriteLine("Adding at start");
                compressedRanges.Insert(0,ranges[i]);
                continue;
            }
            
            //Add to end
            if (ranges[i].Item1 > compressedRanges[^1].Item2)
            {
                if (debug) 
                    Console.WriteLine("Adding at end");
                compressedRanges.Add(ranges[i]);
                continue;
            }
            
            for (var j = 0; j < compressedRanges.Count; j++)
            {
                //Check Overlaps
                if (ranges[i].Item1 <= compressedRanges[j].Item2 && ranges[i].Item2 >= compressedRanges[j].Item1)
                {
                    if (debug) 
                        Console.WriteLine($"Overlap found with: {ranges[i].Item1}-{ranges[i].Item2} and {compressedRanges[j].Item1}-{compressedRanges[j].Item2}");
                    
                    compressedRanges[j] = (Math.Min(ranges[i].Item1, compressedRanges[j].Item1), Math.Max(ranges[i].Item2, compressedRanges[j].Item2));

                    // Check if new range hits the next range
                    if (j <= compressedRanges.Count - 2 && compressedRanges[j+1].Item1 <= compressedRanges[j].Item2)
                    {
                        if (debug) 
                            Console.WriteLine($"New overlap created, merging {compressedRanges[j].Item1}-{compressedRanges[j].Item2} and {compressedRanges[j + 1].Item1}-{compressedRanges[j + 1].Item2}");
                        compressedRanges[j] = (compressedRanges[j].Item1, Math.Max(compressedRanges[j].Item2, compressedRanges[j+1].Item2));
                        compressedRanges.RemoveAt(j+1);
                    }

                    break;
                }

                if (debug) 
                    Console.WriteLine($"No overlap between: {ranges[i].Item1}-{ranges[i].Item2} and {compressedRanges[j].Item1}-{compressedRanges[j].Item2}");

                // Check for insertion
                if (ranges[i].Item2 < compressedRanges[j].Item1)
                {
                    compressedRanges.Insert(j, ranges[i]);
                    break;
                }
            }
            if (debug) 
                Console.WriteLine("");
        }
        
        return compressedRanges;
    }
}