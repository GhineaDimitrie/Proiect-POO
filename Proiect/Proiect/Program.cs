namespace Proiect;

class Program
{
    static void Main(string[] args)
    {
        SistemRezervari sistem = new SistemRezervari(3, 2);
        sistem.AfisareLocuri("Birou");
        sistem.AfisareLocuri("Parcare");
        
        sistem.RezervaLoc("IonPopescu",1,"Birou");
        sistem.AfisareLocuri("Birou");
        sistem.VizualizeazaRezervari("IonPopescu");
        
    }
}