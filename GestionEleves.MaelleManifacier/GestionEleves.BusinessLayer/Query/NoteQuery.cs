using GestionEleves.DAL;
using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.BusinessLayer.Query
{
    internal class NoteQuery
    {
        private Contexte _contexte;

        public NoteQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

        public List<Note> GetNotesByEleve(int EleveID)
        {
            return _contexte.Notes.Where(n => n.EleveId == EleveID).ToList();
        }

        public void AddNote(Note n)
        {
          _contexte.Notes.Add(n);
          _contexte.SaveChanges();
        }


  }
}
