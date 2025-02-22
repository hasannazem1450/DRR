using DRR.Application.Contracts.Commands.Reserv;
using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Reserv
{
    public interface IPatientReservationService : IService
    {
        Task<PatientReservationDto> ReadById(int id);
        Task<List<PatientReservationDto>> ReadPatientReservationByPatientId(int PatientId);
        Task<List<PatientReservationDto>> ConvertToDto(List<PatientReservation> patientreservations);
        Task<PatientReservationDto> ConvertToDto(PatientReservation patientreservation);

    }
}
