using System;
using System.Runtime.InteropServices;

namespace VecEx003;

/*
Durante uma corrida de automóveis com N voltas de duração
foram anotados para um piloto, na ordem, os tempos registrados
em cada volta. Fazer um programa em C# para ler os tempos das
N voltas, calcular e imprimir:
(a) Melhor tempo; (b) Tempo médio das N voltas;
(c) A volta em que o melhor tempo ocorreu;
*/

public static class Program
{
    public static int ParseInt(string prompt, string error = "Entrada invalida")
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int x)) return x;
            Console.WriteLine(error);
        }
    }
    public static void Main()
    {
        double[,] lapTimes = new double[ParseInt("Quanta voltas teve a corrida? "), ParseInt("Quantos carros participaram da corrida? ")];
        //lap, car
        int[] bestTime = { 0, 0 };
        double[] lapAvgs = new double[lapTimes.GetLength(0)];
        for (int LAP = 0; LAP < lapTimes.GetLength(0); LAP++)
        {
            double avg = 0;
            for (int CAR = 0; CAR < lapTimes.GetLength(1); CAR++)
            {
                double time = 0; 
                while (true)
                {
                    Console.Write($"Em quanto tempo (segundos) o {CAR + 1}* carro completou a {LAP + 1}* volta? ");
                    if (double.TryParse(Console.ReadLine(), out time)) break;
                    Console.WriteLine("Entrada invalida");
                }
                lapTimes[LAP, CAR] = time;
                if (time < lapTimes[bestTime[0], bestTime[1]])
                {
                    bestTime[0] = LAP;
                    bestTime[1] = CAR;
                }
                avg += time;
            }
            avg /= lapTimes.GetLength(1);
            lapAvgs[LAP] = avg;
        }

        Console.WriteLine($"Na volta {bestTime[0] + 1}, o {bestTime[1] + 1}* carro correu o melhor tempo de {lapTimes[bestTime[0], bestTime[1]]}s");
        
        for (int LAP = 0; LAP < lapAvgs.Length; LAP++)
        {
            Console.WriteLine($"Volta {LAP+1}: {lapAvgs[LAP]:F2}s");
        }
    }
}