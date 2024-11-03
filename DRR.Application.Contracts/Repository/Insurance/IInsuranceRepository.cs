using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Insurance
{
    public interface IInsuranceRepository : IRepository
    {

        Task<Domain.Insurances.Insurance> ReadInsuranceById(int id);
       

        Task Delete(int id);

        Task Update(Domain.Insurances.Insurance insurance);

        Task Create(Domain.Insurances.Insurance insurance);
    }

}
