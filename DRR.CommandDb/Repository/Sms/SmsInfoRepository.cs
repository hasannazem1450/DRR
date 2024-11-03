using DRR.Application.Contracts.Repository.Sms;
using DRR.CommandDB;
using DRR.Domain.Sms;
using DRR.Framework.Contracts.Common.Enums;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.CommandDb.Repository.Sms;

public class SmsInfoRepository : BaseRepository, ISmsInfoRepository
{
    public SmsInfoRepository(BaseProjectCommandDb db) : base(db)
    {
    }

    public async Task Create(SmsInfo smsInfo)
    {
        await _Db.SmsInfos.AddAsync(smsInfo);
        await _Db.SaveChangesAsync();
    }

    public async Task<SmsInfo> ReadLastByReceiverNumber(string receiverNumber, SmsType smsType)
    {
        var smsInfo = await _Db.SmsInfos.OrderByDescending(x => x.Id)
            .FirstOrDefaultAsync(x => x.ReceiverNumber == receiverNumber && x.SmsType == smsType);

        return smsInfo;
    }
}