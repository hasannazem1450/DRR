using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Jornal.Exceptions
{
    public sealed class ArticleNotFoundException :BusinessException
    {
        public ArticleNotFoundException()
       : base(ExceptionCodes.Article.ArticleNotFound)
        {
        }
        public override string EnglishMessage => "News not found !";
        public override string? PersianMessage => "مقاله یافت نشد !";
    }
}
