using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Domain.Profile.Member;
using DRR.Framework.Contracts.Abstracts;

namespace DRR.Domain.Profile
{
    public class SmeMember : Entity<int>
    {
        public SmeMember(string name, string profilePhoto)
        {
            //TODO:Create Guard
            Name = name;
            ProfilePhoto = profilePhoto;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ProfilePhoto { get; set; }

        public int SmeProfileId{ get; set; }
        public SmeProfile SmeProfile { get; set; }

        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
