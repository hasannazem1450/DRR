using DRR.Domain.Comments;
using DRR.Domain.Event;
using DRR.Domain.FileManagement;
using DRR.Domain.Profile;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;

namespace DRR.Domain.Articles
{
    public class Article : Entity<int>
    {
        public Article(string title,string desc, string shortDesc, int articleTypeId, string link, Guid? dRRFileId, string authors,int smeProfileId)
        {
            Title = title;
            Desc = desc;
            ShortDesc = shortDesc;
            ArticleTypeId = articleTypeId;
            Link = link;
            DRRFileId = dRRFileId;
            Authors = authors;
            SmeProfileId = smeProfileId;
        }

        public string Title { get; set; }
        public string Desc { get; set; }
        public string ShortDesc { get; set; }
        public int ArticleTypeId { get; set; }
     
        public string Link { get; set; }
        public Guid? DRRFileId { get; set; }
        public DRRFile PhotoFile { get; set; }
        public string Authors { get; set; }
        public ArticleType ArticleType { get; set; }
        public int SmeProfileId { get; set; }
        public SmeProfile SmeProfile { get; set; }

        public void Update(string title, string desc, string shortDesc, int articleTypeId, string link, Guid? dRRFileId, string authors, int smeProfileId)
        {
            Title = title;
            Desc = desc;
            ShortDesc = shortDesc;
            ArticleTypeId = articleTypeId;
            Link = link;
            DRRFileId = dRRFileId;
            Authors = authors;
            SmeProfileId = smeProfileId;
        }

        public void SetIsDeleted(bool isDeleted)
        {
            IsDeleted = isDeleted;
        }

        public ICollection<ArticleComment> ArticleComments { get; protected set; }


    }

}
