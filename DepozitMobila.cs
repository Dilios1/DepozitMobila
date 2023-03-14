using System;

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
}
