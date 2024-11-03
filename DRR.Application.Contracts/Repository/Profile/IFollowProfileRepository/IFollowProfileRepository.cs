using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile;
using DRR.Domain.Profile.Follow;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository.Profile.IFollowProfileRepository
{
    public interface IFollowProfileRepository : IRepository
    {
        Task<FollowProfile> ReadById(int id);

        Task<List<FollowProfile>> Read();

        Task Delete(int id);

        Task Update(FollowProfile followProfile);

        Task Create(FollowProfile followProfile);
    }
}
