namespace LiceService.Data
{
	public interface IKorisnikRepository
	{
		public bool KorisnikWithCredentialsExists(string naziv, string lozinka);
	}
}
