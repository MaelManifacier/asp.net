using GestionEleves.BusinessLayer;
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
            GestionEleves.DAL.Entites.Eleve eleve = new DAL.Entites.Eleve();
            eleve.Nom = formData.Nom;
            eleve.Prenom = formData.Prenom;
            eleve.ClassId = formData.ClassId;
            eleve.DateNaissance = formData.DateNaissance;
            bm.AddEleve(eleve);

            return Redirect("/");
          }

          return View("AddStudent");
        }
  }
}