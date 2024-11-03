using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Application.Contracts.Repository.FileManagment;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.FileManagement;
using DRR.Framework.Contracts.Abstracts;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.FileManagment;

public class UploadFileCommandHandler : CommandHandler<UploadFileCommand, UploadFileCommandResponse>
{
    private readonly IDRRFileRespository _DRRFileRespository;
    private readonly IDRRFileService _DRRFileService;

    public UploadFileCommandHandler(IDRRFileRespository DRRFileRespository, IDRRFileService DRRFileService)
    {
        _DRRFileRespository = DRRFileRespository;
        _DRRFileService = DRRFileService;
    }

    public override async Task<UploadFileCommandResponse> Executor(UploadFileCommand command)
    {
        var DRRFile = new DRRFile(command.FormFile.FileName, command.FormFile.FileName.Split(".").LastOrDefault(), "Product");

        var size = await _DRRFileService.GetFileSizeKb(command.FormFile.Length);
        DRRFile.SetSize(size);

        var fullPath = await _DRRFileService.SaveFile(DRRFile, command.FormFile);
        DRRFile.SetFullPath(fullPath);

        await _DRRFileRespository.Create(DRRFile);

        return new UploadFileCommandResponse
        {
            Id = DRRFile.Id
        };
    }
}