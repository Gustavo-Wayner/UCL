using System;

namespace VecEven;

public static class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World!");

        int[] vec = new int[3] {1, 2, 3};

        Console.WriteLine("Esses são os elementos pares do vetor: ");
        for (int i = 0; i < vec.Length; i++)
        {
            if (i % 2 == 0) Console.WriteLine(vec[i]);
        }
    }
}