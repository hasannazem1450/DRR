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
    public class CreateSystemMessageCommandHandler
        : CommandHandler<CreateSystemMessageCommand, CommandResponse>
    {
        private readonly ISystemMessageRepository _systemErrorRepository;
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;


        public CreateSystemMessageCommandHandler(ISystemMessageRepository systemErrorRepository, UserManager<DRR.Domain.Identity.ApplicationUser> userManager)
        {
            _systemErrorRepository = systemErrorRepository;
            _userManager = userManager;
        }

        public override async Task<CommandResponse> Executor(CreateSystemMessageCommand command)
        {
            var found =await _systemErrorRepository.GetMessageByCodeAndType(command.Code, command.TypeMessage);
            
            if (found != null) throw new SystemErrorCodeIsDuplicateException();

            var list = new List<SystemDataMessage>();

            if (command.List.IsEmpty()) throw new SystemErrorMessageIsEmptyException();

            foreach (var item in command.List)
            {
                var value = new SystemDataMessage(item.MessageLanguage, item.Prefix, item.Message);

                list.Add(value);
            }

            var systemError = new Domain.SystemMessages.SystemMessage(command.Code, command.TypeMessage, list);
            
            await _systemErrorRepository.Create(systemError);

            return (CommandResponseSuccessful.CreateSuccessful());
        }
    }
}
