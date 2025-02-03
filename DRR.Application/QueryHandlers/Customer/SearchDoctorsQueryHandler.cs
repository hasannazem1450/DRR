using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.Event;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Customer
{
    public class SearchDoctorsQueryHandler : IQueryHandler<SearchDoctorsQuery, SearchDoctorsQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;

        public SearchDoctorsQueryHandler(IDoctorRepository doctorRepository,
            IDoctorService doctorervice)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorervice;
        }

        public async Task<SearchDoctorsQueryResponse> Execute(SearchDoctorsQuery query,
            CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.ReadAllDoctors();

            var doctorDto = await _doctorService.ConvertToDto(doctor);

            if (query.DoctorName.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterByName(doctorDto, query.DoctorName);

            if (query.doctorFamily.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterByName(doctorDto, query.doctorFamily);

            if (query.docExperiance.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterByName(doctorDto, query.docExperiance); 
            
            if (query.docInstaLink.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterByName(doctorDto, query.docInstaLink);

            if (query.ProvinceId.HasValue)
                doctorDto = await _doctorService.FilterByProvince(doctorDto, query.ProvinceId.Value);

            var totalRecords = doctorDto.Count();
            List<DoctorDto> senditems = doctorDto.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToList();
 
            var result = new SearchDoctorsQueryResponse
            {
                PageNumber =query.pageNumber,
                PageSize = query.pagesize,
                TotalRecords = totalRecords,
                List = senditems
            };

            return result;
        }
    }
}

