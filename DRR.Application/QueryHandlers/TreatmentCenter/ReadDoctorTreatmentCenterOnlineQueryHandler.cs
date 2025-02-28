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
    public class ReadDoctorTreatmentCenterOnlineQueryHandler : IQueryHandler<ReadDoctorTreatmentCenterOnlineQuery, ReadDoctorTreatmentCenterOnlineQueryResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
        private readonly IDoctorTreatmentCenterService _dtcService;

        public ReadDoctorTreatmentCenterOnlineQueryHandler(IDoctorTreatmentCenterRepository dtcRepository, IDoctorTreatmentCenterService dtcService)
        {
            _dtcRepository = dtcRepository;
            _dtcService = dtcService;
        }

        public async Task<ReadDoctorTreatmentCenterOnlineQueryResponse> Execute(ReadDoctorTreatmentCenterOnlineQuery query, CancellationToken cancellationToken)
        {
            var dtcs = await _dtcRepository.ReadDoctorTreatmentCenterByDoctorIdOnline(query.Id);

            var result = new ReadDoctorTreatmentCenterOnlineQueryResponse
            {
                List = await _dtcService.ConvertToDto(dtcs)
            };

            return result;
        }
    }
}