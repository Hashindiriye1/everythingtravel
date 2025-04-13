using FluentValidation;
using ApiUppgift.DTOs;

namespace ApiUppgift.Validators;

public class CreateFlightDtoValidator : AbstractValidator<CreateFlightDto>
{
    public CreateFlightDtoValidator()
    {
        RuleFor(x => x.FlightNumber)
            .NotEmpty()
            .MaximumLength(10);

        RuleFor(x => x.Airline)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DepartureCity)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.ArrivalCity)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.DepartureTime)
            .NotEmpty()
            .Must(dt => dt > DateTime.UtcNow)
            .WithMessage("Departure time must be in the future");

        RuleFor(x => x.ArrivalTime)
            .NotEmpty()
            .Must((flight, arrivalTime) => arrivalTime > flight.DepartureTime)
            .WithMessage("Arrival time must be after departure time");

        RuleFor(x => x.Price)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.AvailableSeats)
            .NotEmpty()
            .GreaterThan(0);

        RuleFor(x => x.Gate)
            .MaximumLength(10);

        RuleFor(x => x.Terminal)
            .MaximumLength(10);
    }
}

public class UpdateFlightDtoValidator : AbstractValidator<UpdateFlightDto>
{
    public UpdateFlightDtoValidator()
    {
        RuleFor(x => x.FlightNumber)
            .MaximumLength(10)
            .When(x => x.FlightNumber != null);

        RuleFor(x => x.Airline)
            .MaximumLength(100)
            .When(x => x.Airline != null);

        RuleFor(x => x.DepartureCity)
            .MaximumLength(100)
            .When(x => x.DepartureCity != null);

        RuleFor(x => x.ArrivalCity)
            .MaximumLength(100)
            .When(x => x.ArrivalCity != null);

        RuleFor(x => x.DepartureTime)
            .Must(dt => dt > DateTime.UtcNow)
            .WithMessage("Departure time must be in the future")
            .When(x => x.DepartureTime.HasValue);

        RuleFor(x => x.ArrivalTime)
            .Must((flight, arrivalTime) => 
                !flight.DepartureTime.HasValue || 
                (arrivalTime.HasValue && arrivalTime.Value > flight.DepartureTime.Value))
            .WithMessage("Arrival time must be after departure time")
            .When(x => x.ArrivalTime.HasValue);

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .When(x => x.Price.HasValue);

        RuleFor(x => x.AvailableSeats)
            .GreaterThan(0)
            .When(x => x.AvailableSeats.HasValue);

        RuleFor(x => x.Gate)
            .MaximumLength(10)
            .When(x => x.Gate != null);

        RuleFor(x => x.Terminal)
            .MaximumLength(10)
            .When(x => x.Terminal != null);
    }
} 