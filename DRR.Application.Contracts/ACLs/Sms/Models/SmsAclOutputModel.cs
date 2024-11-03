using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.ACLs.Sms.Models;

public class SmsAclOutputModel : IAclOutputModel
{
    public bool IsSuccess { get; set; }
}