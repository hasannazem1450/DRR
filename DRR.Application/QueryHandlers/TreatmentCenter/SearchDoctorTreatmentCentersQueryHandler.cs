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
            var dtcs = await _dtcRepository.ReadAllDoctorTreatmentCenters();
            var dtcDto = await _dtcService.ConvertToDto(dtcs);

            if (!query.ProvinceName.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterByProvinceName(dtcDto, query.ProvinceName);
            if (!query.CityName.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterByCityName(dtcDto, query.ProvinceName);
            if (!query.SpecialistIds.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterBySpecialistIds(dtcDto, query.SpecialistIds);
            if (!query.SpecialistName.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterBySpecialistName(dtcDto, query.SpecialistName);
            if (!query.ClinicTypeName.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterByClinicTypeName(dtcDto, query.ClinicTypeName);
            if (!query.OfficeTypeName.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterByOfficeTypeName(dtcDto, query.OfficeTypeName);
            if (!query.DoctorTreatmentCenterName.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterByDoctorTreatmentCenterName(dtcDto, query.DoctorTreatmentCenterName);
            if (!query.Desc.IsNullOrEmpty())
                dtcDto = await _dtcService.FilterByDesc(dtcDto, query.Desc);


            var totalRecords = dtcDto.Count();
            List<DoctorTreatmentCenterDto> senditems = dtcDto.Skip((query.PageNumber - 1) * query.PageSize).Take(query.PageSize).ToList();

            var result = new SearchDoctorTreatmentCentersQueryResponse
            {
                PageNumber = query.PageNumber,
                PageSize = query.PageSize,
                TotalRecords = totalRecords,
                List = senditems
            };

            return result;

        }
    }
}