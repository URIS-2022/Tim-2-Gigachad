using Microsoft.EntityFrameworkCore;

namespace DeoParceleService.Entities
{
	/// <summary>
	/// DbContext za DeoParceleService mikroservis.
	/// </summary>
	public class DeoParceleContext : DbContext
	{
		/// <summary>
		/// Dependency injection za konfiguraciju konekcije i opcije sa bazom.
		/// </summary>
		public DeoParceleContext(DbContextOptions options) : base(options) { }

		/// <summary>
		/// DbSet za entitet parcela.
		/// </summary>
		public DbSet<ParcelaEntity> Parcele { get; set; }

		/// <summary>
		/// DbSet za entitet deo parcela.
		/// </summary>
		public DbSet<DeoParceleEntity> DeloviParcela { get; set; }

		/// <summary>
		/// Popunjava bazu sa inicijalnim podacima.
		/// </summary>
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<ParcelaEntity>().HasData(new
			{
				ID = Guid.Parse("06f51688-c60a-4dbf-8955-f1713fa47e28"),
				KupacID = Guid.Parse("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"),
				Oznaka = "91IZ1JDB21",
				UkupnaPovrsina = 4774,
				KatastarskaOpstina = "STARI_GRAD"
			});
			modelBuilder.Entity<ParcelaEntity>().HasData(new
			{
				ID = Guid.Parse("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
				KupacID = Guid.Parse("f9e22f42-cd14-4e3b-bbb7-eee4fe30a60a"),
				Oznaka = "I48QEJTUAW",
				UkupnaPovrsina = 6054,
				KatastarskaOpstina = "NOVI_GRAD"
			});

			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("edf1f7ca-3b73-4cb8-8cfd-4bd615dd6ada"),
				ParcelaID = Guid.Parse("06f51688-c60a-4dbf-8955-f1713fa47e28"),
				KupacID = Guid.Parse("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
				RedniBroj = "55907",
				Povrsina = 805,
				BrojNekretnina = 10,
				Obradivost = "OBRADIVO",
				Kultura = "NJIVE",
				Klasa = "I",
				ZasticenaZona = "I",
				OblikSvojine = "PRIVATNA_SVOJINA",
				Odvodnjavanje = true
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("3846acaf-3d0e-439a-bf27-85344934f2ca"),
				ParcelaID = Guid.Parse("06f51688-c60a-4dbf-8955-f1713fa47e28"),
				KupacID = Guid.Parse("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
				RedniBroj = "82075",
				Povrsina = 923,
				BrojNekretnina = 15,
				Obradivost = "OBRADIVO",
				Kultura = "NJIVE",
				Klasa = "I",
				ZasticenaZona = "I",
				OblikSvojine = "PRIVATNA_SVOJINA",
				Odvodnjavanje = true
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("dacea418-fdcc-4289-8a94-df82a7056c18"),
				ParcelaID = Guid.Parse("06f51688-c60a-4dbf-8955-f1713fa47e28"),
				KupacID = Guid.Parse("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"),
				RedniBroj = "32477",
				Povrsina = 975,
				BrojNekretnina = 13,
				Obradivost = "OBRADIVO",
				Kultura = "NJIVE",
				Klasa = "I",
				ZasticenaZona = "I",
				OblikSvojine = "MESOVITA_SVOJINA",
				Odvodnjavanje = true
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("6c5fe5f2-5389-4022-ae48-6e905cca6c60"),
				ParcelaID = Guid.Parse("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
				KupacID = Guid.Parse("753d20f5-73a3-4e00-a3a2-e1c43d6b0777"),
				RedniBroj = "78398",
				Povrsina = 440,
				BrojNekretnina = 27,
				Obradivost = "OBRADIVO",
				Kultura = "VOCNJACI",
				Klasa = "II",
				ZasticenaZona = "I",
				OblikSvojine = "PRIVATNA_SVOJINA",
				Odvodnjavanje = true
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("5eb8c5d9-131f-4bba-a31b-b669bca69be3"),
				ParcelaID = Guid.Parse("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
				KupacID = Guid.Parse("4d1c0702-aeb4-4a4f-bdb8-26e1cc53b2eb"),
				RedniBroj = "35683",
				Povrsina = 564,
				BrojNekretnina = 26,
				Obradivost = "OBRADIVO",
				Kultura = "VOCNJACI",
				Klasa = "II",
				ZasticenaZona = "I",
				OblikSvojine = "MESOVITA_SVOJINA",
				Odvodnjavanje = true
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("1c91f161-f4c2-4c58-ba74-ab143b0679ff"),
				ParcelaID = Guid.Parse("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
				KupacID = Guid.Parse("93d92981-a754-41d8-8d1f-b5462a9e0386"),
				RedniBroj = "86657",
				Povrsina = 685,
				BrojNekretnina = 21,
				Obradivost = "OSTALO",
				Kultura = "MOCVARE",
				Klasa = "VIII",
				ZasticenaZona = "IV",
				OblikSvojine = "DRUSTVENA_SVOJINA",
				Odvodnjavanje = false
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("55fd9408-bf63-4113-89c7-8fa72bd1ed5e"),
				ParcelaID = Guid.Parse("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
				KupacID = Guid.Parse("93d92981-a754-41d8-8d1f-b5462a9e0386"),
				RedniBroj = "85120",
				Povrsina = 488,
				BrojNekretnina = 29,
				Obradivost = "OBRADIVO",
				Kultura = "VINOGRADI",
				Klasa = "II",
				ZasticenaZona = "I",
				OblikSvojine = "DRZAVNA_SVOJINA",
				Odvodnjavanje = true
			});
			modelBuilder.Entity<DeoParceleEntity>().HasData(new
			{
				ID = Guid.Parse("aaa2b53b-278d-4ceb-9992-f57bb8818773"),
				ParcelaID = Guid.Parse("08c765d1-2a28-4a70-8ebb-b1cbcdb03a3e"),
				KupacID = Guid.Parse("ccc043c6-398c-485d-9840-092c0441ebe8"),
				RedniBroj = "53891",
				Povrsina = 528,
				BrojNekretnina = 24,
				Obradivost = "OSTALO",
				Kultura = "MOCVARE",
				Klasa = "VIII",
				ZasticenaZona = "IV",
				OblikSvojine = "ZADRUZNA_SVOJINA",
				Odvodnjavanje = false
			});
		}
	}
}
