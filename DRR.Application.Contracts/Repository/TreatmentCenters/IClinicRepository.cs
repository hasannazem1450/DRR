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
    public interface IClinicRepository : IRepository
    {
        Task<List<Clinic>> ReadClinics();
        Task<List<Clinic>> ReadClinicByDto(ClinicDto ClinicDto);
        Task<Clinic> ReadClinicById(int id);
        Task<List<Clinic>> ReadClinicByCityId(int id);
        Task<List<Clinic>> ReadClinicByClinicTypeId(int id);


        Task Delete(int id);

        Task Update(Domain.TreatmentCenters.Clinic clinic);

        Task Create(Domain.TreatmentCenters.Clinic clinic);
    }

}

