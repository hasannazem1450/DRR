using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Articles;
using DRR.Domain.Profile;

namespace DRR.Application.Contracts.Commands.Jornal
{
    public class ArticleDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public int ArticleTypeId { get; set; }

        public string Link { get; set; }
        public Guid? DRRFileId { get; set; }
        public string Authors { get; set; }
        public ArticleType ArticleType { get; set; }
        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; set; }
    }
}
