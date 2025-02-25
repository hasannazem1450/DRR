using DRR.Domain.Reserv;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Reserv
{
    public interface IPatientReservationRepository : IRepository
    {

        Task<PatientReservation> ReadPatientReservationById(int id);
        Task<List<PatientReservation>> ReadAllPatientReservations();
        Task<List<PatientReservation>> ReadPatientReservationByPatientId(int id);
        Task<List<PatientReservation>> ReadPatientReservationByReservationId(int id);

        Task Delete(int id);

        Task Update(PatientReservation patientReservation);

        Task Create(PatientReservation patientReservation);
    }

}
