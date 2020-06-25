using GestionEleves.DAL;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.BusinessLayer.Query
{
	internal class ClasseQuery
	{
		#region "Instanciation"

		private Contexte _contexte;
		public ClasseQuery()
		{
			this._contexte = new Contexte();
		}

		#endregion

		public List<Classe> getAll()
		{
			List<Classe> classe = _contexte.Classes.ToList();
			/*
			classe.ForEach(c =>
			{
				_contexte.Eleves.ToDictionary(c.ClassId, _contexte.Eleves.Select(e => e.ClassId == c.ClassId));
			});*/
			return classe;
		}


	}
}
