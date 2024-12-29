using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Authentication;
using DRR.Application.Contracts.Commands.BaseInfo.City;
using DRR.Application.Contracts.Queries.BaseInfo.City;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace DRR.Host.Controllers.BaseInfo.City
{
    public class CityController : MainController
    {
        public CityController(IDistributor distributor) : base(distributor)
        {
        }

        [AllowAnonymous]
        [SwaggerOperation(Summary = "خواندن شهرها بر اساس استان")]
        [HttpPost("read-city")]
        public async Task<IActionResult> ReadCity([FromBody]ReadCityQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadCityQuery, ReadCityQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        //TODO:Complete The City CRUD
        [SwaggerOperation(Summary = "ایجاد شهر جدید در استان")]
        [HttpPost("create-city")]
        public async Task<IActionResult> CreateCity(CreateCityCommand query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateCityCommand, CreateCityCommandResponse>(query, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "حذف یک شهر")]
        [HttpDelete("delete-city")]
        public async Task<IActionResult> DeleteCity(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<DeleteCityCommand, DeleteCityCommandResponse>(new DeleteCityCommand(), cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = "ویرایش نام یک شهر")]
        [HttpPut("update-city")]
        public async Task<IActionResult> UpdateCity(CancellationToken cancellationToken)
        {

            var result = await Distributor.Push<UpdateCityCommand, UpdateCityCommandResponse>(new UpdateCityCommand(), cancellationToken);

            return OkApiResult(result);
        }
    }
}
