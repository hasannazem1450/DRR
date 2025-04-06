using DRR.Application.Contracts.Commands.Specialists;
using DRR.Application.Contracts.Repository.Specialists;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Specialists
{
    public class DeleteCategoryCommandHandler : CommandHandler<DeleteCategoryCommand, DeleteCategoryCommandResponse>
    {

        private readonly ICategorysRepository _categorysRepository;


        public DeleteCategoryCommandHandler(ICategorysRepository categorysRepository)
        {
            _categorysRepository = categorysRepository;
        }

        public override async Task<DeleteCategoryCommandResponse> Executor(DeleteCategoryCommand command)
        {
            await _categorysRepository.Delete(command.Id);

            return new DeleteCategoryCommandResponse();
        }
    }
}
