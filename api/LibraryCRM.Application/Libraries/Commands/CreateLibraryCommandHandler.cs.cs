using LibraryCRM.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Libraries.Commands;

public class CreateLibraryCommandHandler(ILibraryRepository libraryRepository) : IRequestHandler<CreateLibraryCommand, Guid>
{
    public async Task<Guid> Handle(CreateLibraryCommand request, CancellationToken cancellationToken)
    {
        var library = new Library
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
        };

        await libraryRepository.CreateLibrary(library);
        return library.Id;
    }
}