using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.TreatmentCenters
{
    public interface IOfficeRepository : IRepository
    {
        Task<List<Office>> ReadOffices();
        Task<Office> ReadOfficeById(Guid id);
        Task<int> ReadOfficeDoctorsCountById(Guid id);
        Task<List<Office>> ReadOfficeByCityId(int id);
        Task<List<Office>> ReadOfficeByOfficeTypeId(int id);


        Task Delete(Guid id);

        Task Update(Domain.TreatmentCenters.Office office);

        Task Create(Domain.TreatmentCenters.Office office);
        Task<bool> CheckNameForReapeat(string name);
    }

}
