using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Authentication;

public class GenerateRegistrationCodeCommand : Command
{
    public string Mobile { get; set; }
}

public class GenerateRegistrationCodeCommandResponse : CommandResponse
{
}