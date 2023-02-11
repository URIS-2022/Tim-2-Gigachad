﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KomisijaService.Entities
{
    public class KomisijaEntity
    {
        public KomisijaEntity() { }

        /// <summary>
		/// ID komisije.
		/// </summary>
        [Key] 
        public Guid KomisijaID { get; set; }

        /// <summary>
		/// ID 1. clana.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid Clan1ID { get; set; }

        /// <summary>
		/// ID 2. clana.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid Clan2ID { get; set; }

        /// <summary>
		/// ID 3. clana.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid Clan3ID { get; set; }

        /// <summary>
		/// ID 4. clana.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid Clan4ID { get; set; }

        /// <summary>
		/// ID 5. clana.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid Clan5ID { get; set; }

        /// <summary>
		/// ID predsednika.
		/// </summary>
        [ForeignKey("LiceDTO")]
        public Guid PredsednikID { get; set; }

    }
}
