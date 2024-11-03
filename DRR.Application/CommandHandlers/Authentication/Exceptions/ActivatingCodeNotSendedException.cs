using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Authentication.Exceptions;

public sealed class ActivatingCodeNotSendedException : BusinessException
{
    public ActivatingCodeNotSendedException()
        : base(ExceptionCodes.Identity.ActivatingCodeNotSended)
    {
    }

    public override string? PersianMessage { get; } = "خطا در ارسال کد فعال‌سازی";
    public override string EnglishMessage { get; } = "activation code not sened!";
}