using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Services.Insurance;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Domain.Insurances;
using DRR.Domain.Reserv;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Insurance
{
    public class DoctorInsuranceService : IDoctorInsuranceService
    {
        public async Task<List<DoctorInsuranceDto>> ConvertToDto(List<DoctorInsurance> doctorInsurances)
        {
            var result = doctorInsurances.Select(s => ConvertToDto(s).Result).ToList();

            return result;

        }

        public async Task<DoctorInsuranceDto> ConvertToDto(DoctorInsurance doctorInsurance)
        {
            var result = new DoctorInsuranceDto
            {

                Id = doctorInsurance.Id,
                DoctorId = doctorInsurance.DoctorId,
                InsuranceId = doctorInsurance.InsuranceId,
                ContractSituation = doctorInsurance.ContractSituation,
                InsurancePercent = doctorInsurance.InsurancePercent,
                VisitCostId = doctorInsurance.VisitCostId,
                IsActive = doctorInsurance.IsActive,
                DoctorName = doctorInsurance.Doctor.DoctorName + " " + doctorInsurance.Doctor.DoctorFamily,
                InsuranceName = doctorInsurance.Insurance.Name
            };

            return result;
        }

    }
}
