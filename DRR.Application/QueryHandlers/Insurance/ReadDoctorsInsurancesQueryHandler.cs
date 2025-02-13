using DRR.Application.Contracts.Queries.Insurance;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Services.Insurance;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Insurance
{
    public class ReadDoctorsInsurancesQueryHandler : IQueryHandler<ReadDoctorsInsurancesQuery, ReadDoctorsInsurancesQueryResponse>
    {
        private readonly IDoctorInsuranceRepository _diRepository;
        private readonly IDoctorInsuranceService _diservice;

        public ReadDoctorsInsurancesQueryHandler(IDoctorInsuranceRepository diRepository, IDoctorInsuranceService diservice)
        {
            _diRepository = diRepository;
            _diservice = diservice;
        }

        public async Task<ReadDoctorsInsurancesQueryResponse> Execute(ReadDoctorsInsurancesQuery query, CancellationToken cancellationToken)
        {
            var dis = await _diRepository.ReadDoctorsInsurances();

            var result = new ReadDoctorsInsurancesQueryResponse
            {
                List = await _diservice.ConvertToDto(dis)
            };

            return result;
        }

    }
}
