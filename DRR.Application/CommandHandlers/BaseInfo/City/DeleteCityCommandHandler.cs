using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Repository.BaseInfo;
using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.CommandHandlers.BaseInfo.City
{
    public class DeleteCityCommandHandler : CommandHandler<DeleteCityCommand, DeleteCityCommandResponse>
    {
        private readonly ICityRepository _cityRepository;


        public DeleteCityCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public override async Task<DeleteCityCommandResponse> Executor(DeleteCityCommand command)
        {
            await _cityRepository.Delete(command.Id);

            return new DeleteCityCommandResponse();
        }
    }
}
