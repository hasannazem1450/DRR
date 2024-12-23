using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace DRR.Host.Controllers.Customer
{
    public class DoctorController : MainController
    {
        public DoctorController(IDistributor distributor): base(distributor)
        {

        }
        [HttpGet("read-smeprofile-doctors")]
        public async Task<IActionResult> ReadSmeProfileDoctors([FromQuery]ReadDoctorQuery query , CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorQuery, ReadDoctorQueryResponse> (query , cancellationToken);
            return OkApiResult(result);
        }

        [HttpPost("create-doctor")]
        public async Task<IActionResult> CreateDoctor(CreateDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateDoctorCommand, CreateDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-Doctor")]
        public async Task<IActionResult> UpdateDoctor(UpdateDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateDoctorCommand, UpdateDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-Doctor")]
        public async Task<IActionResult> DeleteDoctor(DeleteDoctorCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteDoctorCommand, DeleteDoctorCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-insurances-doctor")]
        public async Task<IActionResult> ReadInsurancesDoctors([FromQuery] ReadInsurancesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadInsurancesDoctorQuery, ReadInsurancesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        [HttpGet("read-visittype-doctor")]
        public async Task<IActionResult> ReadVisitTypeDoctors([FromQuery] ReadVisitTypeDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadVisitTypeDoctorQuery, ReadVisitTypeDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        //[HttpGet("read-nearest-doctor")]
        //public async Task<IActionResult> ReadNearestDoctors([FromQuery] ReadNearestDoctorQuery query, CancellationToken cancellationToken)
        //{
        //    var result = await Distributor.Send<ReadNearestDoctorQuery, ReadNearestDoctorQueryResponse>(query, cancellationToken);
        //    return OkApiResult(result);
        //}

        [HttpGet("read-nextreserves-doctor")]
        public async Task<IActionResult> ReadReservesDoctor([FromQuery] ReadNextReservesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadNextReservesDoctorQuery, ReadNextReservesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        [HttpGet("read-all-reserves-doctor")]
        public async Task<IActionResult> ReadAllReservesDoctor([FromQuery] ReadReservesDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadReservesDoctorQuery, ReadReservesDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [HttpGet("read-patients-doctor")]
        public async Task<IActionResult> ReadPatientsDoctor([FromQuery] ReadPatientsDoctorQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPatientsDoctorQuery, ReadPatientsDoctorQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        [HttpGet("search-doctors")]
        public async Task<IActionResult> ReadSearchDoctors([FromQuery] SearchDoctorsQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<SearchDoctorsQuery, SearchDoctorsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
    }
}
