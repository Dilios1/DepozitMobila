using System;
using System.Linq;
using System.Collections.Generic;

public class Clienti
{
    // Atribute
    private string nume;
    private string prenume;
    private string adresa;
    private string numarTelefon;
    private string cnp;
    private DateTime dataInregistrare;
    private int numarComenzi;
    public static List<Clienti> listaClienti = new List<Clienti>();

    // Constructor
    public Clienti(string nume, string prenume, string adresa, string numarTelefon, string cnp, DateTime dataInregistrare, int numarComenzi)
    {
        this.nume = nume;
        this.prenume = prenume;
        this.adresa = adresa;
        this.numarTelefon = numarTelefon;
        this.cnp = cnp;
        this.dataInregistrare = dataInregistrare;
        this.numarComenzi = 0;
    }

    // Proprietati
    public string Nume
    {
        get { return nume; }
        set { nume = value; }
    }

    public string Prenume
    {
        get { return prenume; }
        set { prenume = value; }
    }

    public string Adresa
    {
        get { return adresa; }
        set { adresa = value; }
    }

    public string NumarTelefon
    {
        get { return numarTelefon; }
        set { numarTelefon = value; }
    }

    public string CNP
    {
        get { return cnp; }
        set { cnp = value; }
    }

    public DateTime DataInregistrare
    {
        get { return dataInregistrare; }
        set { dataInregistrare = value; }
    }

    public int NumarComenzi
    {
        get { return numarComenzi; }
        set { numarComenzi = value; }
    }

    // Metode
    public void AfiseazaDetaliiClient()
    {
        Console.WriteLine($"Nume: {nume} {prenume}");
        Console.WriteLine($"Adresa: {adresa}");
        Console.WriteLine($"Numar de telefon: {numarTelefon}");
        Console.WriteLine($"CNP: {cnp}");
        Console.WriteLine($"Data inregistrare: {dataInregistrare}");
        Console.WriteLine($"Numar de comenzi: {numarComenzi}");
    }

    public static Clienti CitesteDate()
    {
        Console.Write("Introduceti numele clientului: ");
        string nume = Console.ReadLine();

        Console.Write("Introduceti prenumele clientului: ");
        string prenume = Console.ReadLine();

        Console.Write("Introduceti adresa clientului: ");
        string adresa = Console.ReadLine();

        Console.Write("Introduceti numarul de telefon al clientului: ");
        string numarTelefon = Console.ReadLine();

        Console.Write("Introduceti CNP-ul clientului: ");
        string cnp = Console.ReadLine();

        Console.Write("Introduceti data de inregistrare a clientului (YYYY-MM-DD): ");
        DateTime dataInregistrare = DateTime.Parse(Console.ReadLine());

        Console.Write("Introduceti numarul de comenzi ale clientului: ");
        int numarComenzi = int.Parse(Console.ReadLine());

        Clienti client = new Clienti(nume, prenume, adresa, numarTelefon, cnp, dataInregistrare, numarComenzi);

        return client;
    }

    public void SalveazaDate(string numeFisier)
    {
        using (StreamWriter sw = new StreamWriter(numeFisier))
        {
            foreach (Clienti client in listaClienti)
            {
                sw.WriteLine(client.Nume);
                sw.WriteLine(client.Prenume);
                sw.WriteLine(client.Adresa);
                sw.WriteLine(client.numarTelefon);
                sw.WriteLine(client.CNP);
                sw.WriteLine(client.DataInregistrare);
                sw.WriteLine(client.NumarComenzi);
            }
        }
    }


    public static List<Clienti> CitesteClientiDinFisier(string numeFisier)
    {
        List<Clienti> listaClienti = new List<Clienti>();

        try
        {
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    string[] campuri = linie.Split(',');

                    string nume = campuri[0];
                    string prenume = campuri[1];
                    string adresa = campuri[2];
                    string numarTelefon = campuri[3];
                    string cnp = campuri[4];
                    DateTime dataInregistrare = DateTime.Parse(campuri[5]);
                    int numarComenzi = int.Parse(campuri[6]);

                    Clienti client = new Clienti(nume, prenume, adresa, numarTelefon, cnp, dataInregistrare, numarComenzi);
                    listaClienti.Add(client);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"A aparut o eroare la citirea din fisier: {ex.Message}");
        }

        return listaClienti;
    }

    public static List<Clienti> CautaClienti(string criteriu, string valoare)
    {
        List<Clienti> clientiGasiti = new List<Clienti>();
        switch (criteriu.ToLower())
        {
            case "nume":
                foreach (Clienti client in listaClienti)
                {
                    if (client.Nume.ToLower().Contains(valoare.ToLower()))
                    {
                        clientiGasiti.Add(client);
                    }
                }
                break;
            case "prenume":
                foreach (Clienti client in listaClienti)
                {
                    if (client.Prenume.ToLower().Contains(valoare.ToLower()))
                    {
                        clientiGasiti.Add(client);
                    }
                }
                break;
            case "adresa":
                foreach (Clienti client in listaClienti)
                {
                    if (client.Adresa.ToLower().Contains(valoare.ToLower()))
                    {
                        clientiGasiti.Add(client);
                    }
                }
                break;
            case "numartelefon":
                foreach (Clienti client in listaClienti)
                {
                    if (client.NumarTelefon.ToLower().Contains(valoare.ToLower()))
                    {
                        clientiGasiti.Add(client);
                    }
                }
                break;
            case "cnp":
                foreach (Clienti client in listaClienti)
                {
                    if (client.CNP.ToLower().Contains(valoare.ToLower()))
                    {
                        clientiGasiti.Add(client);
                    }
                }
                break;
            case "numarcomenzi":
                int numarComenzi;
                if (int.TryParse(valoare, out numarComenzi))
                {
                    foreach (Clienti client in listaClienti)
                    {
                        if (client.NumarComenzi > numarComenzi)
                        {
                            clientiGasiti.Add(client);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Valoarea introdusă nu este un număr valid.");
                }
                break;
            default:
                Console.WriteLine("Criteriul introdus nu este valid.");
                break;
        }
        return clientiGasiti;
    }

    public string GetNumeComplet()
    {
        return Nume + " " + Prenume;
    }


}



