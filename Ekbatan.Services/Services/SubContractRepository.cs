using Ekbatan.DataLayer;
using Ekbatan.DomainClasses.MContract;
using Ekbatan.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ekbatan.Services.Services
{
   public class SubContractRepository:ISubContrctRepository
    {
        private EkbatanDbContext _db;
        public SubContractRepository(EkbatanDbContext db)
        {
            _db = db;
        }
        public List<SubContract> GetAllSubContract()
        {
            return _db.SubContracts.ToList();
        }

        public SubContract GetSubContractById(int subContract_Id)
        {
            return _db.SubContracts.Find(subContract_Id);
        }

        public void Insert_SubContract(SubContract subcontract)
        {
            _db.SubContracts.Add(subcontract);
        }

        public void Update_SubContract(SubContract subContract)
        {
            _db.Entry(subContract).State =EntityState.Modified;
        }

        public void Delete_SubContract(SubContract subContract)
        {
            _db.Entry(subContract).State = EntityState.Deleted;
        }


        public void DeleteSubContractById(int subContract_Id)
        {
            var sc = GetSubContractById(subContract_Id);
            Delete_SubContract(sc);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
