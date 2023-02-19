﻿using UgovorOZakupuService.DTO;

namespace UgovorOZakupuService.ServiceCalls
{
    public interface IDeoParceleService
    {
        /// <summary>
		/// Vraća adresu delaParcele od drugog mikro servisa.
		/// </summary>
		/// <param name="deoParceleID">ID dela parcele.</param>
		/// <param name="token">Token za deo parcele mikroservis.</param>
		/// <returns>Vraća model DTO-a dela parcele.</returns>
		Task<DeoParceleDTO?> GetDeoParceleByIDAsync(Guid deoParceleID, string token);
    }
}
