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
		#region "Instanciation"
		private readonly Contexte _contexte;

        public NoteQuery(Contexte contexte)
        {
            _contexte = contexte;
        }

		#endregion


		public List<Note> GetNotesByEleve(int EleveID)
    {
        return _contexte.Notes.Where(n => n.EleveId == EleveID).ToList();
    }

    public int AddNote(Note n)
    {
      _contexte.Notes.Add(n);
      _contexte.SaveChanges();
      return n.NoteId;
    }

    public Note DeleteNote(int noteId)
    {
      Note n = _contexte.Notes.FirstOrDefault(note => note.NoteId == noteId);
      if (n != null)
      {
        _contexte.Notes.Remove(n);
        _contexte.SaveChanges();
      }
      return n;
    }
  }
}
