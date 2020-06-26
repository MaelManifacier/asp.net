using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace GestionEleves.ApplicationWebMVC.Models
{
	public class ClasseViewModel
	{
    [Key]
    public int ClassId { get; set; }

    public string NomEtablissement { get; set; }

    public string Niveau { get; set; }
  }
}