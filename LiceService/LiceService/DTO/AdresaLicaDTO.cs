﻿namespace LiceService.DTO
{
	/// <summary>
	/// DTO za adresu lica.
	/// </summary>
	public class AdresaLicaDTO
	{
		/// <summary>
		/// ID adrese.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// Ulica i broj adrese.
		/// </summary>
		public string UlicaBroj { get; set; } = null!;

		/// <summary>
		/// Mesto adrese.
		/// </summary>
		public string Mesto { get; set; } = null!;

		/// <summary>
		/// Poštanski broj adrese.
		/// </summary>
		public int PostanskiBroj { get; set; } = 0!;

		/// <summary>
		/// Država adrese.
		/// </summary>
		public string Drzava { get; set; } = null!;
	}
}
