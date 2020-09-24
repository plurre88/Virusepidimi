using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virusepidimi
{
    class Program
    {
        static void Main(string[] args)
        {
            int time = 0;
            int numberOfInfected = 1;
            int numberOfInfectedText = 1;
            int antalImmuna = 0;
            
            var diskotek = new List<Person>();
            diskotek.Add(new Person(true, 0, false)); // göra den första personen som är smittad!
            for (int i = 0; i < 49; i++)  // loop för att göra de andra personer som inte är smittade!
            {
                diskotek.Add(new Person(false, 0, false));
            }
            while (true)
            {
                Console.ReadKey();
                int newInfected = 0;

                PrintText(time, numberOfInfectedText, antalImmuna); // metod för att skriva ut info om hur många som e smittade mm.

                foreach (var person in diskotek) // loop för att smitta.
                {
                    if (person.immun)
                    {
                        continue;
                    }
                    else if (!person.smittad)
                    {
                        if (newInfected < numberOfInfected)
                        {
                            person.smittad = true;
                            newInfected++;
                            numberOfInfectedText++;
                        }
                    }
                    else if (person.smittad)
                    {
                        person.smittadTid++;
                        if (person.smittadTid == 5)
                        {
                            person.smittad = false;
                            person.immun = true;
                            antalImmuna++;
                            numberOfInfectedText--;
                            numberOfInfected--;
                        }
                    }
                }
                numberOfInfected = numberOfInfected * 2;
                if(numberOfInfected > diskotek.Count)
                {
                    numberOfInfected = diskotek.Count;
                }
                time++;
            }
        }
        static void PrintText(int a, int b, int c)
        {
            Console.WriteLine($"Antal Timmar: {a}");
            Console.WriteLine($"Antal Smittade: {b}");
            Console.WriteLine($"Antal Immuna: {c}");
            Console.WriteLine("");
        }
    }
    class Person
    {
        public bool smittad { get; set; }
        public int smittadTid { get; set; }
        public bool immun { get; set; }

        public Person(bool smittad, int smittadTid, bool immun)
        {
            this.smittad = smittad;
            this.smittadTid = smittadTid;
            this.immun = immun;
        }
    }
}
