using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Repository;
using DRR.CommandDB;
using DRR.Domain.Identity;
using DRR.Domain.SystemMessages;
using DRR.Framework.Contracts.Common.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DRR.CommandDb.Repository
{
    internal class SystemMessageRepository : BaseRepository, ISystemMessageRepository
    {

        public SystemMessageRepository(BaseProjectCommandDb db, UserManager<ApplicationUser> userManager) : base(db)
        {
        }

        public async Task<SystemMessage> GetMessageByCodeAndType(int code, TypeSystemMessage type)
        {
            var result = await _Db.SystemMessages.Include(x => x.SystemDataMessages).FirstOrDefaultAsync(x => x.Code == code && x.TypeMessage == type);

            return result;
        }

        public async Task<SystemMessage> GetMessageByCode(int code)
        {
            var result = await _Db.SystemMessages.FirstOrDefaultAsync(x => x.Code == code);

            return result;
        }

        public async Task<bool> Create(SystemMessage systemMessage)
        {
            await _Db.SystemMessages.AddAsync(systemMessage);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(SystemMessage systemMessage)
        {
            _Db.SystemMessages.Update(systemMessage);
            var result = await _Db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> Delete(int code)
        {
            var found = await GetMessageByCode(code);

            _Db.SystemMessages.Remove(found);
            return await _Db.SaveChangesAsync() > 0;
        }

        public async Task<List<SystemMessage>> GetAll()
        {
            return await _Db.SystemMessages.Include(s => s.SystemDataMessages).ToListAsync();
        }

        public async Task<SystemDataMessage> GetDataMessageByCodeAndType(int code, TypeSystemMessage type, ContentLanguage language)
        {
            var systemMessage =
                await _Db.SystemMessages
                    .Include(x => x.SystemDataMessages.Where(w => (int)w.MessageLanguage == (int)language))
                    .FirstOrDefaultAsync(x => x.Code == code && x.TypeMessage == type);

            var result = systemMessage?.SystemDataMessages.FirstOrDefault();
            
            return result;
        }
    }
}
