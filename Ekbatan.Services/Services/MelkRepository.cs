using Ekbatan.DataLayer;
using Ekbatan.DomainClasses;
using Ekbatan.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Ekbatan.Services.Services
{

    public class MelkRepository : IMelkRepository
    {

        private EkbatanDbContext _db;
        public MelkRepository(EkbatanDbContext db)
        {
            _db = db;
        }
        public List<Melk> GetAllMelk()
        {
            return _db.Melks.ToList();
        }

        public Melk GetMelkById(int melk_Id)
        {
            return _db.Melks.Find(melk_Id);
        }

        public void Insert_Melk(Melk melk)
        {
            _db.Melks.Add(melk);
        }
        public void Update_Melk(Melk melk)
        {
            _db.Entry(melk).State = EntityState.Modified;
        }

        public void Delete_Melk(Melk melk)
        {
            _db.Entry(melk).State = EntityState.Deleted;
        }

        public void DeleteMelkById(int melk_Id)
        {
            var melk = GetMelkById(melk_Id);
            Delete_Melk(melk);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
