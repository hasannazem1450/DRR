using DRR.Domain.Finance;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Finance
{
    public interface IWalletRepository : IRepository
    {
        Task<Wallet> ReadWalletById(int id);

        Task Delete(int id);

        Task Update(Domain.Finance.Wallet wallet);

        Task Create(Domain.Finance.Wallet wallet);
    }

}
