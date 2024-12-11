using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.Specialists;

namespace DRR.Application.Services.Customer
{
    public class DoctorService :IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDRRFileService _dRRFileService;

        public DoctorService(IDRRFileService dRRFileService)
        {
            _dRRFileService = dRRFileService;
        }
        public async Task<DoctorDto> ReadById(int id)
        {
            var doctor = await _doctorRepository.ReadDoctorById(id);

            var result = new DoctorDto()
            {
                Id = doctor.Id,
                DoctorName = doctor.DoctorName,
                DoctorFamily = doctor.DoctorFamily,
                NationalId = doctor.NationalId,
                SpecialistId = doctor.SpecialistId,
                CodeNezam = doctor.CodeNezam,
                DocExperiance = doctor.DocExperiance,
                DocInstaLink = doctor.DocInstaLink,
                Mobile = doctor.Mobile,
                Desc = doctor.Desc,
                SmeProfile = doctor.SmeProfile,  

            };

            return result;
        }
        public async Task<List<DoctorDto>> ReadDoctorBySmeProfileId(int smeProfileId)
        {
            var doctor = await _doctorRepository.ReadDoctorById(smeProfileId);

            var result = new DoctorDto()
            {
                Id = doctor.Id,
                DoctorName = doctor.DoctorName,
                DoctorFamily = doctor.DoctorFamily,
                NationalId = doctor.NationalId,
                SpecialistId = doctor.SpecialistId,
                CodeNezam = doctor.CodeNezam,
                DocExperiance = doctor.DocExperiance,
                DocInstaLink = doctor.DocInstaLink,
                Mobile = doctor.Mobile,
                Desc = doctor.Desc,
                SmeProfile = doctor.SmeProfile,

            };

            var resualtlist = new List<DoctorDto>();
            resualtlist.Add(result);
            return (resualtlist);
        }
    }
}
