using System;
using GestionEleves.BusinessLayer;
using GestionEleves.DAL.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GestionEleves.UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddEleve_ShouldReturnEleveId()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve eleve = new Eleve { ClassId = 2, DateNaissance = DateTime.Now, Nom = "Oi", Prenom = "Allan" };

          Assert.IsNotNull(bm.AddEleve(eleve));
        }

        [TestMethod]
        public void GetEleve_ShouldReturnEleve()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve eleve = new Eleve { ClassId = 4, DateNaissance = DateTime.Now, Nom = "Balmaské", Prenom = "Alonzo" };
          int eleveId = bm.AddEleve(eleve);
          Assert.IsNotNull(bm.GetEleve(eleveId));
        }


        [TestMethod]
        public void DeleteEleve_ShouldReturnEleve()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve e = bm.GetEleve(2);
          if(e != null)
          {
            Assert.AreEqual(bm.DeleteEleve(2), e);
          }
        }



        [TestMethod]
        public void AddAbsenceToEleve_ShouldReturnAbsenceId()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve eleve = new Eleve { ClassId = 3, DateNaissance = DateTime.Now, Nom = "Embett", Prenom = "Akim" };
          int eleveId = bm.AddEleve(eleve);
          Absence a = new Absence { DateAbsence = DateTime.Now, EleveId = eleveId, Motif = "original" };
          Assert.IsNotNull(bm.AddAbsence(a));
        }

        [TestMethod]
        public void DeleteAbsence_ShouldReturnAbsence()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve eleve = new Eleve { ClassId = 3, DateNaissance = DateTime.Now, Nom = "Provist", Prenom = "Alain" };
          int eleveId = bm.AddEleve(eleve);
          Absence a = new Absence { DateAbsence = DateTime.Now, EleveId = eleveId, Motif = "Bravo, jamais là celui-là" };
          int absenceId = bm.AddAbsence(a);
          a.AbsenceId = absenceId;
          Assert.AreEqual(bm.DeleteAbsence(absenceId), a);
        }

        [TestMethod]
        public void AddNoteToEleve_ShouldReturnNoteId()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve eleve = new Eleve { ClassId = 2, DateNaissance = DateTime.Now, Nom = "Javel", Prenom = "Aude" };
          int eleveId = bm.AddEleve(eleve);
          Note n = new Note { EleveId = eleveId, DateNote = DateTime.Now, Matiere = "Lancer de boue", NoteEleve = 20, Appreciation = "Très impliqué" };
          Assert.IsNotNull(bm.AddNote(n));
        }

        [TestMethod]
        public void DeleteNote_ShouldReturnNote()
        {
          BusinessManager bm = BusinessManager.GetInstance();
          Eleve eleve = new Eleve { ClassId = 3, DateNaissance = DateTime.Now, Nom = "Afritt", Prenom = "Barack" };
          int eleveId = bm.AddEleve(eleve);
          Note n = new Note { EleveId = eleveId, DateNote = DateTime.Now, Matiere = "Course", NoteEleve = 1, Appreciation = "ne peut mieux faire" };
          int noteId = bm.AddNote(n);
          n.NoteId = noteId;
          Assert.AreEqual(bm.DeleteNote(noteId), n);
        }
  }
}
