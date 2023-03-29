using System;



public static class Utilitare
{
    public static void SalveazaDate(string numeFisier, List<Mobila> mobilaList)
    {
        using (StreamWriter sw = new StreamWriter(numeFisier))
        {
            foreach (Mobila mobila in mobilaList)
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
                string[] linie = sr.ReadLine().Split(',');

                string tip = linie[0];
                string nume = linie[1];
                string material = linie[2];
                string culoare = linie[3];
                double pret = double.Parse(linie[4]);
                int cantitate = int.Parse(linie[5]);

                Mobila mobilier = new Mobila(tip, nume, material, culoare, cantitate, pret);
                depozit.AdaugaMobila(mobilier);
            }
        }

        Console.WriteLine("Datele au fost incarcate cu succes din fisierul " + numeFisier);
        return depozit;
    }

}