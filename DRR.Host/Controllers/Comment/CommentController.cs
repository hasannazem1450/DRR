using DRR.Application.Contracts.Commands.Comment;
using DRR.Application.Contracts.Queries.Comment;
using DRR.Controllers;
using DRR.Framework.Contracts.Makers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;

namespace DRR.Host.Controllers.Comment
{
    public class CommentController : MainController
    {
       public CommentController(IDistributor distributor) :base(distributor) 
        {
        }
        [HttpGet("read-smeprofile-Comment")]
        public async Task<IActionResult> ReadSmeProfileComment([FromQuery] ReadSmeProfileCommentQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadSmeProfileCommentQuery, ReadSmeProfileCommentQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpGet("read-doctor-Comment")]
        public async Task<IActionResult> ReadDoctorComment([FromQuery] ReadDoctorCommentQuery query, CancellationToken cancellationToken)
        {
            var result = await Distributor.Send<ReadDoctorCommentQuery, ReadSmeProfileCommentQueryResponse>(query, cancellationToken);

            return OkApiResult(result);
        }

        [HttpPost("create-Comment")]
        public async Task<IActionResult> CreateComment(CreateCommentCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<CreateCommentCommand, CreateCommentCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }


        [HttpPut("update-Comment")]
        public async Task<IActionResult> UpdateComment(UpdateCommentCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<UpdateCommentCommand, UpdateCommentCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }

        [HttpDelete("delete-Comment")]
        public async Task<IActionResult> DeleteComment(DeleteCommentCommand command, CancellationToken cancellationToken)
        {
            var result = await Distributor.Push<DeleteCommentCommand, DeleteCommentCommandResponse>(command, cancellationToken);

            return OkApiResult(result);
        }
    }
}
