using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository.Profile
{
    public interface ISmeMemberRepository : IRepository
    {
        Task<SmeMember> ReadById(int id);

        Task<List<SmeMember>> Read();

        Task Delete(int id);

        Task Update(SmeMember smeMember);

        Task Create(SmeMember smeMember);
    }
}
