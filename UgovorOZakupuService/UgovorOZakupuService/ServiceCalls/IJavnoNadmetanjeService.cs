using UgovorOZakupuService.DTO;

namespace UgovorOZakupuService.ServiceCalls
{
    public interface IJavnoNadmetanjeService
    {
        /// <summary>
		/// Vraća adresu javnog nadmetanja od drugog mikro servisa.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <param name="token">Token za adresu lica mikroservis.</param>
		/// <returns>Vraća model DTO-a javnog nadmetanja.</returns>
		Task<JavnoNadmetanjeDTO?> GetJavnoNadmetanjeByIDAsync(Guid javnoNadmetanjeID, string token);
    }
}
