using System;
using System.Linq;
using System.Collections.Generic;


public class Mobila
{
    public string TipMobila { get; set; }
    public string Nume { get; set; }
    public string Material { get; set; }
    public string Culoare { get; set; }
    public int Cantitate { get; set; }
    public double Pret { get; set; }

    public static List<Mobila> listaMobila = new List<Mobila>();

    public Mobila(string tipMobila, string nume, string material, string culoare, int cantitate, double pret)
    {
        TipMobila = tipMobila;
        Nume = nume;
        Material = material;
        Culoare = culoare;
        Cantitate = cantitate;
        Pret = pret;
    }

    public string GetNume()
    {
        return Nume;
    }

    public void SetCantitate(int cantitate)
    {
        Cantitate = cantitate;
    }

    public static void CitesteDate()
    {
        Console.WriteLine("Introduceti datele despre mobila: ");

        Console.Write("Tip mobila (scaun, masa, dulap): ");
        string tipMobila = Console.ReadLine();

        Console.Write("Nume: ");
        string nume = Console.ReadLine();

        Console.Write("Material: ");
        string material = Console.ReadLine();

        Console.Write("Culoare: ");
        string culoare = Console.ReadLine();

        Console.Write("Pret: ");
        double pret = double.Parse(Console.ReadLine());

        Console.Write("Cantitate:");
        int cantitate = int.Parse(Console.ReadLine());    

        Mobila mobila = new Mobila(tipMobila, nume, material, culoare, cantitate, pret);
        listaMobila.Add(mobila);

        Console.WriteLine("Datele au fost adaugate cu succes!");
    }


   
}
