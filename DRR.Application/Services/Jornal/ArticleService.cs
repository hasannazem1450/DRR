using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Jornal;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Application.Contracts.Services.Jornal;
using DRR.Application.Contracts.Services.Profile;

namespace DRR.Application.Services.Jornal
{

    public class ArticleService : IArticleService
    {
        private readonly ISmeProfileService _smeProfileService;
        private readonly IDRRFileService _b2BFileService;

        public ArticleService(ISmeProfileService smeProfileService, IDRRFileService b2BFileService)
        {
            _smeProfileService = smeProfileService;
            _b2BFileService = b2BFileService;
        }

        public async Task<List<ArticleDto>> OrederDesc(List<ArticleDto> ArticleList)
        {
            var result = ArticleList.OrderByDescending(x => x.Id).ToList();

            return result;
        }

        public async Task<List<ArticleDto>> ConvertTo(List<Domain.Article.Article> ArticleList)
        {
            var result = ArticleList.Select(s => ConvertTo(s).Result).ToList();

            return result;
        }

        public async Task<ArticleDto> ConvertTo(Domain.Articles.Article Article)
        {
            var result = new ArticleDto
            {
                //Id = Article.Id,
                //Title = Article.Title,
                //HeadLine = Article.HeadLine,
                //Description = Article.Description,
                //PhotoFileInfo = Article.PhotoFile != null
                //    ? await _b2BFileService.ConvertToImageFileDto(Article.PhotoFile)
                //    : null,
                //SmeProfile = Article.SmeProfile != null ? await _smeProfileService.ConvertToDto(Article.SmeProfile) : null
            };

            return result;
        }
    }
}
