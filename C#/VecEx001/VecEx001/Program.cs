using System;
using System.Diagnostics.Tracing;

namespace VecEx001;

/*
Faça um programa em c# para ler um vetor de inteiros positivos de 20 posições. 
Imprimir a quantidade de numeros pares e de multiplos de 5
*/

public static class Program
{
    public static void Main()
    {
        Random rand = new Random();
        int[] vec = new int[20];
        int fiveCount = 0;
        int evenCount = 0;

        for (int i = 0; i < 20; i++) vec[i] = rand.Next(0, 100);

        {
            string div = "";
            Console.Write("Conteudo: { ");
            foreach (int i in vec)
            {
                Console.Write($"{div}{i}");
                div = ", ";

                if (i % 5 == 0) fiveCount++;
                if (i % 2 == 0) evenCount++;
            }
            Console.WriteLine(" }");
        }
        Console.WriteLine($"A array possui {fiveCount} multiplos de 5 e {evenCount} numeros par");
    }
}