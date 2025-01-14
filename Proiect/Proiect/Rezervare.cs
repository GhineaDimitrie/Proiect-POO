namespace Proiect;

public class Rezervare
{
    public string NumeUtilizator { get; set; }
    public int NumarLoc { get; set; }
    public String TipLoc { get; set; }
    public Rezervare(string numeUtilizator, int numarLoc, string tipLoc)
    {
        NumeUtilizator = numeUtilizator;
        NumarLoc = numarLoc;
        TipLoc = tipLoc;
    }
}