using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Mapping
{
    public class NoteMapping : EntityTypeConfiguration<Note>
    {
        public NoteMapping()
        {
            ToTable("Note");
            HasKey(n => n.NoteId);
        }
    }
}
