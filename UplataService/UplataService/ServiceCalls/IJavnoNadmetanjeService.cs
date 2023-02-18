using UplataService.Models;

namespace UplataService.ServiceCalls
{
    /// <summary>
	/// Interfejs od servis poziva za javno nadmetanje.
	/// </summary>
    public interface IJavnoNadmetanjeService
    {
        /// <summary>
		/// Vraća javno nadmetanje od drugog mikro servisa.
		/// </summary>
		/// <param name="javnoNadmetanjeID">ID javnog nadmetanja.</param>
		/// <param name="token">Token za javno nadmetanje mikroservis.</param>
		/// <returns>Vraća model DTO-a javnog nadmetanja.</returns>
		Task<JavnoNadmetanjeDTO?> GetJavnoNadmetanjeByIDAsync(Guid javnoNadmetanjeID, string token);
    }
}
