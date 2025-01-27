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
    public class UpdateClinicCommandHandler : CommandHandler<UpdateClinicCommand, UpdateClinicCommandResponse>
    {
        private readonly IClinicRepository _ClinicRepository;

        public UpdateClinicCommandHandler(IClinicRepository ClinicRepository)
        {
            _ClinicRepository = ClinicRepository;
        }


        public override async Task<UpdateClinicCommandResponse> Executor(UpdateClinicCommand command)
        {
            var Clinic = await _ClinicRepository.ReadClinicById(command.Id);

            Clinic.Update(command.Name, command.Address, command.Geolon, command.Geolat, command.Phone,
                command.CityId, command.SiamCode, command.Desc, command.ClinicTypeId);

            await _ClinicRepository.Update(Clinic);

            return new UpdateClinicCommandResponse();
        }
    }
}