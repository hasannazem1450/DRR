using DRR.Application.Contracts.Commands.Information;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Domain.Customer;
using DRR.Domain.Specialists;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.TreatmentCenters
{
    public interface IDoctorTreatmentCenterRepository : IRepository
    {
        Task<List<DoctorTreatmentCenter>> Search(SearchDoctorTreatmentCentersQuery query);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterCountOfDoctorsAndSpecialistsByGuId(Guid guid);
        Task<List<DoctorTreatmentCenter>> ReadAllDoctorTreatmentCenters();
        Task<DoctorTreatmentCenter> ReadDoctorTreatmentCenterById(int id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByNameSSR(string  NameSSR);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorId(int id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByClinicId(Guid? id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByOfficeId(Guid? id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorIdHozoori(int id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorIdOnline(int id);


        Task Delete(int id);

        Task Update(Domain.TreatmentCenters.DoctorTreatmentCenter doctorTreatmentCenter);

        Task Create(Domain.TreatmentCenters.DoctorTreatmentCenter doctorTreatmentCenter);
        Task<List<TreatmentCenterSearchDto>> MainSearch(List<string> searchTerms);
    }

}
