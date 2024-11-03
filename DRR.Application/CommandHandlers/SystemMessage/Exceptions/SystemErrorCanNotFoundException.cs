using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.SystemMessage.Exceptions
{
    public sealed class SystemErrorCanNotFoundException : BusinessException
    {
        public SystemErrorCanNotFoundException()
            : base(ExceptionCodes.SystemMessage.SystemErrorCanNotFound)
        {
        }

        public override string EnglishMessage => "Can not found system error!";
        public override string? PersianMessage => "ارور ناشناخته ای رخ داد !";

    }
}
