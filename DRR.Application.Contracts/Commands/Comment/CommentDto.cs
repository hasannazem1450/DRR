using DRR.Domain.Customer;
using DRR.Domain.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }
        public string CommentDate { get; set; }
        public bool IsAccept { get; set; }
        public int SmeProfileId { get; set; }
        public bool IsSuggest { get; set; }
        public int LikeNumber { get; set; }
        public virtual SmeProfile SmeProfile { get; set; }

    }
}
