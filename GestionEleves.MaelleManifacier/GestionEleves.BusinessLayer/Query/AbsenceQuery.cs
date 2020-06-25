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

		private Contexte _contexte;
		public AbsenceQuery()
		{
			this._contexte = new Contexte();
		}

		#endregion

		public List<Absence> getAbsenceByEleveId(int EleveId)
		{
			return _contexte.Absences.Where(a => a.EleveId == EleveId).ToList();
		}


	}
}
