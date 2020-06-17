using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Entites
{
    public class Absence
    {
        [Key]
        public int AbsenceId { get; set; }

        public DateTime DateAbsence { get; set; }

        [StringLength(200)]
        public string Motif { get; set; }

        [Required]
        public int EleveId { get; set; }
    }
}
