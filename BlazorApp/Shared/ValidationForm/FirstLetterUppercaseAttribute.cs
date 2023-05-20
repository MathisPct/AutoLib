using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BlazorApp.Shared.ValidationForm;

public class FirstLetterUppercaseAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null)
        {
            return new ValidationResult("La valeur ne doit pas être nulle.");
        }

        var stringValue = value.ToString();
        if (Regex.IsMatch(stringValue, @"^[A-Z][a-z]*$"))
        {
            return ValidationResult.Success;
        }
        else
        {
            return new ValidationResult("Le nom/prénom doit commencer par une majuscule et ne doit contenir que des lettres.");
        }
    }
}