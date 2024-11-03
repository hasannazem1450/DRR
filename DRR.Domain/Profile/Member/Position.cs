using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRR.Domain.Profile.Member
{
    public class Position
    {
        public Position(string name)
        {
            //TODO:Create Guard
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<SmeMember> SmeMembers { get; set; }
    }
}
