using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionEleves.DAL.Entites
{
    public class Eleve
    {
        [Key]
        public int EleveId { get; set; }

        [StringLength(20)]
        public string Nom { get; set; }

        [StringLength(20)]
        public string Prenom { get; set; }

        //[Column(TypeName="datetime2")]
        public DateTime DateNaissance { get; set; }

        [Required]
        public int ClassId { get; set; }

        override
        public string ToString()
        {
          return $"EleveId : {this.EleveId}, Nom : {this.Nom}, Prenom : {this.Prenom}, DateNaissance : {this.DateNaissance.ToString()}, ClassId : {this.ClassId}";
        }

        public int GetId()
        {
          return this.EleveId;
        }
  }
}
