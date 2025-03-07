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
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class UpdateOfficeCommandHandler : CommandHandler<UpdateOfficeCommand, UpdateOfficeCommandResponse>
    {
        private readonly IOfficeRepository _OfficeRepository;
        private readonly ICityRepository _CityRepository;
        private readonly IOfficeTypeRepository _OfficeTypeRepository;

        public UpdateOfficeCommandHandler(IOfficeRepository OfficeRepository, ICityRepository CityRepository, IOfficeTypeRepository OfficeTypeRepository)
        {
            _OfficeRepository = OfficeRepository;
            _CityRepository = CityRepository;
            _OfficeTypeRepository = OfficeTypeRepository;
        }


        public override async Task<UpdateOfficeCommandResponse> Executor(UpdateOfficeCommand command)
        {
            var Office = await _OfficeRepository.ReadOfficeById(command.Id);
            var city = await _CityRepository.ReadCityById(command.CityId);
            var officeType = await _OfficeTypeRepository.ReadOfficeTypeById(command.OfficeTypeId);

            Office.Update(command.Name, command.Address, command.Geolon, command.Geolat, command.Phone,
                command.CityId, command.PostalCode, command.OfficeTypeId,city, officeType);

            await _OfficeRepository.Update(Office);

            return new UpdateOfficeCommandResponse();
        }
    }
}