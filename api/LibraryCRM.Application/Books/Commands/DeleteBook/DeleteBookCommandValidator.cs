using FluentValidation;

namespace LibraryCRM.Application.Books.Commands.DeleteBook;

internal class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
{
    public DeleteBookCommandValidator()
    {
        RuleFor(x => x.Id)
           .NotEmpty();
    }
}