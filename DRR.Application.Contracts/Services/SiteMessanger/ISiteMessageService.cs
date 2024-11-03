using DRR.Framework.Contracts.Markers;
using DRR.Domain.SiteMessenger;
using DRR.Application.Contracts.Commands.SiteMessenger;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DRR.Application.Contracts.Services.SiteMessenger
{
    public interface ISiteMessageService : IService
    {
        Task<List<SiteMessage>> ReadAll();
        Task<SiteMessage> ReadById(int id);
        Task<List<SiteMessageDto>> ConvertToDto(List<SiteMessage> sitemessages);
        Task<SiteMessageDto> ConvertToDto(SiteMessage sitemessage);
        Task<SiteMessageImageDto> ConvertTo(SiteMessageImage siteMessageImage);
        Task<List<SiteMessageImageDto>> ConvertTo(List<SiteMessageImage> siteMessageImages);

    }
}
