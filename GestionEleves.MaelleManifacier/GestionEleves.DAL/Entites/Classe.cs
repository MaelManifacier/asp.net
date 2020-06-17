using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Entites
{
    public class Classe
    {
        [Key]
        public int ClassId { get; set; }

        [StringLength(50)]
        public string NomEtablissement { get; set; }

        [StringLength(50)]
        public string Niveau { get; set; }
    }
}
