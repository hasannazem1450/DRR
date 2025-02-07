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
    public class SearchDoctorsQueryHandler : IQueryHandler<SearchDoctorsQuery, SearchDoctorsQueryResponse>
    {
        private readonly IDoctorRepository _doctorRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly ICommentRepository _commentRepository;
        private readonly IDoctorInsuranceRepository _diRepository;

        private readonly IDoctorTreatmentCenterRepository _dtcRepository;
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
            var doctors = await _doctorRepository.ReadAllDoctors();
            if (query.ProvinceId != null || query.ProvinceId == 0)
                doctors = await _doctorService.FilterBoxByProvince(doctors, query.ProvinceId ?? 0);

            var doctorDto = await _doctorService.ConvertToBoxDto(doctors);

            if (query.DoctorName.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterBoxByName(doctorDto, query.DoctorName);

            if (query.doctorFamily.IsNotNullOrEmpty())
                doctorDto = await _doctorService.FilterBoxByName(doctorDto, query.doctorFamily);

            


            var totalRecords = doctorDto.Count();
            List<DoctorBoxDto> senditems = doctorDto.Skip((query.pageNumber - 1) * query.pagesize).Take(query.pagesize).ToList();

            var result = new SearchDoctorsQueryResponse
            {
                PageNumber = query.pageNumber,
                PageSize = query.pagesize,
                TotalRecords = totalRecords,
                List = senditems
            };

            return result;
        }
    }
}

