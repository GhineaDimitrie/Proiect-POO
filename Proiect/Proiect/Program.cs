namespace Proiect;

class Program
{
    static void Main(string[] args)
    {
        Loc loc1 = new Loc(1);
        Console.WriteLine($"Loc {loc1.Numar}: {(loc1.EsteRezervat ? "Rezervat" : "Liber")}");
        
        Rezervare rezervare1=new Rezervare("Ion Popescu", loc1.Numar,false);
        Console.WriteLine($"Rezervare facuta de {rezervare1.NumeUtilizator} pentru loc {rezervare1.NumarLoc} (Birou)");
        
        loc1.EsteRezervat = true;
        Console.WriteLine($"Loc {loc1.Numar}: {(loc1.EsteRezervat ? "Rezervat" : "Liber")}");
    }
}