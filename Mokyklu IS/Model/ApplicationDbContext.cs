using Microsoft.EntityFrameworkCore;
using Mokyklu_IS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mokyklu_IS.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Administratorius> Administratorius { get; set; }
        public DbSet<Registracija> Registracija { get; set; }
        public DbSet<Klase> Klase { get; set; }
        public DbSet<Susirinkimas> Susirinkimas { get; set; }
        public DbSet<Tevas> Tevas { get; set; }
        public DbSet<Dalykas> Dalykas { get; set; }
        public DbSet<Mokinys> Mokinys { get; set; }
        public DbSet<Mokytojas> Mokytojas { get; set; }
        public DbSet<Pastaba> Pastaba { get; set; }
        public DbSet<Zinutes> Zinutes { get; set; }
        public DbSet<Pamoka> Pamoka { get; set; }
        public DbSet<Atsiskaitymas> Atsiskaitymas { get; set; }
        public DbSet<Pazimys> Pazimys { get; set; }
        public DbSet<Namu_Darbas> Namu_Darbas { get; set; }
        public DbSet<Tvarkarastis> Tvarkarastis { get; set; }

        public DbSet<Destymas> Destymas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Destymas>()
                .HasNoKey();
        }

    }
}
