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
    public class ClassesController : Controller
    {
        // GET: Classes
        public ActionResult Index()
        {
          // récupération du BusinessManager
          BusinessManager bm = BusinessManager.GetInstance();

          List<Classe> Classes = bm.GetClasses();
          List<ClasseViewModel> classesViewModel = new List<ClasseViewModel>();
          foreach (var classe in Classes)
          {
            classesViewModel.Add(new ClasseViewModel { ClassId = classe.ClassId, Niveau = classe.Niveau, NomEtablissement = classe.NomEtablissement });
          }

          ViewData.Model = classesViewModel;
          ViewBag.Message = "classes list";

          return View();
        }

        public ActionResult Create(Models.ClasseViewModel formData)
        {
          if(formData.Niveau != null && formData.NomEtablissement != null)
          {
            BusinessManager bm = BusinessManager.GetInstance();
            GestionEleves.DAL.Entites.Classe classe = new DAL.Entites.Classe();
            classe.Niveau = formData.Niveau;
            classe.NomEtablissement = formData.NomEtablissement;
            bm.AddClasse(classe);

            return Redirect("/Classes/Index");
          }

          return View();
        }

    public ActionResult Delete(int id)
    {
      BusinessManager bm = BusinessManager.GetInstance();
      Classe c = bm.DeleteClasse(id);
      if(c != null)
      {
        return Redirect("/Classes/Index");
      }

      return View("Error");
    }

    public ActionResult Details(int id)
    {
      BusinessManager bm = BusinessManager.GetInstance();
      List<Eleve> eleves = bm.GetElevesForClasse(id);

      List<EleveViewModel> elevesViewModel = new List<EleveViewModel>();
      eleves.ForEach(eleve =>
      {
        double moyenne = bm.GetMoyenne(eleve.EleveId);
        if(moyenne > 0.0)
        {
          elevesViewModel.Add(new EleveViewModel { ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, EleveId = eleve.EleveId, Nom = eleve.Nom, Prenom = eleve.Prenom, Moyenne = moyenne });
        }
        elevesViewModel.Add(new EleveViewModel { ClassId = eleve.ClassId, DateNaissance = eleve.DateNaissance, EleveId = eleve.EleveId, Nom = eleve.Nom, Prenom = eleve.Prenom });
      });

      ViewData.Model = elevesViewModel;

      return View();
    }


    }
}