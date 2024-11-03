using DRR.Domain.Reservations;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reservations
{
    public interface IPatientReservationRepository : IRepository
    {

        Task<PatientReservation> ReadPatientReservationById(int id);
        Task<List<PatientReservation>> ReadPatientReservationByPatientId(int id);
        Task<List<PatientReservation>> ReadPatientReservationByReservationId(int id);

        Task Delete(int id);

        Task Update(Domain.Reservations.PatientReservation patientReservation);

        Task Create(Domain.Reservations.PatientReservation patientReservation);
    }

}
