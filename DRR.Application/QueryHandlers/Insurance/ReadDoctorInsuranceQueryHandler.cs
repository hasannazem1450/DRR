﻿using DRR.Application.Contracts.Queries.Customer;
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
    public class ReadDoctorInsuranceQueryHandler : IQueryHandler<ReadDoctorInsuranceQuery, ReadDoctorInsuranceQueryResponse>
    {
        private readonly IDoctorInsuranceRepository _diRepository;

        public ReadDoctorInsuranceQueryHandler(IDoctorInsuranceRepository diRepository)
        {
            _diRepository = diRepository;
           
        }

        public async Task<ReadDoctorInsuranceQueryResponse> Execute(ReadDoctorInsuranceQuery query, CancellationToken cancellationToken)
        {
            var doctorinsurance = await _diRepository.ReadDoctorInsuranceById(query.Id);

            var result = new ReadDoctorInsuranceQueryResponse
            {
                Data = doctorinsurance
            };

            return result;
        }

    }
}
