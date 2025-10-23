using System;
using System.Linq.Expressions;
using System.Text.Json.Nodes;

namespace VecEx002;
/*
dados 2 vetores, A (5 elementos) e B (8 elementos) imprima os elementos comuns aos dois vetores
*/

public static class Program
{
    #region Defining rage
    const int min = 0;
    const int max = 10;
    #endregion

    public static void logArr<T>(T[] arr, string prompt)
    {
        string div = "";
        Console.Write($"{prompt}{{ ");
        foreach (T i in arr)
        {
            Console.Write($"{div}{i}");
            div = ", ";
        }
        Console.WriteLine(" }");
    }
    public static void Main()
    {
        Random rand = new Random();
        int[] A = new int[5];
        int[] B = new int[8];

        for (int i = 0; i < 5; i++) A[i] = rand.Next(min, max);
        for (int i = 0; i < 8; i++) B[i] = rand.Next(min, max);

        logArr(A, "A: ");
        logArr(B, "B: ");

        {
            string div = string.Empty;
            List<int> seenPreviously = new List<int>();
            Console.Write("Os elementos comuns a A e B são: { ");
            foreach (int i in A)
            {
                foreach (int j in B)
                {
                    if (j == i && !seenPreviously.Contains(j))
                    {
                        Console.Write($"{div}{j}");
                        div = ", ";
                        seenPreviously.Add(j);
                    }
                }
            }
            Console.WriteLine(" }");
        }
    }
}