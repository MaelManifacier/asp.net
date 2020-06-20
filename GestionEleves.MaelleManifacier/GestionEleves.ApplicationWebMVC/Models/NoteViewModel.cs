using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionEleves.ApplicationWebMVC.Models
{
    public class NoteViewModel
    {
        public int NoteId { get; set; }
        public int EleveId { get; set; }

        public string Matiere { get; set; }
        public int NoteEleve { get; set; }
        public string Appreciation { get; set; }
        public DateTime DateNote { get; set; }
    }
}