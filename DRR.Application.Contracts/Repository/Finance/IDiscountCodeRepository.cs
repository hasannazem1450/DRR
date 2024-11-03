using DRR.Domain.Finance;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Finance
{
    public interface IDiscountCodeRepository : IRepository
    {
        Task<DiscountCode> ReadDiscountCodeById(int id);

        Task Delete(int id);

        Task Update(Domain.Finance.DiscountCode discountCode);

        Task Create(Domain.Finance.DiscountCode discountCode);
    }

}
