using FluentValidation;
using MovieCup.Domain.Command.Championship;

namespace MovieCup.Application.Validations.Command
{
    public class AddChampionshipCommandValidator : AbstractValidator<AddChampionshipCommand>
    {
        public AddChampionshipCommandValidator()
        {
            RuleFor(e => e.Movies)
                .NotNull()
                .NotEmpty()
                .WithMessage("{PropertyName} not eligible");

            RuleForEach(e => e.Movies)
                .SetValidator(new AddMovieChampionshipCommandValidation());
        }
    }
}
