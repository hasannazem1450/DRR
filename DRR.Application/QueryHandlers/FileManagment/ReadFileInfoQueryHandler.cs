using DRR.Application.Contracts.Queries.FileManagment;
using DRR.Application.Contracts.Repository.FileManagment;
using DRR.Application.Contracts.Services.FileManagment;
using DRR.Application.QueryHandlers.FileManagment.Exceptions;
using DRR.Framework.Contracts.Markers;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Application.QueryHandlers.FileManagment;

public class ReadFileInfoQueryHandler : IQueryHandler<ReadFileInfoQuery, ReadFileInfoQueryResponse>
{
    private readonly IDRRFileRespository _DRRFileRespository;
    private readonly IDRRFileService _DRRFileService;

    public ReadFileInfoQueryHandler(IDRRFileRespository DRRFileRespository, IDRRFileService DRRFileService)
    {
        _DRRFileRespository = DRRFileRespository;
        _DRRFileService = DRRFileService;
    }

    public async Task<ReadFileInfoQueryResponse> Execute(ReadFileInfoQuery query, CancellationToken cancellationToken)
    {
        var file = await _DRRFileRespository.ReadById(query.Id);

        if (file == null)
            throw new DRRFileNotFoundException();

        var result = new ReadFileInfoQueryResponse
        {
            Info = await _DRRFileService.ConvertToImageFileDto(file)
        };

        return result;
    }
}