using DRR.Framework.Contracts.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Comment
{
    public class UpdateCommentCommand : Command
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int DoctorId { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }
        public int SmeProfileId { get; set; }
    }

    public class UpdateCommentCommandResponse : CommandResponse
    {
    }
}