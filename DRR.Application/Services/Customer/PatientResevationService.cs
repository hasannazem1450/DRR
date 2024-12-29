using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Application.Contracts.Repository.Reserv;
using DRR.Application.Contracts.Services.Customer;
using DRR.Domain.Customer;
using DRR.Domain.Finance;
using DRR.Domain.Reserv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Customer
{
    public class PatientResevationService : IPatientResevationService
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
                ReservationId = patientReservation.ReservationId,
                TurnId = patientReservation.TurnId,
                DiscountCodeId = patientReservation.DiscountCodeId,
              
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
                    PatientId =item.PatientId,
                    ReservationId = item.ReservationId,
                    TurnId = item.TurnId,
                    DiscountCodeId = item.DiscountCodeId,
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
                ReservationId = patientreservation.ReservationId,
                TurnId = patientreservation.TurnId,
                DiscountCodeId = patientreservation.DiscountCodeId,
              
            };

            return result;
        }

    }
}
