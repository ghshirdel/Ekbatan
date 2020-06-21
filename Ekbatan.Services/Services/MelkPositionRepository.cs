using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MelkPosition;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
    public class MelkPositionRepository : IMelkPositionRepository
    {
        private EkbatanDbContext _db;
        public MelkPositionRepository(EkbatanDbContext db)
        {
            _db = db;
        }

        public List<MelkPosition> GetAllMelkPositions()
        {
            return _db.MelkPositions.ToList();
        }

        public MelkPosition GetMelkPositionById(int melkPosition_Id)
        {
            return _db.MelkPositions.Find(melkPosition_Id);

        }

        public void Insert_MelkPosition(MelkPosition melkposition)
        {
            _db.MelkPositions.Add(melkposition);

        }

        public void Update_MelkPosition(MelkPosition melkposition)
        {
            _db.Entry(melkposition).State = EntityState.Modified;
        }


        public void Delete_MelkPosition(MelkPosition melkposition)
        {
            _db.Entry(melkposition).State = EntityState.Deleted;
        }

        public void DeleteMelkPositionById(int melkPosition_Id)
        {
            var melkposition = GetMelkPositionById(melkPosition_Id);
            Delete_MelkPosition(melkposition);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
