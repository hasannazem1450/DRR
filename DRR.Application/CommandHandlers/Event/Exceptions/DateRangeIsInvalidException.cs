using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Event.Exceptions
{
    public sealed class DateRangeIsInvalidException : BusinessException
    {
        public DateRangeIsInvalidException()
            : base(ExceptionCodes.EventInfo.DateRangeIsInvalid)
        {
        }

        public override string EnglishMessage => "Date Range Is Invalid !";
        public override string? PersianMessage => "بازه تاریخی انتخاب شده نادرست می‌باشد !";

    }
}
