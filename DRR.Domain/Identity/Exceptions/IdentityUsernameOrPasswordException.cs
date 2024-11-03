using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.MessageCodes;
using DRR.Framework.Contracts.Abstracts;
using DRR.Framework.Contracts.Common.Enums;

namespace DRR.Domain.Identity.Exceptions
{
    public sealed class IdentityUsernameOrPasswordException : BusinessException
    {
        public IdentityUsernameOrPasswordException()
            : base(ExceptionCodes.Identity.UsernameOrPasswordIncorrect)
        {
        }

        public override string EnglishMessage => "Username Or Password Is Incorrect !";
        public override string? PersianMessage => "نام کاربری یا کلمه عبور اشتباه است !";
    }
}
