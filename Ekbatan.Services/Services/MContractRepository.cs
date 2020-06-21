using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MContract;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
     public class MContractRepository:IMContractRepository
    {
        private EkbatanDbContext _db;
        public MContractRepository(EkbatanDbContext db)
        {
            _db = db;
        }

        public List<MContract> GetAllMContract()
        {
            return _db.MContracts.ToList();
        }

        public MContract GetMContractById(int mContract_Id)
        {
            return _db.MContracts.Find(mContract_Id);
        }

        public void Insert_MContract(MContract mContract)
        {
            _db.MContracts.Add(mContract);
        }

        public void Update_MContract(MContract mContract)
        {
            _db.Entry(mContract).State =EntityState.Modified;
        }

        public void Delete_MContract(MContract mContract)
        {
            _db.Entry(mContract).State = EntityState.Deleted;
        }

        public void DEleteMContractById(int mContract_Id)
        {
            var Mc = GetMContractById(mContract_Id);
            Delete_MContract(Mc);
        }
        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
