using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Application.Contracts.Commands.Profile.SmeMember
{
    public class SmeMemberDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }
        
        public Domain.Profile.SmeProfile SmeProfile { get; set; }
        
        public Domain.Profile.Member.Position Position { get; set; }
    }
}
