using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Authentication.Exceptions;

public sealed class ActivatingCodeIsInvalidException : BusinessException
{
    public ActivatingCodeIsInvalidException()
        : base(ExceptionCodes.Identity.ActivatingCodeNotSended)
    {
    }

    public override string? PersianMessage { get; } = "کد فعال‌سازی نامعتبر است";
    public override string EnglishMessage { get; } = "activation code is invalid!";
}