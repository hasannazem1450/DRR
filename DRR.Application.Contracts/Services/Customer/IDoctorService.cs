using DRR.Application.Contracts.Commands.Customer;
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
    }
}
