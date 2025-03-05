using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Application.Contracts.Services.Reserv;
using DRR.Domain.Reserv;
using DRR.Domain.TreatmentCenters;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Services.Reserv
{
    public class ReservationService : IReservationService
    {
        public async Task<List<ReservationDto>> ConvertToDto(List<Reservation> reservations)
        {
            var result = reservations.Select(s => ConvertToDto(s).Result).ToList();

            return result;

        }

        public async Task<ReservationDto> ConvertToDto(Reservation reservation)
        {
            var result = new ReservationDto
            {

                Id = reservation.Id,
                ReservationDate = DatetimeExtension.NumberToDate(reservation.ReservationDate),
                ReservationDateFull = DatetimeExtension.NumberToDate(reservation.ReservationDate).ToGregorianDateTime()?.ToPersianDateStringFull(),
                ReservationDay = Convert.ToInt32(reservation.ReservationDate.ToString().Substring(6, 2)),
                ReservationDayOfWeek = DatetimeExtension.NumberToDate(reservation.ReservationDate).ToGregorianDateTime()?.ToPersianDateStringDay(),
                ReservationMonth = DatetimeExtension.NumberToDate(reservation.ReservationDate).ToGregorianDateTime()?.ToPersianDateStringMonth(),
                DoctorTreatmentCenterId = reservation.DoctorTreatmentCenterId,
                CancleTimeDuration = reservation.CancleTimeDuration,
                ReservationTime = reservation.ReservationTime,
                VisitCostId = reservation.VisitCostId,
                DoctorTreatmentCenter = reservation.DoctorTreatmentCenter,
                VisitCost = reservation.VisitCost
            };

            return result;
        }

        public async Task<List<FirstFreeTurnsDto>> ConvertToFirstFreeTurnDto(List<Reservation> reservations)
        {
            var result = reservations.Select(s => ConvertToFirstFreeTurnDto(s).Result).ToList();

            return result;

        }

        public async Task<FirstFreeTurnsDto> ConvertToFirstFreeTurnDto(Reservation reservation)
        {
            string rt = "";
            string address = "";
            string name = "";
            if (reservation.DoctorTreatmentCenter.Clinic != null)
            { 
                rt = "حضوری";
                name = reservation.DoctorTreatmentCenter.Clinic.Name;
                address = reservation.DoctorTreatmentCenter.Clinic.Address;
            }
            else if (reservation.DoctorTreatmentCenter.Office != null)
            {
                rt = reservation.DoctorTreatmentCenter.Office.OfficeType.Type;
                name = reservation.DoctorTreatmentCenter.Office.Name;
                address = reservation.DoctorTreatmentCenter.Office.Address;
            }
            var result = new FirstFreeTurnsDto
            {

                TurnId = reservation.Turns.First().Id,
                ReservationDate = DatetimeExtension.NumberToDate(reservation.ReservationDate),
                ReservationDateFull = DatetimeExtension.NumberToDate(reservation.ReservationDate).ToGregorianDateTime()?.ToPersianDateStringFull(),
                TreatmentCenterName = name,
                ReservationTime = reservation.Turns.Where(x=> x.IsFree == true).OrderBy(x => x.Stime).First().Stime,
                VisitCostPrice = reservation.VisitCost.Price.ToString(),
                ReservationType = rt,
                TreatmentCenterAddress = address,
            };

            return result;
        }

}
}
