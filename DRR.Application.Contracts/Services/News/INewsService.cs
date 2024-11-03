
using DRR.Application.Contracts.Commands.News;
using DRR.Framework.Contracts.Markers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Services.News
{
    public interface INewsService : IService
    {
        Task<NewsDto> ReadById(int id);
        //Task<List<NewsDto>> Read();
        Task<List<NewsDto>> ReadNewsBySmeProfileId(int SmeProfileId);
    }
}
