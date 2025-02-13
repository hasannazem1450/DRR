using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.Insurance;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Services.Customer;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Insurance
{
    public class ReadDoctorsInsuranceQueryHandler : IQueryHandler<ReadDoctorsInsuranceQuery, ReadDoctorsInsuranceQueryResponse>
    {
        private readonly IDoctorInsuranceRepository _diRepository;

        public ReadDoctorsInsuranceQueryHandler(IDoctorInsuranceRepository diRepository)
        {
            _diRepository = diRepository;
           
        }

        public async Task<ReadDoctorsInsuranceQueryResponse> Execute(ReadDoctorsInsuranceQuery query, CancellationToken cancellationToken)
        {
            var doctors = await _diRepository.ReadDoctorsByInsuranceId(query.InsuranceId);

            var result = new ReadDoctorsInsuranceQueryResponse
            {
                List = doctors
            };

            return result;
        }

    }
}
