using DRR.Application.Contracts.Commands.SiteMessenger;
using DRR.Application.Contracts.Repository.SiteMessenger;
using DRR.Application.Contracts.Services.SiteMessenger;
using DRR.Domain.SiteMessenger;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DRR.Application.Services.Message
{
    public class SiteMessageService : ISiteMessageService
    {
        private readonly ISiteMessageRepository _siteMessageRepository;

        public SiteMessageService(ISiteMessageRepository siteMessageRepository)
        {
            _siteMessageRepository = siteMessageRepository;
        }
        public async Task<List<SiteMessage>> ReadAll()
        {
            var result = await _siteMessageRepository.ReadAll();

            return result;
        }

        public async Task<SiteMessage> ReadById(int id)
        {
            var result = await _siteMessageRepository.ReadById(id);

            return result;
        }

        public async Task<List<SiteMessageDto>> ConvertToDto(List<SiteMessage> siteMessages)
        {
            var result = siteMessages.Select(s => ConvertToDto(s).Result).ToList();

            return result;
        }

        public async Task<SiteMessageDto> ConvertToDto(SiteMessage sitemessage)
        {
            var result = new SiteMessageDto
            {
                MessageBody = sitemessage.MessageBody,
                MessageSubject = sitemessage.MessageSubject,
                MessageType = sitemessage.MessageType,
                MessageImage = sitemessage.MessageImage,
                SenderUserId = sitemessage.SenderUserId,
            };

            return result;
        }

        public async Task<SiteMessageImageDto> ConvertTo(SiteMessageImage siteMessageImage)
        {
            var result = new SiteMessageImageDto
            {
                Id = siteMessageImage.Id,
                ImageId = siteMessageImage.ImageId,
                SiteMessageId = siteMessageImage.SiteMessageId
            };

            return result;
        }

        public async Task<List<SiteMessageImageDto>> ConvertTo(List<SiteMessageImage> siteMessageImages)
        {
            var result = siteMessageImages.Select(s => ConvertTo(s).Result).ToList();

            return result;
        }
    }
}
