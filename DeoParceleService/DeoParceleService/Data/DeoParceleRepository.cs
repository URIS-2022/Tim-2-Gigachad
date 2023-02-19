using AutoMapper;
using DeoParceleService.DTO;
using DeoParceleService.Entities;

namespace DeoParceleService.Data
{
	/// <summary>
	/// Repozitorijum za entitet parcela.
	/// </summary>
	public class DeoParceleRepository : IDeoParceleRepository
	{
		private readonly DeoParceleContext context;
		private readonly IMapper mapper;

		/// <summary>
		/// Dependency injection za repozitorijum.
		/// </summary>
		public DeoParceleRepository(DeoParceleContext context, IMapper mapper)
		{
			this.context = context;
			this.mapper = mapper;
		}

		/// <summary>
		/// Vraća listu delova parcela iz konteksta.
		/// </summary>
		/// <returns>Vraća listu delova parcela.</returns>
		public List<DeoParceleEntity> GetDeloviParcela()
		{
			return context.DeloviParcela.ToList();
		}

		/// <summary>
		/// Vraća jedan deo parcele iz konteksta na osnovu zadatog ID-ja.
		/// </summary>
		/// <param name="deoParceleID">ID deo parcele.</param>
		/// <returns>Vraća specifirani deo parcele.</returns>
		public DeoParceleEntity? GetDeoParceleByID(Guid deoParceleID)
		{
			return context.DeloviParcela.FirstOrDefault(e => e.ID == deoParceleID);
		}

		/// <summary>
		/// Dodaje novi deo parcele u kontekst.
		/// </summary>
		/// <param name="deoParceleCreateDTO">DTO za kreiranje dela parcele.</param>
		/// <returns>Vraća DTO kreirang dela parcele.</returns>
		public DeoParceleDTO CreateDeoParcele(DeoParceleCreateDTO deoParceleCreateDTO)
		{
			DeoParceleEntity deoParcele = mapper.Map<DeoParceleEntity>(deoParceleCreateDTO);
			deoParcele.ID = Guid.NewGuid();
			context.Add(deoParcele);
			return mapper.Map<DeoParceleDTO>(deoParcele);
		}

		/// <summary>
		/// Briše deo parcele iz konteksta.
		/// </summary>
		/// <param name="deoParceleID">ID dela parcele.</param>
		public void DeleteDeoParcele(Guid deoParceleID)
		{
			DeoParceleEntity? deoParcele = GetDeoParceleByID(deoParceleID);
			if (deoParcele != null)
				context.Remove(deoParcele);
		}

		/// <summary>
		/// Sačuva sve promene u kontekstu.
		/// </summary>
		/// <returns>Vraća boolean o potvrdi sačuvanih promena.</returns>
		public bool SaveChanges()
		{
			return context.SaveChanges() > 0;
		}
	}
}
