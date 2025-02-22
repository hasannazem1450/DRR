using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Customer
{
    public class DeletePatientFavoriteCommandHandler : CommandHandler<DeletePatientFavoriteCommand, DeletePatientFavoriteCommandResponse>
    {
        private readonly IPatientFavoriteRepository _pfRepository;


        public DeletePatientFavoriteCommandHandler(IPatientFavoriteRepository pfRepository)
        {
            _pfRepository = pfRepository;
        }

        public override async Task<DeletePatientFavoriteCommandResponse> Executor(DeletePatientFavoriteCommand command)
        {
            await _pfRepository.Delete(command.Id);

            return new DeletePatientFavoriteCommandResponse();
        }
    }
}
