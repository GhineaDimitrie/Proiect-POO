namespace Proiect;

public class SistemRezervari
{
    private List<Loc> locuri = new List<Loc>();
    private List<Rezervare> rezervari = new List<Rezervare>();
    private readonly ILogger logger;

    

    public SistemRezervari(int numarBirouri, int numarParcare,ILogger logger)
    {
        this.logger = logger;
        for (int i = 0; i < numarBirouri; i++)
            locuri.Add(new Loc(i,"Birou"));
        for (int i = 0; i < numarBirouri; i++)
            locuri.Add(new Loc(i,"Parcare"));
        logger.Log($"Sistem de rezervări inițializat cu {numarBirouri} birouri și {numarParcare} parcări.");

    }
   
    public void AfiseazaHarta()
    {
        logger.Log("Afișare hartă locuri");
        Console.WriteLine("Harta locurilor (R - Rezervat, L - Liber):");
        foreach (var loc in locuri)
        {
            Console.Write(loc.EsteRezervat ? "R " : "L ");
        }
        Console.WriteLine();
    }

    
    public void AfiseazaLocuri(string tip)
    {
        logger.Log($"Afișare locuri de tip {tip}");

        Console.WriteLine($"Locuri disponibile pentru {tip}:");
        foreach (var loc in locuri)
        {
            if (loc.Tip == tip && !loc.EsteRezervat)
            {
                Console.WriteLine($"Loc {loc.Numar}: Liber");
            }
        }
    }
  

    public void EditeazaLoc(int numarLoc, bool esteRezervat)
    {
        var loc = locuri.Find(l => l.Numar == numarLoc);
        if (loc != null)
        {
            loc.EsteRezervat = esteRezervat;
            logger.Log($"Loc {numarLoc} editat: rezervat = {esteRezervat}.");
            Console.WriteLine("Loc editat cu succes.");
        }
        else
        {
            logger.Log($"Încercare de editare eșuată: loc {numarLoc} inexistent.");
            Console.WriteLine("Loc inexistent.");
        }
    }
    
    

    public void RezervaLoc(string numeUtilizator, int numarLoc, string tip, decimal cost)
    {
        var loc = locuri.Find(l => l.Numar == numarLoc && l.Tip == tip);
        if (loc == null || loc.EsteRezervat)
        {
            logger.Log($"Rezervare eșuată pentru loc {numarLoc} de tip {tip}.");
            Console.WriteLine("Loc invalid sau deja rezervat.");
            return;
        }

        loc.EsteRezervat = true;
        rezervari.Add(new Rezervare(numeUtilizator, numarLoc, tip, cost));
        logger.Log($"Loc {numarLoc} de tip {tip} rezervat de {numeUtilizator} pentru suma de {cost}.");
        Console.WriteLine("Rezervare realizată cu succes!");
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
    
    public void StergeRezervare(string numeUtilizator, int numarLoc)
    {
        var rezervare = rezervari.Find(r => r.NumeUtilizator == numeUtilizator && r.NumarLoc == numarLoc);
        if (rezervare != null)
        {
            rezervari.Remove(rezervare);
            var loc = locuri.Find(l => l.Numar == numarLoc);
            if (loc != null)
            {
                loc.EsteRezervat = false;
            }
            logger.Log($"Rezervarea pentru locul {numarLoc} a fost ștearsă de către {numeUtilizator}.");
            Console.WriteLine("Rezervare ștearsă cu succes.");
        }
        else
        {
            logger.Log($"Rezervarea pentru locul {numarLoc} nu a fost găsită pentru utilizatorul {numeUtilizator}.");
            Console.WriteLine("Rezervare inexistentă.");
        }
    } 
    
    public void IdentificaTipUtilizator(string tipUtilizator, string numeUtilizator)
    {
        logger.Log($"Identificare utilizator {numeUtilizator} de tip {tipUtilizator}");

        switch (tipUtilizator.ToLower())
        {
            case "normal":
                Console.WriteLine($"Utilizator {numeUtilizator} poate: \n - Face rezervări \n - Vizualiza rezervările \n - Șterge rezervările proprii");
                break;
            case "manager":
                Console.WriteLine($"Utilizator {numeUtilizator} poate: \n - Face rezervări \n - Vizualiza rezervările \n - Modifica rezervările echipei");
                break;
            case "admin":
                Console.WriteLine($"Utilizator {numeUtilizator} poate: \n - Face rezervări \n - Vizualiza rezervările \n - Modifica orice rezervare \n - Edita locurile");
                break;
            default:
                logger.Log($"Tip utilizator necunoscut: {tipUtilizator}");
                Console.WriteLine("Tip de utilizator necunoscut.");
                break;
        }
    }
    
}