namespace KorisnikService.Entities
{
	/// <summary>
	/// Enumeratori za modele entiteta.
	/// </summary>
	public static class EntitiesEnums
	{
		/// <summary>
		/// Enumerator za tipa korisnika.
		/// </summary>
		public enum KorisnikTip
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
