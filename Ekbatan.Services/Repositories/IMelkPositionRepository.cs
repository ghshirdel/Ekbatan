using Ekbatan.DomainClasses;
using Ekbatan.DomainClasses.MelkPosition;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
   public interface IMelkPositionRepository
    {
        List<MelkPosition> GetAllMelkPositions();
        MelkPosition GetMelkPositionById(int melkPosition_Id);
        void Insert_MelkPosition(MelkPosition melkposition);
        void Update_MelkPosition(MelkPosition melkposition);
        void Delete_MelkPosition(MelkPosition melkposition);
        void DeleteMelkPositionById(int melkPosition_Id);
        void Save();

    }
}
