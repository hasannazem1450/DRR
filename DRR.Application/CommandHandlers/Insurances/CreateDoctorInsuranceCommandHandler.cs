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
    internal class CreateDoctorInsuranceCommandHandler : CommandHandler<CreateDoctorInsuranceCommand, CreateDoctorInsuranceCommandResponse>
    {
        private readonly IDoctorInsuranceRepository _doctorinsuranceRepository;
    public CreateDoctorInsuranceCommandHandler(IDoctorInsuranceRepository doctorinsuranceRepository)
    {
            _doctorinsuranceRepository = doctorinsuranceRepository;
    }
    public override async Task<CreateDoctorInsuranceCommandResponse> Executor(CreateDoctorInsuranceCommand command)
    {
        var dins = new DoctorInsurance(command.DoctorId, command.InsuranceId , command.ContractSituation, command.InsurancePercent, command.VisitCostId , command.IsActive );

        await _doctorinsuranceRepository.Create(dins);

        return new CreateDoctorInsuranceCommandResponse();
    }
}
}
