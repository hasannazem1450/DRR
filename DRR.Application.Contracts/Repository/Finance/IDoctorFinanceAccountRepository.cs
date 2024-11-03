using DRR.Domain.Finance;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Finance
{
    public interface IDoctorFinanceAccountRepository : IRepository
    {
        Task<DoctorFinanceAccount> ReadDoctorFinanceAccountById(int id);
        Task<List<DoctorFinanceAccount>> ReadDoctorFinanceAccountByDoctorId(int id);

        Task Delete(int id);

        Task Update(Domain.Finance.DoctorFinanceAccount doctorFinanceAccount);

        Task Create(Domain.Finance.DoctorFinanceAccount doctorFinanceAccount);
    }

}
