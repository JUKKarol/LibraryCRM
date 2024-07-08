using AutoMapper;
using LibraryCRM.Domain.Entities;
using LibraryCRM.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Commands.UpdateBook;

public class UpdateBookCommandHandler(IMapper mapper,
    IBookRepository bookRepository) : IRequestHandler<UpdateBookCommand, bool>
{
    public async Task<bool> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var book = await bookRepository.GetBookById(request.Id);

        if (book == null)
        {
            return false;
        }
        else
        {
            await bookRepository.UpdateBook(mapper.Map<Book>(request));
            return true;
        }
    }
}