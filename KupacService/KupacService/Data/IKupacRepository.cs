﻿using KupacService.DTO;
using KupacService.Entities;

namespace KupacService.Data
{
    public interface IKupacRepository
    {
        List<KupacEntity> GetKupci();

        KupacEntity GetKupacByID(Guid kupacID);

        KupacDTO CreateKupac(KupacCreateDTO kupacCreateDTO);

        void UpdateKupac(KupacEntity kupac);

        void DeleteKupac(Guid kupacID);

        bool SaveChanges();
    }
}