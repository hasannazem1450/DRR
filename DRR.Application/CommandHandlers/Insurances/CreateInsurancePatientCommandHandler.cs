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
    public class CreatePatientInsuranceCommandHandler : CommandHandler<CreatePatientInsuranceCommnad, CreatePatientInsuranceCommnadResponse>
    {
        private readonly IPatientInsuranceRepository _patientinsuranceRepository;
        public CreatePatientInsuranceCommandHandler(IPatientInsuranceRepository patientinsuranceRepository)
        {
            _patientinsuranceRepository = patientinsuranceRepository;
        }
        public override async Task<CreatePatientInsuranceCommnadResponse> Executor(CreatePatientInsuranceCommnad command)
        {
            var pins = new PatientInsurance(command.PatientId, command.InsuranceId, command.Expiredate);

            await _patientinsuranceRepository.Create(pins);

            return new CreatePatientInsuranceCommnadResponse();
        }
    }
}
