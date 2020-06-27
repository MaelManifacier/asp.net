using GestionEleves.ApplicationWebMVC.Models;
using GestionEleves.BusinessLayer;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GestionEleves.ApplicationWebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Dictionary<int, double> listEleves = new Dictionary<int, double>();
          List<Eleve> eleves = bm.GetEleves();
          eleves.ForEach(eleve =>
          {
            List<Note> notesEleve = bm.GetNotesByEleve(eleve.EleveId);
            double moyenne = 0.0;
            if (notesEleve != null && notesEleve.Count > 0)
            {
              moyenne = notesEleve.Average(n => n.NoteEleve);
            }
            listEleves.Add(eleve.EleveId, moyenne);
          });

          List<EleveViewModel> elevesViewModel = new List<EleveViewModel>();
          var sortedList = listEleves.ToList();
          sortedList.Sort((x, y) => y.Value.CompareTo(x.Value));

          for (int i = 0; i < 5; i++)
          {
            Eleve e = bm.GetEleve(sortedList[i].Key);
            elevesViewModel.Add(new EleveViewModel { Nom = e.Nom, Prenom = e.Prenom, DateNaissance = e.DateNaissance, Moyenne = sortedList[i].Value });
          }
          

          ViewData.Model = elevesViewModel;
          return View();
        }

        public ActionResult Students(string searchString)
        {
          // récupération du BusinessManager
          BusinessManager bm = BusinessManager.GetInstance();

          List<Eleve> Eleves;
          if (!String.IsNullOrEmpty(searchString))
          {
            Eleves = bm.SearchEleve(searchString);
          } else
          {
            Eleves = bm.GetEleves();
          }

          List<EleveViewModel> elevesViewModel = GetNotesElevesWithEleveList(bm, Eleves);

            // set de ViewBag à la vue
            ViewBag.Message = "student list";
            ViewData.Model = elevesViewModel;

            return View();
        }

    public static List<EleveViewModel> GetNotesElevesWithEleveList(BusinessManager bm, List<Eleve> Eleves)
    {
      // conversion des eleves en EleveViewModel
      List<EleveViewModel> elevesViewModels = new List<EleveViewModel>();
      List<NoteViewModel> notesViewModelEleve = new List<NoteViewModel>();
      foreach (var eleve in Eleves)
      {
        List<Note> notesEleve = bm.GetNotesByEleve(eleve.EleveId);
        List<Absence> absencesEleve = bm.GetAbsenceByEleveId(eleve.EleveId);

        foreach (var note in notesEleve)
        {
          notesViewModelEleve.Add(new NoteViewModel { NoteId = note.NoteId, EleveId = eleve.EleveId, Matiere = note.Matiere, NoteEleve = note.NoteEleve, Appreciation = note.Appreciation, DateNote = note.DateNote });
        }
        if (notesEleve != null && notesEleve.Count > 0)
        {
          double moyenne = notesEleve.Average(n => n.NoteEleve);
          elevesViewModels.Add(new EleveViewModel { EleveId = eleve.EleveId, Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, Notes = notesViewModelEleve, Moyenne = moyenne });
        }
        else
        {
          elevesViewModels.Add(new EleveViewModel { EleveId = eleve.EleveId, Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance });
        }
      }

      return elevesViewModels;
    }

		#region "Mocks"
		public static void CreateMocks(BusinessManager bm)
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

      Note n = new Note { EleveId = 4, Matiere = "Maths", DateNote = DateTime.Now, Appreciation = "not too bad", NoteEleve = 15 };
      bm.AddNote(n);
    }

    public static void MocksSansBDD()
    {
        // MOCK d'eleves
        List<NoteViewModel> notes = new List<NoteViewModel>();
        notes.Add(new NoteViewModel { Matiere = "laMatiere", NoteEleve = 2, Appreciation = "cette appreciation est qualitative, n'est-ce pas ?", DateNote = DateTime.Now});
        List<EleveViewModel> Students = new List<EleveViewModel>();
        Students.Add(new EleveViewModel { Nom = "YouThere", Prenom = "Hey", ClassId = 1, Notes = notes });
        Students.Add(new EleveViewModel { Nom = "Rouana", Prenom = "Marie", ClassId = 1 });
    }
		#endregion

    }
}