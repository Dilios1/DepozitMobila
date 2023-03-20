using System;
using System.Linq;
using System.Collections.Generic;


class DepozitMobila
{
    public string NumeProprietar { get; set; }
    public string Adresa { get; set; }
    public List<Mobila> MobilaDisponibila { get; set; }

    public DepozitMobila(string numeProprietar, string adresa)
    {
        NumeProprietar = numeProprietar;
        Adresa = adresa;
        MobilaDisponibila = new List<Mobila>();
    }

    public void AdaugaMobila(Mobila mobila)
    {
        MobilaDisponibila.Add(mobila);
    }

    public void EliminaMobila(Mobila mobila)
    {
        MobilaDisponibila.Remove(mobila);
    }

    public List<Mobila> CautaMobila(string criteriu, string valoare)
    {
        List<Mobila> mobilaGasita = new List<Mobila>();

        switch (criteriu)
        {
            case "tip":
                mobilaGasita = MobilaDisponibila.Where(m => m.TipMobila == valoare).ToList();
                break;
            case "pret":
                double pretCautat = double.Parse(valoare);
                mobilaGasita = MobilaDisponibila.Where(m => m.Pret == pretCautat).ToList();
                break;
            default:
                Console.WriteLine("Criteriu invalid!");
                break;
        }

        return mobilaGasita;
    }

    public void SalveazaDate(string numeFisier)
    {
        using (StreamWriter sw = new StreamWriter(numeFisier))
        {
            foreach (Mobila mobila in MobilaDisponibila)
            {
                sw.WriteLine($"{mobila.TipMobila},{mobila.Nume},{mobila.Material},{mobila.Culoare},{mobila.Cantitate},{mobila.Pret}");
            }
        }
        Console.WriteLine($"Datele au fost salvate în fișierul {numeFisier}");
    }

    public static DepozitMobila IncarcareDinFisierText(string numeFisier)
    {
        DepozitMobila depozit = new DepozitMobila("Nume proprietar", "Adresa depozit");

        using (StreamReader sr = new StreamReader(numeFisier))
        {
            while (!sr.EndOfStream)
            {
                string[] linie = sr.ReadLine().Split(';');

                string tip = linie[0];
                string nume = linie[1];
                string material = linie[2];
                string culoare = linie[3];
                int pret = int.Parse(linie[4]);
                int cantitate = int.Parse(linie[5]);

                Mobila mobilier = new Mobila(tip, nume, material, culoare, pret, cantitate);
                depozit.AdaugaMobila(mobilier);
            }
        }

        Console.WriteLine("Datele au fost incarcate cu succes din fisierul " + numeFisier);
        return depozit;
    }

}

  

