using LiceService.Entities;

namespace LiceService.Data
{
	public class FizickoLiceRepository : IFizickoLiceRepository
	{
		public static List<FizickoLiceEntity> FizickaLica { get; set; } = new List<FizickoLiceEntity>();

		public FizickoLiceRepository()
		{
			FillData();
		}

		private static void FillData()
		{
			FizickaLica.AddRange(new List<FizickoLiceEntity>
			{
				new FizickoLiceEntity
				{

					FizickoLiceID = Guid.Parse("32b7d397-b9d1-472d-bb40-542c68305098"),
					JMBG = "4058851174218",
					Ime = "Slavomir",
					Prezime = "Slavic"
				},
				new FizickoLiceEntity
				{
					FizickoLiceID = Guid.Parse("3a054c77-1bf4-4853-8937-8e36502a6848"),
					JMBG = "0786741214886",
					Ime = "Radomir",
					Prezime = "Radic"
				}
			}); ; ;
		}

		public FizickoLiceEntity CreateFizickoLice(FizickoLiceEntity fizickoLice)
		{
			throw new NotImplementedException();
		}

		public void DeleteFizickoLice(Guid fizickoLiceID)
		{
			throw new NotImplementedException();
		}

		public List<FizickoLiceEntity> GetFizickaLica()
		{
			throw new NotImplementedException();
		}

		public FizickoLiceEntity GetFizickoLiceByID(Guid fizickoLiceID)
		{
			throw new NotImplementedException();
		}

		public void UpdateFizickoLice(FizickoLiceEntity fizickoLice)
		{
			throw new NotImplementedException();
		}
	}
}
