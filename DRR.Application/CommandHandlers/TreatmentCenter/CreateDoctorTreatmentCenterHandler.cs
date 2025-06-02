using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class CreateDoctorTreatmentCenterHandler : CommandHandler<CreateDoctorTreatmentCenterCommand, CreateDoctorTreatmentCenterCommandResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;


        public CreateDoctorTreatmentCenterHandler(IDoctorTreatmentCenterRepository dtcRepository)
        {
            _dtcRepository = dtcRepository;
        }

        public override async Task<CreateDoctorTreatmentCenterCommandResponse> Executor(CreateDoctorTreatmentCenterCommand command)
        {
            var ev = new DoctorTreatmentCenter(command.DoctorId, command.ClinicId, command.OfficeId, command.Desc,command.CityId);

            await _dtcRepository.Create(ev);

            return new CreateDoctorTreatmentCenterCommandResponse();
        }
    }
}