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
    public class ReadDoctorOffice4FirstPageQueryHandler : IQueryHandler<ReadDoctorOffice4FirstPageQuery, ReadDoctorOffice4FirstPageQueryResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
        private readonly IDoctorTreatmentCenterService _dtcService;

        public ReadDoctorOffice4FirstPageQueryHandler(IDoctorTreatmentCenterRepository dtcRepository, IDoctorTreatmentCenterService dtcService)
        {
            _dtcRepository = dtcRepository;
            _dtcService = dtcService;
        }

        public async Task<ReadDoctorOffice4FirstPageQueryResponse> Execute(ReadDoctorOffice4FirstPageQuery query, CancellationToken cancellationToken)
        {
            var dtcs = await _dtcRepository.ReadDoctorOffice4FirstPage(query);



            var dtcDto = await _dtcService.ConvertToDoctorOfficePackedDto4FirstPage(dtcs);
            List<DoctorOfficePackedDto4FirstPage> senditems = dtcDto.ToList();

            var result = new ReadDoctorOffice4FirstPageQueryResponse
            {
                List = senditems
            };

            return result;


        }
    }
}