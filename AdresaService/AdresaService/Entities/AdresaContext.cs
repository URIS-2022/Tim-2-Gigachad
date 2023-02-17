﻿using Microsoft.EntityFrameworkCore;

namespace AdresaService.Entities
{
    /// <summary>
	/// DbContext za AdresaService mikroservis.
	/// </summary>
    public class AdresaContext : DbContext
    {
        /// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public AdresaContext(DbContextOptions options) : base(options) { }

        /// <summary>
        /// DbSet za entitet adresa.
        /// </summary>
        public DbSet<AdresaEntity> Adresa { get; set; }

        /// <summary>
        /// Popunjava bazu sa nekim inicijalnim podacima.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("3aa0344b-57b5-450a-b83a-18c4555be65c"),
                Ulica = "Slavoja Perica",
                Broj = 11,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            builder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("6f79d49c-1c14-49b7-94c3-19a81c7f97a0"),
                Ulica = "Dositejeva",
                Broj = 23,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            builder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("878100df-6973-4292-acb1-0c25b7ac2260"),
                Ulica = "Jevrejska",
                Broj = 7,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
            builder.Entity<AdresaEntity>().HasData(new
            {
                ID = Guid.Parse("accad5a2-e5bc-4ff5-a5b7-fc38ab8a47fe"),
                Ulica = "Mise Dimitrijevica",
                Broj = 22,
                Mesto = "Novi Sad",
                PostanskiBroj = 22000,
                Drzava = "Srbija"
            });
        }
    }
}
