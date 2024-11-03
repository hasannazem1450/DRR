using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Authentication.Exceptions
{
    public sealed class UserNameAndPasswordAreNullException : BusinessException
    {
        public UserNameAndPasswordAreNullException()
            : base(ExceptionCodes.Identity.UserNameOrPhoneNumberIsNullOrEmpty)
        {
        }

        public override string? PersianMessage { get; } = "نام کاربری یا شماره تلفن خالی میباشد .";
        public override string EnglishMessage { get; } = "UserName or PhoneNumber Is Empty .";
    }
}
