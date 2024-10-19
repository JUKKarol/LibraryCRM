using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.User.Commands;

public class UpdateUserDetailsCommandHandler(IUserContext userContext,
    IUserStore<LibraryUser> userStore) : IRequestHandler<UpdateUserDetailsCommand>
{
    public async Task Handle(UpdateUserDetailsCommand request, CancellationToken cancellationToken)
    {
        var user = userContext.GetCurrentUser();

        var dbUser = await userStore.FindByIdAsync(user.Id, cancellationToken);

        if (dbUser == null)
        {
            throw new NotFoundException(nameof(LibraryUser), user!.Id);
        }

        dbUser.DateOfBirth = request.DateOfBirth;

        await userStore.UpdateAsync(dbUser, cancellationToken);
    }
}