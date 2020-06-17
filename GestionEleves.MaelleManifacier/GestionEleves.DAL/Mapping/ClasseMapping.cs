using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Mapping
{
    public class ClasseMapping : EntityTypeConfiguration<Classe>
    {
        public ClasseMapping()
        {
            ToTable("Classe");
            HasKey(c => c.ClassId);
        }
    }
}
