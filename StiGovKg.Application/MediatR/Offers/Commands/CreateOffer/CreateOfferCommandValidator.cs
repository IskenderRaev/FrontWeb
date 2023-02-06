using FluentValidation;

namespace StiGovKg.Application.MediatR.Offers.Commands.CreateOffer
{
    public class CreateOfferCommandValidator : AbstractValidator<CreateOfferCommands>
    {
        public CreateOfferCommandValidator()
        {
            RuleFor(v => v.Text)
               .NotEmpty().WithMessage("Поле является обязательным к заполнению")
               .MaximumLength(500).WithMessage("Значение не должно быть больше 1000 символов");
        }
    }
}
