using DRR.Application.Contracts.Queries.Customer;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using DRR.Application.Contracts.Commands.Customer;

namespace DRR.Host.Controllers.Customer
{
    public class PatientFavoriteController : MainController
    {
        public PatientFavoriteController(IDistributor distributor) : base(distributor)
        {

        }
        [HttpGet("read-all-patientfavorite")]
        public async Task<IActionResult> ReadAllPatientFavorite([FromQuery] ReadAllPatientFavoriteQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllPatientFavoriteQuery, ReadPatientFavoriteQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [HttpGet("read-patientfavorite-bypatientid")]
        public async Task<IActionResult> ReadPatientFavorite([FromQuery] ReadPatientFavoriteQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPatientFavoriteQuery, ReadPatientFavoriteQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [HttpPost("create-patientfavorite")]
        public async Task<IActionResult> CreatePatientFavorite(CreatePatientFavoriteCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreatePatientFavoriteCommand, CreatePatientFavoriteCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
        [HttpDelete("delete-patientfavorite")]
        public async Task<IActionResult> DeletePatientFavorite(DeletePatientFavoriteCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeletePatientFavoriteCommand, DeletePatientFavoriteCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
