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

          List<EleveViewModel> elevesViewModel = getNotesElevesWithEleveList(bm, Eleves);

            // set de ViewBag à la vue
            ViewBag.Message = "student list";
            ViewBag.Students = elevesViewModel;

            return View();
        }

    public static List<EleveViewModel> getNotesElevesWithEleveList(BusinessManager bm, List<Eleve> Eleves)
    {
      // conversion des eleves en EleveViewModel
      List<EleveViewModel> elevesViewModels = new List<EleveViewModel>();
      List<NoteViewModel> notesViewModelEleve = new List<NoteViewModel>();
      foreach (var eleve in Eleves)
      {
        List<Note> notesEleve = bm.GetNotesByEleve(eleve.EleveId);
        foreach (var note in notesEleve)
        {
          notesViewModelEleve.Add(new NoteViewModel { NoteId = note.NoteId, EleveId = eleve.EleveId, Matiere = note.Matiere, NoteEleve = note.NoteEleve, Appreciation = note.Appreciation, DateNote = note.DateNote });
        }
        if (notesEleve != null && notesEleve.Count > 0)
        {
          elevesViewModels.Add(new EleveViewModel { Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, Notes = notesViewModelEleve });
        }
        else
        {
          elevesViewModels.Add(new EleveViewModel { Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance });
        }
      }

      return elevesViewModels;
    }

		#region "Mocks"
		public static void createMocks(BusinessManager bm)
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

      Note n = new Note();
      n.EleveId = 4;
      n.Matiere = "Maths";
      n.DateNote = DateTime.Now;
      n.Appreciation = "not too bad";
      n.NoteEleve = 15;
      bm.AddNote(n);
    }

    public static void mocksSansBDD()
    {
        // MOCK d'eleves
        List<NoteViewModel> notes = new List<NoteViewModel>();
        notes.Add(new NoteViewModel { Matiere = "laMatiere", NoteEleve = 2, Appreciation = "cette appreciation est qualitative, n'est-ce pas ?", DateNote = DateTime.Now});
        List<EleveViewModel> Students = new List<EleveViewModel>();
        Students.Add(new EleveViewModel { Nom = "YouThere", Prenom = "Hey", ClassId = 1, Notes = notes });
        Students.Add(new EleveViewModel { Nom = "Rouana", Prenom = "Marie", ClassId = 1 });
    }
		#endregion

        public ActionResult Classes()
        {
            ViewBag.Message = "classes list";

            return View();
        }

    }
}