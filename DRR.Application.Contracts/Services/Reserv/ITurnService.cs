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
    public interface ITurnService : IService
    {
        Task<List<TurnDto>> ConvertToDto(List<Turn> turns);
        Task<TurnDto> ConvertToDto(Turn turn);
    }
}
