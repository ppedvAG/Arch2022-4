using FluentValidation;
using ppedv.Hotelity.Model.Contracts;
using ppedv.Hotelity.Model.DomainModel;

namespace ppedv.Hotelity.Validation
{
    public class ValidationService : IValidationService
    {
        public IEnumerable<ValidationResult> Validate(Gast gast)
        {
            var vali = new GastValidator();
            var result = vali.Validate(gast);

            foreach (var r in result.Errors)
            {
                yield return new ValidationResult() { ErrorText = r.ErrorMessage, Status = GetStatus(r.Severity) };
            }
        }

        private ValidationResultStatus GetStatus(Severity s)
        {
            return s switch
            {
                Severity.Error => ValidationResultStatus.Error,
                Severity.Warning => ValidationResultStatus.Warning,
                Severity.Info => ValidationResultStatus.Info,
                _ => throw new NotImplementedException(),
            };
        }
        public IEnumerable<ValidationResult> Validate(Buchung buchung)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationResult> Validate(Zimmer zimmer)
        {
            throw new NotImplementedException();
        }
    }

    public class GastValidator : AbstractValidator<Gast>
    {
        public GastValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(883).WithSeverity(Severity.Warning);
        }


    }
}