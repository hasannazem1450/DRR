using DRR.Application.Contracts.Queries.FileManagment;
using DRR.Application.Contracts.Repository.FileManagment;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Application.QueryHandlers.FileManagment.Exceptions;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.FileManagment;

public class ReadFileQueryHandler : IQueryHandler<ReadFileQuery, ReadFileQueryResponse>
{
    private readonly IDRRFileRespository _DRRFileRespository;
    private readonly IDRRFileService _DRRFileService;

    public ReadFileQueryHandler(IDRRFileRespository DRRFileRespository, IDRRFileService DRRFileService)
    {
        _DRRFileRespository = DRRFileRespository;
        _DRRFileService = DRRFileService;
    }

    public async Task<ReadFileQueryResponse> Execute(ReadFileQuery query, CancellationToken cancellationToken)
    {
        var file = await _DRRFileRespository.ReadById(query.Id);

        if (file == null)
            throw new DRRFileNotFoundException();

        var result = new ReadFileQueryResponse
        {
            Data = await _DRRFileService.ReadDataFromPath(file.FullPath),
            MimeType = await _DRRFileService.GetMimeTypeForFileExtension(file.FullPath)
        };

        return result;
    }
}