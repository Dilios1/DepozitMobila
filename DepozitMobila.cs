using System;
using System.Linq;
using System.Collections.Generic;


public class DepozitMobila
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

    

}

  

