using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Application.Contracts.Repository.Profile;
using DRR.Application.Contracts.Services.Profile;

namespace DRR.Application.Services.Profile
{
    public class SmeMemberService : ISmeMemberService
    {

        private readonly ISmeMemberRepository _smeMemberRepository;

        public SmeMemberService(ISmeMemberRepository smeMemberRepository)
        {
            _smeMemberRepository = smeMemberRepository;
        }

        public async Task<SmeMemberDto> ReadById(int id)
        {
            var smeMember = await _smeMemberRepository.ReadById(id);

            var result = new SmeMemberDto()
            {
                Id = smeMember.Id,
                SmeProfile = smeMember.SmeProfile,
                Name = smeMember.Name,
                Position = smeMember.Position,
                ProfilePhoto = smeMember.ProfilePhoto
            };

            return result;
        }

        public async Task<List<SmeMemberDto>> Read()
        {
            var smeMember = await _smeMemberRepository.Read();

            var result = new List<SmeMemberDto>();

            foreach (var item in smeMember)
            {
                var dto = new SmeMemberDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Position = item.Position,
                    ProfilePhoto = item.ProfilePhoto,
                    SmeProfile = item.SmeProfile,
                };

                result.Add(dto);
            }

            return result;
        }
    }
}
