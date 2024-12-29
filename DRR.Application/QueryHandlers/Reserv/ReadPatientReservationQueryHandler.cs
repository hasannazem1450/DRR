using DRR.Application.Contracts.Queries.Customer;
using DRR.Application.Contracts.Queries.Event;
using DRR.Application.Contracts.Queries.Reservation;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Customer;
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
    public class ReadPatientReservationQueryHandler : IQueryHandler<ReadPatientReservationQuery, ReadPatientReservationQueryResponse>
    {
        private IPatientReservationRepository _patientreservatioRepository;
        private IPatientResevationService _patientreservationService;
        public ReadPatientReservationQueryHandler(IPatientReservationRepository patientreservatioRepository, IPatientResevationService patientreservationService)
        {
            _patientreservatioRepository = patientreservatioRepository;
            _patientreservationService = patientreservationService;
        }

        public async Task<ReadPatientReservationQueryResponse> Execute(ReadPatientReservationQuery query, CancellationToken cancellationToken)
        {
            var PatientReservation = await _patientreservatioRepository.ReadPatientReservationByPatientId(query.PatientId);

            var result = new ReadPatientReservationQueryResponse
            {
                List = await _patientreservationService.ConvertToDto(PatientReservation)
            };

            return result;
        }
    }
}
