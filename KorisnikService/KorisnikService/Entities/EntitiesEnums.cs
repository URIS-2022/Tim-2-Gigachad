namespace KorisnikService.Entities
{
	/// <summary>
	/// Enumeratori za modele entiteta.
	/// </summary>
	public static class EntitiesEnums
	{
		/// <summary>
		/// Enumerator za tip korisnika.
		/// </summary>
		public enum TipKorisnika
		{
			/// <summary>
			/// Administrator.
			/// </summary>
			ADMIN,

			/// <summary>
			/// Komisija.
			/// </summary>
			KOMISIJA,

			/// <summary>
			/// Operater.
			/// </summary>
			OPERATER,

			/// <summary>
			/// Licitant.
			/// </summary>
			LICITANT
		}
	}
}
