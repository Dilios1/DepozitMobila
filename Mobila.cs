using System;

class Mobila
{
    public int Id { get; set; }
    public string Nume { get; set; }
    public int Cantitate { get; set; }
    public float Pret { get; set; }

    public Mobila(int id, string nume, int cantitate, float pret)
    {
        Id = id;
        Nume = nume;
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
}
