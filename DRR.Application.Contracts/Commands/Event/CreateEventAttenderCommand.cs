using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Event;

public class CreateEventAttenderCommand : Command
{
    public int EventInfoId { get; set; }
    public int SmeProfileId { get; set; }
    public int EventAttenderType { get; set; }
    public string ContactNumber { get; set; }
}

public class CreateEventAttenderCommandResponse : CommandResponse
{
}