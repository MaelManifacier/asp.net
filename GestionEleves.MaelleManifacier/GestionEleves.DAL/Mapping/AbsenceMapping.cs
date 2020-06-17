using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL.Mapping
{
    class AbsenceMapping : EntityTypeConfiguration<Absence>
    {
        public AbsenceMapping()
        {
            ToTable("Absence");
            HasKey(a => a.AbsenceId);
        }
    }
}
