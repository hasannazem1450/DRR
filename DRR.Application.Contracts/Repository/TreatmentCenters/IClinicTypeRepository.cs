using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.TreatmentCenters
{
    public interface IClinicTypeRepository : IRepository
    {
        Task<List<ClinicType>> ReadClinicTypes();
        Task<ClinicType> ReadClinicTypeById(int id);


        Task Delete(int id);

        Task Update(ClinicType clinicType);

        Task Create(ClinicType clinicType);
    }

}
