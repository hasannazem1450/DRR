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
    public class CreateDoctorTreatmentCenterCommandHandler : CommandHandler<CreateDoctorTreatmentCenterCommand, CreateDoctorTreatmentCenterCommandResponse>
    {
        private readonly IDoctorTreatmentCenterRepository _dtcRepository;


        public CreateDoctorTreatmentCenterCommandHandler(IDoctorTreatmentCenterRepository dtcRepository)
        {
            _dtcRepository = dtcRepository;
        }

        public override async Task<CreateDoctorTreatmentCenterCommandResponse> Executor(CreateDoctorTreatmentCenterCommand command)
        {
            var readdoctorforcheck = _dtcRepository.ReadDoctorTreatmentCenterByDoctorId(command.DoctorId);
            if (readdoctorforcheck.Result.Where(x => (command.ClinicId != null && x.ClinicId == command.ClinicId) || ( command.OfficeId != null && x.OfficeId == command.OfficeId)).Count() > 0)
                throw new Exception("قبلا تخصیص داده شده است");

            var ev = new DoctorTreatmentCenter(command.DoctorId, command.ClinicId, command.OfficeId, command.Desc);

            await _dtcRepository.Create(ev);

            return new CreateDoctorTreatmentCenterCommandResponse();
        }
    }
}