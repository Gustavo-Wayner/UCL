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
        Car[] cars = new Car[ParseInt("Quantos carros participaram da corrida? ")];
        int lapCount = ParseInt("Quanta voltas teve a corrida? ");

        for(int car = 0; car < cars.Length; car++)
        {
            cars[car] = new Car(new double[lapCount]);
        }
        //lap, car
        Car bestTime = cars[0];
        double[] lapAvgs = new double[lapCount];
        for (int LAP = 0; LAP < lapCount; LAP++)
        {
            double avg = 0;
            for (int CAR = 0; CAR < cars.Length; CAR++)
            {
                double time;
                while (true)
                {
                    Console.Write($"Em quanto tempo (segundos) o {CAR + 1}* carro completou a {LAP + 1}* volta? ");
                    if (double.TryParse(Console.ReadLine(), out time)) break;
                    Console.WriteLine("Entrada invalida");
                }
                cars[CAR].lapTimes[LAP] = time;
                cars[CAR].ID = (uint)CAR;
                avg += time;
            }
            avg /= cars.Length;
            lapAvgs[LAP] = avg;
        }

        foreach(Car car in cars)
        {
            if (car.lapTimes.Min() < bestTime.lapTimes.Min()) bestTime = car;
        }

        Console.WriteLine($"Na volta {Array.IndexOf(bestTime.lapTimes, bestTime.lapTimes.Min()) + 1}, o {bestTime.ID + 1}* carro correu o melhor tempo de {bestTime.lapTimes.Min()}s");

        Console.WriteLine("------------------------------------------------\nMedias:");
        for (int LAP = 0; LAP < lapAvgs.Length; LAP++)
        {
            Console.WriteLine($"Volta {LAP + 1}: {lapAvgs[LAP]:F2}s");
        }
    }
}

public class Car
{
    public uint ID;
    public double[] lapTimes;
    public Car(double[] time, uint id = 0)
    {
        ID = id;
        lapTimes = time;
    }
}