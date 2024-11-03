using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.SmeProfile.Exceptions;

public sealed class SmeProfileNotExistException : BusinessException
{
    public SmeProfileNotExistException()
        : base(ExceptionCodes.SmeProfile.SmeProfileIsNotExist)
    {
    }

    public override string EnglishMessage => "SmeProfile Is Not Exist !";
    public override string? PersianMessage => "پروفایل وجود ندارد !";

}