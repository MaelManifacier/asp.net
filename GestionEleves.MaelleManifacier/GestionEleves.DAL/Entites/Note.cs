using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Entites
{
    public class Note
    {
        [Key]
        public int NoteId { get; set; }

        [StringLength(40)]
        public string Matiere { get; set; }

        public DateTime DateNote { get; set; }

        [StringLength(200)]
        public string Appreciation { get; set; }

        public int NoteEleve { get; set; }

        [Required]
        public int EleveId { get; set; }

        override
        public string ToString()
        {
          return $"NoteId : {this.NoteId}, EleveId : {this.EleveId}, Matiere : {this.Matiere}, DateNote : {this.DateNote}, NoteEleve : {this.NoteEleve}, Appreciation : {this.Appreciation}";

          // booh that's bad
          //return "NoteId : " + this.NoteId + ", EleveId : " + this.EleveId + ", Matiere : " + this.Matiere + ", DateNote : " + this.DateNote + ", NoteEleve : " + this.NoteEleve + ", Appreciation : " + this.Appreciation;
        }
  }
}
