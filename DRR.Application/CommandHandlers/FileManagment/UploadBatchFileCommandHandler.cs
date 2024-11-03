using DRR.Application.Contracts.Commands.FileManagment;
using DRR.Application.Contracts.Repository.FileManagment;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Domain.FileManagement;
using DRR.Framework.Contracts.Abstracts;
using DRR.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.FileManagment;

public class UploadBatchFileCommandHandler : CommandHandler<UploadBatchFileCommand, UploadBatchFileCommandResponse>
{
    private readonly IDRRFileRespository _DRRFileRespository;
    private readonly IDRRFileService _DRRFileService;

    public UploadBatchFileCommandHandler(IDRRFileRespository DRRFileRespository, IDRRFileService DRRFileService)
    {
        _DRRFileRespository = DRRFileRespository;
        _DRRFileService = DRRFileService;
    }

    public override async Task<UploadBatchFileCommandResponse> Executor(UploadBatchFileCommand command)
    {
        var idList = new List<Guid>();

        if (command.FormFiles.Any())
        {
            var DRRFiles = new List<DRRFile>();

            foreach (var formFile in command.FormFiles)
            {
                var DRRFile = new DRRFile(formFile.FileName, formFile.FileName.GetExtensionFromFilename(), "Product");

                var size = await _DRRFileService.GetFileSizeKb(formFile.Length);
                DRRFile.SetSize(size);

                var fullPath = await _DRRFileService.SaveFile(DRRFile, formFile);
                DRRFile.SetFullPath(fullPath);

                DRRFiles.Add(DRRFile);
                idList.Add(DRRFile.Id);
            }

            await _DRRFileRespository.Create(DRRFiles);
        }

        return new UploadBatchFileCommandResponse
        {
            IdList = idList
        };
    }
}