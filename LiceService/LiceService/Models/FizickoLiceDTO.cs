﻿namespace LiceService.Entities
{
	/// <summary>
	/// DTO za fizičko lice.
	/// </summary>
	public class FizickoLiceDTO
	{
		/// <summary>
		/// ID fizičkog lica.
		/// </summary>
		public Guid ID { get; set; }

		/// <summary>
		/// JMBG fizičkog lica.
		/// </summary>
		public string? JMBG { get; set; }

		/// <summary>
		/// Naziv fizičkog lica.
		/// </summary>
		public string? Naziv { get; set; }
	}
}
