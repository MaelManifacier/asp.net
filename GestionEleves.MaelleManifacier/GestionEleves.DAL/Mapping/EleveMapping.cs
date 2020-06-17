using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Mapping
{
    public class EleveMapping : EntityTypeConfiguration<Eleve>
    {
        public EleveMapping()
        {
            ToTable("Eleve");
            HasKey(e => e.EleveId);

            //HasMany(e => e.Notes).WithRequired(note => note.Eleve).HasForeignKey(note => note.EleveId);
        }
    }
}
