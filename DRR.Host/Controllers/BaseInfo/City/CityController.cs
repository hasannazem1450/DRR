using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Queries.BaseInfo.City;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.BaseInfo.City
{
    public class CityController : MainController
    {
        public CityController(IDistributor distributor) : base(distributor)
        {
        }

        [AllowAnonymous]
        [HttpPost("read-city")]
        public async Task<IActionResult> ReadCity([FromBody]ReadCityQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadCityQuery, ReadCityQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        //TODO:Complete The City CRUD
        [HttpPost("create-city")]
        public async Task<IActionResult> CreateCity(CreateCityCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateCityCommand, CreateCityCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-city")]
        public async Task<IActionResult> DeleteCity(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteCityCommand, DeleteCityCommandResponse>(new DeleteCityCommand(), cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-city")]
        public async Task<IActionResult> UpdateCity(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateCityCommand, UpdateCityCommandResponse>(new UpdateCityCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
