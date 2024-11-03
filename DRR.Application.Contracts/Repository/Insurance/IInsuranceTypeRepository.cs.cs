using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Insurance
{
    public interface IInsuranceTypeRepository : IRepository
    {

        Task<InsuranceType> ReadInsuranceTypeById(int id);


        Task Delete(int id);

        Task Update(Domain.Insurances.InsuranceType insuranceType);

        Task Create(Domain.Insurances.InsuranceType insuranceType);
    }

}
