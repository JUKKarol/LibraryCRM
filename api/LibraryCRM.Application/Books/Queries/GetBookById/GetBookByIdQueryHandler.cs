using AutoMapper;
using LibraryCRM.Application.Books.DTOs;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Exceptions;
using LibraryCRM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Queries.GetBookById;

internal class GetBookByIdQueryHandler(IBookRepository bookRepository,
    IMapper mapper) : IRequestHandler<GetBookByIdQuery, BookDTO>
{
    public async Task<BookDTO> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetBookById(request.Id)
            ?? throw new NotFoundException(nameof(Book), request.Id.ToString());

        var bookDTO = mapper.Map<BookDTO>(book);

        return bookDTO;
    }
}