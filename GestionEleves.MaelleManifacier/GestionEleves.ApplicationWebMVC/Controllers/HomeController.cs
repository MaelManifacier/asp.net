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

        public ActionResult Students()
        {
            /*
            // récupération du BusinessManager
            BusinessManager bm = BusinessManager.GetInstance();
            List<Eleve> Eleves = bm.GetEleves();

            // conversion des eleves en EleveViewModel
            List<EleveViewModel> elevesViewModels = new List<EleveViewModel>();
            List<NoteViewModel> notesViewModelEleve = new List<NoteViewModel>();
            foreach (var eleve in Eleves)
            {
                List<Note> notesEleve = bm.GetNotesByEleve(eleve.EleveId);
                foreach (var note in notesEleve)
                {
                    notesViewModelEleve.Add(new NoteViewModel { Matiere = note.Matiere, NoteEleve = note.NoteEleve, Appreciation = note.Appreciation, DateNote = note.DateNote });
                }
                if(notesEleve != null)
                {
                    elevesViewModels.Add(new EleveViewModel { Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, Notes = notesViewModelEleve });
                } else
                {
                    elevesViewModels.Add(new EleveViewModel { Nom = eleve.Nom, Prenom = eleve.Prenom, ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance });
                }
            }
            */

            // MOCK d'eleves
            List<NoteViewModel> notes = new List<NoteViewModel>();
            notes.Add(new NoteViewModel { Matiere = "laMatiere", NoteEleve = 2, Appreciation = "cette appreciation est qualitative, n'est-ce pas ?", DateNote = DateTime.Now});
            List<EleveViewModel> Students = new List<EleveViewModel>();
            Students.Add(new EleveViewModel { Nom = "YouThere", Prenom = "Hey", ClassId = 1, Notes = notes });
            Students.Add(new EleveViewModel { Nom = "Rouana", Prenom = "Marie", ClassId = 1 });


            // set de ViewBag à la vue
            ViewBag.Message = "student list";
            ViewBag.Students = Students;

            return View();
        }

        public ActionResult Classes()
        {
            ViewBag.Message = "classes list";

            return View();
        }

    }
}