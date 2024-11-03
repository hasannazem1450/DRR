using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.SystemMessage.Exceptions
{
    public sealed class SystemErrorCodeIsDuplicateException : BusinessException
    {
        public SystemErrorCodeIsDuplicateException()
            : base(ExceptionCodes.SystemMessage.SystemErrorCodeIsDuplicate)
        {
        }

        public override string EnglishMessage => "System error code is duplicate!";
        public override string? PersianMessage => "کد ارور مورد نظر وجود دارد !";

    }
}
