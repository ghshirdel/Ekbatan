using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.Karbari;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
    public class KarbariRepository : IKarbariRepository
    {
        private EkbatanDbContext _db;
        public KarbariRepository(EkbatanDbContext db)
        {
            _db = db;
        }

        public List<Karbari> GetAllKarbaries()
        {
            return _db.Karbaris.ToList();
        }

        public Karbari GetKarbariById(int karbari_Id)
        {
            return _db.Karbaris.Find(karbari_Id);
        }

        public void Insert_Karbari(Karbari karbari)
        {
            _db.Karbaris.Add(karbari);
        }
        public void Update_Karbari(Karbari karbari)
        {
            _db.Entry(karbari).State = EntityState.Modified;
        }

        public void Delete_Karbari(Karbari karbari)
        {
            _db.Entry(karbari).State = EntityState.Deleted;
        }

        public void DeleteKarbariById(int karbari_Id)
        {
            var karbari = GetKarbariById(karbari_Id);
            Delete_Karbari(karbari);
        }

        public void Save()
        {
            _db.SaveChanges();
        }


    }
}
