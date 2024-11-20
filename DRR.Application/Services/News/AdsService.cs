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
    public class AdsService : IAdsService
    {

        private readonly IAdsRepository _adsRepository;

        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public async Task<AdsDto> ReadById(int id)
        {
            var ads = await _adsRepository.ReadById(id);

            return new AdsDto()
            {
                Id = ads.Id,
                Title = ads.Title,
                HeadLine = ads.HeadLine,
                Description = ads.Description,
                Photo = ads.Photo,
                SmeProfile = ads.SmeProfile,
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

        public async Task<List<AdsDto>> ReadAdsBySmeProfileId(int SmeProfileId)
        {
            var ads = await _adsRepository.ReadAdsBySmeProfileId(SmeProfileId);

            var result = new List<AdsDto>();

            foreach (var item in ads)
            {
                var dto = new AdsDto()
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
