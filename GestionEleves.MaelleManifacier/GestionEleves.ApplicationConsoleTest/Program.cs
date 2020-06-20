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

          //ajoutEleve(bm);

          listerEleves(bm);

          if (getEleve(bm, 10) != null)
          {
            deleteEleve(bm, 10);
            listerEleves(bm);
          }

          /*
          int numEleve = 4;
          if (getEleve(bm, numEleve) != null)
          {
            createAndAddNoteForEleveId(bm, numEleve);
            addNote(bm, numEleve, "DotNet", "plein de jolis tests", 15);
            afficherNotesEleve(bm, numEleve);
          }
          */

          List<Eleve> eleves = bm.GetEleves();
          foreach (Eleve eleve in eleves)
          {
            List<Note> notesEleve = bm.GetNotesByEleve(eleve.EleveId);
            foreach (var note in notesEleve)
            {
              Console.WriteLine(note);
            }
            if (notesEleve != null)
            {
              Console.WriteLine(notesEleve);
              Console.WriteLine($"notesEleves != null, EleveId = {eleve.EleveId}");
              //elevesViewModels.Add(new EleveViewModel { Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, Notes = notesViewModelEleve });
            }
            else
            {
              Console.WriteLine($"notesEleves == null, EleveId = {eleve.EleveId}");
              //elevesViewModels.Add(new EleveViewModel { Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance });
            }
          }

          // Wait for the user to respond before closing.
          Console.Write("Press any key to close the console app");
          Console.ReadKey();

        }

        public static void ajoutEleve(BusinessManager bm)
        {
          Eleve e = new Eleve { Nom = "YouThere", Prenom = "Hey", ClassId = 1, DateNaissance = DateTime.Now };
          bm.AddEleve(e);

          Eleve e1 = new Eleve { Nom = "UnAutre", Prenom = "Eleve", ClassId = 1, DateNaissance = DateTime.Now };
          bm.AddEleve(e1);

          Eleve e2 = new Eleve { Nom = "Rouana", Prenom = "Marie", ClassId = 2, DateNaissance = DateTime.Now };
          bm.AddEleve(e2);

          Eleve e3 = new Eleve { Nom = "Terieur", Prenom = "Alain", ClassId = 2, DateNaissance = DateTime.Now };
          bm.AddEleve(e3);

          Eleve e4 = new Eleve { Nom = "Terieur", Prenom = "Alex", ClassId = 1, DateNaissance = DateTime.Now };
          bm.AddEleve(e4);
        }

        public static void listerEleves(BusinessManager bm)
        {
          List<Eleve> eleves = bm.GetEleves();
          Console.WriteLine("- - - Liste des élèves - - -");
          foreach (var eleve in eleves)
          {
            Console.WriteLine(eleve.ToString());
          }
          Console.WriteLine("- - - - - - - - - - - - - - -");
          Console.WriteLine();
        }

        public static Eleve getEleve(BusinessManager bm, int eleveId)
        {
          return bm.GetEleve(eleveId);
        }

        public static void deleteEleve(BusinessManager bm, int eleveId)
        {
          bm.DeleteEleve(eleveId);
        }

        public static void createAndAddNoteForEleveId(BusinessManager bm, int eleveId)
        {
          Note n = new Note();
          n.EleveId = eleveId;
          n.Matiere = "Maths";
          n.DateNote = DateTime.Now;
          n.Appreciation = "not too bad";
          n.NoteEleve = 15;
          bm.AddNote(n);
        }

        public static void addNote(BusinessManager bm, int eleveId, string matiere, string appreciation, int noteEleve)
        {
          Note n = new Note();
          n.EleveId = eleveId;
          n.Matiere = matiere;
          n.DateNote = DateTime.Now;
          n.Appreciation = appreciation;
          n.NoteEleve = noteEleve;
          bm.AddNote(n);
        }

        public static void afficherNotesEleve(BusinessManager bm, int eleveId)
        {
          List<Note> notes = bm.GetNotesByEleve(eleveId);
          Console.WriteLine("- - - Liste des notes de l'élève " + eleveId + " - - -");
          foreach (Note note in notes)
          {
            Console.WriteLine(note.ToString());
          }
          Console.WriteLine("- - - - - - - - - - - - - - - - - - - - -");
          Console.WriteLine();
        }

  }
   
}
