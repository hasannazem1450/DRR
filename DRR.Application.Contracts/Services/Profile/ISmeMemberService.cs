using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Services.Profile
{
    public interface ISmeMemberService : IService
    {
        Task<SmeMemberDto> ReadById(int id);

        Task<List<SmeMemberDto>> Read();
    }
}
