using System.ComponentModel.DataAnnotations;
using BlazorApp.Shared.ValidationForm;

namespace BlazorApp.Dto;

public record UserRegistration()
{
    public string Password { get; set; } = String.Empty;
    [Required(ErrorMessage = "Le nom est obligatoire.")]
    [FirstLetterUppercase]
    public string Nom { get; set; } = String.Empty;
    [Required(ErrorMessage = "Le prénom est obligatoire.")]
    [FirstLetterUppercase]
    public string Prenom { get; set; } = String.Empty;
    public DateTime DateNaissance { get; set; } = DateTime.Now;
}