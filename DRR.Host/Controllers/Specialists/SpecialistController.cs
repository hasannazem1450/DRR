using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using System.Threading.Tasks;
using System.Threading;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using DRR.Application.Contracts.Commands.Specialists;
using Swashbuckle.AspNetCore.Annotations;
using DRR.Application.Contracts.Queries.Specialists;
using Microsoft.AspNetCore.Authorization;

namespace DRR.Host.Controllers.Specialists
{
    public class SpecialistController : MainController
    {
        public SpecialistController(IDistributor distributor) : base(distributor)
        {

        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن یک تخصص ")]
        [HttpGet("read-specialist")]
        public async Task<IActionResult> ReadSpecilist([FromQuery] ReadSpecialistQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSpecialistQuery, ReadSpecialistQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-specialists")]
        public async Task<IActionResult> ReadSpecilists([FromQuery] ReadSpecialistsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSpecialistsQuery, ReadSpecialistsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 6000000, Location = ResponseCacheLocation.Any)]
        [SwaggerOperation(Summary = " خواندن همه ")]
        [HttpGet("read-specialists-firstpage")]
        public async Task<IActionResult> ReadSpecilistsFirstPage([FromQuery] ReadSpecialistsFirstPageQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSpecialistsFirstPageQuery, ReadSpecialistsFirstPageQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک تخصص ")]
        [HttpPost("create-specialist")]
        public async Task<IActionResult> CreateSpecilist(CreateSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateSpecialistCommand, CreateSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result); 
        }
        [SwaggerOperation(Summary = " ویرایش یک تخصص ")]
        [HttpPut("update-specialist")]
        public async Task<IActionResult> UpdateSpecialist(UpdateSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateSpecialistCommand, UpdateSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک تخصص ")]
        [HttpDelete("delete-specialist")]
        public async Task<IActionResult> DeleteSpecialis(DeleteSpecialistCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteSpecialistCommand, DeleteSpecialistCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن دسته بندی تخصص ")]
        [HttpGet("read-category")]
        public async Task<IActionResult> ReadCategory([FromQuery] ReadCategoryQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadCategoryQuery, ReadCategoryQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [AllowAnonymous]
        [SwaggerOperation(Summary = " خواندن همه دسته بندی ها ")]
        [HttpGet("read-categorys")]
        public async Task<IActionResult> ReadCategorys([FromQuery] ReadCategorysQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadCategorysQuery, ReadCategorysQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ایجاد یک دسته بندی تخصص ")]
        [HttpPost("create-category")]
        public async Task<IActionResult> CreateCategory(CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateCategoryCommand, CreateCategoryCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " ویرایش یک دسته بندی تخصص ")]
        [HttpPut("update-category")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateCategoryCommand, UpdateCategoryCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک دسته بندی تخصص ")]
        [HttpDelete("delete-category")]
        public async Task<IActionResult> DeleteCategory(DeleteCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteCategoryCommand, DeleteCategoryCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " افزودن یک تخصص به یک دسته بندی ")]
        [HttpPost("add-specialist-to-category")]
        public async Task<IActionResult> CreateSpecialistCategory(AddSpecialistToCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<AddSpecialistToCategoryCommand, AddSpecialistToCategoryCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [SwaggerOperation(Summary = " حذف یک تخصص از یک دسته بندی ")]
        [HttpPost("remove-specialist-from-category")]
        public async Task<IActionResult> RemoveSpecialistCategory(RemoveSpecialistFromCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<RemoveSpecialistFromCategoryCommand, RemoveSpecialistFromCategoryCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
