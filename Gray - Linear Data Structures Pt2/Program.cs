using System;
using System.Collections.Generic;
using System.Linq;

public abstract class ArrayProcessor
{
    protected int[] Numbers;

    public ArrayProcessor(int[] numbers)
    {
        Numbers = numbers;
    }

    public abstract void ProcessArray();
}

public class NumberCounter : ArrayProcessor
{
    public NumberCounter(int[] numbers) : base(numbers)
    {
    }

    public override void ProcessArray()
    {
        Dictionary<int, int> numberCounts = new Dictionary<int, int>();

        foreach (int num in Numbers)
        {
            if (numberCounts.ContainsKey(num))
            {
                numberCounts[num]++;
            }
            else
            {
                numberCounts[num] = 1;
            }
        }

        var sortedKeys = numberCounts.Keys.OrderBy(k => k);

        foreach (var key in sortedKeys)
        {
            Console.WriteLine($"Number {key} occurs {numberCounts[key]} time(s).");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Enter the numbers separated by spaces:");
            string input = Console.ReadLine();

            int[] numbers = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Where(s => int.TryParse(s, out _))
                                  .Select(int.Parse)
                                  .ToArray();

            if (numbers.Length == 0)
            {
                throw new Exception("No valid numbers were entered.");
            }

            ArrayProcessor arrayProcessor = new NumberCounter(numbers);
            arrayProcessor.ProcessArray();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
