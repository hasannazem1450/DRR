using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Profile.SmeProfile;

public class DeleteSmeProfileCommand : Command
{
    public int Id { get; set; }
}

public class DeleteSmeProfileCommandResponse : CommandResponse
{

}