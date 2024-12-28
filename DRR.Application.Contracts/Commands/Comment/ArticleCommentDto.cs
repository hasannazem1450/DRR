using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Articles;
using DRR.Domain.Profile;

namespace DRR.Application.Contracts.Commands.Comment
{
    public class ArticleCommentDto
    {
        public string Desc { get; set; }
        public int ArticleId { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }


        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; protected set; }
        public Article Article { get; set; }
    }
}
