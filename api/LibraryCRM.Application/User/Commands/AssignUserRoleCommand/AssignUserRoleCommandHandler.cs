using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.User.Commands.AssignUserRoleCommand;

public class AssignUserRoleCommandHandler(UserManager<LibraryUser> userManager,
    RoleManager<IdentityRole> roleManager) : IRequestHandler<AssignUserRoleCommand>
{
    public async Task Handle(AssignUserRoleCommand request, CancellationToken cancellationToken)
    {
        var user = await userManager.FindByEmailAsync(request.Email)
            ?? throw new NotFoundException(nameof(LibraryUser), request.Email);

        var role = await roleManager.FindByNameAsync(request.Role)
            ?? throw new NotFoundException(nameof(IdentityRole), request.Role);

        await userManager.AddToRoleAsync(user, role.Name);
    }
}