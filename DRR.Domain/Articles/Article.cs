using DRR.Domain.Comments;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;

namespace DRR.Domain.Articles
{
    public class Article : Entity<int>
    {
        public Article(string title,string desc, string shortDesc, int articleTypeId, string link, Guid? dRRFileId, string? authors)
        {
            Title = title;
            Desc = desc;
            ShortDesc = shortDesc;
            ArticleTypeId = articleTypeId;
            Link = link;
            DRRFileId = dRRFileId;
            Authors = authors;
    
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public int ArticleTypeId { get; set; }
     
        public string Link { get; set; }
        public Guid? DRRFileId { get; set; }
        public string? Authors { get; set; }
        public ArticleType ArticleType { get; set; }





    }

}
