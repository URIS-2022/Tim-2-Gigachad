﻿using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class EksterniDokumentUpdateDTO
    {
        [Required]
        public Guid EksterniDokumentID { get; set; }
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; }
    }
}
