using System;

namespace Test;

public static class Program
{
    public static void Main()
    {
        List<int> vec = new List<int> { 1, 3, 5, 7 };
        vec.Add(9);

        for(int i = 0; i < vec.Count; i++)
        {
            Console.WriteLine($"item {i} da lista: {vec[i]}");
        }
    }
}