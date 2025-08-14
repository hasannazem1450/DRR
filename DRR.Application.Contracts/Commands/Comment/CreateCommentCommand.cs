using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Application.Contracts.Commands.Comment
{
    public class CreateCommentCommand : Command
    {
        public string Desc { get; set; }
        public int DoctorId { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }
        public bool IsSuggest { get; set; }
        public int LikeNumber { get; set; }
        public int SmeProfileId { get; set; }
    }
    public class CreateCommentCommandResponse : CommandResponse
    {
    }
}
