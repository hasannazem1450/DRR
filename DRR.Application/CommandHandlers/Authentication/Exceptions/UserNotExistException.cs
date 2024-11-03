using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Authentication.Exceptions;

public sealed class UserNotExistException : BusinessException
{
    public UserNotExistException()
        : base(ExceptionCodes.Identity.UserNotExist)
    {
    }

    public override string? PersianMessage { get; } = "کاربر وجود ندارد .";
    public override string EnglishMessage { get; } = "User not exist .";
}