using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile.Member;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository.Profile.Member
{
    public interface IPositionRepository : IRepository
    {
        Task Create(Position position);

        Task Update(Position position);

        Task<List<Position>> Read();

        Task<Position> ReadById(int id);

        Task Delete(int id);
    }
}
