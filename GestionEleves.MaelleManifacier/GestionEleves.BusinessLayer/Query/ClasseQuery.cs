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

		private readonly Contexte _contexte;
		public ClasseQuery(Contexte contexte)
		{
			this._contexte = contexte;
		}

		#endregion

		public List<Classe> GetAll()
		{
			List<Classe> classe = _contexte.Classes.ToList();
			/*
			classe.ForEach(c =>
			{
				_contexte.Eleves.ToDictionary(c.ClassId, _contexte.Eleves.Select(e => e.ClassId == c.ClassId));
			});*/
			return classe;
		}

		public Classe GetClasse(int classId)
		{
			return _contexte.Classes.FirstOrDefault(c => c.ClassId == classId);
		}

		public Dictionary<int, Eleve> GetElevesByClasses()
		{
			Dictionary<int, Eleve> elevesDict = new Dictionary<int, Eleve>();
			elevesDict = _contexte.Eleves.ToDictionary(e => e.ClassId);
			return elevesDict;
		}

		public void AddClasse(Classe classe)
		{
			_contexte.Classes.Add(classe);
			_contexte.SaveChanges();
		}

		public Classe DeleteClasse(int ClassId)
		{
			Classe classe = _contexte.Classes.FirstOrDefault(c => c.ClassId == ClassId);
			if(classe != null)
			{
				_contexte.Classes.Remove(classe);
				_contexte.SaveChanges();
			}
			return classe;
		}

		public Classe UpdateClasse(Classe classe)
		{
			Classe aModifier = _contexte.Classes.FirstOrDefault(c => c.ClassId == classe.ClassId);
			if(aModifier != null)
			{
				aModifier.Niveau = classe.Niveau;
				aModifier.NomEtablissement = classe.NomEtablissement;
			}

			return aModifier;
		}


	}
}
