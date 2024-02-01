
using System.ComponentModel.DataAnnotations;

namespace Crud_Assessment.Models
{
    internal class DateOfBirthValidatorAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime? DateOfBirth = (DateTime?)value;
                if (DateOfBirth.HasValue)
                {
                    if (Convert.ToDateTime(DateOfBirth).Year >= 2002 && Convert.ToDateTime(DateOfBirth).Year <= 2007 && Convert.ToDateTime(DateOfBirth).Month >= 01 && Convert.ToDateTime(DateOfBirth).Month <= 12 && Convert.ToDateTime(DateOfBirth).Day >= 01 && Convert.ToDateTime(DateOfBirth).Day <= 31 || Convert.ToDateTime(DateOfBirth).Year == 2008 && Convert.ToDateTime(DateOfBirth).Month == 01 && Convert.ToDateTime(DateOfBirth).Day == 01)
                    {
                        return ValidationResult.Success;
                    }

                }
            }
            return new ValidationResult(ErrorMessage ?? "Date of birth should be in this range:01/01/2002 - 01/01/2008");
        }
    }
}