using Ekbatan.DomainClasses.FrontAge;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
   public interface IFrontAgeRepository
    {
        List<FrontAge> GetFrontAges();
        FrontAge GetFrontAgeById(int frontAge_Id);
        void Insert_FrontAge(FrontAge frontage);
        void Update_FrontAge(FrontAge frontage);
        void Delete_FrontAge(FrontAge frontAge);
        void DeleteFrontAgeById(int frontAge_Id);
        void Save();

    }
}
