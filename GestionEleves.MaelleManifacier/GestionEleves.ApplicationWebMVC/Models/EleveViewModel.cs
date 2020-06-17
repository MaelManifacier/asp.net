using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionEleves.ApplicationWebMVC.Models
{
    public class EleveViewModel
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public List<NoteViewModel> Notes { get; set; }
        public double Moyenne { get; set; }
        public int ClassId { get; set; }
        public DateTime DateNaissance { get; set; }
    }
}