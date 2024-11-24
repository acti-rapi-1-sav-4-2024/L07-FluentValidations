// See https://aka.ms/new-console-template for more information

using FluentValidation.Models;
using FluentValidation.Results;
using FluentValidation.Validators;

Order order = new()
{
    OrderId = 1,
    CustomerName = "Kevin",
    CustomerEmail = "kevinah95@gmail.com",
    CustomerLevel = CustomerLevel.Gold,
    Total = 700,
};

OrderValidator validator = new();

ValidationResult result = validator.Validate(order);

Console.WriteLine($"CustomerName: {order.CustomerName}");
Console.WriteLine($"CustomerEmail: {order.CustomerEmail}");

Console.WriteLine($"IsValid: {result.IsValid}");
foreach (var resultError in result.Errors)
{
    Console.WriteLine($"{resultError.Severity}: {resultError.ErrorMessage}");
}