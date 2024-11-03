using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Authentication;

public class ActivatingRegistrationCommand : Command
{
    public string Mobile { get; set; }
    public string ActivationCode { get; set; }
}

public class ActivatingRegistrationCommandResponse : CommandResponse
{
}