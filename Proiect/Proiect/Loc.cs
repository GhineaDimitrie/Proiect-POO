namespace Proiect;

public class Loc
{
    public int Numar { get; set; }
    public bool EsteRezervat { get; set; } = false;
    
    public string Tip { get; set; }

    public Loc(int numar, string tip)
    {
        Numar = numar;
        Tip = tip;
    }
}