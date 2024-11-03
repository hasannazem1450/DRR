using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.Position;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.Profile.Member
{
    public interface IPositionService : IService
    {

        Task<List<PositionDto>> Read();

        Task<PositionDto> ReadById(int id);
    }
}
