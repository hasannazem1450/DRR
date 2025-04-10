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
    public class SearchDoctorTreatmentCentersQueryHandler : IQueryHandler<SearchDoctorTreatmentCentersQuery, SearchDoctorTreatmentCentersQueryResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
        private readonly IDoctorTreatmentCenterService _dtcService;

        public SearchDoctorTreatmentCentersQueryHandler(IDoctorTreatmentCenterRepository dtcRepository, IDoctorTreatmentCenterService dtcService)
        {
            _dtcRepository = dtcRepository;
            _dtcService = dtcService;
        }

        public async Task<SearchDoctorTreatmentCentersQueryResponse> Execute(SearchDoctorTreatmentCentersQuery query, CancellationToken cancellationToken)
        {
            var dtcs = await _dtcRepository.Search(query);

            var dtcDto = await _dtcService.ConvertToDto(dtcs);
            List<DoctorTreatmentCenterDto> senditems = dtcDto.ToList();

            var result = new SearchDoctorTreatmentCentersQueryResponse
            {
                PageNumber = query.pageNumber,
                PageSize = query.pagesize,
                TotalRecords = query.TotalRecords,
                List = senditems
            };

            return result;


        }
    }
}