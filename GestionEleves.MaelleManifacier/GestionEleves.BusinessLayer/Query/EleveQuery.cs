using GestionEleves.DAL;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.BusinessLayer.Query
{
    internal class EleveQuery
    {
        #region "Instanciation"
        private readonly Contexte _contexte;

        public EleveQuery(Contexte contexte)
        {
            _contexte = contexte;
        }
        #endregion

        #region "Methodes - Queries"

        public List<Eleve> GetAll()
        {
            return _contexte.Eleves.ToList();
        }

        public Eleve GetEleveById(int eleveId)
        {
            return _contexte.Eleves.FirstOrDefault(e => e.EleveId == eleveId);
        }

        public void AddEleve(Eleve eleve)
        {
            _contexte.Eleves.Add(eleve);
            _contexte.SaveChanges();
        }

        public Eleve DeleteEleve(int EleveId)
        {
            //Eleve eleve = (Eleve) _contexte.Eleves.Where(e => e.EleveId == EleveId);
            Eleve eleve = _contexte.Eleves.FirstOrDefault(e => e.EleveId == EleveId);
            if (eleve != null)
            {
                _contexte.Eleves.Remove(eleve);
                _contexte.SaveChanges();
                return eleve;
            }
            return null;
        }

        public Eleve UpdateEleve(Eleve eleve)
        {
            Eleve aModifier = (Eleve) from e in _contexte.Eleves
                              where e.EleveId == eleve.EleveId
                              select e;
            //Eleve eleveAModifier = _contexte.Eleves.FirstOrDefault(e => e.EleveId == eleve.EleveId);
            if(aModifier != null)
            {
              aModifier.DateNaissance = eleve.DateNaissance;
              aModifier.ClassId = eleve.ClassId;
              aModifier.Nom = eleve.Nom;
              aModifier.Prenom = eleve.Prenom;
              _contexte.SaveChanges();
            }
            
            return aModifier;
        }

        public List<Eleve> GetEleveForClasse(int Classid)
        {
          return _contexte.Eleves.Where(e => e.ClassId == Classid).ToList();
        }

        #endregion

    public List<Eleve> SearchEleve(String searchString)
    {
      List<Eleve> eleves = new List<Eleve>();

      string[] words = searchString.Split(' ');
      foreach(string word in words)
      {
        IEnumerable<Eleve> elevesNomQuery =
        from eleve in _contexte.Eleves
        where eleve.Nom == word
        select eleve;
        foreach(Eleve e in elevesNomQuery)
        {
          eleves.Add(e);
        }

        IEnumerable<Eleve> elevesPrenomQuery =
        from eleve in _contexte.Eleves
        where eleve.Prenom == word
        select eleve;
        foreach (Eleve e in elevesPrenomQuery)
        {
          eleves.Add(e);
        }
      }
      return eleves;
    }


    }
}
