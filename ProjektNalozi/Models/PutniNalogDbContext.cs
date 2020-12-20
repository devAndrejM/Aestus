using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ProjektNalozi.Models
{
    public class PutniNalogDbContext : DbContext
    {
        public PutniNalogDbContext(DbContextOptions<PutniNalogDbContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PutniNalogDB;Trusted_Connection=True;MultipleActiveResultSets=true",
                    builder => builder.EnableRetryOnFailure());
            }
        }

        public DbSet<Putnik> Putnici { get; set; }
        public DbSet<PutniNalog> PutniNalozi { get; set; }
        public DbSet<PutnikovNalog> PutnikoviNalozi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Putnik>().ToTable("Putnici");
            modelBuilder.Entity<PutniNalog>().ToTable("PutniNalozi");
            modelBuilder.Entity<PutnikovNalog>()
                .HasKey(pn => new { pn.PutnikId, pn.PutniNalogId });
            modelBuilder.Entity<PutnikovNalog>()
                .HasOne(pn => pn.PutniNalog)
                .WithMany(p => p.PutnikoviNalozi)
                .HasForeignKey(pn => pn.PutniNalogId);
            modelBuilder.Entity<PutnikovNalog>()
                .HasOne(pn => pn.Putnik)
                .WithMany(p => p.PutnikoviNalozi)
                .HasForeignKey(pn => pn.PutnikId);


            modelBuilder.Entity<Putnik>().
                HasData(
                new Putnik { PutnikId = 1, Ime = "Marko", Prezime = "Markić",},
                new Putnik { PutnikId = 2, Ime = "Ivan", Prezime = "Ivanić", },
                new Putnik { PutnikId = 3, Ime = "Luna", Prezime = "Lunić", },
                new Putnik { PutnikId = 4, Ime = "Karla", Prezime = "Karlić", }

                );
            modelBuilder.Entity<PutniNalog>().
                HasData(
                new PutniNalog { PutniNalogId = 1, RazlogPutovanja = "Moralo se", Polazak = new DateTime(2018, 8, 23), Povratak = new DateTime(2018, 8, 28), BrojPutnika = 1,  Polaziste = "Zagreb", Odrediste = "Osijek", Prijevoz = "Službeni automobil", RegistracijaVozila = "ZG2342CA", Komentar = "", Email = "ivan@gmail.com",  },
               new PutniNalog { PutniNalogId = 2, RazlogPutovanja = "Moralo se", Polazak = new DateTime(2020, 8, 24), Povratak = new DateTime(2020, 9, 25), BrojPutnika = 2,  Polaziste = "Zagreb", Odrediste = "Osijek", Prijevoz = "Službeni automobil", RegistracijaVozila = "ZG2342CA", Komentar = "eto", Email = "ivan@gmail.com",  },
                new PutniNalog { PutniNalogId = 3, RazlogPutovanja = "Moralo se", Polazak = new DateTime(2019, 2, 22), Povratak = new DateTime(2019, 2, 23), BrojPutnika = 3,  Polaziste = "Zagreb", Odrediste = "Osijek", Prijevoz = "Službeni automobil", RegistracijaVozila = "ZG2342CA", Komentar = "", Email = "ivan@gmail.com",  },
                new PutniNalog { PutniNalogId = 4, RazlogPutovanja = "Moralo se", Polazak = new DateTime(2021, 1, 21), Povratak = new DateTime(2021, 1, 22), BrojPutnika = 1,  Polaziste = "Zagreb", Odrediste = "Osijek", Prijevoz = "Službeni automobil", RegistracijaVozila = "ZG2342CA", Komentar = "", Email = "ivan@gmail.com",  }
                );

            modelBuilder.Entity<PutnikovNalog>().
                HasData(
                new PutnikovNalog { PutnikId = 1, PutniNalogId = 1 },
                new PutnikovNalog { PutnikId = 1, PutniNalogId = 2 },
                new PutnikovNalog { PutnikId = 1, PutniNalogId = 3 },
                new PutnikovNalog { PutnikId = 2, PutniNalogId = 2 },                
                new PutnikovNalog { PutnikId = 3, PutniNalogId = 3 },
                new PutnikovNalog { PutnikId = 4, PutniNalogId = 3 },
                new PutnikovNalog { PutnikId = 3, PutniNalogId = 4 }
                );

        }
    }
}
