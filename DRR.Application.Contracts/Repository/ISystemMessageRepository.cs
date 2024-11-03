using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.SystemMessages;
using DRR.Framework.Contracts.Common.Enums;
using DRR.Framework.Contracts.Markers;

namespace DRR.Application.Contracts.Repository
{
    public interface ISystemMessageRepository : IRepository
    {
        Task<SystemMessage> GetMessageByCodeAndType(int code, TypeSystemMessage type);
        Task<SystemDataMessage> GetDataMessageByCodeAndType(int code, TypeSystemMessage type, ContentLanguage language);
        Task<SystemMessage> GetMessageByCode(int code);
        Task<bool> Create(SystemMessage systemMessage);
        Task<bool> Update(SystemMessage systemMessage);
        Task<bool> Delete(int code);
        Task<List<SystemMessage>> GetAll();
    }
}
