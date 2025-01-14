using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists.Exceptions
{
    public sealed class SpecialistException : BusinessException
    {
        public SpecialistException()
            : base(ExceptionCodes.Specialist.LongFileSizeForBase64)
        {
        }

        public override string EnglishMessage => "Long File Size For Base64 !";
        public override string? PersianMessage => "حجم فایل برای ذخیره در بیس64 زیاد است !";

    }
}
