using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DRR.Application.CommandHandlers.Exceptions;
using DRR.Application.Contracts.Commands.UserManager;
using DRR.Application.Contracts.Queries.UserManager;
using DRR.Domain.Identity.Exceptions;
using DRR.Framework.Contracts.Markers;
using DRR.Utilities.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DRR.Application.QueryHandlers.UserManager
{
    public class ReadUserRoleQueryHandler : IQueryHandler<ReadUserRoleQuery, ReadUserRoleQueryResponse>
    {
        private readonly UserManager<DRR.Domain.Identity.ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public ReadUserRoleQueryHandler(UserManager<DRR.Domain.Identity.ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<ReadUserRoleQueryResponse> Execute(ReadUserRoleQuery query, CancellationToken cancellationToken)
        {
            if (query.ObjectIsAnyNullOrEmpty())
            {
                var role = await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);

                var result = new ReadUserRoleQueryResponse();

                foreach (var roleItem in role)
                {
                    var users = await _userManager.GetUsersInRoleAsync(roleItem.Name);
                    if (users == null)
                        continue;

                    foreach (var usersItem in users)
                    {
                        result.List.Add(new AspNetUserRolesDto
                        {
                            RoleName = roleItem.Name,
                            UserName = usersItem.UserName,
                        });
                    }
                }
                return result;
            }
            else if (!query.RoleName.IsNullOrEmptyExtension())
            {
                var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Name == query.RoleName, cancellationToken: cancellationToken);
                if (role == null)
                    throw new IdentityException("رول مورد نظر وجود ندارد !","Role is not exist");

                var result = new ReadUserRoleQueryResponse();
                var users = await _userManager.GetUsersInRoleAsync(role.Name);

                foreach (var usersItem in users)
                {
                    if (users == null)
                        continue;

                    result.List.Add(new AspNetUserRolesDto
                    {
                        RoleName = role.Name,
                        UserName = usersItem.UserName,
                    });

                }
                return result;
            }
            else
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == query.UserName, cancellationToken: cancellationToken);

                if (user == null)
                    throw new IdentityException("کاربر مورد نظر وجود ندارد !","User is not exist");

                var result = new ReadUserRoleQueryResponse();
                var roles = await _roleManager.Roles.ToListAsync(cancellationToken: cancellationToken);

                foreach (var roleItem in roles)
                {
                    var users = await _userManager.GetUsersInRoleAsync(roleItem.Name);
                    if (users == null)
                        continue;

                    foreach (var usersItem in users)
                    {
                        if (usersItem.UserName == query.UserName)
                        {
                            result.List.Add(new AspNetUserRolesDto
                            {
                                RoleName = roleItem.Name,
                                UserName = usersItem.UserName,
                            });
                        }
                    }
                }
                return result;

            }
        }
    }
}
