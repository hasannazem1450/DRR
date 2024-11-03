using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SmeProfile.Exceptions
{
    public sealed class SmeRaterNotExistException : BusinessException
    {
        public SmeRaterNotExistException()
            : base(ExceptionCodes.SmeProfile.SmeRaterIsNotExist)
        {
        }

        public override string EnglishMessage => "SmeRater Is Not Exist !";
        public override string? PersianMessage => "رتبه دهنده وجود ندارد !";

    }
}
