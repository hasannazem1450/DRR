﻿using DRR.Application.Contracts.Commands.Customer;
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
    public class UpdateDoctorCommandHandler : CommandHandler<UpdateDoctorCommand, UpdateDoctorCommandResponse>
    {
        private readonly IDoctorRepository _doctorRepository;


        public UpdateDoctorCommandHandler(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public override async Task<UpdateDoctorCommandResponse> Executor(UpdateDoctorCommand command)
        {
            var doctor = await _doctorRepository.ReadDoctorById(command.Id);

            doctor.Update(command.DoctorName, command.DoctorFamily, command.NationalId, command.SpecialistId, command.CodeNezam, command.DocExperiance, command.DocInstaLink, command.Mobile, command.Desc);

            await _doctorRepository.Update(doctor);

            return new UpdateDoctorCommandResponse();
        }
    }
}
