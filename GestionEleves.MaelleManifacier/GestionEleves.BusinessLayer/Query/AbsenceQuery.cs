using GestionEleves.DAL;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.BusinessLayer.Query
{
	internal class AbsenceQuery
	{
		#region "Instanciation"

		private readonly Contexte _contexte;
		public AbsenceQuery(Contexte contexte)
		{
			this._contexte = contexte;
		}

		#endregion

		public List<Absence> GetAbsenceByEleveId(int EleveId)
		{
			return _contexte.Absences.Where(a => a.EleveId == EleveId).ToList();
		}

		public int AddAbsence(Absence a)
		{
			_contexte.Absences.Add(a);
			_contexte.SaveChanges();
			return a.AbsenceId;
		}

		public Absence DeleteAbsence(int absenceId)
		{
			Absence a = _contexte.Absences.FirstOrDefault(absence => absence.AbsenceId == absenceId);
			if(a != null)
			{
				_contexte.Absences.Remove(a);
				_contexte.SaveChanges();
			}
			return a;
		}

		public Absence UpdateAbsence(Absence a)
		{
			Absence absenceAModifier = _contexte.Absences.FirstOrDefault(absence => absence.AbsenceId == a.AbsenceId);
			if(absenceAModifier != null)
			{
				absenceAModifier.DateAbsence = a.DateAbsence;
				absenceAModifier.EleveId = a.EleveId;
				absenceAModifier.Motif = a.Motif;
			}

			return absenceAModifier;
		}


	}
}
