using Ekbatan.DomainClasses.MelkType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
    public interface IMelkTypeRepository
    {
        List<MelkType> GetAllMelkType();
        MelkType GetMelkTypeById(int MelkType_Id);
        void insert_MelkType(MelkType melkType);
        void Update_MelkType(MelkType melkType);
        void Delete_MelkType(MelkType melkType);
        void DeleteMelkTypeById(int melkType_Id);
        void Save();
    }
}
