﻿using DRR.Domain.TreatmentCenters;
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

        Task<DoctorTreatmentCenter> ReadDoctorTreatmentCenterById(int id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByDoctorId(int id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByClinicId(int? id);
        Task<List<DoctorTreatmentCenter>> ReadDoctorTreatmentCenterByOfficeId(int? id);


        Task Delete(int id);

        Task Update(Domain.TreatmentCenters.DoctorTreatmentCenter doctorTreatmentCenter);

        Task Create(Domain.TreatmentCenters.DoctorTreatmentCenter doctorTreatmentCenter);
    }

}