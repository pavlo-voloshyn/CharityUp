using FluentValidation;

namespace PaymentService.Application.Features.Payments.Commands.Pay;

internal class PayCommandValidator : AbstractValidator<PayCommand>
{
    public PayCommandValidator()
    {
        RuleFor(p => p.FoundationId)
            .NotEmpty().WithMessage("FoundationId is required.");

        RuleFor(p => p.UserId)
            .NotEmpty().WithMessage("UserId is required.");

        RuleFor(p => p.Amount)
            .NotEmpty().WithMessage("Amount is required.")
            .GreaterThan(0).WithMessage("Amount should be greater than 0");
    }
}
