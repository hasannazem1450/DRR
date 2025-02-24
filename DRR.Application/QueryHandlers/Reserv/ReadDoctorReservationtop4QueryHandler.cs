using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Queries.Reservation;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Event;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Services.Event;
using DRR.CommandDb.Repository.Event;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Reservation
{
    public class ReadDoctorReservationtop4QueryHandler : IQueryHandler<ReadDoctorReservationtop4Query, ReadDoctorReservationQueryResponse>
    {
        private IReservationRepository _reservatioRepository;
        private IReservationService _reservationService;
        public ReadDoctorReservationtop4QueryHandler(IReservationRepository reservatioRepository, IReservationService reservationService)
        {
            _reservatioRepository = reservatioRepository;
            _reservationService = reservationService;
        }

        public async Task<ReadDoctorReservationQueryResponse> Execute(ReadDoctorReservationtop4Query query, CancellationToken cancellationToken)
        {
            var doctorReservation = await _reservatioRepository.ReadReservationtop4firstpage();

            var result = new ReadDoctorReservationQueryResponse
            {
                Data = await _reservationService.ConvertToDto(doctorReservation)
            };

            return result;
        }
    }
}
