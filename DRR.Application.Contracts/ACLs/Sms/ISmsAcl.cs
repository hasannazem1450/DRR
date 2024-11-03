using DRR.Application.Contracts.ACLs.Sms.Models;
using DRR.Framework.Contracts.Markers;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.ACLs.Sms;

public interface ISmsAcl : IAcl
{
    Task<SmsAclOutputModel> Send(SmsAclInputModel model);
}