﻿using System.ComponentModel.DataAnnotations;

namespace DokumentiService.DTO
{
    public class InterniDokumentUpdateDTO
    {
        public Guid InterniDokumentID { get; set; }
        [Required]
        [MaxLength(100)]
        public string PutanjaDokumenta { get; set; }
    }
}