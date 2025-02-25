using DRR.Application.Contracts.Queries.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Services.Reserv;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Reservation
{
    public class ReadPatientReservationsQueryHandler : IQueryHandler<ReadPatientReservationsQuery, ReadPatientReservationsQueryResponse>
    {
        private IPatientReservationRepository _patientreservatioRepository;
        private IPatientReservationService _patientreservationService;
        public ReadPatientReservationsQueryHandler(IPatientReservationRepository patientreservatioRepository, IPatientReservationService patientreservationService)
        {
            _patientreservatioRepository = patientreservatioRepository;
            _patientreservationService = patientreservationService;
        }

        public async Task<ReadPatientReservationsQueryResponse> Execute(ReadPatientReservationsQuery query, CancellationToken cancellationToken)
        {
            var PatientReservation = await _patientreservatioRepository.ReadPatientReservationByPatientId(query.PatientId);

            var result = new ReadPatientReservationsQueryResponse
            {
                List = await _patientreservationService.ConvertToDto(PatientReservation)
            };

            return result;
        }
    }
}
