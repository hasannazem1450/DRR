using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Project.Exceptions
{
    public sealed class ProjectPriceIsNullOrEmptyException : BusinessException
    {
        public override string Message => "";

        public ProjectPriceIsNullOrEmptyException()
            : base(ExceptionCodes.Project.PriceIsNullOrEmpty)
        {
        }

        public override string PersianMessage => "قیمت خالی میباشد";
        public override string EnglishMessage => "The Price Is Null Or Empty";
    }
}
