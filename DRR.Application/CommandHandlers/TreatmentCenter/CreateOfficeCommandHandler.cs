using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Event;
using DRR.Application.Contracts.Commands.TreatmentCenters;
using DRR.Application.Contracts.Repository.Event;
using DRR.Application.Contracts.Repository.TreatmentCenters;
using DRR.CommandDb.Repository.TreatmentCenters;
using DRR.Domain.TreatmentCenters;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.CommandHandlers.TreatmentCenter
{
    public class CreateOfficeCommandHandler : CommandHandler<CreateOfficeCommand, CreateOfficeCommandResponse>
    {
        private readonly IOfficeRepository _officeRepository;


        public CreateOfficeCommandHandler(IOfficeRepository officeRepository)
        {
            _officeRepository = officeRepository;
        }

        public override async Task<CreateOfficeCommandResponse> Executor(CreateOfficeCommand command)
        {
            if (!await _officeRepository.CheckNameForReapeat(command.Name))
            {
                throw new Exception("نام مطب یا مرکز درمانی تکراری است");
            }
            var ev = new Office(command.Name, command.Address, command.Geolon, command.Geolat, command.Phone,
                command.CityId, command.PostalCode, command.OfficeTypeId);

            await _officeRepository.Create(ev);

            return new CreateOfficeCommandResponse();
        }
    }
}