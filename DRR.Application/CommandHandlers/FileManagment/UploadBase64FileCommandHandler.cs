using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Application.Contracts.Repository.FileManagment;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.FileManagement;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.FileManagment;

public class UploadBase64FileCommandHandler : CommandHandler<UploadBase64FileCommand, UploadBase64FileCommandResponse>
{
    private readonly IDRRFileRespository _DRRFileRespository;
    private readonly IDRRFileService _DRRFileService;

    public UploadBase64FileCommandHandler(IDRRFileRespository DRRFileRespository, IDRRFileService DRRFileService)
    {
        _DRRFileRespository = DRRFileRespository;
        _DRRFileService = DRRFileService;
    }

    public override async Task<UploadBase64FileCommandResponse> Executor(UploadBase64FileCommand command)
    {
        var DRRFile = new DRRFile(command.FileName, command.Extension, "Product");

        var size = await _DRRFileService.GetFileSizeKb(command.Base64);
        DRRFile.SetSize(size);

        var fullPath = await _DRRFileService.SaveFile(DRRFile, command.Base64);
        DRRFile.SetFullPath(fullPath);

        await _DRRFileRespository.Create(DRRFile);

        return new UploadBase64FileCommandResponse
        {
            Id = DRRFile.Id
        };
    }
}