using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionEleves.ApplicationWebMVC.Models
{
	public class AbsenceViewModel
	{
    [Key]
    public int AbsenceId { get; set; }

    [DataType(DataType.Date)]
    public DateTime DateAbsence { get; set; }

    public string Motif { get; set; }

    public int EleveId { get; set; }
  }
}