using Ekbatan.DomainClasses.Karbari;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
   public interface IKarbariRepository
    {
        List<Karbari> GetAllKarbaries();
        Karbari GetKarbariById(int karbari_Id);
        void Insert_Karbari(Karbari karbari);
        void Update_Karbari(Karbari karbari);
        void Delete_Karbari(Karbari karbari);
        void DeleteKarbariById(int karbari_Id);
        void Save();

    }
}
