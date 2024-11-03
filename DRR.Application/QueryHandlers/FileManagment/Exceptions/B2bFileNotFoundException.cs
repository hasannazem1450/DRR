using DRR.Application.MessageCodes;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.QueryHandlers.FileManagment.Exceptions;

public sealed class DRRFileNotFoundException : BusinessException
{
    public DRRFileNotFoundException()
        : base(ExceptionCodes.DRRFile.DRRFileNotFound)
    {
    }

    public override string EnglishMessage => "File not found !";
    public override string? PersianMessage => "فایل یافت نشد !";

}