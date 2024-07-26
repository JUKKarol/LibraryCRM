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

namespace LibraryCRM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(IMapper mapper,
    IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand>
{
    public async Task Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetBookById(request.Id);

        if (book == null)
        {
            throw new NotFoundException(nameof(Book), request.Id.ToString());
        }
        else
        {
            await bookRepository.DeleteBook(book);
        }
    }
}