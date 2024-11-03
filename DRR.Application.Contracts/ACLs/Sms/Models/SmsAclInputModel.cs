using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.ACLs.Sms.Models;

public class SmsAclInputModel : IAclInputModel
{
    public string Receiver { get; set; }
    public string Message { get; set; }
}