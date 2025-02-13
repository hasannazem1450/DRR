using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Domain.Insurances;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Insurance
{
    public interface IDoctorInsuranceService: IService
    {
        Task<List<DoctorInsuranceDto>> ConvertToDto(List<DoctorInsurance> doctorInsurances);
        Task<DoctorInsuranceDto> ConvertToDto(DoctorInsurance doctorInsurance);
    }
}
