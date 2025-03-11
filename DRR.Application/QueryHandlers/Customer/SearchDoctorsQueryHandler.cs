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
            var doctors = await _doctorRepository.Search(query);
        
            var doctorDto = await _doctorService.ConvertToBoxDto(doctors);
            List<DoctorBoxDto> senditems = doctorDto.ToList();

            var result = new SearchDoctorsQueryResponse
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

