using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MelkType;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
    public class MelkTypeRepository : IMelkTypeRepository
    {
        private EkbatanDbContext _db;
        public MelkTypeRepository(EkbatanDbContext db)
        {
            _db = db;
        }

        public List<MelkType> GetAllMelkType()
        {
            return _db.MelkTypes.ToList();
        }

        public MelkType GetMelkTypeById(int melkType_Id)
        {
            return _db.MelkTypes.Find(melkType_Id);
        }

        public void insert_MelkType(MelkType melkType)
        {
            _db.MelkTypes.Add(melkType);
        }

        public void Update_MelkType(MelkType melkType)
        {
            _db.Entry(melkType).State = EntityState.Modified;
        }

        public void Delete_MelkType(MelkType melkType)
        {
            _db.Entry(melkType).State = EntityState.Deleted;
        }

        public void DeleteMelkTypeById(int melkType_Id)
        {
            var melkType = GetMelkTypeById(melkType_Id);
            Delete_MelkType(melkType);
        }
        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
