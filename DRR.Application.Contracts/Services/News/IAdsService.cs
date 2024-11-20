
using DRR.Application.Contracts.Commands.News;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.News
{
    public interface IAdsService : IService
    {
        Task<AdsDto> ReadById(int id);
        //Task<List<NewsDto>> Read();
        Task<List<AdsDto>> ReadAdsBySmeProfileId(int SmeProfileId);
    }
}
