using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEleves.ApplicationWebMVC.Models
{
    public class EleveViewModel
    {
        [Key]
        public int EleveId { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<NoteViewModel> Notes { get; set; }
        public List<AbsenceViewModel> Absences { get; set; }
        public double Moyenne { get; set; }
        public int ClassId { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateNaissance { get; set; }

    public EleveViewModel()
    {

    }

    }
}