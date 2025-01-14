using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Repository.Customer;
using DRR.Framework.Contracts.Abstracts;
using DRR.Domain.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.Customer
{
    public class CreateDoctorCommandHandler : CommandHandler<CreateDoctorCommand, CreateDoctorCommandResponse>
    {
        private readonly IDoctorRepository _doctorRepository;


        public CreateDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public override async Task<CreateDoctorCommandResponse> Executor(CreateDoctorCommand command)
        {
            var Doctor = new Doctor(command.DoctorName, command.DoctorFamily, command.NationalId, command.CodeNezam, command.SpecialistId,  command.DocExperiance, command.DocInstaLink, command.Mobile, command.Desc, command.SmeProfileId)
            {
                SmeProfileId = command.SmeProfileId
            };

            await _doctorRepository.Create(Doctor);

            return new CreateDoctorCommandResponse();
        }
    }
}
