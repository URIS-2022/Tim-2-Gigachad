﻿using AutoMapper;
using JavnoNadmetanjeService.DTO;
using JavnoNadmetanjeService.Entities;

namespace JavnoNadmetanjeService.Profiles
{
    /// <summary>
	/// Profil mapera za model entiteta licitacije.
	/// </summary>
    public class LicitacijaProfile : Profile
    {
        /// <summary>
		/// Profil mapera za model entiteta licitacije.
		/// </summary>
		public LicitacijaProfile()
        {
            CreateMap<LicitacijaDTO, LicitacijaEntity>();
            CreateMap<LicitacijaUpdateDTO, LicitacijaEntity>();
            CreateMap<LicitacijaEntity, LicitacijaEntity>();
        }
    }
}
