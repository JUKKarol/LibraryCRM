using AutoMapper;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Exceptions;
using LibraryCRM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(IMapper mapper,
    IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand>
{
    public async Task Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetBookById(request.Id);

        if (book == null)
        {
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        }
        else
        {
            await bookRepository.UpdateBook(mapper.Map<Book>(request));
        }
    }
}