namespace Proiect;

public class Loc
{
    public int Numar { get; set; }
    public bool EsteRezervat { get; set; } = false;

    public Loc(int numar)
    {
        Numar = numar;
    }
}