using DRR.Application.Contracts.Queries.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Services.Reserv;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Reservation
{
    public class ReadPatientAllReservationQueryHandler : IQueryHandler<ReadAllPatientReservationsQuery, ReadAllPatientReservationsQueryResponse>
    {
        private IPatientReservationRepository _patientreservatioRepository;
        private IPatientReservationService _patientreservationService;
        public ReadPatientAllReservationQueryHandler(IPatientReservationRepository patientreservatioRepository, IPatientReservationService patientreservationService)
        {
            _patientreservatioRepository = patientreservatioRepository;
            _patientreservationService = patientreservationService;
        }

        public async Task<ReadAllPatientReservationsQueryResponse> Execute(ReadAllPatientReservationsQuery query, CancellationToken cancellationToken)
        {
            var PatientReservations = await _patientreservatioRepository.ReadAllPatientReservations();

            var result = new ReadAllPatientReservationsQueryResponse
            {
                List = await _patientreservationService.ConvertToDto(PatientReservations)
            };

            return result;
        }
    }
}
