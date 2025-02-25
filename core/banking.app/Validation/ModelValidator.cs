using System.ComponentModel.DataAnnotations;

namespace banking.app.Validation
{
    public class ModelValidator
    {
        public static List<ValidationResult> ModelValidation(dynamic items)
        {
            var context = new ValidationContext(items);
            var errresult = new List<ValidationResult>();
            var val = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(items, context, errresult, true);

            return errresult;
        }
    }
}
