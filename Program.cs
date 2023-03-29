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
        Utilitare.SalveazaDate("mobila.txt", depozit.MobilaDisponibila);

        // Preluarea datelor dintr-un fisier text
        Console.WriteLine("Incarcare date din fisier text...");
        DepozitMobila depozitMobilier = Utilitare.IncarcareDinFisierText("depot_mobilier.txt");

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


        // Afisare clienti
        Clienti client1 = new Clienti("Popescu", "Ion", "Str. Principală 10", "0740123456", "1234567890123", new DateTime(2022, 01, 01), 3);
        Clienti client2 = new Clienti("Ionescu", "Maria", "Str. Libertatii 20", "0722123456", "2345678901234", new DateTime(2022, 02, 15), 5);
        Clienti client3 = new Clienti("Georgescu", "Andrei", "Str. Republicii 30", "0733123456", "3456789012345", new DateTime(2022, 03, 31), 2);
        List<Clienti> listaClienti = new List<Clienti>();
        listaClienti.Add(client1);
        listaClienti.Add(client2);
        listaClienti.Add(client3);
        Console.WriteLine("\nLista clienti:");
        foreach (Clienti client in listaClienti)
        {
            Console.WriteLine("- Nume: " + client.Nume + ", Prenume: " + client.Prenume + ", Adresa: " + client.Adresa + ", Numar telefon: " + client.NumarTelefon + ", CNP:" + client.CNP + ", Data inregistrare: " + client.DataInregistrare + ", Numar comenzi:" + client.NumarComenzi);
        }

        Console.WriteLine("Afisare clienti:");

        List<Clienti> listaClienti2 = Clienti.CitesteClientiDinFisier("clienti.txt");
        foreach (Clienti client in listaClienti2)
        {
            client.AfiseazaDetaliiClient();
        }


        Console.WriteLine("Cautare clienti dupa nume:");
        Console.Write("Introduceti nume pentru cautare: ");
        string nume = Console.ReadLine();

        List<Clienti> clientiGasiti = Clienti.CautaClienti("nume", nume);
        foreach (Clienti client in clientiGasiti)
        {
            Console.WriteLine(client.GetNumeComplet());
        }



    }
}

