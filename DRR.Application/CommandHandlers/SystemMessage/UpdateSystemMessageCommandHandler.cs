using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.SystemMessage.Exceptions;
using DRR.Application.Contracts.Commands.SystemMessage;
using DRR.Application.Contracts.Repository;
using DRR.Domain.SystemMessages;
using DRR.Framework.Contracts.Abstracts;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;

namespace DRR.Application.CommandHandlers.SystemMessage
{
    public class UpdateSystemMessageCommandHandler
        : CommandHandler<UpdateSystemMessageCommand, CommandResponse>
    {
        private readonly ISystemMessageRepository _systemErrorRepository;
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;


        public UpdateSystemMessageCommandHandler(ISystemMessageRepository systemErrorRepository, UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
        {
            _systemErrorRepository = systemErrorRepository;
            _userManager = userManager;
        }

        public override async Task<CommandResponse> Executor(UpdateSystemMessageCommand command)
        {
            var found = await _systemErrorRepository.GetMessageByCodeAndType(command.Code, command.TypeMessage);

            if (found == null) throw new SystemErrorCanNotFoundException();

            var list = new List<SystemDataMessage>();

            foreach (var item in command.List)
            {
                var mess = new SystemDataMessage(item.MessageLanguage, item.Prefix, item.Message);

                list.Add(mess);
            }

            found.UpdateMessage(list);
           
            await _systemErrorRepository.Update(found);

            return (CommandResponseSuccessful.CreateSuccessful());
        }
    }
}
