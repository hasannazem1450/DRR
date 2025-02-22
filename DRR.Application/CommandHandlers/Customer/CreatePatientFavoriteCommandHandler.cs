using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Customer
{
    public class CreatePatientFavoriteCommandHandler : CommandHandler<CreatePatientFavoriteCommand, CreatePatientFavoriteCommandResponse>
    {
        private readonly IPatientFavoriteRepository _pfRepository;


        public CreatePatientFavoriteCommandHandler(IPatientFavoriteRepository pfRepository)
        {
            _pfRepository = pfRepository;
        }

        public override async Task<CreatePatientFavoriteCommandResponse> Executor(CreatePatientFavoriteCommand command)
        {
            var pf = new PatientFavorite(command.PatientId, command.DoctorId, command.ArticleId);


            await _pfRepository.Create(pf);

            return new CreatePatientFavoriteCommandResponse();
        }
    }
}
