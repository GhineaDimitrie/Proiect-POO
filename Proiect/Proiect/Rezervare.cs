namespace Proiect;

public class Rezervare
{
    public string NumeUtilizator { get; set; }
    public int NumarLoc { get; set; }
    public bool EsteParcare { get; set; }

    public Rezervare(string numeUtilizator, int numarLoc, bool esteParcare)
    {
        NumeUtilizator = numeUtilizator;
        NumarLoc = numarLoc;
        EsteParcare = esteParcare;
    }
}