using System.ComponentModel.DataAnnotations;
using BlazorApp.Shared.ValidationForm;

namespace BlazorApp.Dto;

public record UserRegistration()
{
    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [FirstLetterUppercase]
    public string Nom { get; set; } = String.Empty;

    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    [FirstLetterUppercase]
    public string Prenom { get; set; } = String.Empty;

    [Required(ErrorMessage = "Veuillez renseigner une date de naissance.")]
    public DateTime DateNaissance { get; set; } = DateTime.Now;
    
    [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
    [CustomValidation(typeof(UserRegistration), nameof(ValidatePasswordLength))]
    [CustomValidation(typeof(UserRegistration), nameof(ValidatePasswordNonAlphaNumeric))]
    [CustomValidation(typeof(UserRegistration), nameof(ValidatePasswordDigit))]
    public string Password { get; set; } = String.Empty;
    
    [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
    [Compare(nameof(Password), ErrorMessage = "Les mots de passe ne correspondent pas.")]
    public string ConfirmPassword { get; set; } = String.Empty;
    
    public int MinLengthPassword { get; init; } 
    
    public bool RequireNonAlphaNumeric { get; init; }
    public bool RequireDigit { get; set; }

    public static ValidationResult? ValidatePasswordLength(string password, ValidationContext context)
    {
        var instance = context.ObjectInstance as UserRegistration;
        if (instance == null)
        {
            return ValidationResult.Success;
        }

        if (password.Length < instance.MinLengthPassword)
        {
            return new ValidationResult($"Le mot de passe doit contenir au moins {instance.MinLengthPassword} caractères.");
        }

        return ValidationResult.Success;
    }

    public static ValidationResult? ValidatePasswordNonAlphaNumeric(string password, ValidationContext context)
    {
        var instance = context.ObjectInstance as UserRegistration;
        if (instance == null)
        {
            return ValidationResult.Success;
        }
        
        if (instance.RequireNonAlphaNumeric && !password.Any(char.IsDigit))
        {
            return new ValidationResult("Le mot de passe doit contenir au moins un caractère numérique.");
        }
        
        return ValidationResult.Success;
    }
    
    public static ValidationResult? ValidatePasswordDigit(string password, ValidationContext context)
    {
        var instance = context.ObjectInstance as UserRegistration;
        if (instance == null)
        {
            return ValidationResult.Success;
        }
        
        if (instance.RequireDigit && !password.Any(c => char.IsPunctuation(c) || char.IsSymbol(c)))
        {
            return new ValidationResult("Le mot de passe doit contenir au moins un caractère spécial.");
        }
        
        return ValidationResult.Success;
    }
}