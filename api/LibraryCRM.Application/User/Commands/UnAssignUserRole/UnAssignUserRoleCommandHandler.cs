using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.User.Commands.UnAssignUserRole;

public class UnAssignUserRoleCommandHandler(UserManager<LibraryUser> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<UnAssignUserRoleCommand>
{
    public async Task Handle(UnAssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email)
            ?? throw new NotFoundException(nameof(LibraryUser), request.Email);

        var role = await roleManager.FindByNameAsync(request.Role)
            ?? throw new NotFoundException(nameof(IdentityRole), request.Role);

        await userManager.RemoveFromRoleAsync(user, role.Name);
    }
}