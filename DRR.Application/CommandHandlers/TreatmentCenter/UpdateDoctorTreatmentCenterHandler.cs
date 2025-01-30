using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class UpdateDoctorTreatmentCenterHandler : CommandHandler<UpdateDoctorTreatmentCenterCommand, UpdateDoctorTreatmentCenterCommandResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _DoctorTreatmentCenterRepository;

        public UpdateDoctorTreatmentCenterHandler(IDoctorTreatmentCenterRepository DoctorTreatmentCenterRepository)
        {
            _DoctorTreatmentCenterRepository = DoctorTreatmentCenterRepository;
        }


        public override async Task<UpdateDoctorTreatmentCenterCommandResponse> Executor(UpdateDoctorTreatmentCenterCommand command)
        {
            var DoctorTreatmentCenter = await _DoctorTreatmentCenterRepository.ReadDoctorTreatmentCenterById(command.Id);

            DoctorTreatmentCenter.Update(command.DoctorId, command.ClinicId, command.OfficeId, command.Desc);

            await _DoctorTreatmentCenterRepository.Update(DoctorTreatmentCenter);

            return new UpdateDoctorTreatmentCenterCommandResponse();
        }
    }
}