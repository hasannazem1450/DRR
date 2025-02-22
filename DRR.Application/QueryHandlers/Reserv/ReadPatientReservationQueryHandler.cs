using DRR.Application.Contracts.Queries.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Services.Reserv;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.Reservation
{
    public class ReadPatientReservationQueryHandler : IQueryHandler<ReadPatientReservationQuery, ReadPatientReservationQueryResponse>
    {
        private IPatientReservationRepository _patientreservatioRepository;
        private IPatientReservationService _patientreservationService;
        public ReadPatientReservationQueryHandler(IPatientReservationRepository patientreservatioRepository, IPatientReservationService patientreservationService)
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
