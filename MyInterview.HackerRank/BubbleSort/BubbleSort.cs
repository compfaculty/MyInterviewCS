namespace MyInterview.Test.BubbleSort;

public class BubbleSortTest
{
    public static List<int> Run(List<int> a)
    {
        var swapCount = 0;
        for (int i = 0; i < a.Count; i++)
        {
            for (int j = 0; j < a.Count - 1; j++)
            {
                if (a[j] <= a[j + 1]) continue;
                a[j] = a[j] + a[j + 1];
                a[j + 1] = a[j] - a[j + 1];
                a[j] = a[j] - a[j + 1];
                swapCount++;
            }
        }

        Console.WriteLine($"Array is sorted in {swapCount} swaps.");
        Console.WriteLine($"First Element: {a[0]}");
        Console.WriteLine($"Last Element: {a[a.Count - 1]}");
        return a;
    }
}