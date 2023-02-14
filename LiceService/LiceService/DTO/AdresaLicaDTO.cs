namespace LiceService.DTO
{
	/// <summary>
	/// DTO za adresu lica.
	/// </summary>
	public class AdresaLicaDTO
	{
		/// <summary>
		/// Ulica adrese.
		/// </summary>
		public string Ulica { get; set; }

		/// <summary>
		/// Broj adrese.
		/// </summary>
		public int Broj { get; set; }

		/// <summary>
		/// Mesto adrese.
		/// </summary>
		public string Mesto { get; set; }

		/// <summary>
		/// Poštanski broj adrese.
		/// </summary>
		public int PostanskiBroj { get; set; }

		/// <summary>
		/// Država broj adrese.
		/// </summary>
		public int Drzava { get; set; }
	}
}
