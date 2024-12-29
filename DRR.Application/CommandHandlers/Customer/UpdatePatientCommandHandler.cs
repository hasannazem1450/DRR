using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Customer
{
    public class UpdatePatientCommandHandler : CommandHandler<UpdatePatientCommand, UpdatePatientCommandResponse>
    {
        private readonly IPatientRepository _patientRepository;


        public UpdatePatientCommandHandler(IPatientRepository patientRepository)
        {
            _patientRepository = patientRepository;
        }

        public override async Task<UpdatePatientCommandResponse> Executor(UpdatePatientCommand command)
        {
            var patient = await _patientRepository.ReadPatientById(command.Id);

            patient.Update(command.PatientName, command.PatientFamily, command.NationalId, command.BirthNumber, command.BirthDate, command.CityId, command.Geoloc, command.PatientPhone, command.NecessaryPhone, command.Email, command.Gender, command.SmeProfileId);

            await _patientRepository.Update(patient);

            return new UpdatePatientCommandResponse();
        }
    }
}
