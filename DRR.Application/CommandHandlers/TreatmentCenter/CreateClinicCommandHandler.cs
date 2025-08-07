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
    public class CreateClinicCommandHandler : CommandHandler<CreateClinicCommand, CreateClinicCommandResponse>
    {
        private readonly IClinicRepository _clinicRepository;


        public CreateClinicCommandHandler(IClinicRepository clinicRepository)
        {
            _clinicRepository = clinicRepository;
        }

        public override async Task<CreateClinicCommandResponse> Executor(CreateClinicCommand command)
        {
            if (!await _clinicRepository.CheckNameForReapeat(command.Name))
            {
                throw new Exception("نام مطب یا مرکز درمانی تکراری است");
            }
           
            var ev = new Clinic(command.Name, command.Address, command.Geolon, command.Geolat, command.Phone,
                command.CityId, command.SiamCode, command.Desc, command.ClinicTypeId);

            await _clinicRepository.Create(ev);

            return new CreateClinicCommandResponse();
        }
    }
}