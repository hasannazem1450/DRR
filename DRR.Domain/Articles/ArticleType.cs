using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Articles
{
    public class ArticleType : Entity<int>
    {
        public ArticleType(string type)
        {
            Type = type;

        }


        public string Type { get; set; }
        public void Update(string type)
        { Type = type; }

        public virtual ICollection<Article> Articles { get; set; }


    }

}
