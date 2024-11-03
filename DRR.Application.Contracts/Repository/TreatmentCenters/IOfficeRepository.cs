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
        Task<List<Office>> ReadOfficeByDto(OfficeDto OfficeDto);
        Task<Office> ReadOfficeById(int id);
        Task<List<Office>> ReadOfficeByCityId(int id);
        Task<List<Office>> ReadOfficeByOfficeTypeId(int id);


        Task Delete(int id);

        Task Update(Domain.TreatmentCenters.Office office);

        Task Create(Domain.TreatmentCenters.Office office);
    }

}
