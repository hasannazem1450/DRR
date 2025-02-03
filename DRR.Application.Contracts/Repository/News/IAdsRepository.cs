using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.News;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository.News
{
    public interface IAdsRepository : IRepository
    {
        Task<Domain.News.Ads> ReadById(int id); 

        Task<List<Domain.News.Ads>> Read();

        Task Delete(int id);

        Task Update(Domain.News.Ads ads);

        Task Create(Domain.News.Ads ads);

        Task<List<Domain.News.Ads>> ReadAdsBySmeProfileId(int SmeProfileId);
    }
}
