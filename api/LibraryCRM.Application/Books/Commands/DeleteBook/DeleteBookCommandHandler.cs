using AutoMapper;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommandHandler(IMapper mapper,
    IBookRepository bookRepository) : IRequestHandler<DeleteBookCommand, Guid>
{
    public async Task<Guid> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetBookById(request.Id);

        if (book == null)
        {
            return Guid.Empty;
        }
        else
        {
            await bookRepository.DeleteBook(request.Id);
            return book.Id;
        }
    }
}