using FluentValidation;
using MovieCup.Domain.Command.Championship;

namespace MovieCup.Application.Validations.Command
{
    public class AddMovieChampionshipCommandValidation : AbstractValidator<AddMovieChampionshipCommand>
    {
        public AddMovieChampionshipCommandValidation()
        {
            RuleFor(e => e.Id)
                .NotNull()
                .NotEmpty()
                .WithMessage("Invalid {PropertyName}");

            RuleFor(e => e.Score)
                .LessThan(10)
                .GreaterThan(-1)
                .WithMessage("Invalid {PropertyName}");

            RuleFor(e => e.Title)
                .NotEmpty()
                .WithMessage("Invalid {PropertyName}");

            RuleFor(e => e.Year)
                .GreaterThanOrEqualTo(1800)
                .WithMessage("Invalid {PropertyName}");
        }
    }
}
