using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Domain.Customer;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.Customer
{
    public class CreatePatientCommandHandler : CommandHandler<CreatePatientCommand, CreatePatientCommandResponse>
    {
        private readonly IPatientRepository _patientRepository;


        public CreatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public override async Task<CreatePatientCommandResponse> Executor(CreatePatientCommand command)
        {
            var patient = new Patient(command.PatientName, command.PatientFamily, command.NationalId, command.BirthNumber, command.BirthDate, command.CityId, command.Geolat,command.Geolon, command.PatientPhone, command.NecessaryPhone, command.Email, command.Gender, command.SmeProfileId);


            await _patientRepository.Create(patient);

            return new CreatePatientCommandResponse() {Patient = patient };
        }
    }
}
