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
    public class UpdateOfficeCommandHandler : CommandHandler<UpdateOfficeCommand, UpdateOfficeCommandResponse>
    {
        private readonly IOfficeRepository _OfficeRepository;

        public UpdateOfficeCommandHandler(IOfficeRepository OfficeRepository)
        {
            _OfficeRepository = OfficeRepository;
        }


        public override async Task<UpdateOfficeCommandResponse> Executor(UpdateOfficeCommand command)
        {
            var Office = await _OfficeRepository.ReadOfficeById(command.Id);

            Office.Update(command.Name, command.Address, command.Geolon, command.Geolat, command.Phone,
                command.CityId, command.PostalCode, command.OfficeTypeId);

            await _OfficeRepository.Update(Office);

            return new UpdateOfficeCommandResponse();
        }
    }
}