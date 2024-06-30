using LibraryCRM.Application.Books.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Queries.GetBookById;

public class GetBookByIdQuery(Guid id) : IRequest<BookDTO>
{
    public Guid Id { get; } = id;
}