using DRR.Application.Contracts.Commands.Customer;
using DRR.Application.Contracts.Queries.Customer;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace DRR.Host.Controllers.Customer
{

    public class PatientController  : MainController
    {
        public PatientController(IDistributor distributor) : base(distributor)
        {

        }
        [HttpGet("read-all-patients")]
        public async Task<IActionResult> ReadAllPatients([FromQuery] ReadAllPatientQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadAllPatientQuery, ReadPatientsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }
        [HttpGet("read-smeprofile-patients")]
        public async Task<IActionResult> ReadSmeProfilePatients([FromQuery] ReadPatientBySmeProfileIdQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadPatientBySmeProfileIdQuery, ReadPatientsQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        [HttpPost("create-patient")]
        public async Task<IActionResult> CreatePatient(CreatePatientCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreatePatientCommand, CreatePatientCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPut("update-patient")]
        public async Task<IActionResult> UpdatePatient(UpdatePatientCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdatePatientCommand, UpdatePatientCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-patient")]
        public async Task<IActionResult> DeletePatient(DeletePatientCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeletePatientCommand, DeletePatientCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-insurances-patient")]
        public async Task<IActionResult> ReadInsurancesPatients([FromQuery] ReadInsurancesPatientQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadInsurancesPatientQuery, ReadInsurancesPatientQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }



        [HttpGet("read-nextreserves-Patient")]
        public async Task<IActionResult> ReadReservesPatient([FromQuery] ReadNextReservesPatientQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadNextReservesPatientQuery, ReadNextReservesPatientQueryResponse>(query, cancellationToken);
            return OkApiResult(result);
        }

        //[HttpGet("read-all-reserves-Patient")]
        //public async Task<IActionResult> ReadAllReservesPatient([FromQuery] ReadReservesPatientQuery query, CancellationToken cancellationToken)
        //{
        //    var result = await Distributor.Send<ReadReservesPatientQuery, ReadReservesPatientQueryResponse>(query, cancellationToken);
        //    return OkApiResult(result);
        //}
        
        //[HttpGet("search-Patients")]
        //public async Task<IActionResult> ReadSearchPatients([FromQuery] SearchPatientsQuery query, CancellationToken cancellationToken)
        //{
        //    var result = await Distributor.Send<SearchPatientsQuery, SearchPatientsQueryResponse>(query, cancellationToken);
        //    return OkApiResult(result);
        //}
    }
}
