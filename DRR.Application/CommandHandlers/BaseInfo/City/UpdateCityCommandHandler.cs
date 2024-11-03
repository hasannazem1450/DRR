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
    public class UpdateCityCommandHandler : CommandHandler<UpdateCityCommand, UpdateCityCommandResponse>
    {
        private readonly ICityRepository _cityRepository;


        public UpdateCityCommandHandler(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public override async Task<UpdateCityCommandResponse> Executor(UpdateCityCommand command)
        {
            var city = new Domain.BaseInfo.City(command.Name, command.Code, command.ProvinceId )
            {
                ProvinceId = command.ProvinceId
            };

            await _cityRepository.Update(city);

            return new UpdateCityCommandResponse();
        }
    }
}
