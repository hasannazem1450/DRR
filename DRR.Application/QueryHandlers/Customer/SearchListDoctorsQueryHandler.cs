using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Repository.Comments;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Application.Contracts.Services.Customer;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.TraetmentCenter;
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
    public class SearchListDoctorsQueryHandler : IQueryHandler<SearchListDoctorsQuery, SearchListDoctorsQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IDoctorService _doctorService;

        public SearchListDoctorsQueryHandler(IDoctorRepository doctorRepository,
            IDoctorService doctorervice)
        {
            _doctorRepository = doctorRepository;
            _doctorService = doctorervice;
        }

        public async Task<SearchListDoctorsQueryResponse> Execute(SearchListDoctorsQuery query,
            CancellationToken cancellationToken)
        {
            var doctor = await _doctorRepository.ReadAllDoctors();

            var doctorDto = await _doctorService.ConvertToDto(doctor);

            if (query.DoctorName.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterByName(doctorDto, query.DoctorName);

            if (query.doctorFamily.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterByName(doctorDto, query.doctorFamily);

            var totalRecords = doctorDto.Count();
            List<DoctorDto> senditems = doctorDto.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToList();
 
            var result = new SearchListDoctorsQueryResponse
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

