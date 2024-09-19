using MediatR;

namespace LibraryCRM.Application.Libraries.Commands;

public class CreateLibraryCommand : IRequest<Guid>
{
    public string Name { get; set; }
    public string Address { get; set; }
}