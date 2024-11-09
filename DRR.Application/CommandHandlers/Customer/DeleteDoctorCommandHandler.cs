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
    public class DeleteDoctorCommandHandler : CommandHandler<DeleteDoctorCommand, DeleteDoctorCommandResponse>
    {
        private readonly IDoctorRepository _doctorRepository;


        public DeleteDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public override async Task<DeleteDoctorCommandResponse> Executor(DeleteDoctorCommand command)
        {
            await _doctorRepository.Delete(command.Id);

            return new DeleteDoctorCommandResponse();
        }
    }
}
