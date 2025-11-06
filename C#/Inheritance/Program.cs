using System;
using System.Net;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

namespace InheritanceEx
{
    public class Animal
    {
        protected string species;
        protected string name;
        protected int age;
        protected double weight;

        public Animal()
        {
            name = Program.parseString("Informe o nome do animal: ");
            age = Program.parseInt($"Informe a idade de {name}: ");
            weight = Program.parseDouble($"Informe o peso de {name}: ");

            species = "null";
        }

        public int getAge() { return age; }
        public void setAge(int _age) { age = _age; }

        public virtual void List()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Idade: {age}");
            Console.WriteLine($"Peso: {weight}");
            Console.WriteLine("----------------------------");
        }

        public string getSpecies() { return species; }
    }

    public class Dog : Animal
    {
        private string breed;
        private string color;

        public Dog()
        {
            species = "dog";
            breed = Program.parseString($"Informe a raça de {name}: ");
            color = Program.parseString($"Informe a cor de {name}: ");
        }

        public override void List()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Idade: {age}");
            Console.WriteLine($"Peso: {weight}");
            Console.WriteLine($"Raça: {breed}");
            Console.WriteLine($"Cor: {color}");
            Console.WriteLine("----------------------------");
        }
    }

    public class Cat : Animal
    {
        private string fur_type;
        private string color;

        public Cat()
        {
            species = "cat";
            fur_type = Program.parseString($"Informe o tipo de pelo de {name}: ");
            color = Program.parseString($"Informe a cor de {name}: ");
        }

        public override void List()
        {
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Nome: {name}");
            Console.WriteLine($"Idade: {age}");
            Console.WriteLine($"Peso: {weight}");
            Console.WriteLine($"Tipo de pelo: {fur_type}");
            Console.WriteLine($"Cor: {color}");
            Console.WriteLine("----------------------------");
        }
    }
    public static class Program
    {
        public static string parseString(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine()!;
                if (input != "" && !double.TryParse(input, out double num)) return input;
                Console.WriteLine("Entrada invalida!");   
            }
        }
        public static double parseDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double num)) return num;
                Console.WriteLine("Entrada invalida");
            }
        }

        public static int parseInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int num)) return num;
                Console.WriteLine("Entrada invalida");
            }
        }
        public static void Main()
        {
            List<Animal> animals = new List<Animal>(0);
            int catCount = 0;
            int dogCount = 0;
            bool over = false;

            while (!over)
            {
                string cardoggo;
                Console.Write("Digite 0 para cadastrar um cachorro, 1 para um gato e 2 para sair: ");
                string action = Console.ReadLine()!;

                switch (action)
                {
                    case "0":
                        animals.Add(new Dog());
                        dogCount++;
                        break;
                    case "1":
                        animals.Add(new Cat());
                        dogCount++;
                        break;
                    case "2":
                        over = true;
                        break;
                    default:
                        Console.WriteLine("Entrada invalida");
                        break;
                }
            }

            Console.Clear();

            if (dogCount > 0)
            {
                string plural = catCount > 1 ? "es" : "o";
                Console.WriteLine($"Cã{plural}: ");
                foreach (Animal doggo in animals)
                {
                    if (doggo.getSpecies() == "dog") doggo.List();
                }

                Console.WriteLine("\n\n\n====================================\n\n\n");
            }

            if (catCount > 0)
            {
                string plural = catCount > 1 ? "s" : "";
                Console.WriteLine($"Gato{plural}: ");
                foreach (Animal car in animals)
                {
                    if (car.getSpecies() == "cat") car.List();
                }
            }
        }
    }
}