using GestionEleves.BusinessLayer;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.ApplicationConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessManager bm = BusinessManager.GetInstance();

            Eleve e = new Eleve { Nom = "YouThere", Prenom = "Hey", ClassId = 1, DateNaissance = DateTime.Now };
            bm.AddEleve(e);

            Eleve e1 = new Eleve { Nom = "UnAutre", Prenom = "Eleve", ClassId = 1, DateNaissance = DateTime.Now };
            bm.AddEleve(e1);

            List<Eleve> eleves = bm.GetEleves();
            foreach(var eleve in eleves)
            {
                Console.WriteLine(eleve.ToString());
            }


            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the console app");
            Console.ReadKey();

        }
    }
}
