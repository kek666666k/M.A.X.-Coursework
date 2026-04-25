using FluentValidation;
using TrainingApp.Models;

namespace TrainingApp.Validators;

public class TrainingValidator : AbstractValidator<Training>
{
    public TrainingValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Название тренировки обязательно")
            .MaximumLength(100).WithMessage("Максимум 100 символов");

        RuleFor(x => x.DurationMinutes)
            .GreaterThan(0).WithMessage("Длительность должна быть больше 0");

        RuleFor(x => x.Date)
            .NotEmpty().WithMessage("Дата обязательна");
    }
}