using System.Data;
using FluentValidation.Models;

namespace FluentValidation.Validators;

public class OrderValidator: AbstractValidator<Order>
{
    public OrderValidator()
    {
        RuleFor(order => order.OrderId)
            .NotEmpty();
        RuleFor(order => order.CustomerName)
            .NotNull()
            .WithName("Name");
        RuleFor(order => order.CustomerName)
            .MinimumLength(5)
            .WithSeverity(Severity.Warning);
        RuleFor(order => order.CustomerEmail)
            .NotEmpty()
            .EmailAddress();
        RuleFor(order => order.CustomerLevel)
            .IsInEnum();
        When(order => order.CustomerLevel == CustomerLevel.Gold, () =>
        {
            RuleFor(order => order.Total)
                .InclusiveBetween(500, 1000);
        }).Otherwise(() =>
        {
            RuleFor(order => order.Total)
                .LessThan(1000);
        });
    }
}