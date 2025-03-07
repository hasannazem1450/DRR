using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDb.Repository.TreatmentCentres;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class UpdateClinicCommandHandler : CommandHandler<UpdateClinicCommand, UpdateClinicCommandResponse>
    {
        private readonly IClinicRepository _ClinicRepository;
        private readonly ICityRepository _CityRepository;
        private readonly IClinicTypeRepository _ClinicTypeRepository;

        public UpdateClinicCommandHandler(IClinicRepository ClinicRepository, ICityRepository CityRepository, IClinicTypeRepository ClinicTypeRepository)
        {
            _ClinicRepository = ClinicRepository;

            _CityRepository = CityRepository;
            _ClinicTypeRepository = ClinicTypeRepository;
        }

        public override async Task<UpdateClinicCommandResponse> Executor(UpdateClinicCommand command)
        {
            var Clinic = await _ClinicRepository.ReadClinicById(command.Id);
            var city = await _CityRepository.ReadCityById(command.CityId);
            var clinicType = await _ClinicTypeRepository.ReadClinicTypeById(command.ClinicTypeId);

            Clinic.Update(command.Name, command.Address, command.Geolon, command.Geolat, command.Phone,
                command.CityId, command.SiamCode, command.Desc, command.ClinicTypeId,city ,clinicType);

            await _ClinicRepository.Update(Clinic);

            return new UpdateClinicCommandResponse();
        }
    }
}