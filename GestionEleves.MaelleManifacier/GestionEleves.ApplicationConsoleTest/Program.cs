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

          //AjoutEleve(bm);

          ListerEleves(bm);

          if (GetEleve(bm, 10) != null)
          {
            DeleteEleve(bm, 10);
            ListerEleves(bm);
          }

          /*
          int numEleve = 4;
          if (GetEleve(bm, numEleve) != null)
          {
            CreateAndAddNoteForEleveId(bm, numEleve);
            AddNote(bm, numEleve, "DotNet", "plein de jolis tests", 15);
            AfficherNotesEleve(bm, numEleve);
          }
          */

          if (GetEleve(bm, 2) != null)
          {
            AjoutAbsence(bm, 2);
            ListerEleves(bm);
          }

          List<Eleve> eleves = bm.GetEleves();
          foreach (Eleve eleve in eleves)
          {
            List<Note> notesEleve = bm.GetNotesByEleve(eleve.EleveId);
            List<Absence> absencesEleve = bm.GetAbsenceByEleveId(eleve.EleveId);

            foreach (var note in notesEleve)
            {
              Console.WriteLine(note);
            }
            if (notesEleve != null && notesEleve.Count > 0)
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

        public static void AjoutEleve(BusinessManager bm)
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

        public static void ListerEleves(BusinessManager bm)
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

        public static void AjoutAbsence(BusinessManager bm, int EleveId)
        {
          Absence a = new Absence { DateAbsence = DateTime.Now, EleveId = EleveId, Motif="Flemme" };
          bm.AddAbsence(a);
        }

        public static Eleve GetEleve(BusinessManager bm, int eleveId)
        {
          return bm.GetEleve(eleveId);
        }

        public static void DeleteEleve(BusinessManager bm, int eleveId)
        {
          bm.DeleteEleve(eleveId);
        }

        public static void CreateAndAddNoteForEleveId(BusinessManager bm, int eleveId)
        {
          Note n = new Note();
          n.EleveId = eleveId;
          n.Matiere = "Maths";
          n.DateNote = DateTime.Now;
          n.Appreciation = "not too bad";
          n.NoteEleve = 15;
          bm.AddNote(n);
        }

        public static void AddNote(BusinessManager bm, int eleveId, string matiere, string appreciation, int noteEleve)
        {
          Note n = new Note();
          n.EleveId = eleveId;
          n.Matiere = matiere;
          n.DateNote = DateTime.Now;
          n.Appreciation = appreciation;
          n.NoteEleve = noteEleve;
          bm.AddNote(n);
        }

        public static void AfficherNotesEleve(BusinessManager bm, int eleveId)
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
