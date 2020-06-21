using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.FrontAge;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
    public class FrontAgeRepository:IFrontAgeRepository
    {
        private EkbatanDbContext _db;
        public FrontAgeRepository(EkbatanDbContext db)
        {
            _db = db;
        }

        public List<FrontAge> GetFrontAges()
        {
            return _db.FrontAges.ToList();
        }
        public FrontAge GetFrontAgeById(int frontAge_Id)
        {
            return _db.FrontAges.Find(frontAge_Id);
        }

        public void Insert_FrontAge(FrontAge frontage)
        {
            _db.FrontAges.Add(frontage);
        }

        public void Update_FrontAge(FrontAge frontage)
        {
            _db.Entry(frontage).State =EntityState.Modified;
        }
        public void Delete_FrontAge(FrontAge frontAge)
        {
            _db.Entry(frontAge).State = EntityState.Deleted;
        }

        public void DeleteFrontAgeById(int frontAge_Id)
        {
            var fAge = GetFrontAgeById(frontAge_Id);
            Delete_FrontAge(fAge);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
