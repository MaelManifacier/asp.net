using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public DateTime DateNaissance { get; set; }

        [Required]
        public int ClassId { get; set; }
    }
}
