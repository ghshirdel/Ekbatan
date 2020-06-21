using Ekbatan.DomainClasses;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
    public interface IMelkRepository
    {
        List<Melk> GetAllMelk();
        Melk GetMelkById(int melk_Id);
        void Insert_Melk(Melk melk);
        void Update_Melk(Melk melk);
        void Delete_Melk(Melk melk);
        void DeleteMelkById(int melk_Id);
        void Save();
 }
}
