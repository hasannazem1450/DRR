using DRR.Domain.Sms;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Repository.Sms;

public interface ISmsInfoRepository : IRepository
{
    Task Create(SmsInfo smsInfo);
    Task<SmsInfo> ReadLastByReceiverNumber(string receiverNumber, SmsType smsType);
}