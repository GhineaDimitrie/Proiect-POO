﻿namespace Proiect;

class Program
{
    static void Main(string[] args)
    {
        var logger = new ConsoleLogger();
        SistemRezervari sistem = new SistemRezervari(5, 5, logger);

        Console.Write("Tip utilizator (Normal/Manager/Admin): ");
        string tipUtilizator = Console.ReadLine();
        
        bool ruleaza = true;

        while (ruleaza)
        {
            Console.WriteLine("\nMeniu:");
            if (tipUtilizator.ToLower() == "normal")
            {
                Console.WriteLine("1. Vizualizează locuri birou");
                Console.WriteLine("2. Vizualizează locuri parcare");
                Console.WriteLine("3. Rezervă loc");
                Console.WriteLine("4. Vizualizează rezervările tale");
                Console.WriteLine("5. Șterge o rezervare");
                Console.WriteLine("6. Ieșire");
            }
            else if (tipUtilizator.ToLower() == "manager")
            {
                Console.WriteLine("1. Vizualizează locuri birou");
                Console.WriteLine("2. Vizualizează locuri parcare");
                Console.WriteLine("3. Rezervă loc");
                Console.WriteLine("4. Vizualizează rezervările tale");
                Console.WriteLine("5. Șterge o rezervare");
                Console.WriteLine("6. Modifică rezervări ale echipei");
                Console.WriteLine("7. Ieșire");
            }
            else if (tipUtilizator.ToLower() == "admin")
            {
                Console.WriteLine("1. Vizualizează locuri birou");
                Console.WriteLine("2. Vizualizează locuri parcare");
                Console.WriteLine("3. Rezervă loc");
                Console.WriteLine("4. Vizualizează rezervările tale");
                Console.WriteLine("5. Șterge o rezervare");
                Console.WriteLine("6. Editează locuri");
                Console.WriteLine("7. Afișează harta locurilor");
                Console.WriteLine("8. Ieșire");
            }
            else
            {
                Console.WriteLine("Tip utilizator necunoscut. Ieșire...");
                break;
            }
        
        
        
            int optiune = int.Parse(Console.ReadLine());
            switch (optiune)
            {
                case 1:
                    sistem.AfiseazaLocuri("Birou");
                    break;
                case 2:
                    sistem.AfiseazaLocuri("Parcare");
                    break;
                case 3:
                    Console.Write("Nume utilizator: ");
                    string nume = Console.ReadLine();
                    Console.Write("Număr loc: ");
                    int numarLoc = int.Parse(Console.ReadLine());
                    Console.Write("Tip (Birou/Parcare): ");
                    string tip = Console.ReadLine();
                    Console.Write("Cost rezervare: ");
                    decimal cost = decimal.Parse(Console.ReadLine());
                    sistem.RezervaLoc(nume, numarLoc, tip, cost);
                    break;
                case 4:
                    Console.Write("Nume utilizator: ");
                    string numeVizualizare = Console.ReadLine();
                    sistem.VizualizeazaRezervari(numeVizualizare);
                    break;
                case 5:
                    Console.Write("Nume utilizator: ");
                    string numeStergere = Console.ReadLine();
                    Console.Write("Număr loc: ");
                    int numarStergere = int.Parse(Console.ReadLine());
                    sistem.StergeRezervare(numeStergere, numarStergere);
                    break;
                case 6:
                    if (tipUtilizator.ToLower() == "admin")
                    {
                        Console.Write("Număr loc: ");
                        int locEdit = int.Parse(Console.ReadLine());
                        Console.Write("Este rezervat? (true/false): ");
                        bool esteRezervat = bool.Parse(Console.ReadLine());
                        sistem.EditeazaLoc(locEdit, esteRezervat);
                    }
                    else if (tipUtilizator.ToLower() == "manager")
                    {
                        Console.WriteLine("Opțiune pentru modificarea rezervărilor echipei nu este implementată încă.");
                    }
                    else
                    {
                        ruleaza = false; // Ieșire pentru utilizator normal
                    }

                    break;
                case 7:
                    if (tipUtilizator.ToLower() == "admin")
                    {
                        sistem.AfiseazaHarta();
                    }
                    else
                    {
                        ruleaza = false; // Ieșire pentru manager
                    }

                    break;
                case 8:
                    if (tipUtilizator.ToLower() == "admin")
                    {
                        ruleaza = false; // Ieșire pentru admin
                    }

                    break;
                default:
                    Console.WriteLine("Opțiune invalidă.");
                    break;
            }
        }
    }
}