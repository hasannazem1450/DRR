using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Application.Contracts.Services.Jornal;
using DRR.Application.Contracts.Services.Profile;
using DRR.Application.Services.FileManagment;
using DRR.Domain.Articles;

namespace DRR.Application.Services.Jornal
{

    public class ArticleService : IArticleService
    {
        private readonly ISmeProfileService _smeProfileService;
        private readonly IDRRFileService _dRRFileService;

        public ArticleService(ISmeProfileService smeProfileService, IDRRFileService dRRFileService)
        {
            _smeProfileService = smeProfileService;
            _dRRFileService = dRRFileService;
        }

        public async Task<List<ArticleDto>> OrderDesc(List<ArticleDto> ArticleList)
        {
            var result = ArticleList.OrderByDescending(x => x.Id).ToList();

            return result;
        }

        public async Task<List<ArticleDto>> ConvertTo(List<Article> ArticleList)
        {
            var result = ArticleList.Select(s => ConvertTo(s).Result).ToList();

            return result;
        }

        public async Task<ArticleDto> ConvertTo(Article Article)
        {
            var result = new ArticleDto
            {
                Id = Article.Id,
                Title = Article.Title,
                Desc = Article.Desc,
                ShortDesc = Article.ShortDesc,
                ArticleTypeId = Article.ArticleTypeId,
                Link = Article.Link,
                DRRFileId = Article.DRRFileId,
                Authors = Article.Authors,
                SmeProfileId = Article.SmeProfileId,
                ImageFile = await _dRRFileService.ConvertToImageFileDto(Article.PhotoFile),
                SmeProfileDto =  await _smeProfileService.ConvertToDto(Article.SmeProfile) 
            };

            return result;
        }
    }
}
