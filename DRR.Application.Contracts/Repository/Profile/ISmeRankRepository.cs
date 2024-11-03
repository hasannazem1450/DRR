using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository.Profile
{
    public interface ISmeRankRepository : IRepository
    {
        Task<SmeRank> ReadSmeRankById (int id);
    }
}
