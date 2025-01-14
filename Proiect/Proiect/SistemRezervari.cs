namespace Proiect;

public class SistemRezervari
{
    private List<Loc> locuri = new List<Loc>();
    private List<Rezervare> rezervari = new List<Rezervare>();

    public SistemRezervari(int numarBirouri, int numarParcare)
    {
        for (int i = 0; i < numarBirouri; i++)
            locuri.Add(new Loc(i,"Birou"));
        for (int i = 0; i < numarBirouri; i++)
            locuri.Add(new Loc(i,"Parcare"));

    }
    
    public void AfisareLocuri(string tip)
    {
        Console.WriteLine($"Locuri disponibile pentru {tip}:");
        foreach (var loc in locuri)
        {
            if (loc.Tip == tip && !loc.EsteRezervat)
            {
                Console.WriteLine($"Loc {loc.Numar}: Liber");
            }
        }
    }

    public void RezervaLoc(string numeUtilizator, int numarLoc, string tip)
    {
        var loc = locuri.Find(l => l.Numar == numarLoc && l.Tip == tip);

        if (loc == null || loc.EsteRezervat)
        {
            Console.WriteLine("Loc invalid sau deja rezervat");
            return;
        }
        
        loc.EsteRezervat = true;
        rezervari.Add(new Rezervare(numeUtilizator,numarLoc,tip));
        Console.WriteLine($"Loc {numarLoc} ({tip}) rezervat cu succes de {numeUtilizator}!");
    
    }

    public void VizualizeazaRezervari(string numeUtilizator)
    {
        Console.WriteLine($"Rezervarile pentru {numeUtilizator}:");
        foreach (var rezervare in rezervari)
        {
            if (rezervare.NumeUtilizator == numeUtilizator)
            {
                Console.WriteLine($"Loc {rezervare.NumarLoc} ({rezervare.TipLoc})");
            }
        }
    }
    
    
    
}