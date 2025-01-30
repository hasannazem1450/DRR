using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.TreatmentCenters
{
    public interface IOfficeTypeRepository : IRepository
    {

        Task<List<OfficeType>> ReadOfficeTypes();
        Task<OfficeType> ReadOfficeTypeById(int id);


        Task Delete(int id);

        Task Update(Domain.TreatmentCenters.OfficeType officeType);

        Task Create(Domain.TreatmentCenters.OfficeType officeType);
    }

}
