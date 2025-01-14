namespace Proiect;

public class Rezervare
{
    public string NumeUtilizator { get; set; }
    public int NumarLoc { get; set; }
    public String TipLoc { get; set; }
    public decimal Cost { get; set; }


    public Rezervare(string numeUtilizator, int numarLoc, string tipLoc,decimal cost)
    
   

    {
        NumeUtilizator = numeUtilizator;
        NumarLoc = numarLoc;
        TipLoc = tipLoc;
        Cost = cost;
    }
}