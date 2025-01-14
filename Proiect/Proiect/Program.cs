namespace Proiect;

class Program
{
    static void Main(string[] args)
    {
        Loc loc1 = new Loc(1);
        Console.WriteLine($"Loc {loc1.Numar}: {(loc1.EsteRezervat ? "Rezervat" : "Liber")}");

        loc1.EsteRezervat = true;
        Console.WriteLine($"Loc {loc1.Numar}: {(loc1.EsteRezervat ? "Rezervat" : "Liber")}");
    }
}