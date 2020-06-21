using Ekbatan.DomainClasses.MContract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ekbatan.Services.Repositories
{
   public interface IMContractRepository
    {
        List<MContract> GetAllMContract();
        MContract GetMContractById(int mContract_Id);
        void Insert_MContract(MContract mContract);
        void Update_MContract(MContract mContract);
        void Delete_MContract(MContract mContract);
        void DEleteMContractById(int mContract_Id);
        void Save();

    }
}
