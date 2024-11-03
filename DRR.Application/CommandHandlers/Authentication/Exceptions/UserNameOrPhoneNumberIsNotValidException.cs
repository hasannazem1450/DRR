using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Authentication.Exceptions
{
    public sealed class UserNameOrPhoneNumberIsNotValidException : BusinessException
    {
        public UserNameOrPhoneNumberIsNotValidException()
            : base(ExceptionCodes.Identity.UserNameOrPhoneNumberIsNotValid)
        {
        }

        public override string? PersianMessage { get; } = "نام کاربری یا شماره تلفن صحیح نمیباشد .";
        public override string EnglishMessage { get; } = "UserName or PhoneNumber Is Not Valid !";
    }
}
