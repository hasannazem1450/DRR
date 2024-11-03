using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SiteMessenger.Exceptions
{
    public sealed class MessageReciversIsEmptyException : BusinessException
    {
        public MessageReciversIsEmptyException()
            : base(ExceptionCodes.SiteMessenger.MessageReciversIsEmpty)
        {
        }

        public override string EnglishMessage => "Message Recivers is Empty !";
        public override string? PersianMessage => "گیرنده پیام مشخص نشده است !";
    }
}
