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
        private Contexte _contexte;

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
            Eleve eleveAModifier = _contexte.Eleves.FirstOrDefault(e => e.EleveId == eleve.EleveId);

            return eleveAModifier;
        }
        #endregion
    }
}
