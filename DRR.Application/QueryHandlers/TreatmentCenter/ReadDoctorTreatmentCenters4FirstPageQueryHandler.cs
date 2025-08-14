using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.TreatmentCenter;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.TraetmentCenter;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Markers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.TreatmentCenter
{
    public class ReadDoctorTreatmentCenters4FirstPageQueryHandler : IQueryHandler<ReadDoctorTreatmentCenters4FirstPageQuery, ReadDoctorTreatmentCenters4FirstPageQueryResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
        private readonly IDoctorTreatmentCenterService _dtcService;

        public ReadDoctorTreatmentCenters4FirstPageQueryHandler(IDoctorTreatmentCenterRepository dtcRepository, IDoctorTreatmentCenterService dtcService)
        {
            _dtcRepository = dtcRepository;
            _dtcService = dtcService;
        }

        public async Task<ReadDoctorTreatmentCenters4FirstPageQueryResponse> Execute(ReadDoctorTreatmentCenters4FirstPageQuery query, CancellationToken cancellationToken)
        {
            var dtcs = await _dtcRepository.ReadDoctorTreatmentCenters4FirstPage(query);



            var dtcDto = await _dtcService.ConvertToDoctorTreatmentCenterPackedDto4FirstPage(dtcs);
            List<DoctorTreatmentCenterPackedDto4FirstPage> senditems = dtcDto.ToList();

            var result = new ReadDoctorTreatmentCenters4FirstPageQueryResponse
            {
                List = senditems
            };

            return result;


        }
    }
}