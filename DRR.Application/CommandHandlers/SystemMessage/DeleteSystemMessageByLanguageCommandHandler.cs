using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.SystemMessage.Exceptions;
using DRR.Application.Contracts.Commands.SystemMessage;
using DRR.Application.Contracts.Repository;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.SystemMessage
{
    public class DeleteSystemMessageByLanguageCommandHandler
        : CommandHandler<DeleteSystemMessageByLanguageCommand, CommandResponse>
    {
        private readonly ISystemMessageRepository _systemErrorRepository;

        public DeleteSystemMessageByLanguageCommandHandler(ISystemMessageRepository systemErrorRepository)
        {
            _systemErrorRepository = systemErrorRepository;
        }

        public override async Task<CommandResponse> Executor(DeleteSystemMessageByLanguageCommand command)
        {
            var found = await _systemErrorRepository.GetMessageByCodeAndType(command.Code, command.TypeMessage);

            if (found == null) throw new SystemErrorCanNotFoundException();

            found.DeleteMessageByLanguage(command.ListLanguage);

            await _systemErrorRepository.Update(found);

            return (CommandResponseSuccessful.CreateSuccessful());
        }
    }
}
