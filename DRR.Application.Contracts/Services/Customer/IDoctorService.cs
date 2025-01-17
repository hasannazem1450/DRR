﻿using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Customer
{
    public interface IDoctorService :IService
    {
        Task<DoctorDto> ReadById(int id);
        Task<List<DoctorDto>> ReadDoctorBySmeProfileId(int smeProfileId);
        Task<List<DoctorDto>> FilterByName(List<DoctorDto> doctors, string name);
        Task<List<DoctorDto>> FilterByProvince(List<DoctorDto> doctors, int provinceId);
        Task<List<DoctorDto>> FinalFilter(List<DoctorDto> doctors, ReadDoctorQueryFilters filters);
        Task<List<DoctorDto>> ConvertToDto(List<Doctor> doctors);
        Task<DoctorDto> ConvertToDto(Doctor doctor);
    }
}
