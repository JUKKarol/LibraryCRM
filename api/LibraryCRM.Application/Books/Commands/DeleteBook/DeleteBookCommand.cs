using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCRM.Application.Books.Commands.DeleteBook;

public class DeleteBookCommand(Guid id) : IRequest
{
    public Guid Id { get; set; } = id;
}