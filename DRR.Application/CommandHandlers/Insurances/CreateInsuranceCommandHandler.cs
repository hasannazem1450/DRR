using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.Insurances;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.Insurance;
using DRR.Domain.Insurances;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Insurances
{
    public class CreateInsuranceCommandHandler : CommandHandler<CreateInsuranceCommand, CreateInsuranceCommandResponse>
    {
        private readonly IInsuranceRepository _insuranceRepository;
        public CreateInsuranceCommandHandler(IInsuranceRepository insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }
        public override async Task<CreateInsuranceCommandResponse> Executor(CreateInsuranceCommand command)
        {
            var ins = new Insurance(command.Name, command.InsuranceTypeId);

            await _insuranceRepository.Create(ins);

            return new CreateInsuranceCommandResponse();
        }
    }
}
