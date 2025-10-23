using System;

namespace VecEx002;

/*
dados 2 vetores, A (5 elementos) e B (8 elementos) imprima os elementos comuns aos dois vetores
*/
public static class Program
{
    public static void logArr<T>(T[] arr)
    {
        string div = "";
        Console.Write("Conteudo: { ");
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

        for (int i = 0; i < 5; i++) A[i] = rand.Next(0, 200);
        for (int i = 0; i < 8; i++) B[i] = rand.Next(0, 200);
    }
}