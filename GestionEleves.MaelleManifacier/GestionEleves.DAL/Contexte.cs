using GestionEleves.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GestionEleves.DAL
{
    public class Contexte : DbContext
    {
        public DbSet<Classe> Classes { get; set; }

        public DbSet<Eleve> Eleves { get; set; }

        public DbSet<Note> Notes { get; set; }
        public DbSet<Absence> Absences { get; set; }

        public Contexte() : base("name=ConnexionString")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // pour ne pas avoir besoin de faire :
            // modelBuilder.Configurations.Add(new ClasseMapping());
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
