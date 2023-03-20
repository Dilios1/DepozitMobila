using System;
using System.Collections.Generic;
using System.Linq;




class Program
{
    static void Main(string[] args)
    {
        Mobila mobila1 = new Mobila("Scaun", "Scaun ergonomic", "Mesh", "Negru", 5, 500);
        Mobila mobila2 = new Mobila("Dulap", "Dulap Irim Detroit", "Lemn",  "Negru", 10, 1700);

        DepozitMobila depozit = new DepozitMobila("Stefan Catargiu", "Str. Principală 10");
        depozit.AdaugaMobila(mobila1);
        depozit.AdaugaMobila(mobila2);

        Console.WriteLine("Mobilă disponibilă în depozit:");
        foreach (Mobila mobila in depozit.MobilaDisponibila)
        {
            Console.WriteLine("- " + mobila.GetNume() + ", cantitate: " + mobila.Cantitate + ", pret: " + mobila.Pret);
        }

        DepozitMobila depozit1 = new DepozitMobila("Mihai Andrei", "Str. Veronica Micle 18");

        // Citirea datelor de la tastatura
        Console.WriteLine("Introduceti detaliile pentru un mobilier:");
        Mobila.CitesteDate();
        depozit.AdaugaMobila(Mobila.listaMobila[0]);
        Console.WriteLine($"Mobila adaugata: {depozit.MobilaDisponibila[0].GetNume()}");

        // Salvarea datelor in fisier text
        Console.WriteLine("Salvare date in fisier text...");
        depozit.SalveazaDate("mobila.txt");

        // Preluarea datelor dintr-un fisier text
        Console.WriteLine("Incarcare date din fisier text...");
        DepozitMobila depozitMobilier = DepozitMobila.IncarcareDinFisierText("depot_mobilier.txt");

        // Cautarea dupa anumite criterii
        Console.Write("Cauta dupa criteriu (tip/pret): ");
        string criteriu = Console.ReadLine();

        Console.Write("Valoare: ");
        string valoare = Console.ReadLine();

        List<Mobila> mobilaGasita = depozit.CautaMobila(criteriu, valoare);

        if (mobilaGasita.Count > 0)
        {
            Console.WriteLine("Mobila gasita:");
            foreach (Mobila mobila in mobilaGasita)
            {
                Console.WriteLine(mobila.GetNume());
            }
        }
        else
        {
            Console.WriteLine("Nu a fost gasita nicio mobila care sa corespunda criteriului dat.");
        }






    }
}

