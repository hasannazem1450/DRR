using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.News;
using DRR.Application.Contracts.Repository.News;
using DRR.Application.Contracts.Services.News;

namespace DRR.Application.Services.News
{
    public class NewsService : INewsService
    {

        private readonly INewsRepository _newsRepository;

        public NewsService(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<NewsDto> ReadById(int id)
        {
            var news = await _newsRepository.ReadById(id);

            return new NewsDto()
            {
                Id = news.Id,
                Title = news.Title,
                HeadLine = news.HeadLine,
                Description = news.Description,
                Photo = news.Photo,
                SmeProfile = news.SmeProfile,
            };
        }

        //public async Task<List<NewsDto>> Read()
        //{
        //    var news = await _newsRepository.Read();

        //    var result = new List<NewsDto>();

        //    foreach (var item in news)
        //    {
        //        var dto = new NewsDto()
        //        {
        //            Id = item.Id,
        //            Title = item.Title,
        //            HeadLine = item.HeadLine,
        //            Description = item.Description,
        //            Photo = item.Photo,
        //            SmeProfile = item.SmeProfile,
        //        };

        //        result.Add(dto);
        //    }

        //    return result;
        //}

        public async Task<List<NewsDto>> ReadNewsBySmeProfileId(int SmeProfileId)
        {
            var news = await _newsRepository.ReadNewsBySmeProfileId(SmeProfileId);

            var result = new List<NewsDto>();

            foreach (var item in news)
            {
                var dto = new NewsDto()
                {
                    Id = item.Id,
                    Title = item.Title,
                    HeadLine = item.HeadLine,
                    Description = item.Description,
                    Photo = item.Photo,
                    SmeProfile = item.SmeProfile,
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
