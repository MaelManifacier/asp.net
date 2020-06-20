using GestionEleves.BusinessLayer.Query;
using GestionEleves.DAL;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.BusinessLayer
{
    public class BusinessManager
    {
        #region "Instanciation Singleton / Contexte"
        // instance du singleton
        public static BusinessManager _instance;

        // contexte
        private Contexte _contexte;

        private BusinessManager()
        {
            // on instancie le contexte (projet Model ou DAL)
            _contexte = new Contexte();
        }

        public static BusinessManager GetInstance()
        {
            if(_instance != null)
            {
                return _instance;
            }
            _instance = new BusinessManager();
            return _instance;
        }
        #endregion

        #region "Méthodes"
        public List<Eleve> GetEleves()
        {
            EleveQuery query = new EleveQuery(_contexte);
            var result = query.GetAll();
            return result;
        }

        public Eleve GetEleve(int eleveId)
        {
          EleveQuery query = new EleveQuery(_contexte);
          return query.GetEleveById(eleveId);
        }

        public void AddEleve(Eleve e)
        {
            EleveQuery query = new EleveQuery(_contexte);
            query.AddEleve(e);
        }

        public void DeleteEleve(int EleveID)
        {
            EleveQuery query = new EleveQuery(_contexte);
            // A VOIR
        }

        public List<Note> GetNotesByEleve(int EleveID)
        {
            NoteQuery query = new NoteQuery(_contexte);
            return query.GetNotesByEleve(EleveID);
        }

    #endregion

      #region "SearchEleve"

      public List<Eleve> SearchEleve(String searchString)
      {
      List<Eleve> Eleves = new List<Eleve>();
      EleveQuery query = new EleveQuery(_contexte);
      Eleves = query.SearchEleve(searchString);

      return Eleves;
      }

      #endregion

    #region "Note"

    public void AddNote(Note n)
    {
      NoteQuery query = new NoteQuery(_contexte);
      query.AddNote(n);
    }

    #endregion
  }
}
