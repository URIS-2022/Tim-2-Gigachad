using AutoMapper;
using KorisnikService.DTO;
using KorisnikService.Entities;
using System.Security.Cryptography;

namespace KorisnikService.Data
{
	/// <summary>
	/// Repozitorijum za entitet korisnik.
	/// </summary>
	public class KorisnikRepository : IKorisnikRepository
	{
		private readonly KorisnikContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public KorisnikRepository(KorisnikContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu korisnika iz konteksta.
		/// </summary>
		/// <returns>Vraća listu korisnika.</returns>
		public List<KorisnikEntity> GetKorisnici()
		{
			return context.Korisnici.ToList();
		}

		/// <summary>
		/// Vraća jednog korisnika iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		/// <returns>Vraća specifiranog korisnika.</returns>
		public KorisnikEntity? GetKorisnikByID(Guid korisnikID)
		{
			return context.Korisnici.FirstOrDefault(e => e.ID == korisnikID);
		}

		/// <summary>
		/// Dodaje novog korisnika u kontekst.
		/// </summary>
		/// <param name="korisnikCreateDTO">DTO za kreiranje korisnika.</param>
		/// <returns>Vraća DTO kreiranog korisnika.</returns>
		public KorisnikDTO CreateKorisnik(KorisnikCreateDTO korisnikCreateDTO)
		{
			Tuple<string, string>  hashLozinka = HashPassword(korisnikCreateDTO.Lozinka);
			KorisnikEntity korisnik = mapper.Map<KorisnikEntity>(korisnikCreateDTO);
			korisnik.ID = Guid.NewGuid();
			korisnik.Lozinka = hashLozinka.Item1;
			korisnik.So = hashLozinka.Item2;
			context.Add(korisnik);
			return mapper.Map<KorisnikDTO>(korisnik);
		}

		/// <summary>
		/// Ažurira specifiranog korisnika.
		/// </summary>
		/// <param name="korisnikUpdateDTO">DTO za ažuriranje korisnika.</param>
		/// <returns>Vraća DTO ažuriranog korisnika.</returns>
		public KorisnikDTO UpdateKorisnik(KorisnikUpdateDTO korisnikUpdateDTO)
		{
			KorisnikEntity? oldKorisnik = context.Korisnici.FirstOrDefault(e => e.ID == Guid.Parse(korisnikUpdateDTO.ID));
			KorisnikEntity korisnik = mapper.Map<KorisnikEntity>(korisnikUpdateDTO);
			Tuple<string, string> hashLozinka = HashPassword(korisnik.Lozinka);
			korisnik.Lozinka = hashLozinka.Item1;
			korisnik.So = hashLozinka.Item2;
			mapper.Map(korisnik, oldKorisnik);
			return mapper.Map<KorisnikDTO>(oldKorisnik);
		}

		/// <summary>
		/// Briše korisnika iz konteksta.
		/// </summary>
		/// <param name="korisnikID">ID korisnika.</param>
		public void DeleteKorisnik(Guid korisnikID)
		{
			KorisnikEntity? korisnik = GetKorisnikByID(korisnikID);
			if (korisnik != null)
				context.Remove(korisnik);
		}

		/// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		public bool SaveChanges()
		{
			return context.SaveChanges() > 0;
		}

		/// <summary>
		/// Vrši hašovanje lozinke.
		/// </summary>
		/// <param name="lozinka">Korisnička lozinka.</param>
		/// <returns>Vraća generisani haš i so.</returns>
		private static Tuple<string, string> HashPassword(string lozinka)
		{
			var sBytes = new byte[lozinka.Length];
			RandomNumberGenerator.Create().GetNonZeroBytes(sBytes);
			var salt = Convert.ToBase64String(sBytes);

			var derivedBytes = new Rfc2898DeriveBytes(lozinka, sBytes, 1000);

			return new Tuple<string, string>
			(
			    Convert.ToBase64String(derivedBytes.GetBytes(256)),
			    salt
			);
		}
	}
}
