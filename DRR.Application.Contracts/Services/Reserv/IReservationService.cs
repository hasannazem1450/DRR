using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Event;
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
    public interface IReservationService : IService
    {
        Task<List<ReservationDto>> ConvertToDto(List<Reservation> reservations);
        Task<ReservationDto> ConvertToDto(Reservation reservation);
        Task<List<FirstFreeTurnsDto>> ConvertToFirstFreeTurnDto(List<Reservation> reservations);
        Task<FirstFreeTurnsDto> ConvertToFirstFreeTurnDto(Reservation reservation);

    }
}
