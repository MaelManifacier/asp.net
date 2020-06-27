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
    public class StudentController : Controller
    {
      // GET: Student
      public ActionResult Index()
      {
        return View();
      }

        public ActionResult AddStudent()
        {
          return View();
        }

        [HttpPost]
        public ActionResult AddStudentForm(Models.EleveViewModel formData)
        {
          if (formData.Nom != null && formData.Prenom != null && formData.DateNaissance != null && formData.ClassId >= 0)
          {
            // récupération du BusinessManager
            BusinessManager bm = BusinessManager.GetInstance();
            GestionEleves.DAL.Entites.Eleve eleve = new DAL.Entites.Eleve { Nom = formData.Nom, Prenom = formData.Prenom, ClassId = formData.ClassId, DateNaissance = formData.DateNaissance };
            bm.AddEleve(eleve);

            return Redirect("/Home/Students");
          }

          return View("AddStudent");
        }

    public ActionResult CreateAbsence(int id, Models.AbsenceViewModel formData)
    {
      if(formData.Motif != null && formData.DateAbsence != null)
      {
        BusinessManager bm = BusinessManager.GetInstance();
        bm.AddAbsence(new Absence { EleveId = id, DateAbsence = formData.DateAbsence, Motif = formData.Motif });

        return Redirect("/Home/Students");
      }

      ViewBag.EleveId = id;
      return View("CreateAbsence");
    }

    public ActionResult CreateNote(int id, Models.NoteViewModel formData)
    {
      if (formData.Appreciation != null && formData.DateNote != null && formData.Matiere != null)
      {
        BusinessManager bm = BusinessManager.GetInstance();
        bm.AddNote(new Note { EleveId = id, Appreciation = formData.Appreciation, DateNote = formData.DateNote, Matiere = formData.Matiere, NoteEleve = formData.NoteEleve });

        return Redirect("/Home/Students");
      }

      ViewBag.EleveId = id;
      return View("CreateNote");
    }

    public ActionResult Details(int id)
    {
      BusinessManager bm = BusinessManager.GetInstance();

      List<Note> notes = bm.GetNotesByEleve(id);
      List<NoteViewModel> notesViewModel = new List<NoteViewModel>();
      foreach (Note note in notes)
      {
        notesViewModel.Add(new NoteViewModel
        {
          EleveId = note.EleveId
          ,
          NoteEleve = note.NoteEleve
          ,
          Appreciation = note.Appreciation
          ,
          DateNote = note.DateNote
          ,
          Matiere = note.Matiere
          ,
          NoteId = note.NoteId
        });

      }

      List<Absence> absences = bm.GetAbsenceByEleveId(id);
      List<AbsenceViewModel> absencesViewModels = new List<AbsenceViewModel>();
      absences.ForEach(absence =>
      {
        absencesViewModels.Add(new AbsenceViewModel { AbsenceId = absence.AbsenceId, DateAbsence = absence.DateAbsence, EleveId = absence.EleveId, Motif = absence.Motif });
      });

      Eleve eleve = bm.GetEleve(id);
      EleveViewModel eleveViewModel;
      if (notes != null && notes.Count > 0)
      {
        double moyenne = notes.Average(n => n.NoteEleve);
        eleveViewModel = new EleveViewModel { ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, EleveId = eleve.EleveId, Nom = eleve.Nom, Prenom = eleve.Prenom, Moyenne = moyenne, Notes = notesViewModel };
      }
      else
      {
        eleveViewModel = new EleveViewModel { ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, EleveId = eleve.EleveId, Nom = eleve.Nom, Prenom = eleve.Prenom };
      }

      if(absences != null && absences.Count > 0)
      {
        eleveViewModel.Absences = absencesViewModels;
      }

      ViewData.Model = eleveViewModel;
      return View();
    }

    public ActionResult Edit(int id, Models.EleveViewModel formData)
    {
      if (formData.Nom != null && formData.Prenom != null && formData.DateNaissance != null && formData.ClassId >= 0)
      {
        // récupération du BusinessManager
        BusinessManager bm = BusinessManager.GetInstance();
        GestionEleves.DAL.Entites.Eleve eleve = new DAL.Entites.Eleve { Nom = formData.Nom, Prenom = formData.Prenom, ClassId = formData.ClassId, DateNaissance = formData.DateNaissance, EleveId = formData.EleveId };
        bm.UpdateEleve(eleve);
        
        return Redirect("/Home/Students");
      }

      ViewBag.EleveId = id;
      return View();
    }

    public ActionResult Delete(int id)
    {
      BusinessManager bm = BusinessManager.GetInstance();
      bm.DeleteEleve(id);

      return Redirect("/Classes/Index");
    }

    /* - - - Gestion des absences - - - */
    public ActionResult EditAbsence(int id, Models.AbsenceViewModel formData)
    {
      if(formData.DateAbsence != null && formData.Motif != null)
      {
        BusinessManager bm = BusinessManager.GetInstance();
        bm.UpdateAbsence(new Absence { AbsenceId = formData.AbsenceId, DateAbsence = formData.DateAbsence, EleveId = formData.EleveId, Motif = formData.Motif });

        return Redirect("/Home/Students/");
      }

      ViewBag.EleveId = id;
      return View();
    }

    public ActionResult DeleteAbsence(int id)
    {
      BusinessManager bm = BusinessManager.GetInstance();
      bm.DeleteAbsence(id);

      return Redirect("/Home/Students");
    }
  }
}