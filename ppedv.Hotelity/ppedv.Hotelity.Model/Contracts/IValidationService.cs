using ppedv.Hotelity.Model.DomainModel;
using System.ComponentModel;

namespace ppedv.Hotelity.Model.Contracts
{
    public interface IValidationService
    {
        IEnumerable<ValidationResult> Validate(Gast gast);
        IEnumerable<ValidationResult> Validate(Buchung buchung);
        IEnumerable<ValidationResult> Validate(Zimmer zimmer);
    }

    public class ValidationResult
    {
        public string ErrorText { get; set; }
        public ValidationResultStatus Status { get; set; }
    }

    public enum ValidationResultStatus
    {
        Error,
        Warning,
        Info
    }
}
