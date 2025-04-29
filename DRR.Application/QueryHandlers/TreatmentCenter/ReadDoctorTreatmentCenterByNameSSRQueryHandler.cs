using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.TreatmentCenter
{
    class ReadDoctorTreatmentCenterByNameSSRQueryHandler : IQueryHandler<ReadDoctorTreatmentCenterByNameSSRQuery, ReadDoctorTreatmentCenterByNameSSRQueryResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
        private readonly IDoctorTreatmentCenterService _dtcService;

        public ReadDoctorTreatmentCenterByNameSSRQueryHandler(IDoctorTreatmentCenterRepository dtcRepository, IDoctorTreatmentCenterService dtcService)
        {
            _dtcRepository = dtcRepository;
            _dtcService = dtcService;
        }

        public async Task<ReadDoctorTreatmentCenterByNameSSRQueryResponse> Execute(ReadDoctorTreatmentCenterByNameSSRQuery query, CancellationToken cancellationToken)
        {
            var dtcs = await _dtcRepository.ReadDoctorTreatmentCenterByNameSSR(query.SSRName);

            var result = new ReadDoctorTreatmentCenterByNameSSRQueryResponse
            {
                Data = await _dtcService.ConvertToSSRDto(dtcs)
            };

            return result;
        }
    }
}