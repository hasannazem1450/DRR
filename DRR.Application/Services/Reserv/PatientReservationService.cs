using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Reserv
{
    public class PatientResevationService : IPatientReservationService
    {
        private readonly IPatientReservationRepository _patientReservationRepository;
        public PatientResevationService(IPatientReservationRepository patientReservationRepository)
        {
            _patientReservationRepository = patientReservationRepository;
        }
        public async Task<PatientReservationDto> ReadById(int id)
        {
            var patientReservation = await _patientReservationRepository.ReadPatientReservationById(id);

            return new PatientReservationDto()
            {
                Id = patientReservation.Id,
                PatientId = patientReservation.PatientId,
                ReservationId = patientReservation.Turn.ReservationId,
                TurnId = patientReservation.TurnId,
                DiscountCodeId = patientReservation.DiscountCodeId,
                Patient = patientReservation.Patient,
                Turn = patientReservation.Turn,
                DiscountCode = patientReservation.DiscountCode,
                Reservation = patientReservation.Turn.Reservation,
                DoctorTreatmentCenter = patientReservation.Turn.Reservation.DoctorTreatmentCenter,
                Doctor = patientReservation.Turn.Reservation.DoctorTreatmentCenter.Doctor,

            };
        }
        public async Task<List<PatientReservationDto>> ReadPatientReservationByPatientId(int Patientd)
        {
            var patientReservations = await _patientReservationRepository.ReadPatientReservationByPatientId(Patientd);
            var result = new List<PatientReservationDto>();

            foreach (var item in patientReservations)
            {
                var dto = new PatientReservationDto()
                {
                    Id = item.Id,
                    PatientId = item.PatientId,
                    ReservationId = item.Turn.ReservationId,
                    TurnId = item.TurnId,
                    DiscountCodeId = item.DiscountCodeId,
                    Patient = item.Patient,
                    Turn = item.Turn,
                    DiscountCode = item.DiscountCode,
                    Reservation = item.Turn.Reservation,
                    DoctorTreatmentCenter = item.Turn.Reservation.DoctorTreatmentCenter,
                    Doctor = item.Turn.Reservation.DoctorTreatmentCenter.Doctor,
                };

                result.Add(dto);
            }

            return result;
        }
        public async Task<List<PatientReservationDto>> ConvertToDto(List<PatientReservation> patientreservations)
        {
            var result = patientreservations.Select(s => ConvertToDto(s).Result).ToList();

            return result;

        }

        public async Task<PatientReservationDto> ConvertToDto(PatientReservation patientreservation)
        {
            var result = new PatientReservationDto
            {

                Id = patientreservation.Id,
                PatientId = patientreservation.PatientId,
                ReservationId = patientreservation.Turn.ReservationId,
                TurnId = patientreservation.TurnId,
                DiscountCodeId = patientreservation.DiscountCodeId,
                Patient = patientreservation.Patient,
                Turn = patientreservation.Turn,
                DiscountCode = patientreservation.DiscountCode,
                Reservation = patientreservation.Turn.Reservation,
                DoctorTreatmentCenter = patientreservation.Turn.Reservation.DoctorTreatmentCenter,
                Doctor = patientreservation.Turn.Reservation.DoctorTreatmentCenter.Doctor,

            };

            return result;
        }

    }
}
