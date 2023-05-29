using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Dto;

public sealed record LoginData()
{
    [Required(ErrorMessage = "L'adresse email est obligatoire")]
    [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide")]
    public string Email
    {
        get;
        set;
    }

    [Required(ErrorMessage = "Le mot de passe est obligatoire")]
    public string Password
    {
        get;
        set;
    }
}