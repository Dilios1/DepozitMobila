using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Mobila mobila1 = new Mobila(1, "Canapea", 5, 1500);
        Mobila mobila2 = new Mobila(2, "Masa", 10, 500);

        DepozitMobila depozit = new DepozitMobila("John Doe", "Str. Principală 10");
        depozit.AdaugaMobila(mobila1);
        depozit.AdaugaMobila(mobila2);

        Console.WriteLine("Mobilă disponibilă în depozit:");
        foreach (Mobila mobila in depozit.MobilaDisponibila)
        {
            Console.WriteLine("- " + mobila.GetNume() + ", cantitate: " + mobila.Cantitate + ", pret: " + mobila.Pret);
        }
    }
}