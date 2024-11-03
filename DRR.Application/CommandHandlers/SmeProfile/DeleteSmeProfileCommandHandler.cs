using DRR.Application.CommandHandlers.SmeProfile.Exceptions;
using DRR.Application.Contracts.Commands.Profile.SmeProfile;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Framework.Contracts.Abstracts;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.SmeProfile;

public class DeleteSmeProfileCommandHandler : CommandHandler<DeleteSmeProfileCommand, DeleteSmeProfileCommandResponse>
{
    private readonly ISmeProfileRepository _smeProfileRepository;

    public DeleteSmeProfileCommandHandler(ISmeProfileRepository smeProfileRepository)
    {
        _smeProfileRepository = smeProfileRepository;
    }

    public override async Task<DeleteSmeProfileCommandResponse> Executor(DeleteSmeProfileCommand command)
    {
        var smeProfile = await _smeProfileRepository.ReadById(command.Id);

        if (smeProfile == null)
            throw new SmeProfileNotExistException();

        smeProfile.SetIsDeleted(true);

        await _smeProfileRepository.Update(smeProfile);

        return new DeleteSmeProfileCommandResponse();
    }


}