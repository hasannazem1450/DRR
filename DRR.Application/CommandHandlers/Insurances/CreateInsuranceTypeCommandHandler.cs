using DRR.Application.Contracts.Commands.Insurances;
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
    public class CreateInsuranceTypeCommandHandler : CommandHandler<CreateInsuranceTypeCommand, CreateInsuranceTypeCommandResponse>
    {
        private readonly IInsuranceTypeRepository _insuranceTypeRepository;
        public CreateInsuranceTypeCommandHandler(IInsuranceTypeRepository insuranceTypeRepository)
        {
            _insuranceTypeRepository = insuranceTypeRepository;
        }
        public override async Task<CreateInsuranceTypeCommandResponse> Executor(CreateInsuranceTypeCommand command)
        {
            var it = new InsuranceType(command.Type);

            await _insuranceTypeRepository.Create(it);

            return new CreateInsuranceTypeCommandResponse();
        }
    }
}

