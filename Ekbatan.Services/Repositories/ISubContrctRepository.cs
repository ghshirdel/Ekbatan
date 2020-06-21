using Ekbatan.DomainClasses.MContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
    public interface ISubContrctRepository
    {
        List<SubContract> GetAllSubContract();
        SubContract GetSubContractById(int subContract_Id);
        void Insert_SubContract(SubContract subcontract);
        void Update_SubContract(SubContract subContract);
        void Delete_SubContract(SubContract subContract);
        void DeleteSubContractById(int subContract_Id);
        void Save();

    }
}
