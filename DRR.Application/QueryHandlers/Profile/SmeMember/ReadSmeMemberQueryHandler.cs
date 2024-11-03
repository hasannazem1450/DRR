using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.Contracts.Commands.Profile.SmeMember;
using DRR.Application.Contracts.Queries.Profile.SmeMember;
using DRR.Application.Contracts.Queries.RoleManager;
using DRR.Application.Contracts.Services.Profile;
using DRR.Framework.Contracts.Markers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DRR.Application.QueryHandlers.Profile.SmeMember
{
    public class
        ReadSmeMemberQueryHandler : IQueryHandler<ReadSmeMemberQuery, ReadSmeMemberQueryResponse>
    {

        private readonly ISmeMemberService _smeMemberService;

        public ReadSmeMemberQueryHandler(ISmeMemberService smeMemberService)
        {
            _smeMemberService = smeMemberService;
        }

        public async Task<ReadSmeMemberQueryResponse> Execute(ReadSmeMemberQuery query,
            CancellationToken cancellationToken)
        {
            var smeMember = await _smeMemberService.Read();

            var result = new ReadSmeMemberQueryResponse();

            foreach (var item in smeMember)
            {
                var dto = new SmeMemberDto()
                {
                    Id = item.Id,
                    Position = item.Position,
                    Name = item.Name,
                    ProfilePhoto = item.ProfilePhoto,
                    SmeProfile = item.SmeProfile,
                };


                result.List.Add(dto);
            }

            return result;
        }
    }
}
