namespace DRR.Application.Contracts.Commands.Event;

public class EventAttenderDto
{
    public int Id { get; set; }
    public int SmeProfileId { get; set; }
    public string SmeProfileName { get; set; }
    public int EventInfoId { get; set; }
    public string EventInfoName { get; set; }
    public int EventAttenderType { get; set; }
    public string EventAttenderTypeName { get; set; }
    public string ContactNumber { get; set; }

}