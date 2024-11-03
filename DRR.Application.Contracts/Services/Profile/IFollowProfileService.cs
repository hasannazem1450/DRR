using DRR.Application.Contracts.Commands.Profile.FollowProfile;
using DRR.Framework.Contracts.Markers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.Profile
{
    public interface IFollowProfileService : IService
    {
        Task<FollowProfileDto> ReadById(int id);

        Task<List<FollowProfileDto>> Read();
    }
}
