using FluentValidation;
using TAYF.Application.DTOs;

namespace TAYF.Application.Validators;

/// <summary>
/// Validator for TelemetryDto
/// Enforces the validation rules from the specification:
/// - Timestamp is required.
/// - ACPowerKw, DCPowerKw, Irradiance >= 0.
/// - PlantId and InverterId must exist (will be checked in service layer)
/// </summary>
public class TelemetryDtoValidator : AbstractValidator<TelemetryDto>
{
    public TelemetryDtoValidator()
    {
        RuleFor(x => x.Timestamp)
            .NotEmpty().WithMessage("Timestamp is required.");

        RuleFor(x => x.AcPowerKw)
            .GreaterThanOrEqualTo(0).WithMessage("AC Power must be greater than or equal to 0.");

        RuleFor(x => x.DcPowerKw)
            .GreaterThanOrEqualTo(0).WithMessage("DC Power must be greater than or equal to 0.");

        RuleFor(x => x.Irradiance)
            .GreaterThanOrEqualTo(0).WithMessage("Irradiance must be greater than or equal to 0.");
    }
}