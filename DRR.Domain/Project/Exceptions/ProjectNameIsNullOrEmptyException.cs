using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Project.Exceptions
{
    public sealed class ProjectNameIsNullOrEmptyException : BusinessException
    {
        public ProjectNameIsNullOrEmptyException()
            : base(ExceptionCodes.Project.NameIsNullOrEmpty)
        {
        }

        public override string PersianMessage => "نام خالی میباشد";
        public override string EnglishMessage => "The Name Is Null Or Empty";

    }
}
