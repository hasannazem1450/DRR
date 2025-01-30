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
    public class DeleteDoctorTreatmentCenterHandler : CommandHandler<DeleteDoctorTreatmentCenterCommand, DeleteDoctorTreatmentCenterCommandResponse>
    {

        private readonly IDoctorTreatmentCenterRepository _dtcRepository;


        public DeleteDoctorTreatmentCenterHandler(IDoctorTreatmentCenterRepository dtcRepository)
        {
            _dtcRepository = dtcRepository;
        }

        public override async Task<DeleteDoctorTreatmentCenterCommandResponse> Executor(DeleteDoctorTreatmentCenterCommand command)
        {
            await _dtcRepository.Delete(command.Id);

            return new DeleteDoctorTreatmentCenterCommandResponse();
        }
    }
}
