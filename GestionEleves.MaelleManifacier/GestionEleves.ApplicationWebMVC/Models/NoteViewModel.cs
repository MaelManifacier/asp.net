using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        public DateTime DateNote { get; set; }
    }
}
